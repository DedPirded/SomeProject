﻿using System;

namespace ConsoleAppPM
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hell to World!");
            Console.WriteLine("Выберете операцию: 1 - INN с 10 символами; 2 - INN с 14 символами");
            int numChoice = Convert.ToInt32(Console.ReadLine());
            switch (numChoice)
            {
                case 1:
                    Console.WriteLine("Напишите ваш INN(писать по одному символу)");
                    int[] inn = new int[10];
                    DeclarArray(inn);
                    bool checkAnswer;
                    int year;
                    int day;
                    int month;
                    CheckINN(inn, out checkAnswer);
                    CheckBirthday(inn, out year, out month, out day);
                    WriteAnswer(checkAnswer, CheckSex(inn), year, month, day);
                    break;
                case 2:
                    Console.WriteLine("Данная функция пока не реализована");
                    break;

            }

        }
        static int[] DeclarArray(int[] x)          // Записываем INN в виде массива, где каждый элемент массива является одним символом   
        {
            for (int i = 0; i < 10; i++)
            {
                x[i] = Convert.ToInt32(Console.ReadLine());
            }
            return x;
        }
        static void CheckINN(int[] inn, out bool checkAnswer)
        {
            int[] koef = new int[9] { -1, 5, 7, 9, 4, 6, 10, 5, 7 }; // коэфиценты
            int sum = 0;       // далее операция перемножения коэфицентов и inn кода. Так как нам нужна сумма, будем сразу её присваивать переменной sum  
            for (int i = 0; i < inn.Length - 1; i++)
            {
                sum += inn[i] * koef[i];
            }
            //sum = sum / 11;
            if (sum % 11 == inn[9])   // проверка контрольного числа
                checkAnswer = true;
            else
                checkAnswer = false;

        }
        static void CheckBirthday(int[] inn, out int year, out int month, out int day)
        {
            year = 1900;
            day = 01;
            month = 01;
            int num = inn[0] * 10000 + inn[1] * 1000 + inn[2] * 100 + inn[3] * 10 + inn[4];
            while (num > 365)
            {
                if (year % 4 == 0)
                {
                    num -= 366;
                    year++;
                }
                else
                {
                    num -= 365;
                    year++;
                }
            }
            while (num > 30)
            {
                if (month == 2)
                {
                    num -= 28;
                    month++;
                }
                else
                {
                    if (month % 2 == 0)
                    {
                        num -= 30;
                        month++;
                    }
                    else
                    {
                        num -= 31;
                        month++;
                    }
                }
            }
            day += num;

            /*Console.WriteLine(num);
            Console.WriteLine(years);
            Console.WriteLine(month);
            Console.WriteLine(day);*/
        }
        static string CheckSex(int[] inn)
        {
            if (inn[8] % 2 == 0)
                return "Female";
            else
                return "Male";
        }
        static void WriteAnswer(bool x, string answerSex, int year, int month, int day)
        {
            if (x == true)
                Console.WriteLine("INN верный");
            else
                Console.WriteLine("INN не верный");
            Console.WriteLine("Пол - " + answerSex);
            Console.WriteLine($"День вашего рождения: {year}.{month}.{day}");
        }
    }
}
