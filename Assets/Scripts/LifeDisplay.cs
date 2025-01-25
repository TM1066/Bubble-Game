using System.Collections.Generic;
using UnityEngine;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();

    // Update is called once per frame
    void Update()
    {
        switch (GlobalManager.playerLives)
        {
            case 3:
                foreach (SpriteRenderer spriteRenderer in spriteRenderers)
                {
                    spriteRenderer.color = Color.white;
                }
                break;
            case 2:
                spriteRenderers[0].color = Color.white;
                spriteRenderers[1].color = Color.white;
                spriteRenderers[2].color = Color.clear;
                break;
            case 1:
                spriteRenderers[0].color = Color.white;
                spriteRenderers[1].color = Color.clear;
                spriteRenderers[2].color = Color.clear;
                break;
            case 0:
                foreach (SpriteRenderer spriteRenderer in spriteRenderers)
                {
                    spriteRenderer.color = Color.clear;
                }
                break;
        }
    }
}
