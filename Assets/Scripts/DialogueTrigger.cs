using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public bool bedTrigger;

    public void Start()
    {
        bedTrigger = false;

    }
    public void TriggerDialogue ()
    {
    
        //if (bedTrigger == true)
        
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}