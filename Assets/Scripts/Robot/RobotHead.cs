using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot{


    public class RobotHead : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {


            
        }


        public PieceParentType AddPieceParent<PieceParentType>(string name) where PieceParentType : Component{
            GameObject parent = new GameObject();
            parent.name = $"{name} Piece Parent";
            PieceParentType parentComponent = parent.AddComponent<PieceParentType>();
            parent.transform.parent = transform;
            return parentComponent;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

    }

}