using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSelectorSurface : MonoBehaviour
{
    Vector3 direction;
    Part part;
    PartType partType;
    PartManipulatorSettings settings;

    public void SetPartType(PartType partType){
        this.partType = partType;
    }

    public void SetDirection(Vector3 direction){
        this.direction = direction;

    }

    public void SetPart(Part part){
        this.part = part;
    }

    public void SetPartManipulatorSettings(PartManipulatorSettings settings){
        this.settings = settings;
    }


    public static PartSelectorSurface CreatePartSelectorSurface(Part part, PartType partType, PartManipulatorSettings settings, Vector3 direction, string name){
        GameObject newSurface = new GameObject();
        newSurface.name = name;

        PartSelectorSurface newPartSelectorSurface = newSurface.AddComponent<PartSelectorSurface>();
        newPartSelectorSurface.SetPartType(partType);
        newPartSelectorSurface.SetDirection(direction);
        newPartSelectorSurface.SetPart(partType);
        newPartSelectorSurface.SetPartManipulatorSettings(settings);
        
        Part.AddBoxCollider(part, partType);
        if(settings.GetRenderHitSelections()){
            Part.AddMeshFilter(part, partType);
            Part.AddMeshRenderer(part, partType);
        }
        
        newSurface.transform.parent = newPartGameObject.transform;
        newPartSelectorSurface.UpdatePositionRotationScale();

        return newPartSelectorSurface;
    }

    public void UpdatePositionRotationScale(){

        //position
        Vector3 positionCentered = .5f * direction;
        Vector3 positionOffset = .5f * MathHelper.MultiplyVector3Coords(transform.localScale, direction);
        transform.localPosition = positionCentered + positionOffset;
        
        //scale
        float partSelectorSurfaceScale = partType.GetPartSelectorSurfaceScale();
        Vector3 localScale = new Vector3(1,1,1) + (MathHelper.AbsVector3(direction) * (partType.GetPartSelectorSurfaceScale() - 1)); 
        transform.localScale = localScale;

    }
}
