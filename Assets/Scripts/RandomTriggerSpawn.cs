using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTriggerSpawn : MonoBehaviour
{
    public GameObject TriggerPoint;
    public GameObject MaxPoint;
    public GameObject MinPoint;
    public Vector3 NewRandomPos;
    public float MaxRadius = 15;
    public float MinRadius = 2;
    public float Randomz = 3.1f;

    private void Start()
    {
        ChangePosition();
    }

    public void ChangePosition()
    {
        Vector2 RandomPos = Random.insideUnitCircle * Random.Range(MinRadius, MaxRadius);
        Vector3 newRandomPos = new Vector3(RandomPos.x, Randomz, RandomPos.y);
        TriggerPoint.transform.position = newRandomPos * Random.Range(MinRadius, MaxRadius);
        MaxPoint.transform.position = newRandomPos * MaxRadius;
        MinPoint.transform.position = newRandomPos * MinRadius;
        
    }

}
