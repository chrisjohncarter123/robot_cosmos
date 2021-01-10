using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot{
public class NodeManipulator : PieceManipulator
{

   public NodeManipulator(RobotManipulator robotManipulator) : base(robotManipulator){
        
    }

    public void AddNode(NodeType nodeType){
        PieceType pieceType = nodeType.GetComponent<PieceType>();
        GameObject newNodeGameObject = AddPiece(pieceType);
        
        Node newNode = newNodeGameObject.AddComponent<Node>();
        newNode.transform.parent = robotManipulator.GetNodeParent().transform;

    }

    public void DeleteNode(Node node){

    }
}
}