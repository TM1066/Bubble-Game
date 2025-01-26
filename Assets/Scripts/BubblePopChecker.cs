using UnityEngine;
using UnityEngine.U2D;

public class BubblePopChecker : MonoBehaviour
{
    public RandomMovingBubble movingBubble;
    public SpriteShapeController shapeController;

    // private void OnMouseDown() {
    //     Debug.Log("Click Detected");
    //     movingBubble.StartPOP();
    // }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Click in World Space: " + mousePosition);

            // Iterate through the spline's points to check proximity
            for (int i = 0; i < shapeController.spline.GetPointCount(); i++)
            {
                Vector3 localPoint = shapeController.spline.GetPosition(i);
                Vector3 worldPoint = transform.TransformPoint(localPoint);

                Debug.Log($"Local: {localPoint}, World: {worldPoint}, Mouse: {mousePosition}");
                if (Vector2.Distance(mousePosition, worldPoint) < 1.3f) // Adjust threshold as needed
                {
                    Debug.Log($"Clicked near point {i} of the Sprite Shape!");
                    movingBubble.StartPOP();
                    return;
                }
            }
        }
    }
}
