using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerFlyingHead : MonoBehaviour
{
    public Transform head;
    public Transform distance;
    public SteamVR_Action_Boolean Flying;
    public Vector2ScaleScript Vector2ScaleScript;

    private bool isFlying = false;

    // Update is called once per frame
    void Update()
    {
        if (Flying.GetStateDown(SteamVR_Input_Sources.RightHand)) 
        {
            //isFlying = !isFlying;
            isFlying = true;
        }

        if (Flying.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            //isFlying = !isFlying;
            isFlying = false;
        }

        if (isFlying)
        {
             Vector3 HeadDir = distance.position - head.position;
             transform.position -= HeadDir * Vector2ScaleScript.PlayerFlyingSpeed;
        }
    }
}
