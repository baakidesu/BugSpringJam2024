using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class Animations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Update()
    {
        if (Input.GetMouseButton(0)) //Gun
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Shoot", true);
            animator.SetBool("Teleport", false);
        } if (Input.GetMouseButton(1)) // Teleport
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Shoot", false);
            animator.SetBool("Teleport", true);
        }else 
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Shoot", false);
            animator.SetBool("Teleport", false);
        }
    }
}
