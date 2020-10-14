using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outinput : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text> ();
        // テキストの表示を入れ替える
        score_text.text = InputFieldManager.sampling_rate.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
