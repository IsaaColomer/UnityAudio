using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverScript : MonoBehaviour
{
    public Transform[] waypoints;
    private Vector3[] waypointsVector;
    public Transform player;
    private Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        waypointsVector = new Vector3[waypoints.Length];
        for(int i = 0; i < waypoints.Length; i++)
        {
            waypointsVector[i] = waypoints[i].transform.position;
        }
        trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        System.Array.Sort<Vector3>(waypointsVector, delegate(Vector3 way1, Vector3 way2) {
            return Vector3.Distance(way1, player.position).CompareTo(Vector3.Distance(way2, player.position));
        });

        if(waypoints.Length != 0)
        {
            Vector3 closest = ClosestPointOnLine(waypointsVector[0], waypointsVector[1], player.position);
            trans.position = Vector3.Lerp(trans.position, closest, Time.deltaTime * 2); 
        }
    }

    Vector3 ClosestPointOnLine(Vector3 vA, Vector3 vB, Vector3 vPoint)
    {
        var vVector1 = vPoint - vA;
        var vVector2 = (vB - vA).normalized;
 
        var d = Vector3.Distance(vA, vB);
        var t = Vector3.Dot(vVector2, vVector1);
 
        if (t <= 0)
            return vA;
 
        if (t >= d)
            return vB;
 
        var vVector3 = vVector2 * t;
 
        var vClosestPoint = vA + vVector3;
 
        return vClosestPoint;
    }
}
