using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SoftBody : MonoBehaviour
{
    #region Fields
    private const float splineOffset = 0.5f;

    [SerializeField] SpriteShapeController spriteShape;
    [SerializeField] List<Transform> points = new List<Transform>();
    #endregion

    #region MonoBehaviour Calls
    void Awake()
    {
        UpdateVertices();
    }

    void Update()
    {
        UpdateVertices();
    }
    #endregion

    #region PrivateMethods
    void UpdateVertices()
    {
        foreach (var point in points)
        {
            Vector2 vertex = point.localPosition;
            Vector2 towardsCentre = (Vector2.zero - vertex).normalized;

            float colliderRadius = point.GetComponent<CircleCollider2D>().radius;
            try 
            {
            spriteShape.spline.SetPosition(points.IndexOf(point), vertex - towardsCentre * colliderRadius);
            }
            catch 
            {
                Debug.Log("Spline Points are too close together, attempting to recalculate");
                spriteShape.spline.SetPosition(points.IndexOf(point), vertex - towardsCentre * (colliderRadius + splineOffset));
            }

            Vector2 leftTangent = spriteShape.spline.GetLeftTangent(points.IndexOf(point));

            Vector2 newRightTangent = Vector2.Perpendicular(towardsCentre) * leftTangent.magnitude;
            Vector2 newLeftTangent = Vector2.zero - (newRightTangent);

            //spriteShape.spline.SetLeftTangent(points.IndexOf(point), newLeftTangent);
            //spriteShape.spline.SetRightTangent(points.IndexOf(point), newRightTangent);
        }
    }
    #endregion
}
