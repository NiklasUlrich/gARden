using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GroundingHalo : MonoBehaviour
{
    /// <summary>
    /// The halo object
    /// </summary>
    private SerializedObject halo;

    /// <summary>
    /// The colors the halo will switch between
    /// </summary>
    public Color color1;

    /// <summary>
    /// The colors the halo will switch between
    /// </summary>
    public Color color2;

    /// <summary>
    /// THe speed of the color transitions
    /// </summary>
    public float lerpSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        halo = new SerializedObject(gameObject.GetComponent("Halo"));
    }

    // Update is called once per frame
    void Update()
    {
        halo.FindProperty("m_Color").colorValue = Color.Lerp(color1, color2, Mathf.Sin(Time.time * lerpSpeed));
        halo.ApplyModifiedProperties();
    }
}
