using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using TMPro;
using System.Drawing;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class InputHandler : MonoBehaviour
{
    #region Variables

    private Camera _mainCamera;
    private LineRenderer lineRenderer;
    private GameObject firstObject;
    private GameObject secondObject;
    public GameObject newString;
    private EdgeCollider2D edgeCollider;
    private bool isDrawing = false;
    private bool click = false;
    public static double limeStringRemaining;
    public static double pinkStringRemaining = 900.0f;
    public TMP_Text limeMessageText;
    public TMP_Text townsConnectedText;
    public TMP_Text invalidPathwaysText;
    public int numberTownsVisited;
    public Button finishButton;
    public static int numberTownsMissed;
    public static int numberNullPathways;
    public static int totalScore;

    // Vector2 arrayList of all pairs of points containing all the pathways that the player creates for Scenario1
    private List<Vector2> pathwaysScenario1 = new List<Vector2>();

    // Vector2 array of all pairs of points representing all the existing pathways
    #region Existing Pathways
    public Vector2[] existingPathways = new Vector2[]
    {
            new Vector2(0, 0), new Vector2(6, 1),
            new Vector2(0, 0), new Vector2(1, 1),
            new Vector2(0, 0), new Vector2(1, 2),
            new Vector2(0, 0), new Vector2(1, 4),
            new Vector2(0, 0), new Vector2(0, 3),
            new Vector2(0, 3), new Vector2(1, 1),
            new Vector2(0, 4), new Vector2(2, 2),
            new Vector2(0, 4), new Vector2(2, 3),
            new Vector2(0, 4), new Vector2(2, 5),
            new Vector2(0, 4), new Vector2(0, 5),
            new Vector2(0, 5), new Vector2(4, 3),
            new Vector2(0, 5), new Vector2(2, 5),
            new Vector2(0, 5), new Vector2(1, 7),
            new Vector2(0, 8), new Vector2(1, 7),
            new Vector2(0, 8), new Vector2(4, 7),
            new Vector2(0, 8), new Vector2(2, 10),
            new Vector2(0, 9), new Vector2(1, 7),
            new Vector2(0, 9), new Vector2(5, 7),
            new Vector2(0, 9), new Vector2(4, 12),
            new Vector2(0, 9), new Vector2(3, 13),
            new Vector2(0, 9), new Vector2(2, 14),
            new Vector2(0, 9), new Vector2(1, 12),
            new Vector2(0, 13), new Vector2(2, 10),
            new Vector2(0, 13), new Vector2(1, 12),
            new Vector2(0, 13), new Vector2(3, 12),
            new Vector2(0, 13), new Vector2(4, 12),
            new Vector2(0, 13), new Vector2(2, 14),

            new Vector2(1, 1), new Vector2(1, 2),
            new Vector2(1, 1), new Vector2(3, 1),
            new Vector2(1, 1), new Vector2(2, 2),
            new Vector2(1, 1), new Vector2(2, 3),
            new Vector2(1, 2), new Vector2(2, 5),
            new Vector2(1, 4), new Vector2(2, 2),
            new Vector2(1, 7), new Vector2(2, 5),
            new Vector2(1, 7), new Vector2(4, 4),
            new Vector2(1, 7), new Vector2(4, 9),
            new Vector2(1, 7), new Vector2(2, 10),
            new Vector2(1, 12), new Vector2(2, 10),
            new Vector2(1, 12), new Vector2(3, 12),
            new Vector2(1, 12), new Vector2(3, 13),

            new Vector2(2, 2), new Vector2(3, 1),
            new Vector2(2, 3), new Vector2(2, 2),
            new Vector2(2, 3), new Vector2(3, 1),
            new Vector2(2, 3), new Vector2(4, 4),
            new Vector2(2, 5), new Vector2(2, 3),
            new Vector2(2, 5), new Vector2(3, 1),
            new Vector2(2, 5), new Vector2(4, 3),
            new Vector2(2, 5), new Vector2(4, 4),
            new Vector2(2, 5), new Vector2(5, 5),
            new Vector2(2, 5), new Vector2(4, 7),
            new Vector2(2, 10), new Vector2(4, 7),
            new Vector2(2, 10), new Vector2(4, 9),
            new Vector2(2, 10), new Vector2(3, 11),
            new Vector2(2, 10), new Vector2(3, 12),
            new Vector2(2, 10), new Vector2(3, 13),
            new Vector2(2, 14), new Vector2(2, 10),
            new Vector2(2, 14), new Vector2(3, 13),
            new Vector2(2, 14), new Vector2(6, 12),
            new Vector2(2, 14), new Vector2(5, 14),

            new Vector2(3, 1), new Vector2(6, 1),
            new Vector2(3, 1), new Vector2(4, 3),
            new Vector2(3, 1), new Vector2(4, 4),
            new Vector2(3, 11), new Vector2(4, 12),
            new Vector2(3, 12), new Vector2(4, 12),
            new Vector2(3, 12), new Vector2(7, 14),
            new Vector2(3, 13), new Vector2(6, 12),
            new Vector2(3, 13), new Vector2(5, 14),

            new Vector2(4, 3), new Vector2(6, 1),
            new Vector2(4, 3), new Vector2(5, 5),
            new Vector2(4, 4), new Vector2(6, 2),
            new Vector2(4, 4), new Vector2(5, 7),
            new Vector2(4, 7), new Vector2(4, 4),
            new Vector2(4, 7), new Vector2(5, 5),
            new Vector2(4, 7), new Vector2(5, 7),
            new Vector2(4, 7), new Vector2(7, 10),
            new Vector2(4, 9), new Vector2(5, 7),
            new Vector2(4, 9), new Vector2(6, 8),
            new Vector2(4, 9), new Vector2(7, 10),
            new Vector2(4, 12), new Vector2(8, 10),
            new Vector2(4, 12), new Vector2(6, 12),

            new Vector2(5, 5), new Vector2(6, 1),
            new Vector2(5, 5), new Vector2(6, 2),
            new Vector2(5, 5), new Vector2(7, 4),
            new Vector2(5, 7), new Vector2(5, 5),
            new Vector2(5, 7), new Vector2(7, 4),
            new Vector2(5, 7), new Vector2(6, 8),
            new Vector2(5, 14), new Vector2(6, 12),
            new Vector2(5, 14), new Vector2(7, 13),

            new Vector2(6, 1), new Vector2(10, 2),
            new Vector2(6, 2), new Vector2(10, 2),
            new Vector2(6, 2), new Vector2(7, 4),
            new Vector2(6, 8), new Vector2(9, 9),
            new Vector2(6, 8), new Vector2(7, 10),
            new Vector2(6, 12), new Vector2(8, 10),
            new Vector2(6, 12), new Vector2(10, 11),
            new Vector2(6, 12), new Vector2(11, 13),
            new Vector2(6, 12), new Vector2(7, 13),
            new Vector2(6, 12), new Vector2(7, 14),

            new Vector2(7, 1), new Vector2(9, 0),
            new Vector2(7, 1), new Vector2(10, 2),
            new Vector2(7, 4), new Vector2(9, 0),
            new Vector2(7, 4), new Vector2(10, 2),
            new Vector2(7, 4), new Vector2(11, 2),
            new Vector2(7, 4), new Vector2(8, 5),
            new Vector2(7, 10), new Vector2(8, 5),
            new Vector2(7, 10), new Vector2(9, 5),
            new Vector2(7, 10), new Vector2(10, 7),
            new Vector2(7, 10), new Vector2(8, 7),
            new Vector2(7, 13), new Vector2(10, 12),
            new Vector2(7, 13), new Vector2(8, 14),
            new Vector2(7, 14), new Vector2(10, 11),
            new Vector2(7, 14), new Vector2(11, 11),
            new Vector2(7, 14), new Vector2(12, 11),
            new Vector2(7, 14), new Vector2(10, 12),
            new Vector2(7, 14), new Vector2(11, 13),

            new Vector2(8, 5), new Vector2(9, 0),
            new Vector2(8, 5), new Vector2(10, 2),
            new Vector2(8, 5), new Vector2(10, 3),
            new Vector2(8, 5), new Vector2(9, 5),
            new Vector2(8, 10), new Vector2(9, 9),
            new Vector2(8, 10), new Vector2(10, 9),
            new Vector2(8, 10), new Vector2(12, 11),
            new Vector2(8, 10), new Vector2(10, 11),
            new Vector2(8, 10), new Vector2(10, 11),
            new Vector2(8, 14), new Vector2(10, 11),
            new Vector2(8, 14), new Vector2(10, 12),
            new Vector2(8, 14), new Vector2(14, 13),

            new Vector2(9, 0), new Vector2(12, 1),
            new Vector2(9, 0), new Vector2(11, 2),
            new Vector2(9, 0), new Vector2(10, 2),
            new Vector2(9, 0), new Vector2(10, 3),
            new Vector2(9, 5), new Vector2(10, 2),
            new Vector2(9, 5), new Vector2(11, 2),
            new Vector2(9, 5), new Vector2(11, 4),
            new Vector2(9, 5), new Vector2(11, 8),
            new Vector2(9, 5), new Vector2(10, 7),
            new Vector2(9, 5), new Vector2(10, 9),
            new Vector2(9, 9), new Vector2(9, 5),
            new Vector2(9, 9), new Vector2(10, 9),
            new Vector2(9, 9), new Vector2(11, 11),
            new Vector2(9, 9), new Vector2(10, 11),
            new Vector2(9, 9), new Vector2(10, 7),

            new Vector2(10, 2), new Vector2(11, 2),
            new Vector2(10, 2), new Vector2(12, 1),
            new Vector2(10, 3), new Vector2(11, 2),
            new Vector2(10, 7), new Vector2(11, 4),
            new Vector2(10, 7), new Vector2(11, 8),
            new Vector2(10, 9), new Vector2(10, 7),
            new Vector2(10, 9), new Vector2(11, 8),
            new Vector2(10, 9), new Vector2(12, 11),
            new Vector2(10, 9), new Vector2(11, 11),
            new Vector2(10, 11), new Vector2(10, 9),
            new Vector2(10, 11), new Vector2(13, 14),
            new Vector2(10, 12), new Vector2(11, 11),
            new Vector2(10, 12), new Vector2(12, 11),
            new Vector2(10, 12), new Vector2(14, 13),

            new Vector2(11, 2), new Vector2(12, 1),
            new Vector2(11, 4), new Vector2(11, 2),
            new Vector2(11, 4), new Vector2(12, 1),
            new Vector2(11, 8), new Vector2(11, 4),
            new Vector2(11, 11), new Vector2(13, 14),
            new Vector2(11, 13), new Vector2(11, 11),
            new Vector2(11, 13), new Vector2(12, 11),
            new Vector2(11, 13), new Vector2(16, 11),
            new Vector2(11, 13), new Vector2(14, 12),
            new Vector2(11, 13), new Vector2(14, 13),

            new Vector2(12, 1), new Vector2(17, 0),
            new Vector2(12, 1), new Vector2(15, 1),
            new Vector2(12, 1), new Vector2(16, 2),
            new Vector2(12, 1), new Vector2(16, 3),
            new Vector2(12, 1), new Vector2(15, 3),
            new Vector2(12, 1), new Vector2(14, 5),
            new Vector2(12, 1), new Vector2(14, 6),
            new Vector2(12, 11), new Vector2(14, 12),
            new Vector2(12, 11), new Vector2(14, 13),
            new Vector2(12, 11), new Vector2(13, 14),

            new Vector2(13, 14), new Vector2(14, 12),
            new Vector2(13, 14), new Vector2(14, 13),
            new Vector2(13, 14), new Vector2(15, 14),

            new Vector2(14, 5), new Vector2(15, 3),
            new Vector2(14, 5), new Vector2(16, 8),
            new Vector2(14, 6), new Vector2(14,5),
            new Vector2(14, 6), new Vector2(15, 3),
            new Vector2(14, 6), new Vector2(16, 8),
            new Vector2(14, 12), new Vector2(20, 11),
            new Vector2(14, 12), new Vector2(17, 13),
            new Vector2(14, 12), new Vector2(16, 13),
            new Vector2(14, 12), new Vector2(17, 14),
            new Vector2(14, 12), new Vector2(15, 14),
            new Vector2(14, 13), new Vector2(15, 12),
            new Vector2(14, 13), new Vector2(20, 14),
            new Vector2(14, 13), new Vector2(17, 14),
            new Vector2(14, 13), new Vector2(15, 14),

            new Vector2(15, 1), new Vector2(17, 0),
            new Vector2(15, 1), new Vector2(20, 1),
            new Vector2(15, 1), new Vector2(19, 3),
            new Vector2(15, 3), new Vector2(17, 0),
            new Vector2(15, 3), new Vector2(20, 1),
            new Vector2(15, 3), new Vector2(16, 3),
            new Vector2(15, 12), new Vector2(16, 11),
            new Vector2(15, 12), new Vector2(18, 11),
            new Vector2(15, 12), new Vector2(17, 13),
            new Vector2(15, 14), new Vector2(16, 13),
            new Vector2(15, 14), new Vector2(17, 13),
            new Vector2(15, 14), new Vector2(17, 14),

            new Vector2(16, 2), new Vector2(17, 0),
            new Vector2(16, 2), new Vector2(20, 1),
            new Vector2(16, 2), new Vector2(19, 3),
            new Vector2(16, 3), new Vector2(16, 2),
            new Vector2(16, 3), new Vector2(19, 3),
            new Vector2(16, 3), new Vector2(17, 0),
            new Vector2(16, 3), new Vector2(20, 1),
            new Vector2(16, 8), new Vector2(19, 7),
            new Vector2(16, 11), new Vector2(18, 11),
            new Vector2(16, 11), new Vector2(17, 13),
            new Vector2(16, 11), new Vector2(17, 14),
            new Vector2(16, 13), new Vector2(18, 11),
            new Vector2(16, 13), new Vector2(20, 12),

            new Vector2(17, 0), new Vector2(20, 1),
            new Vector2(17, 0), new Vector2(19, 3),
            new Vector2(17, 13), new Vector2(18, 11),
            new Vector2(17, 13), new Vector2(20, 14),
            new Vector2(17, 14), new Vector2(18, 11),
            new Vector2(17, 14), new Vector2(20, 11),
            new Vector2(17, 14), new Vector2(19, 13),

            new Vector2(18, 11), new Vector2(20, 11),
            new Vector2(18, 11), new Vector2(20, 12),
            new Vector2(18, 11), new Vector2(20, 14),
            new Vector2(18, 11), new Vector2(19, 13),

            new Vector2(19, 3), new Vector2(20, 1),
            new Vector2(19, 13), new Vector2(20, 11),
            new Vector2(19, 13), new Vector2(20, 12),
            new Vector2(19, 13), new Vector2(20, 14),

    };
    #endregion

    #endregion


    void Start()
    {
        _mainCamera = Camera.main;

        limeStringRemaining = 900.0f;      
        numberTownsVisited = 0;
        numberTownsMissed = 78;
        numberNullPathways = 0;
        totalScore = 0;
        ScoreHandler.nextSceneNumber = 2;

    }

    void Update()
    {

        if (isDrawing)
        {
            lineRenderer.positionCount = 2;
            // Get cursor position for the current frame
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Ancor line to first point while drawing
            lineRenderer.SetPosition(0, firstObject.transform.position);
            // Line tracks the cursor position
            lineRenderer.SetPosition(1, cursorPosition);
        }
        else
        {
            if (click && lineRenderer != null)
            {
                // Draw Line between two points
                lineRenderer.SetPosition(0, firstObject.transform.position);
                lineRenderer.SetPosition(1, secondObject.transform.position);

                // Add First point of pathway drawn
                pathwaysScenario1.Add(firstObject.transform.position);
                // Add Second point of pathway drawn
                pathwaysScenario1.Add(secondObject.transform.position);
                
                click = false;
            }
        }
    }

    private void OnClick()
    {
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        // If the player clicks on a town, initiate drawing mode and ancor the first point
        if (rayHit.collider != null && rayHit.collider.gameObject.tag.Contains("Town") && isDrawing == false)
        {

            isDrawing = true;
            newString = Instantiate(newString, new Vector3(0, 0, 0), Quaternion.identity);
            lineRenderer = newString.GetComponent<LineRenderer>();
            firstObject = rayHit.collider.gameObject;
            lineRenderer.positionCount = 2;

        }
        // If the player clicks on a second town while drawing, draw a pathway between the two points
        else
        {
            if (rayHit.collider != null && rayHit.collider.gameObject.tag.Contains("Town"))
            {
                if (numberTownsMissed == 78)
                {
                    numberTownsMissed -= 2;
                }
                else
                {
                    numberTownsMissed -= 1;
                }
                secondObject = rayHit.collider.gameObject;
                edgeCollider = newString.GetComponent<EdgeCollider2D>();
                edgeCollider.points = new Vector2[] { firstObject.transform.position, secondObject.transform.position };
                float distance = Vector3.Distance(firstObject.transform.position, secondObject.transform.position) / 2;
                limeStringRemaining -= distance;

                checkInvalidPathways();
                limeMessageText.SetText("Lime string remaining: " + "\n" + limeStringRemaining.ToString("0.00") + "cm");
                townsConnectedText.SetText("Number Towns Connected:  " + "\n" + (78-numberTownsMissed).ToString() + "/78");
                invalidPathwaysText.SetText("Number Invalid Paths: " + "\n" + numberNullPathways.ToString());

                double score = limeStringRemaining - (numberNullPathways * 20 + numberTownsMissed * 20);
                
                isDrawing = false;
                click = true;
            }
        }

    }

    private void OnRightClick()
    {
        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (rayHit.collider.gameObject.tag == "String")
        {
            GameObject destroyedObject = rayHit.collider.gameObject;
            destroyedObject.GetComponent<LineRenderer>().positionCount = 0;
            EdgeCollider2D destroyedObjectEdgeCollider = destroyedObject.GetComponent<EdgeCollider2D>();
            destroyedObjectEdgeCollider.points = new Vector2[0];
        }
    }

    public void FinishBtnClick()
    {
        
        Debug.Log("Pathways Drawn: ");
        foreach (Vector2 point in pathwaysScenario1)
        {
            Debug.Log(point.x.ToString() + ", " + point.y.ToString());
        }


        // Check if each of the pathways created is the same as an existing pathways
        // If not tally each missed pathway
        double score = limeStringRemaining;
        if (pathwaysScenario1.Count > 1)
        {
            int numberPathwaysMissed = 0;
            for (int i = 0; i < pathwaysScenario1.Count; i += 2)
            {
                bool pathwayMissed = true;

                for (int j = 0; j < existingPathways.Length; j++)
                {
                    // Check if first point is equal
                    if (pathwaysScenario1[i].x == existingPathways[j].x && pathwaysScenario1[i].y == existingPathways[j].y)
                    {
                        // Check if second point is equal, if so the pathway is valid
                        if (pathwaysScenario1[i + 1].x == existingPathways[j + 1].x && pathwaysScenario1[i + 1].y == existingPathways[j + 1].y)
                        {
                            pathwayMissed = false;
                        }
                    }
                }

                if (pathwayMissed) {numberPathwaysMissed++;}
            }
            numberNullPathways = numberPathwaysMissed;
            Debug.Log("Number of Invalid Pathways: " + numberNullPathways);
        }
        else
        {
            Debug.Log("No Pathways Created");
        }

        Debug.Log("Number of missed towns: " + numberTownsMissed);

        // Calculate Score
        score = (limeStringRemaining + 900.0f) - numberTownsMissed * 20 - numberNullPathways * 20;
        totalScore = Convert.ToInt32(score);
        if(totalScore < 0) { totalScore = 0; }
        Debug.Log("Score: " + score);
        

        // Move to Score scene
        SceneManager.LoadScene(9);
    }

    public void checkInvalidPathways()
    {
        // Check if each of the pathways created is the same as an existing pathways
        // If not tally each missed pathway
        double score = limeStringRemaining;
        if (pathwaysScenario1.Count >= 1)
        {
            int numberPathwaysMissed = 0;
            for (int i = 0; i < pathwaysScenario1.Count; i += 2)
            {
                bool pathwayMissed = true;

                for (int j = 0; j < existingPathways.Length; j++)
                {
                    // Check if first point is equal
                    if (pathwaysScenario1[i].x == existingPathways[j].x && pathwaysScenario1[i].y == existingPathways[j].y)
                    {
                        // Check if second point is equal, if so the pathway is valid
                        if (pathwaysScenario1[i + 1].x == existingPathways[j + 1].x && pathwaysScenario1[i + 1].y == existingPathways[j + 1].y)
                        {
                            pathwayMissed = false;
                        }
                    }
                }

                if (pathwayMissed) { numberPathwaysMissed++; }
            }
            numberNullPathways = numberPathwaysMissed;
            Debug.Log("Number of Invalid Pathways: " + numberNullPathways);
        }
    }

    // Undo method removes the last placed pathway, gets it distance and add the value back to total string length left
    public void undo()
    {
        float distance = Vector3.Distance(firstObject.transform.position, secondObject.transform.position) / 3;
        limeStringRemaining += distance;
        lineRenderer.positionCount = 0;
        numberTownsMissed += 1;
        townsConnectedText.SetText("Number Towns Connected:  " + "\n" + (78 - numberTownsMissed).ToString() + "/78");
        limeMessageText.SetText("Lime string remaining: " + "\n" + limeStringRemaining.ToString("0.00") + "cm");
    }

}