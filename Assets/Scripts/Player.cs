using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class Player : MonoBehaviour
{
    //Floats around on screen, ignore Y movement, screen tricking

    public List<Transform> bubbleVertices = new List<Transform>();
    public Transform bubbleCentre;

    public SpriteRenderer bubbleFaceImage;
    public Sprite bubbleEffortFace;
    public Sprite bubbleNeutralFace;
    [Range (0,1)]
    public float size = 0.5f;

    public AudioSource popAudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(KeepBubbleAtCentre());
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HealthSizeScaling();
    }

    void HealthSizeScaling()
    {
        this.transform.localScale = new Vector2(size, size);
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.D) && !GlobalManager.readyToSpawnNewPlayer)
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
            bubbleFaceImage.sprite = bubbleEffortFace;
        }
        else if (Input.GetKey(KeyCode.A) && !GlobalManager.readyToSpawnNewPlayer)
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
            bubbleFaceImage.sprite = bubbleEffortFace;
        }
        else 
        {
            bubbleFaceImage.sprite = bubbleNeutralFace;
        }
    }

    public IEnumerator GameOver()
    {
        if (GlobalManager.playerLives > 0)
        {
            GlobalManager.playerLives--;
            GlobalManager.readyToSpawnNewPlayer = true;
        }
        else 
        {
            GlobalManager.score = 0;
            GlobalManager.playerLives = 3;
        }


        popAudioSource.Play();
        this.GetComponent<SpriteShapeRenderer>().color = Color.clear;
        bubbleFaceImage.color = Color.clear;

        yield return null;
    }

    IEnumerator KeepBubbleAtCentre()
    {
        while (true)
        {
            if (GlobalManager.gameStarted)
            {
                if (bubbleCentre.position.y > 0)
                {
                    bubbleCentre.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-20f));
                }
                else if (bubbleCentre.position.y < 0)
                {
                    bubbleCentre.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,20f));
                }
            }

            yield return new WaitForSeconds(0.01f);
        } 
    }
}
