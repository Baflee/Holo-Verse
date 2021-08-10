using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerFlyingHead : MonoBehaviour
{
    public Transform head;
    public Transform distance;
    [Range(0.1f, 1f)]
    [SerializeField] public float Speed = 0.5f;

    //public SteamVR_TrackedObject leftHand;
    //public SteamVR_TrackedObject rightHand;
    public SteamVR_Action_Boolean Flying;

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
            if()
            {

            }
            else
            { 
                Vector3 HeadDir = distance.position - head.position;
                transform.position -= HeadDir * Speed;
            }
        }
    }
}
