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
                onClap(rightPalm.Position);
            }
        }

#if (UNITY_EDITOR)
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Right, out rightPalm))
            {
                onClap(rightPalm.Position);
            }
        }
        #endif
    }

    void onClap(Vector3 clapPosition)
    {
        for(int i = 0; i < dandelions.Length; i++)
        {
            if(Vector3.Distance(dandelions[i].flowerCenter.position, clapPosition) < clapRange)
            {
                dandelions[i].explode(clapPosition, clapRange);
            }
        }
    }
}
