using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot.Parts{
    
public class AttachPart : MonoBehaviour
{
    [SerializeField]
    RobotManipulator robotManipulator;

    [SerializeField]
    PartType partType;

    [SerializeField]
    PartSelector partSelector;

    void Start(){
        
    }

    public void UsePart(){
        robotManipulator.AddPart(partType);

    }
}
}
