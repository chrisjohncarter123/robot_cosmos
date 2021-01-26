using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot{
public class PartSelectorSurface : MonoBehaviour
{
    [SerializeField]
    Vector3 direction;

    [SerializeField]
    Part part;

    [SerializeField]
    PartType partType;

    [SerializeField]
    RobotManipulator manipulator;

    public void SetPartType(PartType partType){
        this.partType = partType;
    }

    public void SetDirection(Vector3 direction){
        this.direction = direction;

    }

    public Vector3 GetDirection(){
        return direction;
    }

    public void SetPart(Part part){
        this.part = part;
    }

    public Part GetPart(){
        return part;
    }

    public void SetRobotManipulator(RobotManipulator manipulator){
        this.manipulator = manipulator;
    }


    public static PartSelectorSurface Create(Part part, PartType partType, RobotManipulator manipulator, PartSurfaceType surfaceType){
        GameObject newSurface = new GameObject();
        newSurface.name =  surfaceType.GetName();
        Vector3 direction = surfaceType.GetDirection();

        PartSelectorSurface newPartSelectorSurface = newSurface.AddComponent<PartSelectorSurface>();
        newPartSelectorSurface.SetPartType(partType);
        newPartSelectorSurface.SetDirection(direction);
        newPartSelectorSurface.SetPart(part);
        newPartSelectorSurface.SetRobotManipulator(manipulator);
        
        Part.AddBoxCollider(newSurface, partType);
        if(manipulator.GetRenderHitSelections()){
            Part.AddMeshFilter(newSurface, partType);
            Part.AddMeshRenderer(newSurface, partType);
        }
        
        newSurface.transform.parent = part.gameObject.transform;
        newPartSelectorSurface.UpdatePositionRotationScale();

        return newPartSelectorSurface;
    }

    public void UpdatePositionRotationScale(){

        //WARNING!
        //Scale must be set before position because the position is dependant on the scale.

        //scale
        float partSelectorSurfaceScale = partType.GetPartSelectorSurfaceScale();
        Vector3 localScale = new Vector3(1,1,1) + (MathHelper.AbsVector3(direction) * (partType.GetPartSelectorSurfaceScale() - 1)); 
        transform.localScale = localScale;

        //position
        Vector3 positionCentered = .5f * direction;
        Vector3 positionOffset = .5f * MathHelper.MultiplyVector3Coords(transform.localScale, direction);
        transform.localPosition = positionCentered + positionOffset;

        //rotattion
        //...
        
       

    }

    public Vector3 GetAttachingPosition()
    {
        return part.transform.position + partType.RelativeAttachmentPositionOffset;
    }

    public Vector3 GetAttachingEulerAngles()
    {
        return transform.eulerAngles + partType.RelativeAttachmentEulerAnglesOffset;
    }


}
}