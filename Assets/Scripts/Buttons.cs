using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour 
{
    public static void PlayGame()
    {
        GlobalManager.score = 0;
        GlobalManager.playerLives = 3;
        GlobalManager.readyToSpawnNewPlayer = true;
        SceneManager.LoadScene("PlayScene");
    }

    public static void ClearBubbles()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Bubble");

        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }


}
