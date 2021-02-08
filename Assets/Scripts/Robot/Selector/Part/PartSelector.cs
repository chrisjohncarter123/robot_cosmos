using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Robot{
    [RequireComponent(typeof(RaycastHitter))]
    public class PartSelector : Selector
    {
        [SerializeField] bool selectAllParts = true;

        [SerializeField] bool usePartCategory = false;

        [SerializeField] PartCategory partCategory;

        [SerializeField] bool usePartTypes = false;

        [SerializeField] PartType[] partTypes;
        
        protected Part selectedPart;

        
    }
}