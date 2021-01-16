using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Robot{
    public class PartSelector : MonoBehaviour
    {
        [SerializeField]
        PartSelectorGraphic partSelectedGraphic;

        [SerializeField]
        PartSelectorGraphic partHitGraphic;

        [SerializeField]
        bool selectAllParts = true;

        [SerializeField]
        bool usePartCategory = false;

        [SerializeField]
        PartCategory partCategory;

        [SerializeField]
        bool usePartTypes = false;

        [SerializeField]
        PartType[] partTypes;
        
        PartSelectorSurface selectedPartSurface;

        [SerializeField]
        HitType hitType;

        [SerializeField]
        HitTransform hitTransform;

        public enum HitType{
            Part,
            Surface
        }

        public enum HitTransform{
            Camera,
            GameObject
        }

        [SerializeField]
        Transform hitTransformGameObject;

        [SerializeField]
        Vector3 hitTransformRayDirectionOffset = new Vector3(0,0,0);



        public Part GetSelectedPart(){
            return selectedPartSurface.GetPart();
        }

        public PartSelectorSurface GetSelectedSurface(){
            return selectedPartSurface;
        }

        public HitType GetHitType(){
            return hitType;
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            UpdateGraphic(partSelectedGraphic, selectedPartSurface);
            
            UpdateRaycast();
            
        }

        private void UpdateGraphic(PartSelectorGraphic graphic, PartSelectorSurface surface){
            if(graphic && surface)
            {
                graphic.UpdateGraphic(this, surface);

            }
        }

        private void DisableGraphic(PartSelectorGraphic graphic){
            if(graphic){
                graphic.DisableGraphic();
            }
        }

        private void UpdateRaycast(){
            RaycastHit hit;
            Ray ray;
            if(hitTransform == HitTransform.Camera){
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            }
            else if(hitTransform == HitTransform.GameObject){
                Vector3 rayDirection = hitTransformGameObject.forward + hitTransformRayDirectionOffset;
                rayDirection.Normalize();
                ray = new Ray(hitTransformRayDirectionOffset.position, rayDirection);

            }
            
            

            if(partHitGraphic){
                //partHitGraphic.GetComponent<Renderer>().enabled = false;
            }

            Part part = null;
            PartSelectorSurface partSurface = null;
            bool didHit = false;
            
            if (Physics.Raycast(ray, out hit)) {
                
                Transform objectHit = hit.transform;
                partSurface = objectHit.GetComponent<PartSelectorSurface>();
                
                if (partSurface){


                    
                    part = partSurface.GetPart();

                    Debug.Log("Hit " + hit.transform.gameObject.name);

                    if(selectAllParts || 
                    (usePartCategory && part.GetPartType().MatchesCategory(this.partCategory)) ||
                    (usePartTypes && partTypes.Contains (part.GetPartType()))){

                        UpdateGraphic(this.partHitGraphic, partSurface);
                        didHit = true;
                        
                    }
                }
            }
            if(!didHit){
                DisableGraphic(partHitGraphic);

            }
           
            if(Input.GetMouseButtonDown(0)){
                
                if(didHit){
                    this.selectedPartSurface = selectedPartSurface;
                }
                else{
                    DisableGraphic(partSelectedGraphic);
                    partSurface = null;
                }
                
            }
            
        }
    }
}