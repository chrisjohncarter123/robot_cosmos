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
            UpdateGraphic(partSelectedGraphic, selectedPartSurface);

            UpdateRaycast();

        }

        private void UpdateGraphic(SelectorGraphic graphic, PartSurface surface)
        {
            if (graphic && surface)
            {
                graphic.UpdateGraphic(surface);

            }
        }

        private void DisableGraphic(SelectorGraphic graphic)
        {
            if (graphic)
            {
                graphic.DisableGraphic();
            }
        }


        private void SelectPart(PartSurface selectedSurface)
        {

        }

        private void DeselectPart()
        {
            DisableGraphic(partSelectedGraphic);

        }
        
    

        private void UpdateRaycast()
        {
            
            Part part = null;
            PartSurface partSurface = null;
            bool didHit = false;
            

            Transform objectHit = hit.transform;
            partSurface = objectHit.GetComponent<PartSurface>();

            if (partSurface)
            {

                part = partSurface.GetPart();

                if (selectAllParts ||
                    (usePartCategory && part.GetPartType().MatchesCategory(this.partCategory)) ||
                    (usePartTypes && partTypes.Contains(part.GetPartType())))
                {

                    UpdateGraphic(this.partHitGraphic, partSurface);
                    didHit = true;

                }
            }
            

            if (!didHit)
            {
                DisableGraphic(partHitGraphic);

            }

            if (Input.GetMouseButtonDown(0))
            {

                if (didHit)
                {
                    SelectPart(selectedPartSurface);
                }
                else
                {
                    DeselectPart();

                }

            }

        }
    }
}