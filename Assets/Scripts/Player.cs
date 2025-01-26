using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;

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
    public SpriteShapeRenderer spriteShapeRenderer;

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

    public void StartGameOver()
    {
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        foreach (CircleCollider2D circleCol in GetComponentsInChildren<CircleCollider2D>())
        {
            if (circleCol)
            {
                Destroy(circleCol);
            }
        }
        popAudioSource.Play();
        spriteShapeRenderer.color = Color.clear;
        bubbleFaceImage.color = Color.clear;

        if (GlobalManager.playerLives >= 1)
        {
            GlobalManager.playerLives--;
            GlobalManager.readyToSpawnNewPlayer = true;
            yield return new WaitForSeconds(1f);
            Destroy(this.gameObject);
        }
        else 
        {
            GlobalManager.SaveHighScore();
            StartCoroutine(GameObject.Find("UICanvas").GetComponent<UIController>().GameOverTextSetter());
            yield return new WaitForSeconds(5f);
            GlobalManager.score = 0;
            GlobalManager.playerLives = 3;
            SceneManager.LoadScene("Main Menu");
        }

        yield return null;
    }

    IEnumerator KeepBubbleAtCentre()
    {
        while (true)
        {
            if (GlobalManager.gameStarted)
            {
                Rigidbody2D rig = bubbleCentre.GetComponent<Rigidbody2D>();
                Debug.Log("Player World Position: " + bubbleCentre.position.y);
                if (bubbleCentre.position.y > 0)
                {
                    rig.AddForce(new Vector2(0,-(rig.linearVelocityY * 20) - 10f));
                }
                else if (bubbleCentre.position.y < 0)
                {
                    rig.AddForce(new Vector2(0,(rig.linearVelocityY * 2) + 10));
                }
            }
            yield return new WaitForSeconds(0.01f);
        } 
    }
}
