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
        public string PartA(string inStr)
        {
            StringBuilder strBuilder = new StringBuilder();
            for (int i = inStr.Length - 1; i >= 0; i--)
            {
                strBuilder.Append(inStr[i]);
            }
            return strBuilder.ToString();
        }

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

    class AnsTwo
    {
        int _no = 0;

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

        List<int> _allNoExcept1 = new List<int>();
        List<int> _allNoExcept2 = new List<int>();
        List<int> _allNoExcept3 = new List<int>();
        List<int> _allNoRemained = new List<int>();

        public string AllNo
        {
            get
            {
                return getNoString(_allNo);
            }
        }

        public string No1
        {
            get
            {
                return getNoString(_allNoExcept1);
            }
        }

        public string No2
        {
            get
            {
                return getNoString(_allNoExcept2);
            }
        }

        public string No3
        {
            get
            {
                return getNoString(_allNoExcept3);
            }
        }

        public string NoRemained
        {
            get
            {
                return getNoString(_allNoRemained);
            }
        }

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

        public void RemoveNo(int no1, int no2)
        {
            foreach (int no in _allNo)
            {
                if (no % no1 == 0 && no != (no1 * no2))
                    _allNoExcept1.Add(no);
                else if (no % no2 == 0 && no != (no1 * no2))
                    _allNoExcept2.Add(no);
                else
                    _allNoRemained.Add(no);
                if (no == (no1 * no2))
                    _allNoExcept3.Add(no);
            }
        }
    }

}
