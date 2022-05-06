using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_control : MonoBehaviour
{
    public Camera camera;
    private Collider collider;
    private bool mouseDown = false;
    private Material material;
    private Vector3 bias;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        material = GetComponent<Renderer>().material;
    }
    private void OnMouseDown()
    {
        collider.enabled = false;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 currentPos = transform.position;
            Vector3 mousePos = hit.point;
            bias = (currentPos - mousePos) * 1f;
        }
            Debug.Log("Enter");
        mouseDown = true;
        
        material.color = Color.red;
        
    }

    private void OnMouseUp()
    {        
        mouseDown = false;
        collider.enabled = true;
        material.color = Color.white;
    }
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        float drawLength = 50.0f;
        Debug.DrawRay(ray.origin, ray.direction * drawLength, color: Color.green);

        if (mouseDown)  //Input.GetMouseButton(0) && 
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 mousePos = hit.point;
                //Vector3 normal = hit.normal.normalized;
                //Debug.Log($"Normal: {normal}");
                //transform.position = Vector3.MoveTowards(pos, pos + normal, 1.2f);
                Vector3 currentPos = transform.position;
                
                float distance = Vector3.Distance(mousePos, currentPos);
                Debug.Log($"mousePos: {mousePos}");
                Debug.Log($"currrentPos: {currentPos}");
                Debug.Log($"bias: {bias}");
                //transform.position = Vector3.MoveTowards( mousePos, -bias, distance);
                transform.position = mousePos + bias* -1f;
            }
        }

    }
}
