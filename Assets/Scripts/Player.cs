using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed = 4f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical, 0);

        transform.position += direction.normalized * (playerMoveSpeed * Time.deltaTime);
        
        if(horizontal < 0)
        {
            spriteRenderer.flipX = true;
        } else if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        animator.SetBool("isWalkingSide", horizontal != 0);
        animator.SetBool("isWalkingBack",vertical > 0);
        animator.SetBool("isWalkingFront", vertical < 0);

    }
}
