using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomShader : MonoBehaviour
{
    /// <summary>
    /// The material the mesh will use at start
    /// </summary>
    public Color startColor;

    /// <summary>
    /// The material the mesh will transition to
    /// </summary>
    public Color endColor;

    /// <summary>
    /// The hardness of the transition. The higher the value, the smaller the transition area.
    /// </summary>
    public float transitionSharpness;

    /// <summary>
    /// The position of the middle point of the color transition. 0 is very bottom, 1 is very top
    /// </summary>
    public float transitionPos;

    /// <summary>
    /// The position the transitionPos is moving towards. If this is not equal transitionPos, transitionPos will be updated
    /// </summary>
    float targetPos;

    /// <summary>
    /// Is true when the TransitionPos is supposed to be moved next frame
    /// </summary>
    bool moveTransitionPos;

    /// <summary>
    /// The speed at which the transitionPos is moved
    /// </summary>
    public float transitionSpeed;

    /// <summary>
    /// how much the transition will move when MoveTransition() is called
    /// </summary>
    public float transitionStepSize;

    /// <summary>
    /// is true when the color of the ushroom has wholly changed, i.e. transitionPos >= 1
    /// </summary>
    private bool transitionCompleted;
    public bool TransitionCompleted { get => transitionCompleted; }

    /// <summary>
    /// The objects mesh
    /// </summary>
    Mesh mesh;
    
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transitionPos;
        transitionCompleted = false;
        moveTransitionPos = false;
        mesh = GetComponent<MeshFilter>().mesh;
        UpdateColorTransition();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveTransitionPos)
        {
            transitionPos += Time.deltaTime * transitionSpeed * 0.1f;
            UpdateColorTransition();
            if (transitionPos >= targetPos)
            {
                moveTransitionPos = false;
                if (transitionPos >= 1) transitionCompleted = true;
            }
        }
    }

    // <SetTransitionPos>
    /// <summary>
    /// Sets a new Position for the color transition
    /// </summary>
    /// <param name="newPos">The new color transition position</param>
    public void MoveTransition()
    {
        if (!transitionCompleted)
        {
            targetPos = transitionPos + transitionStepSize;
            moveTransitionPos = true;
        }
    }

    // <UpdateColorTransition>
    /// <summary>
    /// updates the colors of the mesh
    /// </summary>
    void UpdateColorTransition()
    {        
        Vector2[] uv = mesh.uv;
        Color[] colors = new Color[uv.Length];

        for (int i = 0; i < uv.Length; i++)
        {
            colors[i] = Color.Lerp(endColor, startColor, uv[i].y * transitionSharpness - transitionSharpness * transitionPos + 0.5f);
        }
        mesh.colors = colors;
    }
}
