using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Robot.Parts;

namespace Robot{

public class RobotManipulator : MonoBehaviour
{
    [SerializeField]
    RobotManipulatorSettings settings;
    
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

     public void CreateNewRobot(){

        GameObject newRobot = new GameObject();
        newRobot.name = "Robot Head";
        this.robotHead = newRobot.AddComponent<RobotHead>();
        this.nodeParent = this.robotHead.AddPieceParent<NodeParent>("Node");
        this.partParent = this.robotHead.AddPieceParent<PartParent>("Part");
        AddPart<CommandCubeType>();
    }

    public void DestroyImmediateRobot(){
        if(robotHead != null){
            DestroyImmediate(robotHead.gameObject);
        }

    }

    public void AddNode(NodeType nodeType){
        PieceType pieceType = nodeType.GetComponent<PieceType>();
        GameObject newNodeGameObject = AddPiece(pieceType);
        
        Node newNode = newNodeGameObject.AddComponent<Node>();
        newNode.transform.parent = robotManipulator.GetNodeParent().transform;

    }

    public void DeleteNode(Node node){

    }


    public PartManipulator(RobotManipulator robotManipulator) : base(robotManipulator){
        settings = robotManipulator.GetRobotManipulatorSettings().GetPartManipulatorSettings();
    }

    public void AddPart<T>() where T : MonoBehaviour {
        PartType partType = robotManipulator.GetRobotManipulatorSettings().GetPartType<T>();
        AddPart(partType);

    }

    public void AddPart(PartType partType){
        Part part = Part.Create(partType);

    }

    


    public void DeletePart(Part part){

    }

    
}
}