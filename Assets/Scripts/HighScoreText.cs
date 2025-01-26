using TMPro;
using UnityEngine;

public class HighScoreText : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        text.text = $"High Score\n{Mathf.RoundToInt(GlobalManager.highScore)}";
    }
}
