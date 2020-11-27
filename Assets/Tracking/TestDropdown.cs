using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Linq;
 
namespace Test
{
    public class TestDropdown : MonoBehaviour
    {
        [SerializeField]
        private Dropdown dropdown;

        private void Awake()
        {
            DirectoryInfo dir = new DirectoryInfo(FilePath.folderpath);
            FileInfo[] info = dir.GetFiles("*.csv");

            foreach(FileInfo f in info)
            {
                dropdown.options.Add(new Dropdown.OptionData { text = f.Name });
            }
            //dropdown.options.Add(new Dropdown.OptionData { text = "Item #1" });
            //dropdown.options.Add(new Dropdown.OptionData { text = "Item #2" });
            //dropdown.options.Add(new Dropdown.OptionData { text = "Item #3" });
 
            dropdown.RefreshShownValue();
        }
    }
}