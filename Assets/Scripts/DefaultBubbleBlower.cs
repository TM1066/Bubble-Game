using System.Collections;
using UnityEngine;

public class DefaultBubbleBlower : MonoBehaviour
{
    public GameObject bubblePrefab;
    public KeyCode keyToBlow;
    public Transform spawnArea;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyToBlow))
        {
            var bubble = Instantiate(bubblePrefab,spawnArea);
            bubble.transform.position = spawnArea.transform.position;
            var bubbleScale = Random.Range(0f,3f);
            bubble.transform.localScale = new Vector2(0,0);

            StartCoroutine(Utils.ScaleLerp(bubble.transform, new Vector2(0,0), new Vector2(bubbleScale, bubbleScale), Random.Range(0.5f,2f)));

            bubble.GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2 (Random.Range(-50f, 50f),300));
        }
    }

    IEnumerator HandleBlowing() // wink a wink
    {
        while (true)
        {
            if (Input.GetKey(keyToBlow))
            {
                var bubble = Instantiate(bubblePrefab,spawnArea);
                bubble.transform.position = spawnArea.transform.position;
                var bubbleScale = Random.Range(0f,3f);
                bubble.transform.localScale = new Vector2(0,0);

                StartCoroutine(Utils.ScaleLerp(bubble.transform, new Vector2(0,0), new Vector2(bubbleScale, bubbleScale), Random.Range(0.5f,2f)));

                bubble.GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2 (Random.Range(-50f, 50f),300));
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
