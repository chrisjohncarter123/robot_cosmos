using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot.Parts{

[RequireComponent(typeof(PartSelector))]
public class AttachPart : MonoBehaviour
{
    [SerializeField]
    RobotManipulator robotManipulator;

    [SerializeField]
    PartType partType;

    [SerializeField]
    PartSelector partSelector;

    void Start(){
        partSelector = gameObject.GetComponent<PartSelector>();
    }

    public void UsePart(){
        robotManipulator.AddPart(partType);

    }
}
}
