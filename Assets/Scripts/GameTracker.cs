using UnityEngine;

public class GameTracker : MonoBehaviour
{
    private static GameTracker instance = null;

    void Awake()
    {
        // Deals with duplicates

        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scenes
            GlobalManager.LoadHighScore();
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate
        }
    }
}
