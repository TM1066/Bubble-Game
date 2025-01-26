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
        scoreText.text = $"Score: {Mathf.RoundToInt(GlobalManager.score)}";
        highScoreText.text = $"{Mathf.RoundToInt(GlobalManager.highScore)}";
        gameOverText.text = "";

    }

    public IEnumerator GameOverTextSetter()
    {
        gameOverText.text = $"Game Over\n\n{GlobalManager.score}/{GlobalManager.highScore}";
        while (true)
        {
            StartCoroutine(Utils.ColorLerp(gameOverText, Color.clear, Color.white, 1f));
            yield return new WaitForSeconds(1f);
            StartCoroutine(Utils.ColorLerp(gameOverText, Color.white, Color.clear, 1f));
            yield return new WaitForSeconds(1f);
        }
    }
    
}
