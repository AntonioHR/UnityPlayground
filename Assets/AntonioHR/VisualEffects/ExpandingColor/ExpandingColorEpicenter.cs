using AntonioHR.VisualEffects.ExpandingColor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntonioHR.VisualEffects.ExpandingColor
{
    public class ExpandingColorEpicenter : MonoBehaviour
    {
        [SerializeField]
        private float rate = 1;
        [SerializeField]
        private bool reset;
        [SerializeField]
        private float resetThreshold;

        private float radius;

        public void Update()
        {
            UpdateRadiusLocal();
            EpicenterData.Radius = radius;
            EpicenterData.Epicenter = transform.position;
        }

        private void UpdateRadiusLocal()
        {
            radius += rate * Time.deltaTime;
            if (reset && radius > resetThreshold)
                radius -= resetThreshold;
        }
    }
}