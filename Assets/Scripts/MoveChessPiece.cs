using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChessPiece : MonoBehaviour
{
    private Color originalColor;
    private Texture MainTexture;
    private bool dragging = false;

    [SerializeField] float gridSnapSize = 0.112f;
    [SerializeField] float fixedHieght = 0.74f;
    private static bool initialized;


    void Start()
    {
        if (!initialized)
        {
            initialized = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            Transform draggingObject = transform;
            Plane plane = new Plane(Vector3.up, Vector3.up * fixedHieght); // ground plane
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance; // the distance from the ray origin to the ray intersection of the plane

            if (plane.Raycast(ray, out distance))
            {
                draggingObject.position = ray.GetPoint(distance); // distance along the ray
                if (name.Contains("Black"))
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
                }
                //section below is for snapping to block
                //Vector3 rayPoint = ray.GetPoint(distance);
                //Vector3 snappedRayPoint = rayPoint;
                //snappedRayPoint.x = (Mathf.RoundToInt(rayPoint.x / gridSnapSize) * gridSnapSize);
                //snappedRayPoint.z = (Mathf.RoundToInt(rayPoint.z / gridSnapSize) * gridSnapSize);
                //draggingObject.position = snappedRayPoint;
            }
        }
    }

    void OnMouseDown()
    {
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }
    void OnMouseEnter()
    {
        originalColor = GetComponent<Renderer>().material.color;
        MainTexture = GetComponent<Renderer>().material.mainTexture;
        GetComponent<Renderer>().material.mainTexture = null;

        if (GetComponent<Renderer>().name.Contains("White"))
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
        else if (GetComponent<Renderer>().name.Contains("Black"))
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.mainTexture = MainTexture;
        GetComponent<Renderer>().material.color = originalColor;
    }
}
