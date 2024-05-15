using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class InputHandler : MonoBehaviour
{
    #region Variables

    private Camera _mainCamera;
    private LineRenderer lineRenderer;
    private GameObject firstObject;
    private GameObject secondObject;
    public GameObject newString;
    public Material lineMaterial; // Material for the line
    private EdgeCollider2D edgeCollider;
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
            if (click && lineRenderer != null)
            {
                lineRenderer.SetPosition(0, firstObject.transform.position);
                lineRenderer.SetPosition(1, secondObject.transform.position);
                click = false;
            }

        }
    }

    private void OnClick()
    {
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));


        if (rayHit.collider.gameObject.tag == "Town" && isDrawing == false)
        {
            isDrawing = true;
            newString = Instantiate(newString, new Vector3(0, 0, 0), Quaternion.identity);         
            lineRenderer = newString.GetComponent<LineRenderer>();
            firstObject = rayHit.collider.gameObject;
            
        }
        else
        {
            if (rayHit.collider.gameObject.tag == "Town")
            {
                secondObject = rayHit.collider.gameObject;
                edgeCollider = newString.GetComponent<EdgeCollider2D>();
                edgeCollider.points = new Vector2[] { firstObject.transform.position, secondObject.transform.position };
                isDrawing = false;
                click = true;
            }

        }
        
        Debug.Log(rayHit.collider.gameObject.name);
    }

    private void OnRightClick()
    {
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (rayHit.collider.gameObject.tag == "String")
        {
           Destroy(rayHit.collider.gameObject);
        }

        lineRenderer = new LineRenderer();
    }
}