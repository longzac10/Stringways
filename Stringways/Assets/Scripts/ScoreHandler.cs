using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public TMP_Text s1mtown;
    public TMP_Text s1mpath;
    public TMP_Text s1total;

    public TMP_Text s2mtown;
    public TMP_Text s2mpath;
    public TMP_Text s2total;
    public TMP_Text s250;

    public TMP_Text s3mtown;
    public TMP_Text s3mpath;
    public TMP_Text s3total;
    public TMP_Text s350;

    // Start is called before the first frame update
    void Start()
    {
        s1mtown.SetText(InputHandler.numberTownsMissed.ToString());
        s1mpath.SetText(InputHandler.numberNullPathways.ToString());
        s1total.SetText(InputHandler.totalScore.ToString());

        s2mtown.SetText(InputHandler2.numberTownsMissed2.ToString());
        s2mpath.SetText(InputHandler2.numberNullPathways2.ToString());
        s2total.SetText(InputHandler2.totalScore2.ToString());
        s250.SetText(InputHandler2.totalRed.ToString());

        s3mtown.SetText(InputHandler3.numberTownsMissed3.ToString());
        s3mpath.SetText(InputHandler3.numberNullPathways3.ToString());
        s3total.SetText(InputHandler3.totalScore3.ToString());
        s350.SetText(InputHandler3.nonAlternating.ToString());

    }
}

