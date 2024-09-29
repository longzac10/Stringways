using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public TMP_Text s1mtown;
    public TMP_Text s1mpath;
    public TMP_Text s1total;

    // Start is called before the first frame update
    void Start()
    {
        s1mtown.SetText(InputHandler.numberTownsMissed.ToString());
        s1mpath.SetText(InputHandler.numberNullPathways.ToString());
        s1total.SetText(InputHandler.totalScore.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
