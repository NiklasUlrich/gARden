using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloorDetector : MonoBehaviour
{
    public TextFade text;
    // Start is called before the first frame update
    void Start()
    {
        float height = (float)CoreServices.BoundarySystem.FloorHeight;
        text.HeightText(height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
