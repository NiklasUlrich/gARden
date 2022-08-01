using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    /// <summary>
    /// Event which will be played when the object is grabbed
    /// </summary>
    public AK.Wwise.Event WwisePickUpEvent;

    /// <summary>
    /// Event which will be played when the object is released
    /// </summary>
    public AK.Wwise.Event WwiseThrowEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // <OnThrow>
    /// <summary>
    /// plays a wwise event when the object is thrown
    /// </summary>
    public void OnThrow()
    {
        if (WwiseThrowEvent != null)
        {
            WwiseThrowEvent.Post(gameObject);
        }
    }

    // <OnThrow>
    /// <summary>
    /// plays a wwise event when the object is grabbed
    /// </summary>
    public void OnGrab()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        if (WwisePickUpEvent != null)
        {
            WwisePickUpEvent.Post(gameObject);
        }
    }
}
