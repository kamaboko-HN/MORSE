using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

[JsonObject("ModeData")]
public class __ModeData__
{
    [JsonProperty("ChapterTitles")]
    public string[] ChapterTitles = new string[5];

    [JsonProperty("Dates")]
    public string[,] Dates = new string[5,5];

    [JsonProperty("Diaries")]
    public string[,] Diaries = new string[5,5];

    [JsonProperty("ConDocTexts")]
    public string[,] ConDocTexts = new string[5,5];
/*
    [JsonProperty("MissionCodes")]
    public string[,] MissionCodes = new string[2,2];
    */
}

public class LoadJson : MonoBehaviour
{
    private __ModeData__ MD;
    public __ModeData__ ModeData
    {
        get { return MD; }
        set { MD = value; }
    }
    
    void Start()
    { 
        //MakeJson();
        StreamReader reader;
        reader = new StreamReader (Application.dataPath + "/Modedata/modedata.json");
        var datastr = reader.ReadToEnd ();
        reader.Close ();
        Debug.Log(datastr);
        ModeData = JsonConvert.DeserializeObject<__ModeData__>(datastr);
        Debug.Log(ModeData.Dates[0,0]);
        //Debug.Log(MD.ConDocTexts[0,0]);
        //Debug.Log(MD.MissionCodes[0,0]);
        Debug.Log(ModeData.ChapterTitles[0]);
        GameObject.FindWithTag("ModeM").GetComponent<ModeManager>().JsonDataImport();
    }
}

