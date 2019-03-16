using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed_Dialogue : MonoBehaviour
{
    public bool isBTriggered;
    public GameObject hitObject;
    public Dialogue bedDialogue;
    public DialogueManager dialogueManager;
    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        isBTriggered = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 150f))
        {
            hitObject = hit.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.Space) && isBTriggered)
            {
                if (hitObject.tag == "Bed")
                    if (isBTriggered)
                    {
                        {
                            TriggerBedDialogue();
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
        isBTriggered = false;
        dialogueManager.voidEnd = false;
    }
    public void Disappear()
    {
        dialogueManager.EndDialogue();
    }
    public void TriggerBedDialogue()
    {
        dialogueManager.StartDialogue(bedDialogue);
    }
    
    public void ContinueDialogue()
    {
        dialogueManager.DisplayNextSentence();
    }

}
