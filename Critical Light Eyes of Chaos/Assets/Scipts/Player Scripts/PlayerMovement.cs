using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public bool canMove = true;
    public float rotationSpeed = 50.0f;
    void Start()
    {
        
    }
    void Update()
    {

        if (canMove)
        {

            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            Vector3 rotation = new Vector3(0, horizontal * rotationSpeed * Time.deltaTime, 0);
            Vector3 move = Vector3.forward * Speed * Time.deltaTime * vertical;
            transform.Rotate(rotation);
            transform.Translate(move);
            
        }

    }
}
