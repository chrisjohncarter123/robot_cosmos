using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot{
public class PartGroup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameObject CreateNewPartGroup(){
        GameObject newPartGroup = new GameObject();
        return newPartGroup;
        
    }

    public void AttachPart(Part part){
        part.transform.parent = transform;
        
    }

    public void DetachPart(Part part){
        part.transform.parent = null;
    }
}
}
