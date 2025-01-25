using UnityEngine;
using System.Collections;

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

    public static IEnumerator PositionLerpAndDestroy(Transform thingToMove, Vector3 vectorFrom, Vector3 vectorTo, float duration)
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

        GameObject.Destroy(thingToMove.gameObject);
        yield return null;
    }


}
