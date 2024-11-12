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
    public TMP_Text s150Tally;
    public TMP_Text s1C;
    public TMP_Text s1total;

    public TMP_Text s2String;
    public TMP_Text s2mtown;
    public TMP_Text s2mpath;
    public TMP_Text s2B;
    public TMP_Text s250Tally;
    public TMP_Text s2C;
    public TMP_Text s2total;

    public TMP_Text s3String;
    public TMP_Text s3mtown;
    public TMP_Text s3mpath;
    public TMP_Text s3B;
    public TMP_Text s350Tally;
    public TMP_Text s3C;
    public TMP_Text s3total;

    public TMP_Text s4String;
    public TMP_Text s4mtown;
    public TMP_Text s4mpath;
    public TMP_Text s4B;
    public TMP_Text s450Tally;
    public TMP_Text s4C;
    public TMP_Text s4total;

    public TMP_Text s5String;
    public TMP_Text s5mtown;
    public TMP_Text s5mpath;
    public TMP_Text s5B;
    public TMP_Text s550Tally;
    public TMP_Text s5C;
    public TMP_Text s5total;

    public TMP_Text s6String;
    public TMP_Text s6mtown;
    public TMP_Text s6mpath;
    public TMP_Text s6B;
    public TMP_Text s650Tally;
    public TMP_Text s6C;
    public TMP_Text s6total;

    public static int nextSceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        s1String.SetText((InputHandler.limeStringRemaining + 900.0f).ToString("0"));
        s1mtown.SetText(InputHandler.numberTownsMissed.ToString());
        s1mpath.SetText(InputHandler.numberNullPathways.ToString());
        s1B.SetText(((InputHandler.numberTownsMissed + InputHandler.numberNullPathways) * 20).ToString("0"));
        s1total.SetText(InputHandler.totalScore.ToString());

        s2String.SetText((InputHandler2.limeStringRemaining2 + 900.0f).ToString("0"));
        s2mtown.SetText(InputHandler2.numberTownsMissed2.ToString());
        s2mpath.SetText(InputHandler2.numberNullPathways2.ToString());
        s2B.SetText(((InputHandler2.numberTownsMissed2 + InputHandler2.numberNullPathways2) * 20).ToString("0"));
        s250Tally.SetText(InputHandler2.totalRed.ToString());
        s2C.SetText(((InputHandler2.totalRed) * 50).ToString());
        s2total.SetText(InputHandler2.totalScore2.ToString());

        s3String.SetText((InputHandler3.limeStringRemaining3 + 900.0f).ToString("0"));
        s3mtown.SetText(InputHandler3.numberTownsMissed3.ToString());
        s3mpath.SetText(InputHandler3.numberNullPathways3.ToString());
        s3B.SetText(((InputHandler3.numberTownsMissed3 + InputHandler3.numberNullPathways3) * 20).ToString("0"));
        s350Tally.SetText(InputHandler3.nonAlternating.ToString());
        s3C.SetText(((InputHandler3.nonAlternating) * 50).ToString());
        s3total.SetText(InputHandler3.totalScore3.ToString());

        s4String.SetText((InputHandler4.limeStringRemaining4 + InputHandler4.pinkStringRemaining4).ToString("0"));
        s4mtown.SetText(InputHandler4.numberTownsMissed4.ToString());
        s4mpath.SetText(InputHandler4.numberNullPathways4.ToString());
        s4B.SetText(((InputHandler4.numberTownsMissed4 + InputHandler4.numberNullPathways4) * 20).ToString("0"));
        s450Tally.SetText(InputHandler4.numberMultiColourCross.ToString());
        s4C.SetText((InputHandler4.numberMultiColourCross * 50).ToString());
        s4total.SetText(InputHandler4.totalScore4.ToString());
        



    }
}

