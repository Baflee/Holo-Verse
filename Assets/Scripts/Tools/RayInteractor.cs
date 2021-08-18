using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;


public class RayInteractor : MonoBehaviour
{
    public static GameObject currentObject;
    private GameObject TeleportComponent;
    public GameObject Ray;
    public SteamVR_Action_Boolean InteractUI;
    public ShowController ShowController;
    int currentID;
    // Start is called before the first frame update
    void Start()
    {
        currentObject = null;
        currentID = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(ShowController.loaded == true)
        {
            Ray = GameObject.Find("Player/SteamVRObjects/RightHand/PointerSteam/New Game Object/Cube");
        }

        if(TeleportComponent == null)
        {
            TeleportComponent = GameObject.Find("Teleporting");
        }
        
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            int id = hit.collider.gameObject.GetInstanceID();

            if(currentID != id)
            {
                currentID = id;
                currentObject = hit.collider.gameObject;

                string tag = currentObject.tag;
                if (tag == "UI")
                    TeleportComponent.SetActive(false);

                if (tag == "Button")
                {
                    TeleportComponent.SetActive(false);
                    Button Button = currentObject.GetComponent<Button>();
                    if (InteractUI.GetStateDown(SteamVR_Input_Sources.RightHand))
                    {
                        TeleportComponent.SetActive(true);
                        Button.onClick.Invoke();
                    }
                }

                SteamVR_LaserPointer Laser = GetComponent<SteamVR_LaserPointer>();

                if (ShowController.clonemenu.activeSelf)
                {
                    Laser.enabled = true;
                    Ray.SetActive(true);
                    TeleportComponent.SetActive(false);
                }
                else if (!ShowController.clonemenu.activeSelf)
                {
                    Laser.enabled = false;
                    Ray.SetActive(false);
                    TeleportComponent.SetActive(true);
                }
            }
        }    
    }
}
