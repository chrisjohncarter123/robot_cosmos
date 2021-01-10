using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot{
    public class PieceCategory : MonoBehaviour
    {
        [SerializeField]
        string categoryName;

        [SerializeField]
        string categoryDescription;

        static List<PieceCategory> allCategories;

        void Start(){
            if(allCategories == null){
                allCategories = new List<PieceCategory>();
            }
            allCategories.Add(this);
            

        }

        public static PieceCategory[] AllCategories(){
            return allCategories.ToArray();
        }
    }
}
