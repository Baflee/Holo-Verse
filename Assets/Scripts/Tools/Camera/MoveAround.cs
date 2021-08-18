using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    public float speed = 3f;
    public Transform pathParent;
    Transform targetPoint;
    int index;

    public GameObject splineHolder;

    //Add a Spline Computer component to this object
    private SplineFollower follower;
    bool recalculate = false;
    Vector3 prevPos = new Vector3();
    float prevLen = 0;

    public float AngleMin = 100;
    public float AngleMax = 130;
    public float HorizDistMin = 150;
    public float HorizDistMax = 200;
    public float VertDistMin = 150;
    public float VertDistMax = 200;
    public float YPosition;

    int cleancycle = 0;

    int invVal = 1;

    Vector3 origin;
    void OnDrawGizmos()
    {
        Vector3 from;
        Vector3 to;
        for (int a = 0; a < pathParent.childCount - 1; a++)
        {
            from = pathParent.GetChild(a).position;
            to = pathParent.GetChild(a + 1).position;
            Gizmos.color = new Color(1, 0, 0);
            Gizmos.DrawLine(from, to);
        }
    }
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        int inverse = Random.Range(0, invVal) == 0 ? 1 : -1;
        origin = new Vector3(inverse * Random.Range(HorizDistMin, HorizDistMax), YPosition, inverse * Random.Range(HorizDistMin, HorizDistMax));
        var camera = GetComponent<Camera>();
        transform.position = origin;
        GeneratePath();
    }

    // Update is called once per frame
    void Update()
    {

        if (follower == null)
        {
            //if (cleancycle < 10)
            //    cleancycle++;
            //else
            //{
                GeneratePath();
                cleancycle = 0;
            //}
        }
        else if (follower.result.percent == 1)
        {
            GameObject.Destroy(gameObject.GetComponent<SplineFollower>());
            GameObject.Destroy(splineHolder.GetComponent<SplineComputer>());

            origin = pathParent.GetChild(pathParent.childCount - 1).transform.position;
            foreach (Transform child in pathParent.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            follower = null;
            Debug.Log("End Cycle");
        }
        else
        {
            transform.position = follower.EvaluatePosition(follower.result.percent);
            follower.result.percent += speed * 0.000001f;
        }
        /*
        // transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        //  if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        /*    if (recalculate)
            {
                follower.result.percent = follower.Travel(0, prevLen, Spline.Direction.Forward); ;
                recalculate = false;
            }

            else if (follower.result.percent > 0.5)
            {
                prevPos = follower.result.position;
                prevLen = follower.CalculateLength(0, follower.result.percent);
                recalculate = true;
                index++;
                index %= pathParent.childCount;
                targetPoint = pathParent.GetChild(index);
                GameObject sphere = GetRandomPoint(targetPoint.transform.position, m_fAngleMin, m_fAngleMax, m_fDistMin, m_fDistMax);
                SplinePoint point = new SplinePoint();
                point.position = sphere.transform.position;
                point.normal = Vector3.up;
                point.size = 5f;
                point.color = Color.white;
                spline.ResampleTransform();
                // spline.
                spline.SetPoint(spline.pointCount, point);

                spline.Rebuild();

            }*/

    }

    public GameObject GetRandomPoint(   Vector3 prevPosition, 
                                        float angleMin, float angleMax, 
                                        float horizDistMin, float horizDistMax,
                                        float vertDistMin, float vertDistMax)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.layer = LayerMask.NameToLayer("Path");

        float inverse = Random.Range(0, invVal) == 0 ? 1 : -0.3f;
        sphere.transform.position = Quaternion.Euler(0, inverse * Random.Range(angleMin, angleMax), 0) * prevPosition;

        inverse = Random.Range(0, invVal) == 0 ? 1 : -1;
        var planeVector = sphere.transform.position;
        planeVector.Set(planeVector.x, 0, planeVector.z);
        planeVector = inverse * Random.Range(horizDistMin, horizDistMax) * planeVector.normalized;

        inverse = Random.Range(0, 2) == 0 ? 1 : -1;
        sphere.transform.position = new Vector3(planeVector.x, Random.Range(vertDistMin, vertDistMax),
            planeVector.z);

        sphere.transform.parent = pathParent.transform;
        return sphere;
    }

    private void GeneratePath()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.layer = LayerMask.NameToLayer("Path");

        sphere.transform.position = origin;
        sphere.transform.parent = pathParent.transform;

        index = 0;

        for (int i = 0; i < 30; i++)
        {
            sphere = GetRandomPoint(pathParent.GetChild(i).transform.position, 
                                    AngleMin, AngleMax, 
                                    HorizDistMin, HorizDistMax,
                                    VertDistMin, VertDistMax);
            sphere.transform.parent = pathParent.transform;
        }

        follower = gameObject.AddComponent<SplineFollower>();
        follower.followSpeed = speed;
        follower.computer = splineHolder.AddComponent<SplineComputer>();
        follower.computer.type = Spline.Type.BSpline;
        follower.autoFollow = false;
        //Create a new array of spline points
        SplinePoint[] points = new SplinePoint[pathParent.childCount];
        //Set each point's properties
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = new SplinePoint();
            points[i].position = pathParent.GetChild(i).transform.position;
            points[i].normal = Vector3.up;
            points[i].size = 5f;
            points[i].color = Color.white;
        }
        //Write the points to the spline
        follower.computer.SetPoints(points);
    }
}
