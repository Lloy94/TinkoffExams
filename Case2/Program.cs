using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Case2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program s = new Program();
            string num1 = s.GetNum();
            int x = s.Num(num1);
            for (int i = 0; i < x; i++)
            {
                s.GetCommand();
            }
            s.MaxCount();
        }    
            
       void MaxCount()
        {
            int j = 0;
            for (int i = 1; i < Commands.Count(); i++)
            {
                if (Commands[i]==Commands[i-1])
                    j++;
            }
            if (j > 0)
                j++;
            Console.WriteLine($"{j}");
        }
        void CommandErrorMsg()
        {
            Console.WriteLine("неверно задана команда");
        }

        void ErrorMsg()
        {
            Console.WriteLine("введенное количество комманд неверно");
        }

        bool Error(int i)
        {
            if (Commands.Count() == i)
                return true;
            else return false;
        }

        List<string> Commands = new List<string>();
        void GetCommand()
        {
            Console.WriteLine("Введите комманду, в команде должно быть 3 человека");
            string s = Console.ReadLine();
            string[] text = s.Split(' ');
            var regex = new Regex(@"[A-Z]");
            if (text.Length!=3)
            { 
                CommandErrorMsg();
                GetCommand();
            }            
            foreach (var name in text)
            {
               
                if (!regex.IsMatch(name))
                {
                    CommandErrorMsg();
                    GetCommand();
                }
            }
            text.OrderBy(p => p);
            string command="";
            foreach (var com in text)
                command += com;
            Commands.Add(command);
        }

        void NumErrorMsg()
        {
            Console.WriteLine("введеное число должно быть в диапазоне от 1 до 10^3");
        }

        string GetNum()
        {
            Console.WriteLine("введите число от 1 до 10^3");
            string s = Console.ReadLine();
            return s;
        }

        int Num(string s)
        {
            bool success = int.TryParse(s, out int i);
            if (success)
            {
                if (i >= 1 && i <= Math.Pow(10,3))
                    return i;
                else
                {
                    NumErrorMsg();
                    s = GetNum();
                    return Num(s);
                }
            }
            NumErrorMsg();
            s = GetNum();
            return Num(s);
        }
    }
}

