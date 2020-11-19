using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//ここ注意
using System.Text;
using System.IO;

public class PositionOut : MonoBehaviour {
    //変数設定
    float m_X;
    float m_Y;
    float m_Z;
    //知りたい座標のGaeObjectの設定
    public Camera FirstPersonCamera;
    public StreamWriter sw;
    public string combinedPath;

    //現在時刻を格納
    string Hour;
    string Minute;
    string Second;
    string Millisec;


    // Use this for initialization
    void Start () {
        
        Time.fixedDeltaTime = InputFieldManager.sampling_rate;
        //Time.fixedDeltaTime = (float)1;
        
        //現在時刻を取得
        string year = System.DateTime.Now.Year.ToString();
        string month = System.DateTime.Now.Month.ToString();
        string day = System.DateTime.Now.Day.ToString();
        Hour = System.DateTime.Now.Hour.ToString();
        Minute = System.DateTime.Now.Minute.ToString();
        string time = year + month + day + "_" + Hour + Minute;

        //現在時刻からファイル名を決定
        string filename = time + ".csv";

        string[] s1 = {"time", "x", "y", "z"};
        string s2 = string.Join(",", s1);
        combinedPath = Path.Combine(Application.persistentDataPath, filename);
        using (sw = new StreamWriter(combinedPath, false))
        {
            sw.WriteLine(s2);
        }

        
        
    }

    // Update is called once per frame
    void FixedUpdate () {

        //それぞれに座標を挿入
        m_X = FirstPersonCamera.transform.position.x;
        m_Y = FirstPersonCamera.transform.position.z;
        m_Z = FirstPersonCamera.transform.position.y;

        //テキストに表示
        this.GetComponent<Text> ().text = "(" + m_X.ToString() + ", " + m_Y.ToString() + ")";

        //現在時刻を取得
        Hour = System.DateTime.Now.Hour.ToString();
        Minute = System.DateTime.Now.Minute.ToString();
        Second = System.DateTime.Now.Second.ToString();
        Millisec = System.DateTime.Now.Millisecond.ToString();

        string time = Hour + ":" + Minute + ":" + Second + ":" + Millisec;


        //csvファイルに書き込み
        string[] str = {time, m_X.ToString(), m_Y.ToString(), m_Z.ToString()};
        string str2 = string.Join(",", str);
        using (sw = new StreamWriter(combinedPath, true))
        {
            sw.WriteLine(str2);
        }
    }
}
