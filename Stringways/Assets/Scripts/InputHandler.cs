using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class InputHandler : MonoBehaviour
{
    #region Variables

    private Camera _mainCamera;
    public LineRenderer lineRenderer;
    public GameObject firstObject;
    public GameObject secondObject;
    public GameObject newString;
    public Material lineMaterial; // Material for the line
    public float lineWidth = 0.1f; // Width of the line
    private bool isDrawing = false;
    private bool click = false;
    #endregion

    void Start()
    {
        _mainCamera = Camera.main;
        lineRenderer.positionCount = 2;
        Instantiate(newString, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Update()
    {

        if (isDrawing)
        {
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, firstObject.transform.position);
            lineRenderer.SetPosition(1, cursorPosition);
        }
        else
        {
            if (click)
            {
                lineRenderer.SetPosition(0, firstObject.transform.position);
                lineRenderer.SetPosition(1, secondObject.transform.position);
            }

        }
    }

    private void OnClick()
    {
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));


        if (rayHit.collider.gameObject.tag == "Town" && isDrawing == false)
        {
            isDrawing = true;
            GameObject line = new GameObject("Line"); // Create a new GameObject for the line
            lineRenderer = line.AddComponent<LineRenderer>(); // Add LineRenderer component
            lineRenderer.material = lineMaterial; // Set material
            lineRenderer.startWidth = lineWidth; // Set start width
            lineRenderer.endWidth = lineWidth; // Set end width
            firstObject = rayHit.collider.gameObject;
        }
        else
        {
            if (rayHit.collider.gameObject.tag == "Town")
            {
                secondObject = rayHit.collider.gameObject;
                isDrawing = false;
            }

        }
        click = true;
        Debug.Log(rayHit.collider.gameObject.name);
    }

    private void OnRightClick()
    {
        // Create a ray from the camera to the mouse position
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        //RaycastHit hit;

        // Check if the object hit by the ray has a LineRenderer component
        LineRenderer lineRenderer = rayHit.collider.gameObject.GetComponent<LineRenderer>();
        if (lineRenderer != null)
        {
            // If so, destroy the object
            Destroy(rayHit.collider.gameObject);
        }
        Debug.Log("Right click");
    }
}