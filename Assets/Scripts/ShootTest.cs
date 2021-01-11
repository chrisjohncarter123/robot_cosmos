using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTest : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            GameObject newBullet = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * force);

        }
    }
}
