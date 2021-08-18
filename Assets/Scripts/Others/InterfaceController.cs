using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceController : MonoBehaviour
{
    public void Introduction()
    {
        SceneManager.LoadScene("Introduction", LoadSceneMode.Single);
    }

    public void Mesopotamien()
    {
        SceneManager.LoadScene("Mesopotamien", LoadSceneMode.Single);
    }

    public void Warrior()
    {
        SceneManager.LoadScene("Warrior", LoadSceneMode.Single);
    }
}
