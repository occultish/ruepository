using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Dialogue : MonoBehaviour
{
    public bool isDDTriggered;
    public GameObject hitObject;
    public Dialogue doorDialogue;
    public DialogueManager dialogueManager;
    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        isDDTriggered = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 150f))
        {
            hitObject = hit.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.Space) && isDDTriggered)
            {
                if (hitObject.tag == "Door")
                    if (isDDTriggered)
                    {
                        {
                            TriggerDoorDialogue();
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
        isDDTriggered = false;
        dialogueManager.voidEnd = false;
    }

    public void Disappear()
    {
        dialogueManager.EndDialogue();
    }

    public void TriggerDoorDialogue()
    {
        dialogueManager.StartDialogue(doorDialogue);
    }

    public void ContinueDialogue()
    {
        dialogueManager.DisplayNextSentence();
    }
}

