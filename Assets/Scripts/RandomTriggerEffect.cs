using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTriggerEffect : MonoBehaviour
{
    public RandomTriggerSpawn randomTriggerSpawn;

    // Update is called once per frame
    void ChangeEffect(int effect)
    {
        switch (effect)
        {
            case 5:
                Debug.Log("Why hello there good sir! Let me teach you about Trigonometry!");
                break;
            case 4:
                Debug.Log("Hello and good day!");
                break;
            case 3:
                Debug.Log("Whadya want?");
                break;
            case 2:
                Debug.Log("Grog SMASH!");
                break;
            case 1:
                Debug.Log("Ulg, glib, Pblblblblb");
                break;
            default:
                Debug.Log("Incorrect intelligence level.");
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            randomTriggerSpawn.ChangePosition();
            ChangeEffect(Random.Range(1, 6));
        }
    }
}
