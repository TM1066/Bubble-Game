using UnityEngine;

public class DamagingEntity : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Player"))
        {
            GameObject.Find("Player Bubble").GetComponent<Player>().StartGameOver();
            foreach (var dart in FindObjectsByType<DamagingEntity>(FindObjectsSortMode.None))
            {
                if (dart != this)
                {
                    Destroy(dart);
                }
            }
            Destroy(this);
        }
    }
}
