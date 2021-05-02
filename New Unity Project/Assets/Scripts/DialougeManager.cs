using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeManager : MonoBehaviour
{
    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialouge(Dialouge dialouge)
    {
        Debug.Log("Starting conversation with " + dialouge.name);
        
        sentences.Clear();

        foreach (string sentence in dialouge.sentences)
        {
            
        }
    }

    
}
    