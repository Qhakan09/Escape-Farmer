using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject eIcon;
    
    private bool isPlayerNear;
    void Start()
    {
        eIcon.SetActive(false);
    }

    void Update()
    {
        if(isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("isDoorOpen", true);
            eIcon.SetActive(false);

            StartCoroutine(EnterTree());
        }
    }

    private IEnumerator EnterTree()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("TreeHouse");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerNear = true;
            eIcon.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerNear = false;
            eIcon.SetActive(false);

            animator.SetBool("isDoorOpen", false);
        }
    }
}
