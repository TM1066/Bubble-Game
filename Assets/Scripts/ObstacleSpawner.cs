using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform endPoint;
    public List<Transform> spawnPoints = new List<Transform>();

    public GameObject dartBladePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            if (Random.Range(0,2) == 1 && !GlobalManager.readyToSpawnNewPlayer)
            {
                switch (Random.Range(0,5)) // add more for each spawn pattern
                {
                    case 0:
                        SpawnObject(dartBladePrefab, spawnPoints[0]);
                        SpawnObject(dartBladePrefab, spawnPoints[3]);
                        break;

                    case 1:
                        SpawnObject(dartBladePrefab, spawnPoints[0]);
                        SpawnObject(dartBladePrefab, spawnPoints[1]);
                        break;
                    case 2:
                        SpawnObject(dartBladePrefab, spawnPoints[1]);
                        SpawnObject(dartBladePrefab, spawnPoints[2]);
                        break;
                    case 3:
                        SpawnObject(dartBladePrefab, spawnPoints[1]);
                        SpawnObject(dartBladePrefab, spawnPoints[3]);
                        break;
                }
            }
            yield return new WaitForSeconds(1.6f);
        }
    }

    void SpawnObject(GameObject gameObject, Transform spawnArea)
    {
        GameObject spawnedObject = Instantiate (gameObject, spawnArea);
        spawnedObject.transform.position = spawnArea.position;
        StartCoroutine(Utils.PositionLerpAndDestroy(spawnedObject.transform, spawnArea.transform.position, new Vector3(spawnArea.transform.position.x, endPoint.position.y, 0),GlobalManager.objectSpeed));
    }
}
