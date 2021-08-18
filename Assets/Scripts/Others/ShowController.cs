using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;

public class ShowController : MonoBehaviour
{
    [SerializeField]
    public bool loaded = true;
    private GameObject iconslotright = null;
    private GameObject iconslotleft = null;
    private GameObject controllerleft = null;

    [SerializeField]
    public Material interactmaterial;
    public Material defaultmaterial;

    [SerializeField]
    public GameObject iconmovement;
    private GameObject cloneiconmovement = null;
    public Vector3 iconmovementposition;
    public Vector3 iconmovementscale;

    [SerializeField]
    public GameObject iconteleportation;
    private GameObject cloneiconteleportation = null;
    public Vector3 iconteleportationposition;
    public Vector3 iconteleportationscale;

    [SerializeField]
    public GameObject iconfly;
    private GameObject cloneiconfly = null;
    public Vector3 iconflyposition;
    public Vector3 iconflyscale;

    [SerializeField]
    public GameObject iconscale;
    private GameObject cloneiconscale = null;
    public Vector3 iconscaleposition;
    public Vector3 iconscalescale;

    [SerializeField]
    public GameObject menu;
    public GameObject clonemenu = null;
    public Vector3 menuposition;
    public Vector3 menuscale;

    [SerializeField]
    public PlayerController PlayerController;
    public PlayerFlyingHead PlayerFlyingHead;
    public Teleport Teleport;
    public Vector2ScaleScript Vector2ScaleScript;

    [SerializeField]
    public bool showController = false;
    public bool showIcons = false;
    public float MinShowMenu;
    public float MaxShowMenu;

    private void Start()
    {
        cloneiconscale = GameObject.Instantiate(iconscale);
        cloneiconteleportation = GameObject.Instantiate(iconteleportation);
        cloneiconmovement = GameObject.Instantiate(iconmovement);
        cloneiconfly = GameObject.Instantiate(iconfly);
        clonemenu = GameObject.Instantiate(menu);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (loaded == true && iconslotright && iconslotleft)
        {
            cloneiconmovement.transform.parent = iconslotright.transform;
            cloneiconmovement.transform.localPosition = iconmovementposition;
            cloneiconmovement.transform.localRotation = Quaternion.Euler(84, 0, 0);
            cloneiconmovement.transform.localScale = iconmovementscale;

            cloneiconteleportation.transform.parent = iconslotright.transform;
            cloneiconteleportation.transform.localPosition = iconteleportationposition;
            cloneiconteleportation.transform.localRotation = Quaternion.Euler(90, 0, 0);
            cloneiconteleportation.transform.localScale = iconteleportationscale;

            cloneiconfly.transform.parent = iconslotright.transform;
            cloneiconfly.transform.localPosition = iconflyposition;
            cloneiconfly.transform.localRotation = Quaternion.Euler(90, 0, 0);
            cloneiconfly.transform.localScale = iconflyscale;

            cloneiconscale.transform.parent = iconslotleft.transform;
            cloneiconscale.transform.localPosition = iconscaleposition;
            cloneiconscale.transform.localRotation = Quaternion.Euler(90, 0, 0);
            cloneiconscale.transform.localScale = iconscalescale;

            clonemenu.transform.parent = iconslotleft.transform;
            clonemenu.transform.localPosition = menuposition;
            clonemenu.transform.localRotation = Quaternion.Euler(-90, 180, 0);
            clonemenu.transform.localScale = menuscale;
            loaded = false;
        }

        controllerleft = GameObject.Find("Player/SteamVRObjects/LeftHand");
        iconslotright = GameObject.Find("Player/SteamVRObjects/RightHand/RightRenderModel Slim(Clone)/controller(Clone)/trackpad");
        iconslotleft = GameObject.Find("Player/SteamVRObjects/LeftHand/LeftRenderModel Slim(Clone)/controller(Clone)/trackpad");

        if (iconslotleft && iconslotright && showIcons == true)
        {
            if (PlayerController.movementbool == true)
            {
                iconslotright.GetComponent<Renderer>().material = interactmaterial;
                cloneiconmovement.SetActive(true);
            }
            else if (Teleport.visible == true)
            {
                iconslotright.GetComponent<Renderer>().material = interactmaterial;
                cloneiconteleportation.SetActive(true);
            }
            else if (PlayerFlyingHead.isFlying == true)
            {
                iconslotright.GetComponent<Renderer>().material = interactmaterial;
                cloneiconfly.SetActive(true);
            }
            else
            {
                iconslotright.GetComponent<Renderer>().material = defaultmaterial;
                cloneiconfly.SetActive(false);
                cloneiconteleportation.SetActive(false);
                cloneiconmovement.SetActive(false);
            }

            if (Vector2ScaleScript.ScaleUp == true || Vector2ScaleScript.ScaleDown == true)
            {

                iconslotleft.GetComponent<Renderer>().material = interactmaterial;
                cloneiconscale.SetActive(true);
            }
            else
            {
                iconslotleft.GetComponent<Renderer>().material = defaultmaterial;
                cloneiconscale.SetActive(false);
            }
        }

        if (iconslotleft && iconslotright && controllerleft.transform.eulerAngles.z >= MinShowMenu && controllerleft.transform.eulerAngles.z <= MaxShowMenu)
        {
            clonemenu.SetActive(true);
        }
        else
        {
            clonemenu.SetActive(false);
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
