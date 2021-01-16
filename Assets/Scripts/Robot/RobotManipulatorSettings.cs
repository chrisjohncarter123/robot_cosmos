﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Robot{
    [RequireComponent(typeof(NodeManipulatorSettings))]
    [RequireComponent(typeof(PartManipulatorSettings))]
    
    public class RobotManipulatorSettings : MonoBehaviour
    {
        public NodeManipulatorSettings GetNodeManipulatorSettings(){
            return gameObject.GetComponent<NodeManipulatorSettings>();
        }

        public PartManipulatorSettings GetPartManipulatorSettings(){
            return gameObject.GetComponent<PartManipulatorSettings>();
        }

        public NodeType GetNodeType<T>() where T : MonoBehaviour{
            NodeType nodeType = transform.Find("Node Types").GetComponentsInChildren<T>()[0].GetComponent<NodeType>();

            return nodeType;

        }

        public NodeType[] GetNodeTypes(){
            NodeType[] nodeTypes = transform.Find("Node Types").GetComponentsInChildren<NodeType>();

            return nodeTypes;

        }

        public PartType GetPartType<T>() where T : MonoBehaviour{
 
            PartType partType = transform.Find("Part Types").GetComponentsInChildren<T>()[0].GetComponent<PartType>();

            return partType;

        }

        

        public PartType[] GetPartTypes(){
            PartType[] partTypes = transform.Find("Part Types").GetComponentsInChildren<PartType>();

            return partTypes;

        }
    }

}
