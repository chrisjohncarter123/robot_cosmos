using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartManipulatorSettings : MonoBehaviour
{
    [SerializeField]
    bool renderHitSelections = false;

    public bool GetRenderHitSelections(){
        return renderHitSelections;
    }
}
