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
        SceneManager.LoadScene("Holo-Verse", LoadSceneMode.Single);
    }
}
