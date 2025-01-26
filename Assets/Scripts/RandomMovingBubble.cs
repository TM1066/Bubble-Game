using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.U2D;

public class RandomMovingBubble : MonoBehaviour
{
    public List<Transform> bubbleVertices = new List<Transform>();

    public AudioSource popAudioSource;

    public GameObject bubblePopPrefab;

    public SpriteShapeRenderer spriteShapeRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(HandleMovement());
        float scale = Random.Range(0.1f, 1f);
        this.transform.localScale = new Vector2 (scale,scale);
    }

    public void StartPOP()
    {
        StartCoroutine(Pop());
    }

    private IEnumerator Pop()
    {
        spriteShapeRenderer.color = Color.clear;

        foreach (Transform t in bubbleVertices)
        {
            t.GetComponent<CircleCollider2D>().enabled = false;
        }

        Instantiate(bubblePopPrefab, bubbleVertices[Random.Range(0, bubbleVertices.Count)]);
        popAudioSource.Play();
        yield return new WaitForSeconds(2);

        Destroy(this.gameObject);


    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     Debug.Log("bubble Collision Entered");
    //     if (other.transform.CompareTag("Bubble"))
    //     {
    //         this.transform.localScale += other.transform.localScale;
    //         Destroy(other.gameObject);
    //     }
    // }

    IEnumerator HandleMovement()
    {
        while (true)
        {
            int value = Random.Range(1,4);

            if (value == 1)
            {
                foreach (Transform vertex in bubbleVertices)
                {
                    if (UnityEngine.Random.Range(0,120) == 1)
                    {
                        vertex.GetComponent<Rigidbody2D>().AddForce(new Vector2(200,0));
                    }
                }
            }
            else if (value == 2)
            {
                foreach (Transform vertex in bubbleVertices)
                {
                    if (UnityEngine.Random.Range(0,120) == 1)
                    {
                        vertex.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200,0));
                    }
                }
            }
            else if (value == 3)
            {
                foreach (Transform vertex in bubbleVertices)
                {
                    if (UnityEngine.Random.Range(0,120) == 1)
                    {
                        vertex.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,200));
                    }
                }
            }
            else if (value == 4)
            {
                foreach (Transform vertex in bubbleVertices)
                {
                    if (UnityEngine.Random.Range(0,120) == 1)
                    {
                        vertex.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-200));
                    }
                }
            }

            yield return new WaitForSeconds(Random.Range(0.1f,5f));
        }
    }
}
