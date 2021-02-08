using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot{
public abstract class RaycastHitterGraphic : MonoBehaviour
{

    Renderer renderer;
    void Start(){
        renderer = GetComponent<Renderer>();

    }

    public abstract void UpdateGraphic();

    public void UpdateGraphic(PartSelector partSelector, PartSurface surface){
        renderer.enabled = true;

    }
    public void DisableGraphic(){
        renderer.enabled = false;
    }

   
    protected void UpdatePosition(Vector3 partPosition){
        transform.position = partPosition;

    }

    protected void UpdatePosition(Vector3 partPosition, Vector3 direction, float distance){
        transform.position = partPosition + (direction * distance);

    }
    protected void UpdateRotation(Vector3 eulerAngles){
        transform.eulerAngles = eulerAngles;

    }
    protected void UpdateScale(Vector3 scale){
        transform.localScale = scale;

    }

}
}