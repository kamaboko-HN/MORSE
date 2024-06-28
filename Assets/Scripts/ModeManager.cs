using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModeManager : MonoBehaviour
{
    private UIManager UIManagerScript;
    private TelegraphKeyManager TelegraphKeyScript;
    private ControlDocumentManager ControlDocumentScript;
    private ReceiverManager ReceiverScript;
    private TextMeshProUGUI ControlDocument;
    private __ModeData__ ModeDataOnManager;
    private int ChapterVar;
    public int ChapterVarProperty
    {
        get { return ChapterVar; }
        set { ChapterVar = value; }
    }

    private int[] StageSelectNum = new int[2]{1,1};
    public int[] StageSelectProperty
    {
        get { return StageSelectNum; }
        set { StageSelectNum = value; }
    }
    

    private TextMeshProUGUI ChapterTitleText;
    private TextMeshProUGUI StageAText;
    private TextMeshProUGUI StageBText;
    private TextMeshProUGUI StageCText;
    private TextMeshProUGUI StageDText;
    private TextMeshProUGUI StageEText;
    private TextMeshProUGUI DiaryTitleText;
    private TextMeshProUGUI DiaryText;

    void Start(){
        UIManagerScript = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        TelegraphKeyScript = GameObject.FindWithTag("TKey").GetComponent<TelegraphKeyManager>();
        ControlDocumentScript = GameObject.FindWithTag("ConDocText").GetComponent<ControlDocumentManager>();
        ReceiverScript = GameObject.FindWithTag("OutputText").GetComponent<ReceiverManager>();
        ControlDocument = GameObject.FindWithTag("ConDocText").GetComponent<TextMeshProUGUI>();

        ChapterVarProperty = 1;

        ChapterTitleText = UIManagerScript.ChapterTitle.GetComponent<TextMeshProUGUI>();
        StageAText = UIManagerScript.StageA.GetComponent<TextMeshProUGUI>();
        StageBText = UIManagerScript.StageB.GetComponent<TextMeshProUGUI>();
        StageCText = UIManagerScript.StageC.GetComponent<TextMeshProUGUI>();
        StageDText = UIManagerScript.StageD.GetComponent<TextMeshProUGUI>();
        StageEText = UIManagerScript.StageE.GetComponent<TextMeshProUGUI>();
        DiaryTitleText = UIManagerScript.DiaryTitle.GetComponent<TextMeshProUGUI>();
        DiaryText = UIManagerScript.Diary.GetComponent<TextMeshProUGUI>();
    }
    public void JsonDataImport(){
        ModeDataOnManager = GameObject.FindWithTag("ModeM").GetComponent<LoadJson>().ModeData;
        Debug.Log(ModeDataOnManager.ChapterTitles);
    }

    public void OnClickBack(){
        TelegraphKeyScript.CanInput = false;
        ControlDocumentScript.ResetConDoc();
        ReceiverScript.ResetReceiver();
        UIManagerScript.ModeUIObject.SetActive(false);
        UIManagerScript.TitleUIObject.SetActive(true);
    }

    public void SetModeText(int ModeNum){
        //ControlDocumentのText
        ControlDocument.text = ConDocTexts[ModeNum];
        //指定のモールスコード

    }  

    private string[] ConDocTexts = new string[]{
@"Free Mode

A = .-
B = -...
C = -.-.
D = -..
E = .
F = .._.
G = --.
H = ....
I = ..
J = .---
K = -.-
L = .-..
M = --
N = -.
O = ---
P = .--.
Q = --.-
R = .-.
S = ...
T = -
U = ..-
V = ...-
W = .--
X = -..-
Y = -.--
Z = --.."
    };

    private string[,] MissionCode = new string[,]{
        {"Free"}
    };

    public void ChapterInitialization(){
        ChapterVarProperty = 1;
        ChangeStageData(ChapterVarProperty);
    }
    public void OnClickSetChapter1(){ //Illinois
        ChapterVarProperty = 1;
        ChangeStageData(ChapterVarProperty);
    }
    public void OnClickSetChapter2(){ //Baltimore
        ChapterVarProperty = 2;
        ChangeStageData(ChapterVarProperty);
    }
    public void OnClickSetChapter3(){ //Columbia
        ChapterVarProperty = 3;
        ChangeStageData(ChapterVarProperty);
    }
    public void OnClickSetChapter4(){ //London
        ChapterVarProperty = 4;
        ChangeStageData(ChapterVarProperty);
    }
    public void OnClickSetChapter5(){ //Paris
        ChapterVarProperty = 5;
        ChangeStageData(ChapterVarProperty);
    }

    void ChangeStageData(int ChapterNum){
        int ChapterNumIndex = ChapterNum - 1;
        Debug.Log(ModeDataOnManager.ChapterTitles[ChapterNumIndex]);
        ChapterTitleText.text = "Chapter " + ChapterNum.ToString() + "\n" + ModeDataOnManager.ChapterTitles[ChapterNumIndex];
        StageAText.text = "A, " + ModeDataOnManager.Dates[ChapterNumIndex,0];
        StageBText.text = "B, " + ModeDataOnManager.Dates[ChapterNumIndex,1];
        StageCText.text = "C, " + ModeDataOnManager.Dates[ChapterNumIndex,2];
        StageDText.text = "D, " + ModeDataOnManager.Dates[ChapterNumIndex,3];
        StageEText.text = "E, " + ModeDataOnManager.Dates[ChapterNumIndex,4];
    }

    public void OnClickSetStageA(){
        SetStage(0);
    }
    public void OnClickSetStageB(){
        SetStage(1);
    }
    public void OnClickSetStageC(){
        SetStage(2);
    }
    public void OnClickSetStageD(){
        SetStage(3);
    }
    public void OnClickSetStageE(){
        SetStage(4);
    }

    void SetStage(int StageNum){
        DiaryTitleText.text = ModeDataOnManager.Dates[ChapterVarProperty - 1,StageNum] + ", " + ModeDataOnManager.ChapterTitles[ChapterVarProperty - 1];
        DiaryText.text = ModeDataOnManager.Diaries[ChapterVarProperty - 1,StageNum];
        StageSelectProperty[0] = ChapterVarProperty;
        StageSelectProperty[1] = StageNum;
    }

    public void OnClickStartStage(){
        UIManagerScript.StageSelectUIObject.SetActive(false);
        UIManagerScript.ModeUIObject.SetActive(true);
        TelegraphKeyScript.CanInput = true;
    }
}