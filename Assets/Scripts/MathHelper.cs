using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathHelper
{
    public static Vector3 AbsVector3(Vector3 vector){
        return new Vector3(
            Mathf.Abs(vector.x),
            Mathf.Abs(vector.y),
            Mathf.Abs(vector.z)
        );
    }

    public static Vector3 MultiplyVector3Coords(Vector3 a, Vector3 b){
        return new Vector3(
            a.x * b.x,
            a.y * b.y,
            a.z * b.z
        );
    }
}
