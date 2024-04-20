using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Animator animator;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public static float bulletSpeed = 10f;

    public float cooldownTime = 0.5f; // Atışlar arasındaki bekleme süresi
    private bool canShoot = true; // Atış yapılabilir durum

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
    }

    void Shoot()
    {
        // Mermiyi oluştur ve ateş et
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        animator.SetTrigger("Shoot");
    }

    IEnumerator Cooldown()
    {
        // Atış yapılabilir durumu false yap ve bekleyip tekrar true yap
        canShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }
}