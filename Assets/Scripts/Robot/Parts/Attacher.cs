using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot.Parts{
    
public class Attacher : MonoBehaviour
{
    [SerializeField]
    PartType partType;
        
    void Start(){
        partSelector.AddOnSelect(UsePart);
        
    }

    public void UsePart(){
        robotManipulator.AddPart(partType);

    }
}
}
