using UnityEngine;

public class SetRandomColour : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (spriteRenderer)
        {
            spriteRenderer.color = Utils.GetRandomColor();
        }

    }
}
