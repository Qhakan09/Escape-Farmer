using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;
    //[SerializeField] private Sprite openDoor;
    //[SerializeField] private Sprite closeDoor;
    //private SpriteRenderer spriteRenderer;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger çalıştı");
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isDoorOpen", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isDoorOpen", false);
        }
    }
}
