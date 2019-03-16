using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror_Dialogue : MonoBehaviour
{
    public bool isMTriggered;
    public GameObject hitObject;
    public Dialogue mirrorDialogue;
    public DialogueManager dialogueManager;
    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        isMTriggered = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 150f))
        {
            hitObject = hit.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.Space) && isMTriggered)
            {
                if (hitObject.tag == "Mirror")
                    if (isMTriggered)
                    {
                        {
                            TriggerMirrorDialogue();
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
        isMTriggered = false;
        dialogueManager.voidEnd = false;
    }

    public void Disappear()
    {
        dialogueManager.EndDialogue();
    }

    public void TriggerMirrorDialogue()
    {
        dialogueManager.StartDialogue(mirrorDialogue);
    }

    public void ContinueDialogue()
    {
        dialogueManager.DisplayNextSentence();
    }
}
