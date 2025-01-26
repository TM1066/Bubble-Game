using System.Collections;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ScoreIncrementer());
    }

    IEnumerator ScoreIncrementer()
    {
        while (true)
        {
            if (GameObject.Find("Player Bubble") && !GlobalManager.gameFinished)
            {
                GlobalManager.score += (1f * GameObject.Find("Player Bubble").GetComponent<Player>().size);
                if (GlobalManager.score > GlobalManager.highScore)
                {
                    GlobalManager.highScore = GlobalManager.score;
                }
            }
            yield return new WaitForSeconds(1);
        }
    }
}
