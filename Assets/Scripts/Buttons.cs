using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour 
{
    public static void PlayGame()
    {
        Physics2D.gravity = new Vector2(0,0);
        GlobalManager.score = 0;
        GlobalManager.playerLives = 3;
        GlobalManager.readyToSpawnNewPlayer = true;
        GlobalManager.gameFinished = false;
        SceneManager.LoadScene("PlayScene");
    }

    public void ClearBubbles(GameObject floor)
    {
        StartCoroutine(Vacuum(floor));
    }

    private IEnumerator Vacuum(GameObject floor)
    {
        this.GetComponent<AudioSource>().Play();
        floor.SetActive(false);
        Physics2D.gravity = new Vector2(0,-10);
        yield return new WaitForSeconds(5);
        Physics2D.gravity = new Vector2(0,0);
        floor.SetActive(true);

        // while (GameObject.Find("Random Bubble"))
        // {
        //     Destroy (GameObject.Find("Random Bubble"));
        // }
    }


}
