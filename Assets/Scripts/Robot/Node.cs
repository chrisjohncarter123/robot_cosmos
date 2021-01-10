using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    [ExecuteInEditMode]
    public class Node : MonoBehaviour
    {
        Part part;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(0,0,0);
        }
    }

}