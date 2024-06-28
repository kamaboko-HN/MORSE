using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class ReceiverManager : MonoBehaviour
{
    private TextMeshProUGUI ReceiveText;
    void Start()
    {
        ReceiveText = GameObject.FindWithTag("OutputText").GetComponent<TextMeshProUGUI>();
    }

    public void ResetReceiver(){
        ReceiveText.text = "";
        FreeMode = false;
        MissionCodes = new string[]{};
    }

    //#### #### ###  #  # #### # ##  ####
    //#    #  # #  # # #  ###  ##     #
    //#### #### #  #  ##  #### #      #
    private string convertCode;
    private int ConvertCount;
    private string[] HitList = new string[]{
        ".-", "-...", "-.-.", "-..", ".",
        ".._.", "--.", "....", "..", ".---",
        "-.-", ".-..", "--", "-.", "---",
        ".--.", "--.-", ".-.", "...", "-",
        "..-", "...-", ".--", "-..-", "-.--",
        "--.."
    };

    private string[,] ConvertList = new string[26,2]{
        { "A", ".-" }, 
        { "B", "-..." }, 
        { "C", "-.-." }, 
        { "D", "-.." },
        { "E", "." },
        { "F", "..-." },
        { "G", "--." },
        { "H", "...." },
        { "I", ".." },
        { "J", ".---" },
        { "K", "-.-" },
        { "L", ".-.." },
        { "M", "--" },
        { "N", "-." },
        { "O", "---" },
        { "P", ".--." },
        { "Q", "--.-" },
        { "R", ".-." },
        { "S", "..." },
        { "T", "-" },
        { "U", "..-" },
        { "V", "...-" },
        { "W", ".--" },
        { "X", "-..-" },
        { "Y", "-.--" },
        { "Z", "--.." }, 
        };

    private string[] missonCodes;
    public string[] MissionCodes
    {
        get { return missonCodes; }
        set { missonCodes = value; }
    }

    private bool FreeMode = false;

    public void Convert(int Count)
    {
        convertCode = ReceiveText.text.Substring(ReceiveText.text.Length - Count, Count);
        Debug.Log(convertCode);
        if (HitList.Contains(convertCode)){
            for (int ind = 0; ind <= 26; ind++)
            {
                if (ConvertList[ind,1]==convertCode)
                {
                    Debug.Log(ConvertList[ind,0]);
                    ReceiveText.text = ReceiveText.text.Replace(convertCode, ConvertList[ind,0]);
                    break;
                }
            }
        }
        else{
            Debug.Log("Clear");
            ReceiveText.text = ReceiveText.text.Replace(convertCode, "");
        }
    }

    public void CodeCheck(){
        
    }

    public void SetMissionCode(string[,] MC){
        if (MC[0,0] == "Free"){
            FreeMode = true;
        }
        else {
            FreeMode = false;
            //MissionCodes = MC[0,0];
        }
    }
}
