using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public float shiftroughness;
 
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            animator.SetTrigger("Teleport");
            float lerpedx = Mathf.Lerp(player.transform.position.x, Bullet.lastBulletPosition.x, shiftroughness);
            float lerpedy = Mathf.Lerp(player.transform.position.y, Bullet.lastBulletPosition.y + 1.58f, shiftroughness);
            float lerpedz = Mathf.Lerp(player.transform.position.z, Bullet.lastBulletPosition.z, shiftroughness);
            player.transform.position = new Vector3(lerpedx, lerpedy, lerpedz);

        }  
    }
}
