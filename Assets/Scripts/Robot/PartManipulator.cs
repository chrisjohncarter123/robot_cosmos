using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot{
public class PartManipulator : PieceManipulator
{
    
    private PartManipulatorSettings settings;


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
