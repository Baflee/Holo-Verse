using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ShowController : MonoBehaviour
{
    private GameObject iconslotright = null;
    private GameObject iconslotleft = null;
    public Material iconmovement;
    public Material iconteleportation;
    public Material iconscaleup;
    public Material iconscaledown;
    public Material iconfly;
    public Material defaultmaterial;
    public PlayerController PlayerController;
    public PlayerFlyingHead PlayerFlyingHead;
    public Teleport Teleport;
    public Vector2ScaleScript Vector2ScaleScript;
    public bool showController = false;
    public bool showIcons = false;

    // Update is called once per frame
    void Update()
    {
        iconslotright = GameObject.Find("Player/SteamVRObjects/RightHand/RightRenderModel Slim(Clone)/controller(Clone)/trackpad");
        iconslotleft = GameObject.Find("Player/SteamVRObjects/LeftHand/LeftRenderModel Slim(Clone)/controller(Clone)/trackpad");

        if(iconslotleft && iconslotright && showIcons == true)
        {
            if (PlayerController.movementbool == true)
            {
                iconslotright.GetComponent<Renderer>().material = iconmovement;
            }
            else if (Teleport.visible == true)
            {
                iconslotright.GetComponent<Renderer>().material = iconteleportation;
            }
            else if (PlayerFlyingHead.isFlying == true)
            {
                iconslotright.GetComponent<Renderer>().material = iconfly;
            }
            else
            {
                iconslotright.GetComponent<Renderer>().material = defaultmaterial;
            }

            if (Vector2ScaleScript.ScaleUp == true)
            {
                iconslotleft.GetComponent<Renderer>().material = iconscaleup;
            }
            else if (Vector2ScaleScript.ScaleDown == true)
            {
                iconslotleft.GetComponent<Renderer>().material = iconscaledown;
            }
            else
            {
                iconslotleft.GetComponent<Renderer>().material = defaultmaterial;
            }
        }

        foreach (var hand in Player.instance.hands)
        {
            if (showController)
            {
                hand.ShowController();
            }
            else
            {
                hand.HideController();
            }
        }
    }
}
