using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using TestWorkMVVP.Models;


namespace TestWorkMVVP.CreateArrayAndFindValue
{
    public class CreateArray
    {
        public static void ArrayCreate()
        {
            string patchToFile = PathFile();
            if(!patchToFile.Contains(".txt"))
            {
                return;
            }
            ArrayBD.IntArray = GetArray(patchToFile);
            
        }
        private static int[] GetArray(string path)
        {
            string stringValue = File.ReadAllText(path);
            var valueList = new List<int>();
            string[] stringArrayValue = stringValue.Split(',');
            for (int i = 0; i < stringArrayValue.Length; i++)
            {
                try
                {
                    valueList.Add(Convert.ToInt32(stringArrayValue[i]));
                }
                catch
                {
                    return null;
                }
            }
            valueList.Sort();
            return valueList.ToArray();
        }
        private static string PathFile()
        {
            OpenFileDialog dialogExplorer = new OpenFileDialog();
            dialogExplorer.ShowDialog();
            return dialogExplorer.FileName;
        }
    }
}
