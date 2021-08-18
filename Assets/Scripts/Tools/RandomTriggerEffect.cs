using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTriggerEffect : MonoBehaviour
{
    public RandomTriggerSpawn randomTriggerSpawn;
    public Animator SculptureAnimation;
    public AudioSource kitAudio;
    public AudioClip firstAudio;
    public AudioClip secondAudio;
    public AudioClip thirdAudio;
    public AudioClip fourAudio;
    public AudioClip fiveAudio;

    // Update is called once per frame
    private void Update()
    {
        if(kitAudio == null)
        {
            kitAudio = GameObject.Find("Player").GetComponent<AudioSource>();
        }
    }

    void ChangeEffect(int effect)
    {
        switch (effect)
        {
            case 5:
                Debug.Log("Why hello there good sir! Let me teach you about Trigonometry!");
                SculptureAnimation.SetBool("Anim1", false);
                SculptureAnimation.SetBool("Anim2", false);
                SculptureAnimation.SetBool("Anim3", false);
                SculptureAnimation.SetBool("Anim4", false);
                SculptureAnimation.SetBool("Anim5", true);
                kitAudio.PlayOneShot(fiveAudio, 0.5F);
                break;
            case 4:
                Debug.Log("Hello and good day!");
                SculptureAnimation.SetBool("Anim1", false);
                SculptureAnimation.SetBool("Anim2", false);
                SculptureAnimation.SetBool("Anim3", false);
                SculptureAnimation.SetBool("Anim4", true);
                SculptureAnimation.SetBool("Anim5", false);
                kitAudio.PlayOneShot(fourAudio, 0.5F);
                break;
            case 3:
                Debug.Log("Whadya want?");
                SculptureAnimation.SetBool("Anim1", false);
                SculptureAnimation.SetBool("Anim2", false);
                SculptureAnimation.SetBool("Anim3", true);
                SculptureAnimation.SetBool("Anim4", false);
                SculptureAnimation.SetBool("Anim5", false);
                kitAudio.PlayOneShot(thirdAudio, 0.5F);
                break;
            case 2:
                Debug.Log("Grog SMASH!");
                SculptureAnimation.SetBool("Anim1", false);
                SculptureAnimation.SetBool("Anim2", true);
                SculptureAnimation.SetBool("Anim3", false);
                SculptureAnimation.SetBool("Anim4", false);
                SculptureAnimation.SetBool("Anim5", false);
                kitAudio.PlayOneShot(secondAudio, 0.5F);
                break;
            case 1:
                Debug.Log("Ulg, glib, Pblblblblb");
                SculptureAnimation.SetBool("Anim1", true);
                SculptureAnimation.SetBool("Anim2", false);
                SculptureAnimation.SetBool("Anim3", false);
                SculptureAnimation.SetBool("Anim4", false);
                SculptureAnimation.SetBool("Anim5", false);
                kitAudio.PlayOneShot(firstAudio, 0.5F);
                break;
            default:
                Debug.Log("Incorrect intelligence level.");
                SculptureAnimation.SetBool("Anim1", true);
                SculptureAnimation.SetBool("Anim2", false);
                SculptureAnimation.SetBool("Anim3", false);
                SculptureAnimation.SetBool("Anim4", false);
                SculptureAnimation.SetBool("Anim5", false);
                kitAudio.PlayOneShot(firstAudio, 0.5F);
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
