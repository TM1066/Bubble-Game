using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {GlobalManager.score}";
        highScoreText.text = $"{GlobalManager.highScore}";
    }
    
}
