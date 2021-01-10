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

    NodeManipulator nodeManipulator;
    PartManipulator partManipulator;

    void Start(){
         if(nodeManipulator == null || partManipulator == null){
            nodeManipulator = new NodeManipulator(this);
            partManipulator = new PartManipulator(this);

         }
        
    }

    public NodeManipulator GetNodeManipulator(){
        return nodeManipulator;
    }
    public PartManipulator GetPartManipulator(){
        return partManipulator;
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

    public RobotManipulatorSettings GetRobotManipulatorSettings(){
        return settings;
    }
     public void CreateNewRobot(){

         if(nodeManipulator == null || partManipulator == null){
            nodeManipulator = new NodeManipulator(this);
            partManipulator = new PartManipulator(this);

         }

        GameObject newRobot = new GameObject();
        newRobot.name = "Robot Head";
        this.robotHead = newRobot.AddComponent<RobotHead>();
        this.nodeParent = this.robotHead.AddPieceParent<NodeParent>("Node");
        this.partParent = this.robotHead.AddPieceParent<PartParent>("Part");

        partManipulator.AddPart<CommandCubeType>();
    }

    public void DestroyImmediateRobot(){
        if(robotHead != null){
            DestroyImmediate(robotHead.gameObject);
        }

    }

    
}
}