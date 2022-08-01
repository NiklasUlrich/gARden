using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FruitBehavior : MonoBehaviour
{
    /// <summary>
    /// Which event will be played when touch is started
    /// </summary>
    public AK.Wwise.Event GrabWwiseEvent;

    /// <summary>
    /// Which event will be played when touch is started
    /// </summary>
    public AK.Wwise.Event ThrowWwiseEvent;

    /// <summary>
    /// WThe seedling which will spawn when this fruit is planted
    /// </summary>
    public Seedling seedling;

    public bool banana;

    bool planted = false;
    public bool Planted { get => planted; set => planted = value; }

    // Start is called before the first frame update
    void Start()
    {
        seedling.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //is called when the fruit is grabbed
    public void OnGrab()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;

        if (GrabWwiseEvent != null)
        {
            GrabWwiseEvent.Post(gameObject);
        }
    }

    //is called when the fruit is released
    public void OnRelease()
    {
        if (ThrowWwiseEvent != null)
        {
            ThrowWwiseEvent.Post(gameObject);
        }
    }

    public void Plant()
    {
        seedling.gameObject.SetActive(true);
        seedling.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));
        seedling.GetComponent<Animator>().SetBool("Completed", true);
        planted = true;
        gameObject.SetActive(false);
    }
}
