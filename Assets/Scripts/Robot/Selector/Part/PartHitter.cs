using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    public abstract class PartHitter : RaycastHitter
    {

        [SerializeField] SelectorGraphic partSelectedGraphic;

        [SerializeField] SelectorGraphic partHitGraphic;
        
        [SerializeField] HitTransform hitTransform;

        public enum HitTransform
        {
            Camera,
            GameObject
        }

        [SerializeField] Transform hitTransformGameObject;

        [SerializeField] Vector3 hitTransformRayDirectionOffset = new Vector3(0, 0, 0);

        private RaycastHitter hitter;
        

        private void Start()
        {
            hitter = gameObject.GetComponent<RaycastHitter>();
        }

        void Update()
        {

        }

    }
}