using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prectice
{
    class press
    {

        //利用二叉树原理来建立四则运算
        private press h = null;//节点的父节点
        private press l = null;//左枝
        private press r = null;//右枝
        private bool isRight;//右节点
        private bool isLeft;//左节点
        private string p;// 所在节点的符号
        public float value = 0;//初始值为0
        private static string[] c = { "+", "-", "*", "/" };
        private static Random ra = new Random();
        public float createpress(int number = 3)
        {
            if (number == 1)
            {

                //当为第一层时，生成随机四个数
                value = ra.Next(0, 10);
                p = value.ToString();

                //第二层为*/;
                if (this.h.isRight == true && (this.h.h.p == "*" || this.h.h.p == "/"))
                {
                    if (isLeft == true)
                        p = "(" + p;
                    else
                        p = p + ")";
                }

                else//第二层为+-;
                {
                    if (this.h.p == "+" || this.h.p == "-")
                    {
                        if (isLeft == true)
                            p = "(" + p;
                        else
                            p = p + ")";
                    }

                }
                return value;

            }
            int a = ra.Next(4);
            p = c[a];
            l = new press();
            r = new press();

            l.isLeft = true;
            r.isRight = true;
            l.h = this;
            r.h = this;
            float f1, f2;
            switch (p)
            {
                case "+":
                    value = l.createpress(number - 1) + r.createpress(number - 1);
                    break;
                case "-":
                    do
                    {
                        value = l.createpress(number - 1) - r.createpress(number - 1);
                    }
                    while (value < 0);

                    break;

                case "*":
                    value = l.createpress(number - 1)*r.createpress(number - 1);
                    break;
                case "/":
                    do
                    {
                        f1 = r.createpress(number - 1);
                        f2 = l.createpress(number - 1);
                        {
                            continue;
                        }
                        value = f1 / f2;
                    } while (value < 0 || f1 % f2 != 0);
                    break;
            }
            return value;
        }

        // private void ReadLine(string v)
        // {
        //    throw new NotImplementedException();
        //}

        public string getpress()
        {
            if (this.l != null && this.r != null)
                return this.l.getpress() + this.p + this.r.getpress();
            else
                return p.ToString();
        }
    }
    class Program
    {
        private static object convert;

        public static void Main(string[] args)
        {
            press e = new press();
            StringBuilder d = new StringBuilder();
            Console.WriteLine("请输入所需题数");
            int t1 = int.Parse(Console.ReadLine());

            //Console.WriteLine("请输入所需题数");
            // String t1 = Console.ReadLine();//获取用户输入数值
            int i = 0;
            e.createpress();
            do
            {
                e.createpress();
                if (e.value < 0)
                    e.createpress();
                else
                {
                    i++;
                    string s = e.getpress() + "="/*+ e.value*/;
                    Console.WriteLine(s);
                    d.AppendLine(s);
                    Console.WriteLine("输入答案");
                    int t2 = int.Parse(Console.ReadLine());
                    if (e.value != t2)
                    {
                        Console.WriteLine("is wrong");
                    }
                    else
                    {
                        Console.WriteLine("is right");
                    }
                }
            }
            while (i < t1);
            FileStream fs = new FileStream(Environment.CurrentDirectory + "Answer.txt", FileMode.OpenOrCreate);
            StreamWriter sn = new StreamWriter(fs);
            sn.WriteLine(d.ToString());
            sn.Close();
        }
    }
}
