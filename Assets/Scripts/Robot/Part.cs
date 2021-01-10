using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    public class Part : MonoBehaviour
    {
        [SerializeField]
        PartType partType;

        Node prgoramNode;

        Piece piece;



        public Piece GetPiece(){
            return this.piece;
        }

        public PartType GetPartType(){
            return partType;
        }

        public void SetPartType(PartType partType){
            this.partType = partType;

        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
