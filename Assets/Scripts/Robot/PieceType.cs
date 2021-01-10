using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceType : MonoBehaviour
{

    [SerializeField]
    string pieceTypeName;
    [SerializeField]
    string pieceTypeDescription;
    public string GetPieceTypeName(){
        return pieceTypeName;
    }
    public string GetPieceTypeDescription(){
        return pieceTypeDescription;
    }
}
