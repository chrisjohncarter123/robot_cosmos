using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    public class Part : MonoBehaviour
    {
        [SerializeField]
        PartType partType;

        Node prgoramNode;

        Piece piece;

        PartManipulatorSettings settings;

        Dictionary<Vector3, PartSelectorSurface> surfaces;

        void Start(){
            this.surfaces = new Dictionary<Vector3, PartSelectorSurface>();
        }

        public Piece GetPiece(){
            return this.piece;
        }

        public PartType GetPartType(){
            return partType;
        }

        public void SetPartType(PartType partType){
            this.partType = partType;

        }

        public void SetPartManipulatorSettings(PartManipulatorSettings settings){
            this.settings = settings;
        }

        public static Part Create(PartType partType, PartManipulatorSettings settings){
            PieceType pieceType = partType.GetComponent<PieceType>();
            GameObject newPartGameObject = AddPiece(pieceType);
            
            //Transform
            newPartGameObject.transform.position = new Vector3(0,8,0);
            newPartGameObject.transform.position += partType.GetPositionOffset();
            newPartGameObject.transform.eulerAngles += partType.GetRotationOffset();
            newPartGameObject.transform.localScale = partType.GetScale();
            
            //Add components
            Part part = newPartGameObject.AddComponent<Part>();
            part.SetPartType(partType);
            part.transform.parent = robotManipulator.GetPartParent().transform;
            
            AddMeshFilter(newPartGameObject, partType);
            AddMeshRenderer(newPartGameObject, partType);
            AddBoxCollider(newPartGameObject, partType);
            
            
            //Add PartSelectorSurfaces
            surfaces[new Vector3( 1, 0, 0)] = PartSelectorSurface.Create(part, partType, settings, new Vector3( 1, 0, 0), "Part Selector Surface - Right");
            surfaces[new Vector3(-1, 0, 0)] = PartSelectorSurface.Create(part, partType, settings, new Vector3(-1, 0, 0), "Part Selector Surface - Left");
            surfaces[new Vector3( 0, 1, 0)] = PartSelectorSurface.Create(part, partType, settings, new Vector3( 0, 1, 0), "Part Selector Surface - Top");
            surfaces[new Vector3( 0,-1, 0)] = PartSelectorSurface.Create(part, partType, settings, new Vector3( 0,-1, 0), "Part Selector Surface - Bottom");
            surfaces[new Vector3( 0, 0, 1)] = PartSelectorSurface.Create(part, partType, settings, new Vector3( 0, 0, 1), "Part Selector Surface - Forward");
            surfaces[new Vector3( 0, 0,-1)] = PartSelectorSurface.Create(part, partType, settings, new Vector3( 0, 0,-1), "Part Selector Surface - Back");

            return part;

        }

    public static MeshFilter AddMeshFilter(GameObject gameObject, PartType partType){
        MeshFilter meshFilter = GameObjectHelper.AddMeshFilter(gameObject);
        meshFilter.mesh = partType.GetMesh();
        return meshFilter;
    }
    public static MeshRenderer AddMeshRenderer(GameObject gameObject, PartType partType){
        MeshRenderer meshRenderer = GameObjectHelper.AddMeshRenderer(gameObject);
        meshRenderer.material = partType.GetMaterial();
        return meshRenderer;
    }

    public static BoxCollider AddBoxCollider(GameObject gameObject, PartType partType){
        BoxCollider boxCollider = GameObjectHelper.AddBoxCollider(gameObject);
        boxCollider.material = partType.GetPhysicMaterial();
        return boxCollider;

    }
    }
}
