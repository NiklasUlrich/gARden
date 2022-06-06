using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class MushroomTouch : MonoBehaviour, IMixedRealityTouchHandler
{
    /// <summary>
    /// The shader of the object
    /// </summary>
    MushroomShader mushroomShader;

    /// <summary>
    /// The script that controls the tiny mushrooms
    /// </summary>
    public TinyMushrooms tinyMushrooms;

    /// <summary>
    /// if the mushroom's task is completed
    /// </summary>
    bool completed;

    // Start is called before the first frame update
    void Start()
    {
        mushroomShader = gameObject.GetComponent<MushroomShader>();
        completed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed) { 
            if (mushroomShader.TransitionCompleted)
            {
                Debug.Log("Mushroom: Transition completed");
                completed = true;
                tinyMushrooms.Animate();
            }
        }
    }

    public void OnTouchCompleted(HandTrackingInputEventData eventData){}

    public void OnTouchStarted(HandTrackingInputEventData eventData){
        mushroomShader.MoveTransition();
    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData){}
}
