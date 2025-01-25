using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform endPoint;
    public List<Transform> spawnPoints = new List<Transform>();

    public GameObject sawBladePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            if (Random.Range(0,2) == 1)
            {
                switch (Random.Range(0,5)) // add more for each spawn pattern
                {
                    case 0:
                        SpawnObject(sawBladePrefab, spawnPoints[0]);
                        SpawnObject(sawBladePrefab, spawnPoints[3]);
                        break;

                    case 1:
                        SpawnObject(sawBladePrefab, spawnPoints[0]);
                        SpawnObject(sawBladePrefab, spawnPoints[1]);
                        break;
                    case 2:
                        SpawnObject(sawBladePrefab, spawnPoints[1]);
                        SpawnObject(sawBladePrefab, spawnPoints[2]);
                        break;
                    case 3:
                        SpawnObject(sawBladePrefab, spawnPoints[1]);
                        SpawnObject(sawBladePrefab, spawnPoints[3]);
                        break;
                }
            }
            yield return new WaitForSeconds(2f);
        }
    }

    void SpawnObject(GameObject gameObject, Transform spawnArea)
    {
        GameObject spawnedObject = Instantiate (gameObject, spawnArea);
        StartCoroutine(Utils.PositionLerpAndDestroy(spawnedObject.transform, this.transform.position, new Vector3(this.transform.position.x, endPoint.position.y, 0),GlobalManager.objectSpeed));
    }
}
