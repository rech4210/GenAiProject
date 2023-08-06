using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialgueManager : Manager<DialgueManager>
{
    TextMeshProUGUI textMeshProUGUI;
    public float charDisplayInterval = 0.05f;
    private Queue<string> dialogueQueue = new Queue<string>();
    private Coroutine currentCoroutine;

    public void SetTMP(TextMeshProUGUI textMeshProUGUI)
    {
        this.textMeshProUGUI = textMeshProUGUI;
    }

    public void StartDialogue(string dialogue)
    {
        string[] dialogueLines = dialogue.Split('\n'); // Split dialogue into lines using newline character
        foreach (string line in dialogueLines)
        {
            string[] words = line.Split(' '); // Split each line into words using space character
            string newLine = "";
            foreach (string word in words)
            {
                if (newLine.Length + word.Length + 1 > 50) // Check if adding the next word exceeds line length
                {
                    dialogueQueue.Enqueue(newLine); // Enqueue the current line
                    newLine = "";
                }
                newLine += word + " ";
            }
            dialogueQueue.Enqueue(newLine); // Enqueue the last line
        }

        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(AnimateDialogue());
    }

    IEnumerator AnimateDialogue()
    {
        textMeshProUGUI.text = "";
        while (dialogueQueue.Count > 0)
        {
            string line = dialogueQueue.Dequeue();
            for (int i = 0; i < line.Length; i++)
            {
                textMeshProUGUI.text += line[i];
                yield return new WaitForSeconds(charDisplayInterval);
            }
            //yield return new WaitForSeconds(0.5f); // Pause between lines
            //textMeshProUGUI.text = "";
        }
    }

}
