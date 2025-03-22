using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem instance;

    public TextMeshProUGUI dialogueText;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;

    public float typingSpeed = 0.2f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        lines = new Queue<DialogueLine>();
    }

    private void Update()
    {
        if (isDialogueActive)
        {
            if(Input.GetMouseButtonDown(0))
            {
                DisplayNextDialogueLine();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (!this.isActiveAndEnabled) return;

        isDialogueActive = true;

        lines.Clear();

        foreach(DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    private void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueText.text = "";
        foreach(char letter in dialogueLine.line.ToCharArray())
        {
            dialogueText.text += letter;
            //GameManager.instance.clickSound.Play();
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    void EndDialogue()
    {
        isDialogueActive = false;
        StopAllCoroutines();
        dialogueText.text = "";
    }
}
