using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolRaycast : MonoBehaviour
{

    RaycastHit hit;
    public GameObject hitObject;

    void FixedUpdate()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f))
        {
            hitObject = hit.transform.gameObject;
            if (Input.GetMouseButtonDown(0))
            {
                if (CompareTag("Bed"))
                {
                    hitObject = hit.transform.gameObject;
                    print("It works.");
                }
            }
        }
    }
}