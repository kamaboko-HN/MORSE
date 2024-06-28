using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlDocumentManager : MonoBehaviour
{
    private TextMeshProUGUI ControlDocument;
    void Start()
    {
        ControlDocument = GameObject.FindWithTag("ConDocText").GetComponent<TextMeshProUGUI>();
        //ConDocは29行以内
    }

    public void ResetConDoc(){
        ControlDocument.text = 
@"CREDIT

Director:Kamaboko
Designer:Kamaboko
Engineer:Kamaboko

UsedTools:
Visual Studio Code
Unity
adobe Photo Shop

Pictures&Materials:
Midjourney
Wikipedia
BEIZ images
建築パース.com
photo AC";
    }
}
