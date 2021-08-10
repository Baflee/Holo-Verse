using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BooleanScaleScript : MonoBehaviour
{   
    public GameObject Player;
    [Range(0.5f, 6f)]
    [SerializeField] public float PlayerScale = 1.5f;
    [Range(1f, 12f)]
    [SerializeField] public float PlayerSpeed = 4f;
    public SteamVR_Action_Boolean ScaleLeft;
    public SteamVR_Action_Boolean ScaleRight;
    public SteamVR_Action_Boolean ScaleReset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player.transform.localScale = new Vector3(PlayerScale, PlayerScale, PlayerScale);
        PlayerSpeed = PlayerScale * 2f;

        if (ScaleLeft.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Downscale();
        }

        if (ScaleReset.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            PlayerScale = 1.5f;
        }

        if (ScaleRight.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Upscale();
        }
    }

    void Upscale()
    {
        if(PlayerScale <= 6.00f)
        {
            PlayerScale += 0.25f;
        }
        else
        PlayerScale = 6f;
    }

    void Downscale()
    {
        if (PlayerScale >= 0f)
        {
            PlayerScale -= 0.25f;
        }
        else
        PlayerScale = 0f;
    }

}
