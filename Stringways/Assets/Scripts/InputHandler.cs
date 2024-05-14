using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class InputHandler : MonoBehaviour
{
    #region Variables

    private Camera _mainCamera;
    public LineRenderer lineRenderer;
    private GameObject firstObject;
    private GameObject secondObject;
    public GameObject newString;
    public Material lineMaterial; // Material for the line
    public float lineWidth = 0.1f; // Width of the line
    private bool isDrawing = false;
    private bool click = false;
    private double limeStringRemaining = 9.0f;
    private double pinkStringRemaining = 9.0f;
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
            GameObject newPath = Instantiate(newString, new Vector3(0, 0, 0), Quaternion.identity);         
            lineRenderer = newPath.GetComponent<LineRenderer>();
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

        if (!rayHit)
            return;

        if (rayHit.collider.gameObject.tag == "String")
        {
            Destroy(rayHit.collider.gameObject);
        }
        Debug.Log("Right click");
    }
}