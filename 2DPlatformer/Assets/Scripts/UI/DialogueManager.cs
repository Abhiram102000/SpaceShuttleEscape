using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    private Queue<string> sentences;
    [TextArea(3, 10)]
    public string[] dialogue;
    public float dialogueTime = 5.0f;
    private float activeTime = 0.0f;
    public GameObject Dialogue;
    public GameObject Player;
    public GameObject Timer;


    private void Start()
    {
        sentences = new Queue<string>();
        StartDialogue();
    }

    public void StartDialogue()
    {
        Player.GetComponent<PlayerController>().enabled = false;
        Timer.GetComponent< Timer >().enabled = false;
        sentences.Clear();
        foreach (string sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }

        NextSentence();
    }

    public void NextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        if (activeTime > dialogueTime)
        {
            Destroy(Dialogue);
        }
        Player.GetComponent<PlayerController>().enabled = true;
        Timer.GetComponent<Timer>().enabled = true;
    }

    void Update()
    {
        if (activeTime > dialogueTime)
        {
            NextSentence();
            activeTime = 0.0f;
        }
        else
        {
            activeTime += Time.deltaTime;
        }
    }
}
