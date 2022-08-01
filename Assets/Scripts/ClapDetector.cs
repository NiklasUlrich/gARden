using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;



public class ClapDetector : MonoBehaviour
{
    MixedRealityPose rightPalm;
    MixedRealityPose leftPalm;

    public GameObject dandelionCollection;

    Dandelion[] dandelions;

    public float clapRange;

    public AK.Wwise.Event clapWwiseEvent;

    // Start is called before the first frame update
    void Start()
    {
        dandelions = dandelionCollection.GetComponentsInChildren<Dandelion>();
    }

    // Update is called once per frame
    void Update()
    {
        //measures the distance between the left and right palm while they are both detected
        if(HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Right, out rightPalm) &&
            HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Left, out leftPalm))
        {
            Debug.Log("palm distance: " + Vector3.Distance(rightPalm.Position, leftPalm.Position));
            if (Vector3.Distance(rightPalm.Position, leftPalm.Position) < .1f)
            {
                OnClap(rightPalm.Position);
            }
        }

#if (UNITY_EDITOR)
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Right, out rightPalm))
            {
                OnClap(rightPalm.Position);
            }
        }
        #endif
    }

    void OnClap(Vector3 clapPosition)
    {
        for(int i = 0; i < dandelions.Length; i++)
        {
            if(Vector3.Distance(dandelions[i].flowerCenter.position, clapPosition) < clapRange)
            {
                dandelions[i].Explode(clapPosition, clapRange);
            }
        }

        gameObject.transform.position = clapPosition;

        if (clapWwiseEvent != null)
        {
            clapWwiseEvent.Post(gameObject);
        }
    }
}
