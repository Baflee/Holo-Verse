using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTeleporter : MonoBehaviour
{
    public GameObject Teleporter;
    void Start()
    {
        Teleporter.SetActive(true);
    }

}
