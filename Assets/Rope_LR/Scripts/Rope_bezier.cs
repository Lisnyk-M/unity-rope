using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope_bezier : MonoBehaviour
{
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    public LineRenderer lineRenderer;

    public Vector3[] SetPoints(int count)
    {
        Vector3[] points = new Vector3[count];
        float dt = 1f / (count - 1);

        for (int i = 0; i < count; i++)
        {
            points[i] = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, dt * i);            
        }

        return points;
    }

    void Start()
    {
        SetPoints(20);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 20;
    }

    void Update()
    {
        lineRenderer.SetPositions(SetPoints(20));
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
