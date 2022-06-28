using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FruitBehavior : MonoBehaviour
{
    /// <summary>
    /// Which event will be played when touch is started
    /// </summary>
    public AK.Wwise.Event GrabWwiseEvent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //is called when the fruit is grabbed
    public void OnRelease()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;

        if (GrabWwiseEvent != null)
        {
            GrabWwiseEvent.Post(gameObject);
        }
    }
}
