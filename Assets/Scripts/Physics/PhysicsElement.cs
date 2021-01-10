﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsElement : MonoBehaviour
{
    [SerializeField]
    Vector3 force;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        DeactivatePhysics();

        UpdatePsudoPhysics();

        ActivatePhysics();
        
    }

    private void UpdatePsudoPhysics(){
        
    }

    private void ActivatePhysics(){

    }

    private void DeactivatePhysics(){

    }

    void OnCollisionEnter(){
        ActivatePhysics();

    }

    void OnCollisionExit(){
        DeactivatePhysics();
    }
}
