using UnityEngine;

public class DamagingEntity : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Player"))
        {
            GameObject.Find("Player Bubble").GetComponent<Player>().StartGameOver();
        }
    }
}
