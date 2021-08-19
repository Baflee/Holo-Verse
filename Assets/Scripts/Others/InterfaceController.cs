using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceController : MonoBehaviour
{
    public void Introduction()
    {
        if (GameObject.Find("IntroductionPlayer") != null)
        {
            Destroy(GameObject.Find("IntroductionPlayer"));
        }
        if (GameObject.Find("Player") != null)
        {
            Destroy(GameObject.Find("Player"));
        }
        SceneManager.LoadScene("Introduction", LoadSceneMode.Single);

    }

    public void Mesopotamien()
    {
        if (GameObject.Find("IntroductionPlayer") != null)
        {
            Destroy(GameObject.Find("IntroductionPlayer"));
        }
        if (GameObject.Find("Player") != null)
        {
            Destroy(GameObject.Find("Player"));
        }
        SceneManager.LoadScene("Mesopotamien", LoadSceneMode.Single);

    }

    public void Warrior()
    {
        SceneManager.LoadScene("Warrior", LoadSceneMode.Single);
        if(GameObject.Find("IntroductionPlayer") != null)
        {
            Destroy(GameObject.Find("IntroductionPlayer"));
        }
    }
}
