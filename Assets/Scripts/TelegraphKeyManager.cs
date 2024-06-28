using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TelegraphKeyManager : MonoBehaviour
{
    private TextMeshProUGUI ReceiveText;
    private ReceiverManager ReceiverScript;

    private float downTime;
    private bool nowDown = false;
    private float inputTime;
    private bool nowInput = false;
    private float nonInputTime = 0.0f;

    private int inputCount;
    public int InputCount{
        get{ return this.inputCount; }
        private set{ this.inputCount = value; }
    }
    private bool canInput = false;
    public bool CanInput
    {
        get { return canInput; }
        set { canInput = value; }
    }
    
    void Start()
    {
        Debug.Log("STARTED");
        ReceiveText = GameObject.FindWithTag("OutputText").GetComponent<TextMeshProUGUI>();
        ReceiverScript = GameObject.FindWithTag("OutputText").GetComponent<ReceiverManager>();
        Debug.Log(ReceiveText);
        Debug.Log(ReceiverScript);
        Debug.Log(CanInput);
    }

    // Update is called once per frame
    void Update()
    {   
        if (CanInput == true){
            //入力検知
            //キー押し true, 入力中 true,　キー押し時間リセット
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                nowDown = true;
                nowInput = true;
                downTime = 0f;
            }

            //入力中検知
            //キー押し時間追加
            if (Input.GetKey(KeyCode.Space))
            {
                if (nowDown == true)
                {
                    downTime += Time.deltaTime;
                }
            }
            
            //入力終了検知
            //キー押し時間 0.3秒以下=. , キー押し時間0.3以上=-
            //キー押し false, 無入力時間リセット
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (downTime <= 0.3f)
                {
                    ReceiveText.text = ReceiveText.text+".";
                    Debug.Log(".");
                    InputCount += 1;
                }
                else if (downTime > 0.3f)
                {
                    ReceiveText.text = ReceiveText.text+"-";
                    Debug.Log("-");
                    InputCount += 1;
                }
                nowDown = false;
                nowInput = false;
                nonInputTime = 0.0f;
            }

            //無入力検知
            //無入力時間追加
            //1秒超えたら変換
            if (nowInput == false)
            {   
                if (InputCount > 0)
                {
                    nonInputTime += Time.deltaTime;
                    if (nonInputTime > 1.0f){
                        ReceiverScript.Convert(InputCount);
                        InputCount = 0;
                    }
                }
            }
        }
    }
}
