using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedling : MonoBehaviour
{
    /// <summary>
    /// Which event will be played when the object is spawned
    /// </summary>
    public AK.Wwise.Event GrowWwiseEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //called when the object is created
    void Awake()
    {
        if (GrowWwiseEvent != null)
        {
            GrowWwiseEvent.Post(gameObject);
        }
    }
}
