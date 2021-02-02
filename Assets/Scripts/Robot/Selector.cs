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
        
        protected PartSurface selectedPartSurface;
        protected Part selectedPart;

        [SerializeField]
        HitType hitType;

        [SerializeField]
        HitTransform hitTransform;

        public enum HitType{
            Part,
            Surface,
            Handle
        }

        public enum HitTransform{
            Camera,
            GameObject
        }

        [SerializeField]
        Transform hitTransformGameObject;

        [SerializeField]
        Vector3 hitTransformRayDirectionOffset = new Vector3(0,0,0);

        public delegate void OnSelect();
        public delegate void OnHit();

        OnSelect onSelect = null;
        OnHit onHit = null;

        public void AddOnSelect(OnSelect onSelect){
            
            this.onSelect += onSelect;

        }
        public void AddOnHit(OnHit onHit){
            this.onHit += onHit;

        }

        public Part GetSelectedPart(){
            return selectedPartSurface.GetPart();
        }

        public PartSurface GetSelectedSurface(){
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

        private void UpdateGraphic(PartSelectorGraphic graphic, PartSurface surface){
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

        protected virtual void OnSelectPart()
        {
            
        }
        protected virtual void OnDeselectPart()
        {
            
        }

        private void SelectPart(PartSurface selectedSurface)
        {
            OnSelectPart();
        }

        private void DeselectPart()
        {
            DisableGraphic(partSelectedGraphic);
            selectedPartSurface = null;
            OnDeselectPart();
        }

        private void UpdateRaycast(){
            RaycastHit hit;
            Ray ray = new Ray();
            if(hitTransform == HitTransform.Camera){
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            }
            else if(hitTransform == HitTransform.GameObject){
                Vector3 rayDirection = hitTransformGameObject.forward + hitTransformRayDirectionOffset;
                rayDirection.Normalize();
                ray = new Ray(hitTransformRayDirectionOffset, rayDirection);

            }


            Part part = null;
            PartSurface partSurface = null;
            bool didHit = false;
            
            if (Physics.Raycast(ray, out hit)) {
                
                Transform objectHit = hit.transform;
                partSurface = objectHit.GetComponent<PartSurface>();
                
                if (partSurface){

                    part = partSurface.GetPart();

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