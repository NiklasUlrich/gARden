using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomObserver : MonoBehaviour
{
    MushroomTouch[] mushrooms;
    bool finished = false;

    public AK.Wwise.Event FinishedWwiseEvent;

    public ParticleSystem[] effects;

    // Start is called before the first frame update
    void Start()
    {
        mushrooms = GetComponentsInChildren<MushroomTouch>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            CheckMushrooms();
        }
    }

    void CheckMushrooms()
    {
        finished = true;
        for (int i = 0; i < mushrooms.Length; i++)
        {
            if (!mushrooms[i].Completed)
            {
                finished = false;
                return;
            }
        }

        Debug.Log("Mushrooms completed");
        if (FinishedWwiseEvent != null)
        {
            FinishedWwiseEvent.Post(gameObject);
        }

        for(int i = 0; i < effects.Length; i++)
        {
            effects[i].Play();
        }
        
    }
}
