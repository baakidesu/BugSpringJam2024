using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    
    public float speed;
    public float gravity;
    public float jumpHeight;

    private bool isGrounded;
    
    

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

        float horizantal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizantal + transform.forward * vertical;
        controller.Move(move * speed * Time.deltaTime);

        #endregion

        #region Gravity

        isGrounded = Physics.CheckSphere(ground.position, distance, mask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        #endregion

        #region Jump

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        
        #endregion

        #region Teleport

        if (Input.GetMouseButton(1))
        {
            player.transform.position = Bullet.lastBulletPosition;

        }

        #endregion
        
    }

 

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(4);
    }

    
}
