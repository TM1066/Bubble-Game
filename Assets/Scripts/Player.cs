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
    public Sprite bubblePopImage;
    [Range (0,1)]
    public float size = 0.5f;

    public AudioSource popAudioSource;
    public SpriteShapeRenderer spriteShapeRenderer;

    //private bool isDead;

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
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && !GlobalManager.readyToSpawnNewPlayer)
        {
            //bubbleCentre.GetComponent<Rigidbody2D>().AddForce(new Vector2(10,0));
            foreach (Transform vertex in bubbleVertices)
            {
                if (UnityEngine.Random.Range(0,120) == 1)
                {
                    vertex.GetComponent<Rigidbody2D>().AddForce(new Vector2(200 - size * 50,0));
                    //vertex.position = new Vector2(vertex.position.x + 1, vertex.position.y);
                }
            }
            bubbleFaceImage.sprite = bubbleEffortFace;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && !GlobalManager.readyToSpawnNewPlayer)
        {
           //bubbleCentre.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10,0));
            foreach (Transform vertex in bubbleVertices)
            {
                if (UnityEngine.Random.Range(0,120) == 1)
                {
                    vertex.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200 + size * 50,0));
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

        foreach (ObstacleSpawner spawner in FindObjectsByType<ObstacleSpawner>(FindObjectsSortMode.None))
                {
                    spawner.canSpawnObjects = false;
                }
        // GetComponentInChildren<SpriteShapeController>().spline.isOpenEnded = true;
        // foreach (DistanceJoint2D distanceJoi in GetComponentsInChildren<DistanceJoint2D>())
        // {
        //     if (distanceJoi)
        //     {
        //         Destroy(distanceJoi);
        //     }
        // }
        // foreach (SpringJoint2D springJoi in GetComponentsInChildren<SpringJoint2D>())
        // {
        //     if (springJoi)
        //     {
        //         Destroy(springJoi);
        //     }
        // }
        foreach (Transform vertex in bubbleVertices)
        {
            vertex.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        }
        //isDead = true;

        popAudioSource.Play();
        spriteShapeRenderer.color = Color.clear;
        bubbleFaceImage.color = Color.clear;
        //bubbleFaceImage.sprite = bubblePopImage;

        if (GlobalManager.playerLives > 1)
        {
            GlobalManager.playerLives--;
            GlobalManager.readyToSpawnNewPlayer = true;
            yield return new WaitForSeconds(1f);
            Destroy(this.gameObject);
        }
        else 
        {
            GlobalManager.playerLives--;
            GlobalManager.gameFinished = true;
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
            if (!GlobalManager.readyToSpawnNewPlayer)
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
