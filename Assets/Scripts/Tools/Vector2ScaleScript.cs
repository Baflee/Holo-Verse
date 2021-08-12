using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Vector2ScaleScript : MonoBehaviour
{
    public GameObject Player;
    public PlayerController PlayerController;
    public float MaxScale;
    public float MinScale;
    public float MaxPlayerWalkingSpeed;
    public float MinPlayerWalkingSpeed;
    public float MaxPlayerFlyingSpeed;
    public float MinPlayerFlyingSpeed;
    public bool ScaleDown;
    public bool ScaleUp;
    [Range(0.5f, 6f)]
    [SerializeField] public float PlayerScale = 1.5f;
    [Range(4f, 12f)]
    [SerializeField] public float PlayerWalkingSpeed;
    [Range(0.15f, 0.01f)]
    [SerializeField] public float PlayerFlyingSpeed;
    public SteamVR_Action_Vector2 ScaleSlider;
    public SteamVR_Action_Boolean ScaleReset;

    // Update is called once per frame
    void Update()
    {
        Player.transform.localScale = new Vector3(PlayerScale, PlayerScale, PlayerScale);
        WalkingSpeed();
        FlyingSpeed();
        VerifyScaleHUD();
        PlayerController.speed = PlayerWalkingSpeed;

        if (ScaleSlider.axis.magnitude > 0.1f && PlayerScale <= MaxScale && PlayerScale >= MinScale)
        {
            var fromAbs = ScaleSlider.axis.x - -1f;
            var fromMaxAbs = 1f - -1f;

            var normal = fromAbs / fromMaxAbs;

            var toMaxAbs = MaxScale - MinScale;
            var toAbs = toMaxAbs * normal;

            PlayerScale = toAbs + MinScale;
        }

        if (ScaleReset.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            PlayerScale = 1.5f;
        }
    }

    void WalkingSpeed()
    {
        var fromAbs = PlayerScale - MinScale;
        var fromMaxAbs = MaxScale - MinScale;

        var normal = fromAbs / fromMaxAbs;

        var toMaxAbs = MaxPlayerWalkingSpeed - MinPlayerWalkingSpeed;
        var toAbs = toMaxAbs * normal;

        PlayerWalkingSpeed = toAbs + MinPlayerWalkingSpeed;
    }

    void FlyingSpeed()
    {
        var fromAbs = PlayerScale - MinScale;
        var fromMaxAbs = MaxScale - MinScale;

        var normal = fromAbs / fromMaxAbs;

        var toMaxAbs = MaxPlayerFlyingSpeed - MinPlayerFlyingSpeed;
        var toAbs = toMaxAbs * normal;

        PlayerFlyingSpeed = toAbs + MinPlayerFlyingSpeed;
    }

    void VerifyScaleHUD()
    {
        if (ScaleSlider.axis.x < 0f)
        {
            ScaleDown = true;
        }
        else
            ScaleDown = false;

        if (ScaleSlider.axis.x > 0f)
        {
            ScaleUp = true;
        }
        else
            ScaleUp = false;
    }
}


