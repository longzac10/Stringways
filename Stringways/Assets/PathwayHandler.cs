using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathwayHandler : MonoBehaviour
{
    public GameObject newExistingPathway;
    // Start is called before the first frame update
    void Start()
    {

        Vector2[] points = new Vector2[]
        {
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

        };

        for(int i = 0; i < points.Length; i++) {
            GameObject newPathway = new GameObject();
            newPathway = Instantiate(newExistingPathway, new Vector3(0, 0, 0), Quaternion.identity);
            LineRenderer lineRenderer = newPathway.GetComponent<LineRenderer>();
            //lineRenderer.SetWidth(0.7f, 0.7f);
            lineRenderer.startWidth = 0.2f;
            lineRenderer.SetPosition(0, points[i]);
            lineRenderer.SetPosition(1, points[i+1]);
            i = i+1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
