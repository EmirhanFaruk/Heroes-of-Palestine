using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public Button nextButton;

    private Queue<string> sentences;
    private Queue<string> names;

    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        nextButton.onClick.AddListener(DisplayNextSentence);
    }

    public void StartDialog(Dialog dialog)
    {
        Debug.Log("Starting dialog with " + dialog.lines.Length + " lines.");

        sentences.Clear();
        names.Clear();

        foreach (DialogLine line in dialog.lines)
        {
            names.Enqueue(line.name);
            sentences.Enqueue(line.sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        Debug.Log("Displaying next sentence.");

        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string name = names.Dequeue();
        string sentence = sentences.Dequeue();
        nameText.text = name;
        dialogText.text = sentence;
    }

    void EndDialog()
    {
        Debug.Log("End of conversation.");
    }
}
