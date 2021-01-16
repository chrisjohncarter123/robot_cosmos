using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot{
    public class Piece : MonoBehaviour
    {
        [SerializeField]
        string pieceName;

        [SerializeField]
        string pieceDescription;

        [SerializeField]
        PartCategory[] pieceCategories;

        public bool ContainsCategory(PartCategory categoryTest){
           // Debug.Error("Implementation Error!");
            return false;
            

        }

        public bool ContainsCategory(PartCategory[] categoriesTest){
          //  Debug.Error("Implementation Error!");
            return false;
            

        }

        public static Piece Create(PieceType pieceType){
            GameObject newPieceGameObject = new GameObject();
            newPieceGameObject.name = pieceType.GetPieceTypeName();
            Piece piece = newPieceGameObject.AddComponent<Piece>();
            return piece;

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