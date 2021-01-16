using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    public class PartType : MonoBehaviour
    {
        [SerializeField]
        Vector3 positionOffset = new Vector3(0,0,0);

        [SerializeField]
        Vector3 rotationOffset = new Vector3(0,0,0);

        [SerializeField]
        Vector3 scale = new Vector3(1,1,1);

        [SerializeField]
        float partSelectorDistance = 2;

        [SerializeField]
        bool usePartScaleForPartSelectorHitScale = true;

        [SerializeField]
        Vector3 partSelectorHitScale = new Vector3(1.15f,1.15f,1.15f);

        [SerializeField]
        float partSelectorSurfaceScale = 1;

        [SerializeField]
        Mesh mesh;

        [SerializeField]
        Material material;

        [SerializeField]
        PhysicMaterial physicMaterial;

        [SerializeField]
        PartCategory partCategory;

        public Vector3 GetPositionOffset(){
            return positionOffset;
        }

        public Vector3 GetRotationOffset(){
            return rotationOffset;
        }

        public Vector3 GetScale(){
            return scale;
        }

        public float GetPartSelectorDistance(){
            return partSelectorDistance;
        }

        public Vector3 GetPartSelectorHitScale(){
            if(usePartScaleForPartSelectorHitScale){
                return scale;
            }
            else{
                return partSelectorHitScale;
            }
            
        }

        public float GetPartSelectorSurfaceScale(){
            return partSelectorSurfaceScale;
        }

        public Mesh GetMesh(){
            return mesh;
        }

        public Material GetMaterial(){
            return material;
        }

        public PhysicMaterial GetPhysicMaterial(){
            return physicMaterial;
        }

        public bool MatchesCategory(PartCategory partCategory){
            return this.partCategory == partCategory;
        }

        
    }
}
