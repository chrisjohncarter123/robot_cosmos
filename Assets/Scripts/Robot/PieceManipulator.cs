using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Robot{
    public class PieceManipulator
    {

        protected RobotManipulator robotManipulator;

        protected PieceManipulator(RobotManipulator robotManipulator){
            this.robotManipulator = robotManipulator;

        }

       

        protected GameObject AddPiece(PieceType pieceType){
            GameObject newPieceGameObject = new GameObject();
            newPieceGameObject.name = pieceType.GetPieceTypeName();
            return newPieceGameObject;

        }
        

        

       
    }

}
