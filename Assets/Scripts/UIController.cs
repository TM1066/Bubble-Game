using UnityEngine;
using TMPro;
using System.Collections;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gameOverText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"<u>Score</u> {Mathf.RoundToInt(GlobalManager.score)}";
        highScoreText.text = $"{Mathf.RoundToInt(GlobalManager.highScore)}";
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
