using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilePath : MonoBehaviour
{
    public static string folderpath;
    // Start is called before the first frame update
    void Start()
    {
        folderpath = Application.persistentDataPath;
    }
}
