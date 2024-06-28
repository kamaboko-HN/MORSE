using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInitialization : MonoBehaviour
{
    private UIManager UIManagerScript;
    void Start()
    {
        UIManagerScript = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        //BackUIObject = GameObject.FindWithTag("BackUI");
        UIManagerScript.BackUIObject.SetActive(true);
        //TitleUIObject = GameObject.FindWithTag("TitleUI");
        UIManagerScript.TitleUIObject.SetActive(true);
        //StageSelectUIObject = GameObject.FindWithTag("SSUI");
        UIManagerScript.StageSelectUIObject.SetActive(false);
        //FreeModeUIObject = GameObject.FindWithTag("FMUI");
        UIManagerScript.ModeUIObject.SetActive(false);
    }
}
