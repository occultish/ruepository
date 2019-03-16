using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Dialogue : MonoBehaviour
{
    public bool isEndTriggered;
    public Dialogue endDialogue;
    public DialogueManager dialogueManager;
    public Bed_Dialogue trig1;
    public Pill_Dialogue trig2;
    public Mirror_Dialogue trig3;
    public Desk_Dialogue trig4;
    public Books_Dialogue trig5;
    public Dresser_Dialogue trig6;
    public Door_Dialogue trig7;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        isEndTriggered = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueManager.voidEnd == false && isEndTriggered == false && trig1.isBTriggered == false && trig2.isPTriggered == false && trig3.isMTriggered == false && trig4.isDDDTriggered == false && trig5.isBBTriggered == false && trig6.isDTriggered == false && trig7.isDDTriggered == false)
        {
            isEndTriggered = true;
            if (isEndTriggered == true)
            {
                TriggerEndDialogue();
            }
        }
            if(Input.GetKeyDown(KeyCode.Backspace))
            {
                LoadEnd();
            }

        
    }

    public void LoadEnd()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Disappear()
    {
        dialogueManager.EndDialogue();
    }

    public void TriggerEndDialogue()
    {
        dialogueManager.StartDialogue(endDialogue);
    }

    public void ContinueDialogue()
    {
        dialogueManager.DisplayNextSentence();
    }
    
}


