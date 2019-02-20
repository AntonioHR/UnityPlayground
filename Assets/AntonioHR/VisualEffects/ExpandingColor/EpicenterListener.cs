using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntonioHR.VisualEffects.ExpandingColor
{
    public class EpicenterListener : MonoBehaviour
    {
        public const string EpicenterId = "_Epicenter";
        public const string RadiusId = "_Radius";

        private Renderer renderer;
        
        private void Awake()
        {
            renderer = GetComponent<Renderer>();
        }
        private void LateUpdate()
        {
            renderer.material.SetVector(EpicenterId, EpicenterData.Epicenter);
            renderer.material.SetFloat(RadiusId, EpicenterData.Radius);
        }
    }
}