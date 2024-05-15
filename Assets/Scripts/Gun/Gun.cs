using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Animator animator;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public static float bulletSpeed = 20f;
    public Image image;

    public float cooldownTime = 1f; // Atışlar arasındaki bekleme süresi
    private bool canShoot = true; // Atış yapılabilir durum

    private float cooldownTimer = 0f; // Bekleme süresi sayaç

    void Update()
    {
        // Eğer ateş tuşuna basıldıysa ve atış yapılabilir durumdaysa
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            // Ateş et
            Shoot();
            // Bekleme süresini başlat
            StartCoroutine(Cooldown());
        }

        // Bekleme süresi sayaç kontrolü
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            image.fillAmount = 1-(cooldownTimer / cooldownTime);
        }
        else
        {
            image.fillAmount = 1f;
        }
    }

    void Shoot()
    {
        // Mermiyi oluştur ve ateş et
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        animator.SetTrigger("Shoot");
        // Bekleme süresi sayaçını başlat
        cooldownTimer = cooldownTime;
    }

    IEnumerator Cooldown()
    {
        // Atış yapılabilir durumu false yap
        canShoot = false;

        // Bekleme süresi kadar bekleyip tekrar true yap
        yield return new WaitForSeconds(cooldownTime);

        canShoot = true;
    }
}
