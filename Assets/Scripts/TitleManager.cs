using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    private UIManager UIManagerScript;
    private GameObject ModeUIObject;
    private TelegraphKeyManager TelegraphKeyScript;
    private ModeManager ModeManagerScript;
    void Start(){
        UIManagerScript = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        ModeManagerScript = GameObject.FindWithTag("ModeM").GetComponent<ModeManager>();
        TelegraphKeyScript = GameObject.FindWithTag("TKey").GetComponent<TelegraphKeyManager>();
    }
    public void OnClickStoryMode(){
        UIManagerScript.TitleUIObject.SetActive(false);
        UIManagerScript.StageSelectUIObject.SetActive(true);
        ModeManagerScript.ChapterInitialization();
    }
    public void OnClickFreeMode(){
        UIManagerScript.TitleUIObject.SetActive(false);
        UIManagerScript.ModeUIObject.SetActive(true);
        ModeManagerScript.SetModeText(0);
        TelegraphKeyScript.CanInput = true;
    }
    public void OnClickSettings(){

    }
    public void OnClickQuit(){

    }
}
