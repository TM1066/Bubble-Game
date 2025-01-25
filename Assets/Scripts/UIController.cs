using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {GlobalManager.score}";
        highScoreText.text = $"{GlobalManager.score}";
    }
    
}
