using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill_Dialogue : MonoBehaviour
{
    public bool isPTriggered;
    public GameObject hitObject;
    public Dialogue pillDialogue;
    public DialogueManager dialogueManager;
    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        isPTriggered = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 150f))
        {
            hitObject = hit.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.Space) && isPTriggered)
            {
                if (hitObject.tag == "Pills")
                    if (isPTriggered)
                    {
                        {
                            TriggerPillDialogue();
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
        isPTriggered = false;
        dialogueManager.voidEnd = false;
    }

    public void Disappear()
    {
        dialogueManager.EndDialogue();
    }

    public void TriggerPillDialogue()
    {
        dialogueManager.StartDialogue(pillDialogue);
    }

    public void ContinueDialogue()
    {
        dialogueManager.DisplayNextSentence();
    }
}
