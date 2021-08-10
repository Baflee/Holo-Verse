using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerFlyingHand : MonoBehaviour
{
    public Transform head;
    public SteamVR_TrackedObject leftHand;
    //public SteamVR_TrackedObject rightHand;
    public SteamVR_Action_Boolean Flying;

    [Range(0.1f, 1f)]
    [SerializeField] public float Speed = 0.5f;

    private bool isFlying = false;

    // Update is called once per frame
    void Update()
    {
        if (Flying.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            isFlying = !isFlying;
        }

        if (isFlying)
        {
            Vector3 leftDir = leftHand.transform.position - head.position;
            transform.position += leftDir * Speed;
        }
    }
}
