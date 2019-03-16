using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror_Dialogue : MonoBehaviour
{
    private bool isTriggered;
    public GameObject hitObject;
    public Dialogue mirrorDialogue;
    public DialogueManager dialogueManager;
    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        TriggerDialogue();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f))
        {
            hitObject = hit.transform.gameObject;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (hitObject.tag == "Mirror")
                {
                    TriggerDialogue();
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        ContinueDialogue();
                    }
                    print("It works.");
                }
            }
        }
        
    }
    
    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(mirrorDialogue);
    }
    
    public void ContinueDialogue()
    {
        dialogueManager.DisplayNextSentence();
    }

}
