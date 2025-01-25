using UnityEngine;

public static class GlobalManager
{
    public static bool gameStarted = true;

    public static int playerLives = 3;

    public static int score = 0;
    public static int highScore = 0;

    public static float objectSpeed = 1f;

    public static bool readyToSpawnNewPlayer = true;
}
