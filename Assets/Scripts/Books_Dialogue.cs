using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Books_Dialogue : MonoBehaviour
{
    public bool isBBTriggered;
    public GameObject hitObject;
    public Dialogue bookDialogue;
    public DialogueManager dialogueManager;
    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        isBBTriggered = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 150f))
        {
            hitObject = hit.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.Space) && isBBTriggered)
            {
                if (hitObject.tag == "Books")
                    if (isBBTriggered)
                    {
                        {
                            TriggerBookDialogue();
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
        isBBTriggered = false;
        dialogueManager.voidEnd = false;
    }

    public void Disappear()
    {
        dialogueManager.EndDialogue();
    }

    public void TriggerBookDialogue()
    {
        dialogueManager.StartDialogue(bookDialogue);
    }

    public void ContinueDialogue()
    {
        dialogueManager.DisplayNextSentence();
    }
}

