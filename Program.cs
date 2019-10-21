using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // "3,5,7"
            int k = int.Parse(Console.ReadLine());
            int count = 0, b, a, len;
            List<int> fact = new List<int>();
            for (int i = 2; i < 1000; i++)
            {
                fact.Clear();
                a = i;
                for (b = 2; a > 1; b++)
                    if (a % b == 0)
                    {
                        fact.Add(b);
                        while (a % b == 0)
                        {
                            a /= b;
                        }
                    }
                len = fact.Count();
                remove_prime(ref fact);
                len = fact.Count();
                chek_valid( ref len, ref count);
                if (count == k)
                {
                    Console.WriteLine(i);
                    break;
                }

            }
            Console.ReadLine();
        }





        private static void chek_valid(ref int len, ref int count)
        {
            //int flag1 = 0;
            //for (int h = 0; h < len; h++)
            //if(len>0)
            //{
                //int flag = 0;
                //for (int g = 2; g <= fact.ElementAt(h); g++)
                //{
                //    if (fact.ElementAt(h) / g == 0)
                //    {
                //        flag = 1;
                //        break;
                //    }
                //}
               // if (flag == 0)//flag=0 means there is one more prime  so stop it there
                
                //    flag1 = 1;
                //    break;
                
            //}??
            if (len == 0)
            {
                count += 1;
            }
        }






        private static void remove_prime(ref List<int> fact)

        {
            string prime = ConfigurationManager.AppSettings["primeNumbers"];

            string[] tokens = prime.Split(',');
            List<int> configList = new List<int>();
            foreach (var num in tokens)
            {
                configList.Add(Convert.ToInt32(num));
            }
            foreach (int d in configList)
            {
                if (fact.Contains(d))
                {
                    fact.Remove(d);
                }

            }

        }



    }
}


    



