using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    public class Part : MonoBehaviour
    {
        RobotHead robotHead;

        PartParent partParent;

        [SerializeField]
        PartType partType;

        Node prgoramNode;

        Piece piece;

        RobotManipulator manipulator;

        Dictionary<Vector3, PartSelectorSurface> surfaces = null;

        void Start(){
            
        }

        public Piece GetPiece(){
            return this.piece;
        }

        public PartType GetPartType(){
            return partType;
        }

        public void SetRobotHead(RobotHead robotHead){
            this.robotHead = robotHead;
        }

        public void SetPartParent(PartParent partParent){
            this.partParent = partParent;
        }

        public void SetPartType(PartType partType){
            this.partType = partType;

        }

        public void SetRobotManipulator(RobotManipulator manipulator){
            this.manipulator = manipulator;
        }

        public void AddSurface(Vector3 direction, string name){
            if(this.surfaces == null){
                this.surfaces = new Dictionary<Vector3, PartSelectorSurface>();
            }
            this.surfaces[direction] = PartSelectorSurface.Create(this, partType, manipulator, direction, name);

        }

        public void SetPosition(Vector3 position){
            transform.position = position;
        }

        public static Part Create(RobotHead robotHead, PartParent partParent, PartType partType, RobotManipulator manipulator){
            PieceType pieceType = partType.GetComponent<PieceType>();
            Piece newPiece = Piece.Create(pieceType);

            GameObject newPartGameObject = newPiece.gameObject;
            
            //Transform
            newPartGameObject.transform.parent = partParent.transform;
            newPartGameObject.transform.position = new Vector3(0,0,0);
            newPartGameObject.transform.eulerAngles += partType.GetRotationOffset();
            newPartGameObject.transform.localScale = partType.GetScale();
            
            //Add components
            Part part = newPartGameObject.AddComponent<Part>();
            part.SetRobotHead(robotHead);
            part.SetRobotManipulator(manipulator);
            part.SetPartParent(partParent);
            part.SetPartType(partType);
            
            
            AddMeshFilter(newPartGameObject, partType);
            AddMeshRenderer(newPartGameObject, partType);
            AddBoxCollider(newPartGameObject, partType);
            
            
            //Add PartSelectorSurfaces
            part.AddSurface(new Vector3( 1, 0, 0), "Part Selector Surface - Right");
            part.AddSurface(new Vector3(-1, 0, 0), "Part Selector Surface - Left");
            part.AddSurface(new Vector3( 0, 1, 0), "Part Selector Surface - Up");
            part.AddSurface(new Vector3( 0,-1, 0), "Part Selector Surface - Down");
            part.AddSurface(new Vector3( 0, 0, 1), "Part Selector Surface - Forward");
            part.AddSurface(new Vector3( 0, 0,-1), "Part Selector Surface - Back");
            
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
