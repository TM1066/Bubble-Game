using UnityEngine;

public static class GlobalManager
{
    public static bool gameFinished = false;

    public static int playerLives = 3;

    public static float score = 0;
    public static float highScore = 0;

    public static float objectSpeed = 2f;

    public static bool readyToSpawnNewPlayer = true;
    public static bool cameraMoving = false;
    public static void SaveHighScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetFloat("High Score", highScore);
        }
        
    }
    public static void LoadHighScore()
    {
        PlayerPrefs.GetFloat("High Score", highScore);
    }
}
