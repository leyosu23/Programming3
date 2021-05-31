using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoonseop_Lee_Sec003_Lab02_Exercise02
{
    public class CountWords
    {
        public string Uppercase(string sentence)
        {
            if (sentence.Length > 0)
            {
                char[] array = sentence.ToCharArray();
                for (int i = 0; i < sentence.Length; i++)
                {
                    array[i] = char.ToUpper(array[i]);
                }
                return new string(array);
            }
            return sentence;
        }
    }
}
