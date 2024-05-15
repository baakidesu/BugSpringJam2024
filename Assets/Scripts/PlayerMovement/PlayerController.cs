using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Image doublejumpindicator;
    public Animator animator;
    private CharacterController controller;
    private Vector3 velocity;

    public float speed;
    public float gravity;
    public float jumpHeight;

    public float shiftroughness;
    private bool isGrounded;
    private bool canDoubleJump; // Çift zıplama yapılabilir mi?

    public Transform ground;
    public GameObject player;
    public float distance = 0.3f;

    public LayerMask mask;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        #region Movement

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * speed * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);

        #endregion

        #region Gravity

        isGrounded = Physics.CheckSphere(ground.position, distance, mask);

        if (isGrounded && velocity.y < 0)
        {
            doublejumpindicator.enabled = true;
            velocity.y = 0f;
            canDoubleJump = true; // Yere temas ettiğinde çift zıplama yeteneğini yeniden etkinleştir
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        #endregion

        #region Jump

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded) // Yerdeyken
            {
                doublejumpindicator.enabled = true;
                velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity); // Normal zıplama
                canDoubleJump = true; // Çift zıplamayı etkinleştir
                
            }
            else if (canDoubleJump) // Havadayken ve çift zıplama yapılabilir durumdaysa
            {  
                velocity.y = 0f; // Hızı sıfırla
                velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity); // Çift zıplama
                canDoubleJump = false; // Bir kez çift zıplama yapıldı
                doublejumpindicator.enabled = false;
            }
        }

        #endregion

        #region Teleport

        if (Input.GetMouseButton(1))
        {
            animator.SetTrigger("Teleport");
            float lerpedx = Mathf.Lerp(player.transform.position.x, Bullet.lastBulletPosition.x, shiftroughness);
            float lerpedy = Mathf.Lerp(player.transform.position.y, Bullet.lastBulletPosition.y + 1.58f, shiftroughness);
            float lerpedz = Mathf.Lerp(player.transform.position.z, Bullet.lastBulletPosition.z, shiftroughness);
            player.transform.position = new Vector3(lerpedx, lerpedy, lerpedz);

        }

        #endregion
        
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene(4);
    }
}