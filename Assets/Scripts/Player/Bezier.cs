using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier
{
    public Vector3[] Points;

    public Bezier()
    {
        Points = new Vector3[4];
    }

    public Bezier(Vector3[] points)
    {
        Points = points;
    }

    public Vector3 StartPosition
    {
        get
        {
            return Points[0];
        }
    }

    public Vector3 EndPosition
    {
        get
        {
            return Points[3];
        }
    }

    public Vector3 GetSegment(float Time)
    {
        Time = Mathf.Clamp01(Time);
        float time = 1 - Time;

        return (time * time * time * Points[0]) 
            + (3 * time * time * Time * Points[1])
            + (3 * time * time * Time * Points[2])
            + (Time * time * Time * Points[3]);
    }

    public Vector3[] GetSegments(int subdivisions)
    {
        Vector3[] segments = new Vector3[subdivisions];

        float time;
        for (int i = 0; i < subdivisions; i++)
        {
            time = (float)i / subdivisions;
            segments[i] = GetSegment(time);
        }

        return segments;
    }
}
