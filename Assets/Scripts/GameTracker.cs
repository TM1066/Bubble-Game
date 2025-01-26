using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GlobalManager.SaveHighScore();
            Application.Quit(); 
        }
    }
}
