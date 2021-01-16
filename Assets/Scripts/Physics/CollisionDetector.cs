using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotPhysics{
public class CollisionDetector : MonoBehaviour
{
    public List<Collider> collisions;

    // Start is called before the first frame update
    void Start()
    {
        collisions = new List<Collider>();;
    }

    private void OnTriggerEnter(Collider other)
    {
        collisions.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        collisions.Remove(other);
    }
}
}