using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RSA
{
    class Program //クラスの定義
    {
        public String Num2alpha(int num)
        {
            String words = ""; //初期値を設定
            String splnums = "";
            List<string> nums = new List<string>(); //動的配列の宣言
            int len = num.ToString().Length;
            if (len % 2 == 0)//文字列の長さが偶数の場合のみ実行する
            {
                for (int i = 0; i < len - 1; i += 2)
                {
                    splnums = num.ToString().Substring(i, 2); //numを二文字ずつに分割
                    nums.Add(splnums);
                }

                foreach (var index in nums)
                {
                    words += Convert.ToChar(Int32.Parse(index) + 64);
                    //65がアルファベットAの始まる十進数上での文字コード
                    //出てきた数字＋65 -1→出てきた数字＋64して、文字コードを算出
                    //それをToCharで変換
                }
                return words;
            }
            else
            {
                words = "偶数桁じゃないので変換されませんでした";
            }
            return words;
        }
        static void Main(string[] args)
        {
            int p = 37;
            int q = 71;
            int e = 79;
            int c = 904;
            int m = 0; //何かを初期化しないで宣言しちゃだめだよ
            int n = p * q;
            String newLine = Environment.NewLine; //改行コードの取得

            for (int i = 0; i < e; i++)
            {
                if (i * (p - 1) * (q - 1) % e == e - 1)
                {
                    m = i;
                    //Console.WriteLine(m);
                    break;
                }
            }
            int d = (m * (p - 1) * (q - 1) + 1) / e;
            System.Numerics.BigInteger M = System.Numerics.BigInteger.Pow(c, d) % n;
            Program obj = new Program();
            String s2 = obj.Num2alpha((int)M); //メソッド実行
            String s = String.Format("m={0}{4}d={1}{4}M={2}{4}アルファベット変換={3}", m, d, M, s2, newLine);
            Console.WriteLine(s);
        }
    }
}
