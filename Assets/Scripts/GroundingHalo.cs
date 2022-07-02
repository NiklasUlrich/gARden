using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GroundingHalo : MonoBehaviour
{
    public Light halo;

    public float minIntensity = .2f;
    public float maxIntensity = 1.5f;

    /// <summary>
    /// THe speed of the color transitions
    /// </summary>
    public float lerpSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        halo.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.Sin(Time.time * lerpSpeed));
    }
}
