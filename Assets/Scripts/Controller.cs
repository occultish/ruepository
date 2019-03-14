using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject player;
    public int speed;
    public int rotateSpeed;
	
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotateSpeed);
        }else if (Input.GetKey(KeyCode.D))
        {
            player.transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotateSpeed);
        }
    }
}