using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;


public class RayInteractorIntro : MonoBehaviour
{
    public static GameObject currentObject;
    public SteamVR_Action_Boolean InteractUI;
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
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            int id = hit.collider.gameObject.GetInstanceID();

            if (currentID != id)
            {
                SteamVR_LaserPointer Laser = GetComponent<SteamVR_LaserPointer>();
                currentID = id;
                currentObject = hit.collider.gameObject;

                string tag = currentObject.tag;

                if (tag == "Button")
                {
                    Button Button = currentObject.GetComponent<Button>();
                    if (InteractUI.GetStateDown(SteamVR_Input_Sources.RightHand))
                    {
                        Button.onClick.Invoke();
                    }
                }
            }
        }
    }
}