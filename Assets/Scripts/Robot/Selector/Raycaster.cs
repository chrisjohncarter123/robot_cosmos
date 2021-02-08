using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RaycastHitter : MonoBehaviour
{
    public delegate void OnHit(GameObject gameObject);
    public delegate void OnClick(GameObject gameObject);

    private List<OnHit> onHits;
    private List<OnClick> onClicks;

    void Start()
    {
        onHits = new List<OnHit>();
        onClicks = new List<OnClick>();
    }

    void Update()
    {
        UpdateRaycast();
    }
    
    private void UpdateRaycast(){
        RaycastHit hit;
        Ray ray = new Ray();

        Vector3 rayDirection = transform.forward;
        rayDirection.Normalize();
        ray = new Ray(transform.position, rayDirection);
        
        if (Physics.Raycast(ray, out hit)) {

            GameObject objectHit = hit.transform.gameObject;
            
            CallOnHits(objectHit);

            if (Input.GetMouseButtonDown(0))
            {
                CallOnHClicks(objectHit);
            }
        }
    }

    public void AddOnHitEvent(OnHit hit)
    {
        onHits.Add(hit);
    }

    public void AddOnClickEvent(OnClick click)
    {
        onClicks.Add(click);
    }

    private void CallOnHits(GameObject gameObject)
    {
        foreach (var onHit in onHits)
        {
            onHit(gameObject);
        }
    }
    private void CallOnHClicks(GameObject gameObject)
    {
        foreach (var onClick in onClicks)
        {
            onClick(gameObject);
        }
    }
}
