using System.Collections;
using UnityEngine;

public class DefaultBubbleBlower : MonoBehaviour
{
    public GameObject bubblePrefab;
    //public KeyCode keyToBlow;
    public Transform spawnArea;
    public AudioSource bubbleSpawnSourceAudio;

    // Update is called once per frame
    void Start() 
    {
        StartCoroutine(HandleBlowing());    
    }

    IEnumerator HandleBlowing() // wink a wink
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.X) | Input.GetKey(KeyCode.G))
            {
                bubbleSpawnSourceAudio.Play();
                var bubble = Instantiate(bubblePrefab,spawnArea);
                bubble.name = "Random Bubble";
                float bubbleScale = Random.Range(0f,1f);
                bubble.transform.localScale = new Vector2(bubbleScale,bubbleScale);
                bubble.transform.position = new Vector2 (spawnArea.transform.position.x, spawnArea.transform.position.y + bubbleScale * 2f);
                //StartCoroutine(Utils.ScaleLerp(bubble.transform, new Vector2(0,0), new Vector2(bubbleScale, bubbleScale), Random.Range(0.1f,0.3f)));
                int xForce = Random.Range(-300, 300);

                foreach (Rigidbody2D rig in bubble.GetComponentsInChildren<Rigidbody2D>())
                {
                    rig.AddForce(new Vector2 (xForce,300));
                }
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
