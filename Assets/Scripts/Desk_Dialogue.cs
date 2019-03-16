﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk_Dialogue : MonoBehaviour
{
    private bool isTriggered;
    public GameObject hitObject;
    public Dialogue deskDialogue;
    public DialogueManager dialogueManager;
    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        isTriggered = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 150f))
        {
            hitObject = hit.transform.gameObject;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (hitObject.tag == "Desk")
                    if (isTriggered)
                    {
                        {
                            TriggerDeskDialogue();
                            if (Input.GetKeyDown(KeyCode.Mouse0))
                            {
                                ContinueDialogue();
                            }

                            isTriggered = false;
                        }
                    }
            }
        }

    }
    public void Disappear()
    {
        dialogueManager.EndDialogue();
    }
    public void TriggerDeskDialogue()
    {
        dialogueManager.StartDialogue(deskDialogue);
    }
    
    public void ContinueDialogue()
    {
        dialogueManager.DisplayNextSentence();
    }

}