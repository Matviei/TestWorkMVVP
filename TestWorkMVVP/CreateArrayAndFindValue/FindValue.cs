using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkMVVP.Models;

namespace TestWorkMVVP.CreateArrayAndFindValue
{
    /// <summary>
    /// Класс для реализации поиска значений в массиве
    /// </summary>
    public class FindValue
    {/// <summary>
    /// Поиск в массиве по введенному числу
    /// </summary>
    /// <param name="searhValue"></param>
    /// <returns></returns>
        public static int FindCountValue(int searhValue)
        {
            int[] array = ArrayBD.IntArray;
            int countValue = 0;
            foreach (int value in array)
            {
                if (value == searhValue)
                    countValue++;
            }
            return countValue;
        }
    }
}
