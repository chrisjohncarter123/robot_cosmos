using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot.Parts{
    
public class Attacher : MonoBehaviour
{
    [SerializeField]
    PartType partType;

    [SerializeField]
    PartSelector partSelector;
        
    void Start(){
        partSelector.AddOnSelect(UsePart);
        
    }

    public void UsePart(){
        robotManipulator.AddPart(partType);

    }


}
}
