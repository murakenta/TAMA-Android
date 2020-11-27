using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class InputFieldManager : MonoBehaviour
{
    //InputFieldを格納するための変数
    InputField inputField;
    
    //サンプリングレートを格納
    public static float sampling_rate;
 
    // Start is called before the first frame update
    void Start()
    {
        //InputFieldコンポーネントを取得
        inputField = GameObject.Find("InputField").GetComponent<InputField>();
    }
 
 
    //入力された名前情報を読み取ってコンソールに出力する関数
    public void GetInputName()
    {
        //InputFieldからテキスト情報を取得する
        sampling_rate = float.Parse(inputField.text);
 
        //テキストにサンプリングレートを表示
        inputField.text = sampling_rate.ToString();
    }
}