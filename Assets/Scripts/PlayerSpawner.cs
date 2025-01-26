using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnArea;
    public Transform cameraSpawningLocation;
    public Transform cameraPlayLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(HandleBlowingAndCameraMoving());
    }

    IEnumerator HandleBlowingAndCameraMoving() // wink a wink
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Space) && GlobalManager.readyToSpawnNewPlayer && !GlobalManager.cameraMoving)
            {
                var playerBubble = Instantiate(playerPrefab);
                playerBubble.name = "Player Bubble";
                playerBubble.transform.position = new Vector2 (spawnArea.transform.position.x, spawnArea.transform.position.y + 1);

                while (Input.GetKey(KeyCode.Space) && playerBubble.transform.localScale.x < 1.2f)
                {
                    foreach (Rigidbody2D rig in playerBubble.GetComponentsInChildren<Rigidbody2D>())
                    {
                        rig.linearVelocity = Vector2.up;
                    }
                    playerBubble.transform.localScale += new Vector3 (0.001f, 0.001f);
                    yield return new WaitForSeconds(0.1f);
                }
            
                // foreach (Rigidbody2D rig in playerBubble.GetComponentsInChildren<Rigidbody2D>())
                // {
                //     rig.AddForce(new Vector2 (0,0));
                // }
                GlobalManager.readyToSpawnNewPlayer = false;
            }
            else if (Camera.main.transform.position != cameraSpawningLocation.position && !GlobalManager.cameraMoving && GlobalManager.readyToSpawnNewPlayer)
            {
                StartCoroutine(Utils.CameraLerp(Camera.main, Camera.main.transform.position, cameraSpawningLocation.position, 3, 2f));
            }
            else if (Camera.main.transform.position != cameraPlayLocation.position && !GlobalManager.cameraMoving && !GlobalManager.readyToSpawnNewPlayer)
            {
                StartCoroutine(Utils.CameraLerp(Camera.main, Camera.main.transform.position, cameraPlayLocation.position, 5, 1.5f));
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
