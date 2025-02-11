using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public GameObject dialogue;
    bool dialogueactive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            dialogueactive = true;
            AudioManager.Instance.PlaySFX(7);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            dialogueactive = false;
            
        }
    }
    private void Update()
    {
        if (dialogueactive && Input.GetKeyDown(KeyCode.E))
        {
            AudioManager.Instance.PlaySFX(4);
            dialogue.SetActive(true);
        }
    }
}
