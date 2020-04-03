using System;

namespace ConsoleAppPM
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hell to World!");
            Console.WriteLine("Выберете операцию: 1 - INN с 10 символами; 2 - INN с 14 символами");
            int numChoice = Convert.ToInt32(Console.ReadLine());
            switch(numChoice)
            {
                case 1:               
                    Console.WriteLine("Напишите ваш INN");
                    int[] inn = new int[10];
                    DeclarArray(inn);
                    bool checkAnswer;
                    CheckINN(inn, out checkAnswer);
                    WriteAnswer(checkAnswer);
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
        static void WriteAnswer(bool x)
        {
            if (x == true)
                Console.WriteLine("INN верный");
            else
                Console.WriteLine("INN не верный");
        }
    }
}
