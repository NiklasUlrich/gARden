using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class MushroomTouch : MonoBehaviour, IMixedRealityTouchHandler
{
    /// <summary>
    /// The shader of the object
    /// </summary>
    MushroomColorChanger colorChanger;

    /// <summary>
    /// The script that controls the tiny mushrooms
    /// </summary>
    public TinyMushrooms tinyMushrooms;

    /// <summary>
    /// if the mushroom's task is completed
    /// </summary>
    bool completed;

    /// <summary>
    /// Which event will be played when touch is started
    /// </summary>
    public AK.Wwise.Event TouchWwiseEvent;

    public bool Completed { get => completed; set => completed = value; }


    // Start is called before the first frame update
    void Start()
    {
        colorChanger = gameObject.GetComponent<MushroomColorChanger>();
        Completed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Completed) { 
            if (colorChanger.completed)
            {
                Debug.Log("Mushroom: Transition completed");
                Completed = true;
                tinyMushrooms.Animate();
            }
        }
    }

    public void OnTouchCompleted(HandTrackingInputEventData eventData){}

    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        Debug.Log("[Input] Touch is started.");

        colorChanger.colorChange();

        if (TouchWwiseEvent != null)
        {
            TouchWwiseEvent.Post(gameObject);
        }
        
    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData){}
}
