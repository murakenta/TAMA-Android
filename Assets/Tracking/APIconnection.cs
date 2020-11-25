using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System.Text;

public class APIconnection : MonoBehaviour
{
    public string url = "http://192.168.1.76/api/trajectories";
    //public static TextAsset csvFile;



    public void Onclick(){
        StartCoroutine("Start");
    }

    [System.Serializable]
    public class Dataset
    {
        public string trajectory;
    }

    // Start is called before the first frame update
    // Use this for initialization
    IEnumerator Start () {
        
        // csvファイル名
        var filePath = PositionOut.combinedPath;
        var fileName = PositionOut.filename;

        // csvファイルをJson形式に変換
        Dataset dataset = new Dataset ();
        var csvFile = new StreamReader(filePath);
        dataset.trajectory = csvFile.ReadToEnd();
        string reader = JsonUtility.ToJson (dataset);
        byte[] postData = Encoding.UTF8.GetBytes (reader);

        // データフォームの設定
        //List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        //formData.Add( new MultipartFormFileSection(postData, "trajectory") );

        //WWWForm form = new WWWForm();
        //form.AddField("trajectory", postData); //methodというフィールド名でPOSTという値を設定

        // データをサーバに送信
        using (UnityWebRequest www = new UnityWebRequest(url, "POST"))
        {
            // jsonの設定
            www.uploadHandler = (UploadHandler) new UploadHandlerRaw(postData);
            www.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();

            //ヘッダーにタイプを設定
            www.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    
    }
}
