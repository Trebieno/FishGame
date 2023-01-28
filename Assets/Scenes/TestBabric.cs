using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TestBabric : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _maxDistanse, _minDistanse;
    [SerializeField] private float _kof;
    private LineRenderer _line;
    

    const int maxIterations = 100;
    const float minAccenptableDst = 0.01f;

    private void Start() 
    {
        _line = GetComponent<LineRenderer>();
    }

    private Vector3[] GetPoints(LineRenderer line)
    {
        List<Vector3> points = new List<Vector3>();
        int count = line.positionCount;

        for (int i = 0; i < count; i++)
        {
            points.Add(line.GetPosition(i));            
        }
        return points.ToArray();
    }

    int prevCount = 0;
    float prevDis = 0;
    private void Update() 
    {
        if(_line.positionCount == 0)
            return;
        
        var dis = Vector2.Distance(_line.GetPosition(0), _target.position);

        
        if(_line.positionCount != prevCount)
        {
            var points = GetPoints(_line);

            var count1 = points[0].magnitude * points.Length;
            var count2 = points[0].magnitude * prevCount;

            var ads = Mathf.Abs(count1 - count2);

            var d = ads / prevCount;

            for (int i = 1; i < points.Length; i++)
            {
                points[i].x = points[i-1].x + _kof / Mathf.Sqrt(points[i].x * points[i-1].x + points[i].y * points[i-1].y) * d;
                points[i].y = points[i-1].y +  _kof / Mathf.Sqrt(points[i].x * points[i-1].x + points[i].y * points[i-1].y) * d;
            }
            _line.SetPositions(points);
        }

        
        // if(dis != prevDis)
        // {
        //     _line.positionCount = (int)dis;
        // }       

        if(_target != null && _line.positionCount >= 1)
            Solve(GetPoints(_line), _target.position);

        prevCount = _line.positionCount;
        prevDis = dis;
    }

    public void Solve(Vector3[] points, Vector3 target)
    {
        Vector3 origin = points[0];
        float[] segmentLengths = new float[points.Length - 1];
        for (int i = 0; i < points.Length - 1; i++)
        {
                segmentLengths[i] = (points[i + 1] - points[i]).magnitude;
        }

        for (int iteration = 0; iteration < maxIterations; iteration++)
        {
            bool startingFromTarget = iteration % 2 == 0;
            Array.Reverse(points);
            Array.Reverse(segmentLengths);
            points[0] = (startingFromTarget) ? target : origin;

            for (int i = 1; i < points.Length; i++)
            {
                Vector3 dir = (points[i] - points[i-1]).normalized;
                points[i] = points[i-1] + dir * segmentLengths[i-1];        
            }
            
            float dstToTarget = (points[points.Length - 1] - target).sqrMagnitude;
            _line.SetPositions(points);
            
            if(!startingFromTarget && dstToTarget <= minAccenptableDst)
                return;
                
        }
    }

}
