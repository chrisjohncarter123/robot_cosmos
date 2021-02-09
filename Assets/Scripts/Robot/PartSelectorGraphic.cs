using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot{
public class PartSelectorGraphic : MonoBehaviour
{

    Renderer renderer;
    void Start(){
        renderer = GetComponent<Renderer>();

    }

    public void UpdateGraphic(PartSelector selector, PartSurface surface){
        renderer.enabled = true;
        UpdatePositionRotationScale(selector, surface);

    }
    public void DisableGraphic(){
        renderer.enabled = false;
    }
    public void UpdatePositionRotationScale(PartSelector selector, PartSurface surface){

        

        Part part = surface.GetPart();
        PartType partType = part.GetPartType();
        PartSelector.HitType hitType = selector.GetHitType();

        if(hitType == PartSelector.HitType.Surface){
            UpdatePosition(part.transform.position, surface.GetDirection(), partType.GetPartSelectorDistance());

        }
        else if(hitType == PartSelector.HitType.Part){
            UpdatePosition(part.transform.position);

        }

        
        UpdateRotation(part.transform.eulerAngles);
        UpdateScale(partType.GetPartSelectorHitScale());
        
    }
    private void UpdatePosition(Vector3 partPosition){
        transform.position = partPosition;

    }

    private void UpdatePosition(Vector3 partPosition, Vector3 direction, float distance){
        transform.position = partPosition + (direction * distance);

    }
    private void UpdateRotation(Vector3 eulerAngles){
        transform.eulerAngles = eulerAngles;

    }
    private void UpdateScale(Vector3 scale){
        transform.localScale = scale;

    }

}
}