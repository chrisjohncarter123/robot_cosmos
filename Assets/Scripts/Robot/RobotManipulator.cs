using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Robot.Parts;

namespace Robot{

public class RobotManipulator : MonoBehaviour
{
    [SerializeField]
    bool renderHitSelections = false;

    [SerializeField]
    Vector3 initialPartPosition = new Vector3(0,10,0);
    
    RobotHead robotHead = null;
    NodeParent nodeParent = null;
    PartParent partParent = null;


    void Start(){
        
    }


    public RobotHead GetRobotHead(){
        return robotHead;
    }
    public NodeParent GetNodeParent(){
        return nodeParent;
    }
    public PartParent GetPartParent(){
        return partParent;
    }
    public bool GetRenderHitSelections(){
        return renderHitSelections;
    }

    public NodeType GetNodeType<T>() where T : MonoBehaviour{
        NodeType nodeType = transform.Find("Node Types").GetComponentsInChildren<T>()[0].GetComponent<NodeType>();

        return nodeType;

    }

    public NodeType[] GetNodeTypes(){
        NodeType[] nodeTypes = transform.Find("Node Types").GetComponentsInChildren<NodeType>();

        return nodeTypes;

    }

    public PartType GetPartType<T>() where T : MonoBehaviour{

        PartType partType = transform.Find("Part Types").GetComponentsInChildren<T>()[0].GetComponent<PartType>();

        return partType;

    }

    

    public PartType[] GetPartTypes(){
        PartType[] partTypes = transform.Find("Part Types").GetComponentsInChildren<PartType>();

        return partTypes;

    }


     public void CreateNewRobot(){

        GameObject newRobot = new GameObject();
        newRobot.name = "Robot Head";
        this.robotHead = newRobot.AddComponent<RobotHead>();
        this.nodeParent = this.robotHead.AddPieceParent<NodeParent>("Node");
        this.partParent = this.robotHead.AddPieceParent<PartParent>("Part");
        CreateInitialPart();
    }

    void CreateInitialPart(){
        Part part = AddPart<CommandCubeType>();
        part.SetPosition(initialPartPosition);

    }

    public void DestroyImmediateRobot(){
        if(robotHead != null){
            DestroyImmediate(robotHead.gameObject);
        }

    }

    public void AddNode(NodeType nodeType){
        /*
        PieceType pieceType = nodeType.GetComponent<PieceType>();
        GameObject newNodeGameObject = AddPiece(pieceType);
        
        Node newNode = newNodeGameObject.AddComponent<Node>();
        newNode.transform.parent = robotManipulator.GetNodeParent().transform;
        */

    }

    public void DeleteNode(Node node){

    }

    public Part AddPart<T>() where T : MonoBehaviour {
        PartType partType = GetPartType<T>();
        return AddPart(partType);

    }

    public Part AddPart(PartType partType){
        return Part.Create(robotHead, partParent, partType, this);

    }


    public Part AddPart<T>(PartSurface surface) where T : MonoBehaviour {
        PartType partType = GetPartType<T>();
        
        return AddPart(partType);

    }

    public Part AddPart(PartType partType, PartSurface surface){
        
        return Part.Create(robotHead, partParent, partType, this);

    }

    public Part AddPart(PartType partType, Vector3 position){
        
        return Part.Create(robotHead, partParent, partType, this);

    }

    public void AttachPart(Part basePart, PartSurface surface, Part attachingPart){
        attachingPart.transform.position = surface.GetAttachingPosition();
        attachingPart.transform.eulerAngles = surface.GetAttachingEulerAngles();
       

    }

    


    public void DeletePart(Part part){
        Destroy(part.gameObject);

    }

    
}
}