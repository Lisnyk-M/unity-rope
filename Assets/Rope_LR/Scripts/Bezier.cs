using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bezier
{
    public static Vector3 GetPoint(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            oneMinusT * oneMinusT * oneMinusT * v0 +
            3f * oneMinusT * oneMinusT * t * v1 +
            3f * oneMinusT * t * t * v2 +
            t * t * t * v3;
    }
}
