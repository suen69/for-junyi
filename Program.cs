using System;
using System.Collections.Generic;
using System.Text;

namespace Ans1and2
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckData data = new CheckData();
            AnsOne one = new AnsOne();
            AnsTwo two = new AnsTwo(data.CheckNo);

            Console.WriteLine("1-(A)");
            Console.WriteLine("Enter a string like this [{0}]", data.CheckPartA);
            Console.WriteLine("Get a result like this [{0}]\r\n", one.PartA(data.CheckPartA));

            Console.WriteLine("1-(B)");
            Console.WriteLine("Enter a string like this [{0}]", data.CheckPartB);
            Console.WriteLine("Get a result like this [{0}]\r\n", one.PartB(data.CheckPartB));

            Console.WriteLine("2");
            Console.WriteLine("Input: {0}", data.CheckNo);
            Console.WriteLine("所有的數字是: {0}", two.AllNo);
            Console.WriteLine("扣除 {0} 的倍數以及 {1} 的倍數，保留同時是 {2} 和 {3} 的倍數", data.no1, data.no2, data.no1, data.no2);
            two.RemoveNo(data.no1, data.no2);
            Console.WriteLine("其中 {0} 被剃除; {1} 被剃除; 但是 {2} 被保留", two.No1, two.No2, two.No3);
            Console.WriteLine("所以剩下來的數字是 {0}, 因此", two.NoRemained);
            Console.WriteLine("Output: {0}", two.ValidCount);

            Console.Title = "執行結果:";
            Console.ReadKey();
        }
    }

    class CheckData
    {
        public string CheckPartA = "junyiacademy";
        public string CheckPartB = "flipped class room is important";
        public int CheckNo = 15;
        public int no1 = 3;
        public int no2 = 5;
    }

    class AnsOne
    {
        /// <summary>
        /// 1-A. 請寫一個程式把裡面的字串反過來。
        /// </summary>
        /// <param name="inStr">輸入字串</param>
        /// <returns>輸出字串</returns>
        public string PartA(string inStr)
        {
            StringBuilder strBuilder = new StringBuilder();
            for (int i = inStr.Length - 1; i >= 0; i--)
            {
                strBuilder.Append(inStr[i]);
            }
            return strBuilder.ToString();
        }

        /// <summary>
        /// 請寫一個程式把裡面的字串，每個單字本身做反轉，但是單字的順序不變。
        /// </summary>
        /// <param name="inStr">輸入字串</param>
        /// <returns>輸出字串</returns>
        public string PartB(string inStr)
        {
            string[] arrStr = inStr.Split(' ');
            List<string> arrString = new List<string>();
            StringBuilder res = new StringBuilder();
            foreach (string s in arrStr)
                arrString.Add(PartA(s) + " ");
            foreach (string s in arrString.ToArray())
                res.Append(s);
            return res.ToString().TrimEnd();
        }
    }

    /// <summary>
    /// 請寫一個程式，Input 是一個數字，Output 是從 1 到這個數字，扣除掉所有 3 的
    /// 倍數以及 5 的倍數，但是需要保留同時是 3 和 5 的倍數的總數字數
    /// </summary>
    class AnsTwo
    {
        /// <summary>
        /// 輸入數字
        /// </summary>
        int _no = 0;

        /// <summary>
        /// 所有數字列表
        /// </summary>
        List<int> _allNo
        {
            get
            {
                List<int> res = new List<int>();
                for (int i = 0; i < _no; i++)
                    res.Add(i + 1);
                return res;
            }
        }

        /// <summary>
        /// 扣除 no1 條件的數字列表
        /// </summary>
        List<int> _allNoExcept1 = new List<int>();

        /// <summary>
        /// 扣除 no2 條件的數字列表
        /// </summary>
        List<int> _allNoExcept2 = new List<int>();

        /// <summary>
        /// 保留 no1 x no2 條件的數字列表
        /// </summary>
        List<int> _allNoExcept3 = new List<int>();  

        /// <summary>
        /// 最後結果的數字列表
        /// </summary>
        List<int> _allNoRemained = new List<int>();

        /// <summary>
        /// 取得所有數字列表
        /// </summary>
        public string AllNo
        {
            get
            {
                return getNoString(_allNo);
            }
        }

        /// <summary>
        /// 取得排除 no1 倍數的數字列表 
        /// </summary>
        public string No1
        {
            get
            {
                return getNoString(_allNoExcept1);
            }
        }

        /// <summary>
        /// 取得排除 no2 倍數的數字列表 
        /// </summary>
        public string No2
        {
            get
            {
                return getNoString(_allNoExcept2);
            }
        }

        /// <summary>
        /// 取得保留 no1 x no2 倍數的數字列表
        /// </summary>
        public string No3
        {
            get
            {
                return getNoString(_allNoExcept3);
            }
        }

        /// <summary>
        /// 取得最後符合條件設定的列表清單
        /// </summary>
        public string NoRemained
        {
            get
            {
                return getNoString(_allNoRemained);
            }
        }

        /// <summary>
        /// 取得符合條件設定的清單項目個數
        /// </summary>
        public int ValidCount
        {
            get
            {
                return _allNoRemained.Count;
            }
        }

        string getNoString(List<int> data)
        {
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < data.Count; i++)
            {
                res.Append(data[i].ToString() + ", ");
            }
            return res.Remove(res.Length - 2, 2).ToString();
        }

        public AnsTwo(int inNo)
        {
            _no = inNo;
        }

        /// <summary>
        /// 移除 no1 倍數的數字, 移除 no2 倍數的數字, 保留 no1 x no2 倍數數字
        /// </summary>
        /// <param name="no1">要移除的數字1</param>
        /// <param name="no2">要移除的數字2</param>
        public void RemoveNo(int no1, int no2)
        {
            foreach (int no in _allNo)
            {
                if (no % no1 == 0 && no % (no1 * no2) != 0)
                    _allNoExcept1.Add(no);
                else if (no % no2 == 0 && no % (no1 * no2) != 0)
                    _allNoExcept2.Add(no);
                else
                    _allNoRemained.Add(no);
                if (no == (no1 * no2))
                    _allNoExcept3.Add(no);
            }
        }
    }

}
