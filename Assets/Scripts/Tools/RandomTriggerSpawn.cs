using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTriggerSpawn : MonoBehaviour
{
    public GameObject TriggerPoint;
    public GameObject MaxPoint;
    public GameObject MinPoint;
    private Vector3 Circle;
    private Vector3 NewRandomPos;
    public float XRadius;
    public float ZRadius;

    private void Start()
    {
        Circle = Random.insideUnitCircle;
        ChangePosition();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ChangePosition();
        }
    }

    public void ChangePosition()
    {
        Vector2 RandomPos = Circle * Random.Range(-XRadius, XRadius);
        Vector3 newRandomPos = new Vector3(RandomPos.x, 0, Random.Range(-ZRadius, ZRadius));
        TriggerPoint.transform.position = newRandomPos * Random.Range(-XRadius, XRadius);
        MaxPoint.transform.position = newRandomPos * XRadius;
        MinPoint.transform.position = newRandomPos * -XRadius;
        
    }

}
