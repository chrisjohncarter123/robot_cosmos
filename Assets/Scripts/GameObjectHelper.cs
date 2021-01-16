using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectHelper
{
    public static MeshFilter AddMeshFilter(GameObject gameObject){
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        return meshFilter;
    }
    public static MeshRenderer AddMeshRenderer(GameObject gameObject){
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        return meshRenderer;
    }

    public static BoxCollider AddBoxCollider(GameObject gameObject){
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        return boxCollider;

    }
}
