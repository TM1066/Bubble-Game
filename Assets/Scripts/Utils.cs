using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UIElements;
using TMPro;

public static class Utils 
{
    public static IEnumerator PositionLerp(Transform thingToMove, Vector3 vectorFrom, Vector3 vectorTo, float duration)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration) 
        {
            if (thingToMove != null) // I like to destroy
            {
                thingToMove.position = Vector3.Lerp(vectorFrom, vectorTo, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            else 
            {
                break;
            }
        }
        yield return null;
    }

    public static IEnumerator CameraLerp(Camera camera, Vector3 vectorFrom, Vector3 vectorTo, float cameraSize, float duration)
    {
        GlobalManager.cameraMoving = true;

        float timeElapsed = 0;
        float cameraCurrentSize = camera.orthographicSize;

        while (timeElapsed < duration) 
        {
            if (camera != null) // I like to destroy
            {
                camera.transform.position = Vector3.Slerp(vectorFrom, vectorTo, timeElapsed / duration);
                camera.orthographicSize = Mathf.Lerp(cameraCurrentSize, cameraSize, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            else 
            {
                break;
            }
        }
        camera.transform.position = vectorTo;
        GlobalManager.cameraMoving = false;
        yield return null;
    }

    public static IEnumerator ColorLerp(TextMeshProUGUI text, Color startColor, Color endColor, float duration)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration) 
        {
            if (text != null) // I like to destroy
            {
                text.color = Color.Lerp(startColor, endColor, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            else 
            {
                break;
            }
        }
        yield return null;
    }

    public static IEnumerator ScaleLerp(Transform thingToScale, Vector2 scaleFrom, Vector2 scaleTo, float duration)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration) 
        {
            if (thingToScale != null) // I like to destroy
            {
                thingToScale.localScale = Vector3.Slerp(scaleFrom, scaleTo, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            else 
            {
                break;
            }
        }
        yield return null;
    }

    public static Color GetRandomColor()
    {
        byte r = (Byte) UnityEngine.Random.Range(50, 255); // Make sure Colours don't get too dark to see
        byte g = (Byte) UnityEngine.Random.Range(50, 255);
        byte b = (Byte) UnityEngine.Random.Range(50, 255);

        return new Color32(r,g,b,255); // everything starts out 1 alpha
    }

    public static IEnumerator PositionLerpAndDestroy(Transform thingToMove, Vector3 vectorFrom, Vector3 vectorTo, float duration)
    {
        yield return new WaitForSeconds(1.5f);

        float timeElapsed = 0;

        while (timeElapsed < duration) 
        {
            if (thingToMove != null) // I like to destroy
            {
                thingToMove.position = Vector3.Lerp(vectorFrom, vectorTo, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            else 
            {
                break;
            }
        }

        GameObject.Destroy(thingToMove.gameObject);
        yield return null;
    }


}
