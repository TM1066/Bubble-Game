using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreMultText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"<u>Score</u> {Mathf.RoundToInt(GlobalManager.score)}";
        highScoreText.text = $"{Mathf.RoundToInt(GlobalManager.highScore)}";
        if (GameObject.Find("Player Bubble"))
        {
            scoreMultText.text = Math.Round(GameObject.Find("Player Bubble").GetComponent<Player>().size * 2,3).ToString();
        }
    }

    public IEnumerator GameOverTextSetter()
    {
        gameOverText.text = $"Game Over\n\n{Mathf.RoundToInt(GlobalManager.score)}/{Mathf.RoundToInt(GlobalManager.highScore)}";
        while (true)
        {
            StartCoroutine(Utils.ColorLerp(gameOverText, Color.clear, Color.white, 1f));
            yield return new WaitForSeconds(1f);
            StartCoroutine(Utils.ColorLerp(gameOverText, Color.white, Color.clear, 1f));
            yield return new WaitForSeconds(1f);
        }
    }
    
}
