using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cryptoterface : MonoBehaviour
{
    public GameObject CameraHolder;
    public GameObject CameraPath;
    public GameObject CameraHeadset;
    public Toggle TogglePath;
    public Toggle ToggleHeadset;
    public GameObject InterfaceCamera;
    public GameObject UnHideButton;
    public Slider SpeedAuto;
    // Start is called before the first frame update

    public void Start()
    {
        TogglePath.isOn = false;
        if (CameraHolder == null)
        {
            CameraHolder = GameObject.Find("/Path/CameraHolder");
        }

        if (CameraPath == null)
        {
            CameraPath = GameObject.Find("/Path/CameraHolder/PathCamera");
            CameraPath.SetActive(false);
        }

        if (CameraHeadset == null)
        {
            CameraHeadset = GameObject.Find("/Player/SteamVRObjects/VRCamera/BackgroundCamera");
        }

        if (TogglePath == null)
        {
            TogglePath = GameObject.Find("PToggle").GetComponent<Toggle>();
        }

        if (ToggleHeadset == null)
        {
            ToggleHeadset = GameObject.Find("HToggle").GetComponent<Toggle>();
        }

        if (InterfaceCamera == null)
        {
            InterfaceCamera = GameObject.Find("Interface Camera");
        }

        if (UnHideButton == null)
        {
            UnHideButton = GameObject.Find("UnHideButton");
        }
    }
    public void Update()
    {
        SetAutoCameraSpeed(SpeedAuto.value);

        if (CameraHeadset == null)
        {
            CameraHeadset = GameObject.Find("BackgroundCamera");
        }

        if (TogglePath == null)
        {
            TogglePath = GameObject.Find("PToggle").GetComponent<Toggle>();
        }

        if (ToggleHeadset == null)
        {
            ToggleHeadset = GameObject.Find("HToggle").GetComponent<Toggle>();
        }

        if (InterfaceCamera == null)
        {
            InterfaceCamera = GameObject.Find("Interface Camera");
        }

        if (UnHideButton == null)
        {
            UnHideButton = GameObject.Find("UnHideButton");
        }
    }

    public void SetCameraPath (bool isCameraPath)
    {
        if (CameraHeadset.activeSelf == true && CameraPath.activeSelf == false)
        {
            CameraPath.SetActive(isCameraPath);
            ToggleHeadset.isOn = false;
        }
        else
        {
            CameraPath.SetActive(isCameraPath);
        }
    }

    public void SetCameraHeadset (bool isCameraHeadset)
    {
        if(CameraPath.activeSelf == true && CameraHeadset.activeSelf == false)
        {
            CameraHeadset.SetActive(isCameraHeadset);
            TogglePath.isOn = false;
        }
        else
        {
            CameraHeadset.SetActive(isCameraHeadset);
        }
        
    }

    public void HideCameraMenu() 
    {
        InterfaceCamera.SetActive(false);
        UnHideButton.SetActive(true);
    }

    public void ShowCameraMenu()
    {
        InterfaceCamera.SetActive(true);
        UnHideButton.SetActive(false);
    }

    public void SetAutoCameraSpeed(float Speed)
    {
        CameraHolder.GetComponent<MoveAround>().speed = Speed;
    }

}
