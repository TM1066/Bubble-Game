using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnArea;
    public Transform cameraSpawningLocation;
    public Transform cameraPlayLocation;
    public AudioSource bubbleSpawnAudioSource;

    public TextMeshProUGUI multiText;

    public KeyCode spawnKey;
    public KeyCode altSpawnKey;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera.main.transform.position = cameraSpawningLocation.position;
        StartCoroutine(HandleBlowingAndCameraMoving());
    }

    void Update()
    {
        if (Camera.main.transform.position != cameraSpawningLocation.position && !GlobalManager.cameraMoving && GlobalManager.readyToSpawnNewPlayer)
            {
                StartCoroutine(Utils.CameraLerp(Camera.main, Camera.main.transform.position, cameraSpawningLocation.position, 4, 2f));
            }
            if (Camera.main.transform.position != cameraPlayLocation.position && !GlobalManager.cameraMoving && !GlobalManager.readyToSpawnNewPlayer)
            {
                StartCoroutine(Utils.CameraLerp(Camera.main, Camera.main.transform.position, cameraPlayLocation.position, 5, 1.5f));
            }
    }

    IEnumerator HandleBlowingAndCameraMoving() // wink a wink
    {
        while (true)
        {
            if (( Input.GetKey(spawnKey) || Input.GetKey(altSpawnKey) ) && GlobalManager.readyToSpawnNewPlayer && !GlobalManager.cameraMoving)
            {
                var playerBubble = Instantiate(playerPrefab);
                playerBubble.name = "Player Bubble";
                playerBubble.transform.position = new Vector2 (spawnArea.transform.position.x, spawnArea.transform.position.y + 1);
                var playerVar = playerBubble.GetComponent<Player>(); 
                playerVar.size = 0.3f;

                while (( Input.GetKey(spawnKey) || Input.GetKey(altSpawnKey) ) && playerVar.size < 1f)
                { 
                    playerVar.size += 0.01f;
                    multiText.text = $"Multiplier: {(1f * GameObject.Find("Player Bubble").GetComponent<Player>().size).ToString("n2")}";
                    yield return new WaitForSeconds(0.1f);
                }
                bubbleSpawnAudioSource.Play();
                GlobalManager.readyToSpawnNewPlayer = false;
                foreach (Rigidbody2D rig in playerBubble.GetComponentsInChildren<Rigidbody2D>())
                {
                    rig.linearVelocity = Vector2.up;
                }
                yield return new WaitForSeconds(5f);

                foreach (ObstacleSpawner spawner in FindObjectsByType<ObstacleSpawner>(FindObjectsSortMode.None))
                {
                    spawner.canSpawnObjects = true;
                }
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
