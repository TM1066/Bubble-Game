using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Floats around on screen, ignore Y movement, screen tricking

    public List<Transform> bubbleVertices = new List<Transform>();
    public Transform bubbleCentre;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(KeepBubbleAtCentre());
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //bubbleCentre.GetComponent<Rigidbody2D>().AddForce(new Vector2(10,0));
            foreach (Transform vertex in bubbleVertices)
            {
                if (UnityEngine.Random.Range(0,120) == 1)
                {
                    vertex.GetComponent<Rigidbody2D>().AddForce(new Vector2(20,0));
                    //vertex.position = new Vector2(vertex.position.x + 1, vertex.position.y);
                }
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
           //bubbleCentre.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10,0));
           foreach (Transform vertex in bubbleVertices)
            {
                if (UnityEngine.Random.Range(0,120) == 1)
                {
                    vertex.GetComponent<Rigidbody2D>().AddForce(new Vector2(-20,0));
                    //vertex.position = new Vector2(vertex.position.x - 1, vertex.position.y);
                }
            }
        }
    }

    IEnumerator KeepBubbleAtCentre()
    {
        while (true)
        {
            if (bubbleCentre.position.y > 0)
            {
                bubbleCentre.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-0.75f));
            }
            else if (bubbleCentre.position.y < 0)
            {
                bubbleCentre.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,0.75f));
            }
            yield return new WaitForSeconds(0.01f);
        } 
    }
}
