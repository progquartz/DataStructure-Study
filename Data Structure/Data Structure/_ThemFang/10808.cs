using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    /// <summary>
    /// 현재 만들어놓은 
    /// </summary>
    class _10808
    {
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        public void Solve()
        //static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            // 만약 segfault오류나면 쓰지 말것.
            // 만약 Argumentnull오류가 난다면 이놈은 쓰지말것.
            string sentence = Console.ReadLine();
            int[] alphabet = new int[26];
            for (int i = 0; i < sentence.Length; i++)
                alphabet[sentence[i] - 'a']++;
            StringBuilder sb = new StringBuilder();
            foreach (int a in alphabet)
                sb.Append(a + " ");
            Console.WriteLine(sb);
            sr.Close();
            sw.Close();
        }


    }


}
