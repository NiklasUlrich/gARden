using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionObserver : MonoBehaviour
{
    bool finished = false;
    Dandelion[] dandelions;
    public AK.Wwise.Event FinishedWwiseEvent;

    // Start is called before the first frame update
    void Start()
    {
        dandelions = GetComponentsInChildren<Dandelion>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            CheckDandelions();
        }
    }

    void CheckDandelions()
    {
        finished = true;
        for(int i = 0; i < dandelions.Length; i++)
        {
            if (!dandelions[i].Exploded)
            {
                finished = false;
                return;
            }
        }

        Debug.Log("Dandelions completed");
        if (FinishedWwiseEvent != null)
        {
            FinishedWwiseEvent.Post(gameObject);
        }
    }
}
