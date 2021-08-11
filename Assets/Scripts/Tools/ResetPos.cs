using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ResetPos : MonoBehaviour
{

    public GameObject Player;
    public SteamVR_Action_Boolean PlayerPositionReset;
    public Transform Position1;
    public float YRotate;

    private void Start()
    {
        Player.transform.position = new Vector3(Position1.position.x, Position1.position.y, Position1.position.z);
        Player.transform.rotation = Quaternion.Euler(0, YRotate, 0);
    }
    void Update()
    {
        if (PlayerPositionReset.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Player.transform.position = new Vector3(Position1.position.x, Position1.position.y, Position1.position.z);
            Player.transform.rotation = Quaternion.Euler(0, YRotate, 0);
        }
    }
}
