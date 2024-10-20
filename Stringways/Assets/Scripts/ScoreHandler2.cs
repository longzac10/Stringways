using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler2 : MonoBehaviour
{

    public TMP_Text s7mpath;
    public TMP_Text s7total;
    public TMP_Text s750;

    public TMP_Text s9mpath;
    public TMP_Text s9total;
    public TMP_Text s950;

    // Start is called before the first frame update
    void Start()
    {


        
        s7mpath.SetText(InputHandler7.numberNullPathways7.ToString());
        //s3total.SetText(InputHandler7.totalScore7.ToString());
        s750.SetText(InputHandler7.nonGreen.ToString());

    }
}

