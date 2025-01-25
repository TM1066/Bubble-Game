using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SoftBody : MonoBehaviour
{
    #region Fields
    public float splineOffset = 0.5f;
    public float tension = 0.5f;

    [SerializeField] SpriteShapeController spriteShape;
    [SerializeField] List<Transform> points = new List<Transform>();
    #endregion

    #region MonoBehaviour Calls
    void Awake()
    {
        //points.Sort((a, b) => Vector2.SignedAngle(Vector2.up, a.localPosition).CompareTo(Vector2.SignedAngle(Vector2.up, b.localPosition)));

        //UpdateVertices();
    }

    void Update()
    {
        UpdateVertices();
    }
    #endregion

    #region PrivateMethods
    void UpdateVertices()
    {
        for (int i = 0; i < points.Count; i++)
        {
            Transform point = points[i];
            Vector2 vertex = point.localPosition;
            Vector2 towardsCentre = (Vector2.zero - vertex).normalized;
            float colliderRadius = point.GetComponent<CircleCollider2D>().radius;

            try 
            {
            spriteShape.spline.SetPosition(i, vertex - towardsCentre * colliderRadius * tension);

            }
            catch 
            {
                Debug.Log("Spline Points are too close together, attempting to recalculate");
                spriteShape.spline.SetPosition(i, vertex - towardsCentre * (colliderRadius + splineOffset));
            }


            Vector2 edgeDir = (vertex - towardsCentre).normalized;
            Vector2 perpendicularDir = new Vector2(-edgeDir.y, edgeDir.x);  

            float tangentStrength = 0.5f;
            Vector2 newRightTangent = perpendicularDir * tangentStrength;
            Vector2 newLeftTangent = -newRightTangent;

            spriteShape.spline.SetLeftTangent(i, newLeftTangent);
            spriteShape.spline.SetRightTangent(i, newRightTangent);

            spriteShape.RefreshSpriteShape();
        }
    }


    void UpdateVerticesExample()
{

    // if (spriteShape.spline.GetPointCount() != points.Count)
    // {
    //     Debug.LogWarning("Spline and points count mismatch, updating...");
    //     spriteShape.spline.Clear();
    //     for (int i = 0; i < points.Count; i++)
    //     {
    //         spriteShape.spline.InsertPointAt(i, points[i].position);  // Placeholder to set count
    //     }
    // }


    spriteShape.spline.Clear();
    for (int i = 0; i < points.Count; i++)
    {
        spriteShape.spline.InsertPointAt(i, points[i].localPosition);  // Placeholder to set count
    }



    // for (int i = 0; i < points.Count; i++)
    // {
    //     Transform point = points[i];
    //     Vector2 vertex = point.localPosition;  
    //     Vector2 towardsCentre = (Vector2.zero - vertex).normalized;
    //     float colliderRadius = point.GetComponent<CircleCollider2D>().radius;

    //     try
    //     {
    //         spriteShape.spline.SetPosition(i, vertex - towardsCentre * colliderRadius);
    //     }
    //     catch
    //     {
    //         Debug.LogWarning($"Point {i} too close, recalculating...");
    //         spriteShape.spline.SetPosition(i, vertex - towardsCentre * (colliderRadius + splineOffset));
    //     }
    // }

    spriteShape.RefreshSpriteShape();  // Ensure visual update
}

    #endregion
}
