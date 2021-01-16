using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotPhysics{
public class PseudoPhysicsObject : MonoBehaviour
{
    [SerializeField]
    CollisionDetector collisionDetectorPosition;
    [SerializeField]
    CollisionDetector collisionDetectorRotation;
    
    [SerializeField]
    Vector3 pseudoForce;

    [SerializeField]
    Vector3 pseudoRotationForce;

    Rigidbody rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }

    void LateUpdate()
    {

        UpdatePseudoPhysicsPosition();
        UpdatePseudoPhysicsRotation();
        
    }

    private void UpdatePseudoPhysicsPosition(){
        Vector3 movement = pseudoForce * Time.deltaTime;
        Vector3 testPosition = transform.position + movement;
        collisionDetectorPosition.transform.position = testPosition;
        collisionDetectorPosition.transform.rotation = transform.rotation;

        if(collisionDetectorPosition.collisions.Count <= 1){

            transform.position = collisionDetectorPosition.transform.position;

        }

        
    }
    private void UpdatePseudoPhysicsRotation(){
        Vector3 rotation = pseudoRotationForce * Time.deltaTime;
        collisionDetectorRotation.transform.position = transform.position;
        collisionDetectorRotation.transform.eulerAngles = transform.eulerAngles;
        collisionDetectorRotation.transform.Rotate(rotation.x, rotation.y, rotation.z);
    
        if(collisionDetectorRotation.collisions.Count <= 1){

            transform.eulerAngles = collisionDetectorRotation.transform.eulerAngles;

        }

        
    }


}
}