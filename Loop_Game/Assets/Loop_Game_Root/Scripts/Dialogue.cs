using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private TextMeshProUGUI dialogueText;
    private float typingTime = 0.05f;
    private AudioSource audioDialogo;

    public GameObject dialogueActive;
    public GameObject dialogueNext;
    public GameObject dialogueBack;
    public GameObject dialoguePanel;
    private string fullText;
    public bool scene = false;

    void Start()
    {
        audioDialogo = GetComponent<AudioSource>();

        dialogueText = GetComponent<TextMeshProUGUI>();
        if (dialogueText != null)
        {
            Time.timeScale = 0f;
            fullText = dialogueText.text;
            dialogueText.text = "";
            StartCoroutine(TypeText());
        }
    }

    private IEnumerator TypeText()
    {
        foreach (char ch in fullText)
        {
            dialogueText.text += ch;
            audioDialogo.PlayOneShot(audioDialogo.clip);
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    void Update()
    {
        if (dialogueActive.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))
            {
                if (dialogueNext == null)
                {
                    Time.timeScale = 1f;
                    dialogueActive.SetActive(false);
                    dialogueBack.SetActive(true);
                    dialoguePanel.SetActive(false);
                }

                else if (scene == true)
                {
                    Time.timeScale = 1f;
                    dialogueNext.SetActive(true);
                }


                else
                {
                 
                    dialogueActive.SetActive(false);
                    dialogueNext.SetActive(true);
                }
            }
        }
    }
}
