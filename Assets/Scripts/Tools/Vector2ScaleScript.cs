using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Vector2ScaleScript : MonoBehaviour
{
    public GameObject Player;
    [Range(0.5f, 6f)]
    [SerializeField] public float PlayerScale = 1.5f;
    [Range(1f, 12f)]
    [SerializeField] public float PlayerSpeed = 4f;
    public SteamVR_Action_Vector2 ScaleSlider;
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

        if (ScaleSlider.axis.magnitude > 0.1f && PlayerScale <= 6.00f && PlayerScale >= 0f)
        {
            var fromAbs = ScaleSlider.axis.x - -1f;
            var fromMaxAbs = 1f - -1f;

            var normal = fromAbs / fromMaxAbs;

            var toMaxAbs = 6f - 0.5f;
            var toAbs = toMaxAbs * normal;

            var to = toAbs + 0.5f;

            PlayerScale = to;
        }

        if (ScaleReset.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            PlayerScale = 1.5f;
        }

        Debug.Log(ScaleSlider.axis.x);
    }

    /*
    void Upscale()
    {
        if (PlayerScale <= 6.00f)
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
    */

    void Regulatescale()
    {

    }

}
