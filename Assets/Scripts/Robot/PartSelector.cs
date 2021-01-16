using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Robot{
    public class PartSelector : MonoBehaviour
    {
        [SerializeField]
        Vector3 rayDirectionOffset = new Vector3(0,0,0);

        [SerializeField]
        GameObject partSelectedGraphic;

        [SerializeField]
        GameObject partHitGraphic;

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

        
        
        Part selectedPart;

        public Part GetSelectedPart(){
            return selectedPart;
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(selectedPart){
                UpdateGraphic(partSelectedGraphic, selectedPart);
            }
            
            UpdateRaycast();
            
        }

        private void UpdateGraphic(GameObject graphic, Part part){
            if(graphic && part)
            {
                graphic.GetComponent<Renderer>().enabled = true;
                graphic.transform.position = part.transform.position;
                graphic.transform.rotation = part.transform.rotation;
            }
        }

        private void UpdateRaycast(){
            RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayDirection = transform.forward + rayDirectionOffset;
            rayDirection.Normalize();
            Ray ray = new Ray(transform.position, rayDirection);

            partHitGraphic.GetComponent<Renderer>().enabled = false;

            Part part = null;
            
            if (Physics.Raycast(ray, out hit)) {
                Transform objectHit = hit.transform;
                part = objectHit.GetComponent<Part>();
                
                if(part){

                    if(selectAllParts || 
                      (usePartCategory && part.GetPartType().MatchesCategory(this.partCategory)) ||
                      (usePartTypes && partTypes.Contains (part.GetPartType()))){

                        UpdateGraphic(this.partHitGraphic, part);

                        if(Input.GetMouseButtonDown(0)){
                            SelectPart(part);
                        }
                    }

                }
            }

        }

        void SelectPart(Part selectedPart){
            this.selectedPart = selectedPart;


        }

        void DeselectPart(){
            partSelectedGraphic.GetComponent<Renderer>().enabled = false;
            selectedPart = null;

        }
    }
}