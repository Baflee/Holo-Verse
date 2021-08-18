using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Valve.VR;


public class ResetPos : MonoBehaviour
{
    public SteamVR_Action_Boolean PlayerPositionReset;
    public GameObject Spawner;
    public float YRotate;
    public GameObject Player;

    private void Start()
    {
        if(Player == null)
        {
            Player = GameObject.Find("Player");
        }

        Player.transform.position = new Vector3(Spawner.transform.position.x, Spawner.transform.position.y, Spawner.transform.position.z);
        Player.transform.rotation = Quaternion.Euler(0, YRotate, 0);
    }
    void Update()
    {
        if (PlayerPositionReset.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Player.transform.position = new Vector3(Spawner.transform.position.x, Spawner.transform.position.y, Spawner.transform.position.z);
            Player.transform.rotation = Quaternion.Euler(0, YRotate, 0);
        }
    }
}
