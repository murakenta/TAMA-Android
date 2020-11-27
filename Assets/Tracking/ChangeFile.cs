using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
 
public class ChangeFile : MonoBehaviour
{
    //Dropdownを格納する変数
    [SerializeField] private Dropdown dropdown;

    public static string file;

 
    // オプションが変更されたときに実行するメソッド
    public void Changefile()
    {
        DirectoryInfo dir = new DirectoryInfo(FilePath.folderpath);
        FileInfo[] info = dir.GetFiles("*.csv");

        for(int x=1; x<=info.Length; ++x){
            if(dropdown.value == x){
                file = info[x-1].Name;
                Debug.Log(file);
            }
        }

    }
}