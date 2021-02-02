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

    public void UpdateGraphic(Selector selector, PartSurface surface){
        renderer.enabled = true;
        UpdatePositionRotationScale(selector, surface);

    }
    public void DisableGraphic(){
        renderer.enabled = false;
    }
    public void UpdatePositionRotationScale(Selector selector, PartSurface surface){
        
        Part part = surface.GetPart();
        PartType partType = part.GetPartType();
        Selector.HitType hitType = selector.GetHitType();

        if(hitType == Selector.HitType.Surface)
        {
            Vector3 direction = surface.SurfaceType.GetDirection();
            UpdatePosition(part.transform.position, direction, partType.GetPartSelectorDistance());
            UpdateRotation(part.transform.eulerAngles);
            UpdateScale(partType.GetPartSelectorHitScale());

        }
        else if(hitType == Selector.HitType.Part){
            UpdatePosition(part.transform.position);
            UpdateRotation(part.transform.eulerAngles);
            UpdateScale(partType.GetPartSelectorHitScale());

        }
        else if (hitType == Selector.HitType.Handle)
        {
            
        }

        
        
        
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