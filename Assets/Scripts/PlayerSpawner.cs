using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalManager.readyToSpawnNewPlayer)
        {
            SpawnPlayer();
        }
    }

    private IEnumerator SpawnPlayer()
    {
        GameObject playerGameObject = Instantiate(playerPrefab, transform);


        yield return null;
    }
}
