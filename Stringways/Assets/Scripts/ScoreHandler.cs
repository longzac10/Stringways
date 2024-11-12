using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public TMP_Text s1String;
    public TMP_Text s1mtown;
    public TMP_Text s1mpath; 
    public TMP_Text s1B;
    public TMP_Text s1C;
    public TMP_Text s1total;

    public TMP_Text s2mtown;
    public TMP_Text s2mpath;
    public TMP_Text s2total;
    public TMP_Text s250;
    public TMP_Text s2_20Tally;

    public TMP_Text s3mtown;
    public TMP_Text s3mpath;
    public TMP_Text s3total;
    public TMP_Text s350;
    public TMP_Text s3_20Tally;

    public TMP_Text s4mtown;
    public TMP_Text s4mpath;
    public TMP_Text s4total;
    public TMP_Text s450;
    public TMP_Text s4_20Tally;

    public TMP_Text s5mtown;
    public TMP_Text s5mpath;
    public TMP_Text s5total;
    public TMP_Text s550;
    public TMP_Text s5_20Tally;

    public TMP_Text s6mtown;
    public TMP_Text s6mpath;
    public TMP_Text s6total;
    public TMP_Text s650;
    public TMP_Text s6_20Tally;

    public static double limeStringRemaining;
    public static double pinkStringRemaining = 900.0f;

    // Start is called before the first frame update
    void Start()
    {
        s1String.SetText(InputHandler.limeStringRemaining.ToString("0"));
        s1mtown.SetText(InputHandler.numberTownsMissed.ToString());
        s1mpath.SetText(InputHandler.numberNullPathways.ToString());
        s1B.SetText(((InputHandler.numberTownsMissed + InputHandler.numberNullPathways) * 20).ToString("0"));
        s1total.SetText(InputHandler.totalScore.ToString());


        s2mtown.SetText(InputHandler2.numberTownsMissed2.ToString());
        s2mpath.SetText(InputHandler2.numberNullPathways2.ToString());
        s2total.SetText(InputHandler2.totalScore2.ToString());
        s250.SetText(InputHandler2.totalRed.ToString());

        s3mtown.SetText(InputHandler3.numberTownsMissed3.ToString());
        s3mpath.SetText(InputHandler3.numberNullPathways3.ToString());
        s3total.SetText(InputHandler3.totalScore3.ToString());
        s350.SetText(InputHandler3.nonAlternating.ToString());

        s4mtown.SetText(InputHandler4.numberTownsMissed4.ToString());
        s4mpath.SetText(InputHandler4.numberNullPathways4.ToString());
        s4total.SetText(InputHandler4.totalScore4.ToString());
        s450.SetText(InputHandler4.numberMultiColourCross.ToString());



    }
}

