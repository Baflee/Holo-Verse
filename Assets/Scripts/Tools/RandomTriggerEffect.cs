using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTriggerEffect : MonoBehaviour
{
    public RandomTriggerSpawn randomTriggerSpawn;
    public GameObject Spawner;
    public Material Mat1;
    public Material Mat2;
    public Material Mat3;
    public Material Mat4;
    public Material Mat5;

    // Update is called once per frame
    void ChangeEffect(int effect)
    {
        switch (effect)
        {
            case 5:
                Debug.Log("Why hello there good sir! Let me teach you about Trigonometry!");
                //Spawner.GetComponent<MeshRenderer>().material = Mat1;
                break;
            case 4:
                Debug.Log("Hello and good day!");
                //Spawner.GetComponent<MeshRenderer>().material = Mat2;
                break;
            case 3:
                Debug.Log("Whadya want?");
                //Spawner.GetComponent<MeshRenderer>().material = Mat3;
                break;
            case 2:
                Debug.Log("Grog SMASH!");
                //Spawner.GetComponent<MeshRenderer>().material = Mat4;
                break;
            case 1:
                Debug.Log("Ulg, glib, Pblblblblb");
                //Spawner.GetComponent<MeshRenderer>().material = Mat5;
                break;
            default:
                Debug.Log("Incorrect intelligence level.");
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            randomTriggerSpawn.ChangePosition();
            ChangeEffect(Random.Range(1, 6));
        }
    }
}
