using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    private string[] dialogueLines;
    private int currentLine = 0;
    private bool dialogueActive = false;

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (!dialogueActive)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            NextLine();
        }
    }

    public void StartDialogue()
    {
        dialoguePanel.SetActive(true);

       // Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = false;

        dialogueLines = new string[]
        {
            "O: Merhaba, hoş geldiniz.",
            "M: Bir gece kalacağım. Al şu kimliği ve işlemleri hızlı yap. O korkunç 20'ler partisinden sonra bir saniye daha ayakta duracak halim yok."
        };

        currentLine = 0;
        dialogueActive = true;

        dialogueText.text = dialogueLines[currentLine];
    }

    void NextLine()
    {
        currentLine++;

        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
        }
        else
        {
            dialogueActive = false;

            // Burada sonra seçenekleri açacağız.
            Debug.Log("Seçenekler burada açılacak.");
        }
    }
}