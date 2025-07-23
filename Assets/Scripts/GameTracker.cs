using UnityEngine;
using UnityEngine.InputSystem;

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

        var mouse = Mouse.current;
        mouse?.WarpCursorPosition (new Vector2 (-50, 0)); //MOVE THE STUPID MOUSE OUT OF **THEEE WAYYYYY**
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GlobalManager.SaveHighScore();
            Application.Quit(); 
        }
    }

    private void OnApplicationFocus(bool focusStatus) {
        foreach (AudioSource aS in FindObjectsByType<AudioSource>(FindObjectsSortMode.None))
        {
            if (aS.volume > 0)
            {
                aS.volume = 0;
            }
            else 
            {
                aS.volume = 0.6f;
            }
        }
    }
}
