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
    public Material lineMaterial; // Material for the line
    public float lineWidth = 0.1f; // Width of the line
    private bool isDrawing = false;
    private bool click = false;
    #endregion

    private void Awake()
    {
        _mainCamera = Camera.main;
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
      
        if(isDrawing)
        {
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, firstObject.transform.position);
            lineRenderer.SetPosition(1, cursorPosition);
        }
        else
        {
            if(click)
            {
                lineRenderer.SetPosition(0, firstObject.transform.position);
                lineRenderer.SetPosition(1, secondObject.transform.position);
            }
            
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;


        
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;
        

        if(rayHit.collider.gameObject.tag == "Town" && isDrawing ==false)
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
            if(rayHit.collider.gameObject.tag == "Town")
            {
                secondObject = rayHit.collider.gameObject;
                isDrawing = false;
            }
            
        }
        click = true;
        Debug.Log(rayHit.collider.gameObject.name);
    }
}