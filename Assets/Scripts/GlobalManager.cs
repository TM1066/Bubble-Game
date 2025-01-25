using UnityEngine;

public static class GlobalManager
{
    public static bool gameStarted = true;

    public static int playerLives = 3;

    public static float score = 0;
    public static float highScore = 0;

    public static float objectSpeed = 2f;

    public static bool readyToSpawnNewPlayer = false;
    public static void SaveHighScore()
    {
        PlayerPrefs.SetFloat("High Score", highScore);
    }
    public static void LoadHighScore()
    {
        PlayerPrefs.GetFloat("High Score", highScore);
    }
}
