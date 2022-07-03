using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionSeed : MonoBehaviour
{
    private AK.Wwise.Event DandelionSeedWwiseEvent;

    public Dandelion parent;

    // Start is called before the first frame update
    void Start()
    {
        DandelionSeedWwiseEvent = parent.seedWwiseEvent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pop()
    {
        if (DandelionSeedWwiseEvent != null)
        {
            DandelionSeedWwiseEvent.Post(gameObject);
        }
        gameObject.SetActive(false);
    }


}
