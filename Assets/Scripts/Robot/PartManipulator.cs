using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot{
public class PartManipulator : PieceManipulator
{
    public PartManipulator(RobotManipulator robotManipulator) : base(robotManipulator){
        
    }

    public void AddPart<T>() where T : MonoBehaviour {
        PartType partType = robotManipulator.GetRobotManipulatorSettings().GetPartType<T>();
        AddPart(partType);

    }

    public void AddPart(PartType partType){
        PieceType pieceType = partType.GetComponent<PieceType>();
        GameObject newPartGameObject = AddPiece(pieceType);
        
        //Transform
        newPartGameObject.transform.position = new Vector3(0,8,0);
        newPartGameObject.transform.position += partType.GetPositionOffset();
        newPartGameObject.transform.eulerAngles += partType.GetRotationOffset();
        
        //Add components
        Part newPart = newPartGameObject.AddComponent<Part>();
        newPart.SetPartType(partType);
        newPart.transform.parent = robotManipulator.GetPartParent().transform;
        newPart.transform.localScale = partType.GetScale();
        MeshFilter meshFilter = newPart.gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = partType.GetMesh();
        MeshRenderer meshRenderer = newPart.gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = partType.GetMaterial();
        BoxCollider boxCollider = newPart.gameObject.AddComponent<BoxCollider>();
        boxCollider.material = partType.GetPhysicMaterial();

        //Add PartSelectorSurfaces
        
        CreatePartSelectorSurface(partType, newPartGameObject, new Vector3(1,0,0), "Part Selector Surface - Right");
        CreatePartSelectorSurface(partType, newPartGameObject, new Vector3(-1,0,0), "Part Selector Surface - Left");
        CreatePartSelectorSurface(partType, newPartGameObject, new Vector3(0,1,0), "Part Selector Surface - Top");
        CreatePartSelectorSurface(partType, newPartGameObject, new Vector3(0,-1,0), "Part Selector Surface - Bottom");
        CreatePartSelectorSurface(partType, newPartGameObject, new Vector3(0,0,1), "Part Selector Surface - Forward");
        CreatePartSelectorSurface(partType, newPartGameObject, new Vector3(0,0,-1), "Part Selector Surface - Back");


    }

    private GameObject CreatePartSelectorSurface(PartType partType, GameObject newPartGameObject, Vector3 direction, string name){
        GameObject newSurface = new GameObject();
        newSurface.name = name;

        MeshFilter meshFilter = newSurface.AddComponent<MeshFilter>();
        meshFilter.mesh = partType.GetMesh();
        MeshRenderer meshRenderer = newSurface.AddComponent<MeshRenderer>();
        meshRenderer.material = partType.GetMaterial();
        BoxCollider boxCollider = newSurface.AddComponent<BoxCollider>();
        boxCollider.material = partType.GetPhysicMaterial();
        
        newSurface.transform.parent = newPartGameObject.transform;
        float partSelectorSurfaceScale = partType.GetPartSelectorSurfaceScale();
        newSurface.transform.localScale = direction * partSelectorSurfaceScale;
        newSurface.transform.localPosition = direction * partSelectorSurfaceScale;

        return newSurface;
        

    }



    public void DeletePart(Part part){

    }
}
}
