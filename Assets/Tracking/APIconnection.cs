using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class APIconnection : MonoBehaviour
{
    public string url = "http://192.168.1.76/api/trajectories";


    public void Onclick(){
        StartCoroutine("Start");
    }

    // Start is called before the first frame update
    // Use this for initialization
    IEnumerator Start () {
        
        // csvファイル名
        var fileName = PositionOut.combinedPath;
        // Resourcesのcsvフォルダ内のcsvファイルをTextAssetとして取得
        var csvFile = Resources.Load(fileName) as TextAsset;
        // csvファイルの内容をStringReaderに変換
        string reader = csvFile.text;
    
        WWWForm form = new WWWForm ();
        form.AddField (fileName, reader);
        var www = new WWW (url, form);
        yield return www;
    
    }
}
