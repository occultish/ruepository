using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dresser_Dialogue : MonoBehaviour
{
    public bool isDTriggered;
    public GameObject hitObject;
    public Dialogue dresserDialogue;
    public DialogueManager dialogueManager;
    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        isDTriggered = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 150f))
        {
            hitObject = hit.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.Space) && isDTriggered)
            {
                if (hitObject.tag == "Dresser")
                    if (isDTriggered)
                    {
                        {
                            TriggerDresserDialogue();
                            if (Input.GetKeyDown(KeyCode.Mouse0))
                            {
                                ContinueDialogue();
                            }

                            if ((dialogueManager.voidEnd) == true)
                            {
                                TriggerEnd();
                            }
                        }
                    }
            }
        }

    }
    public void TriggerEnd()
    {
        isDTriggered = false;
        dialogueManager.voidEnd = false;
    }
    public void Disappear()
    {
        dialogueManager.EndDialogue();
    }
    public void TriggerDresserDialogue()
    {
        dialogueManager.StartDialogue(dresserDialogue);
    }
    
    public void ContinueDialogue()
    {
        dialogueManager.DisplayNextSentence();
    }

}