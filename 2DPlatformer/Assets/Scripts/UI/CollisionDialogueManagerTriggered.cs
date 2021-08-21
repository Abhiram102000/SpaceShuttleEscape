using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDialogueManagerTriggered : MonoBehaviour
{

    
    public Text dialogueText;
    private Queue<string> sentences;
    [TextArea(3, 10)]
    public string[] dialogue;
    public float dialogueTime = 5.0f;
    private float activeTime = 0.0f;
    public GameObject Dialogue;


    private void Start()
    {
        if (Dialogue.GetComponent<Text>().enabled == false)
        {
            Dialogue.GetComponent<Text>().enabled = true;
        }
        sentences = new Queue<string>();
        Dialogue.GetComponent<Text>().enabled = false;
    }

    public void StartDialogue()
    {
        sentences.Clear();
        Dialogue.GetComponent<Text>().enabled = true;
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
            Dialogue.GetComponent<Text>().enabled = false;
        }
        
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
