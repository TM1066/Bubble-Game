using TMPro;
using UnityEngine;

public class HighScoreText : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        GlobalManager.LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"High Score\n{Mathf.RoundToInt(GlobalManager.highScore)}";
    }
}
