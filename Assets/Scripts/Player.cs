using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Floats around on screen, ignore Y movement, screen tricking

    //public List<Transform> bubbleVertices = new List<Transform>();
    public Transform bubbleCentre;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            bubbleCentre.GetComponent<Rigidbody2D>().AddForce(new Vector2(1,0));
        }
    }

}
