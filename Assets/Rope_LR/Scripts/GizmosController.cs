using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GizmosController : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Material material;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void OnMouseDown()
    {
        material.color = Color.red;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseUp()
    {
        material.color = Color.white;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

}
