using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot{
public class PartSelectorHit : MonoBehaviour
{

    public void UpdatePositionRotationScale(PartSelectorSurface surface){

        Part part = surface.GetPart();
        PartType partType = part.GetPartType();

        UpdatePosition(part.transform.position, surface.GetDirection(), partType.GetPartSelectorDistance());
        UpdateRotation(part.transform.eulerAngles);
        UpdateScale(partType.GetPartSelectorHitScale());
        
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