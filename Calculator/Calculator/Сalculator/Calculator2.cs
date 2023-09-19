using Calculator.MyInteraface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Сalculator
{
    /// <summary>
    /// Названия методов ничего не говорят об их смысле
    /// </summary>
    internal class Calculator2
    {
        /// <summary>
        /// Зачем тут возвращать строку, когда можно вернуть число? Название параметра str - ничего не говорит о его смысле.
        /// </summary>
        public string GetResult2(string str, int number1, int number2)
        {
            string resultoperation = "";
            switch (str)
            {
                case "+":
                    {
                        return resultoperation = $"{number1 + number2}";
                        break; // Тут и дальше брейк не нужен, так как есть ретёрн. И зачем в return присваивание resultoperation?
                    }
                case "-":
                    {
                        return resultoperation = $"{number1 - number2}";
                        break;
                    }
                case "*":
                    {
                        return resultoperation = $"{number1 * number2}";
                        break;
                    }
                case "/":
                    {
                        return resultoperation = $"{number1 / number2}";
                        break;
                    }
                case "%":
                    {
                        return resultoperation = $"{number1 % number2}";
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Неизвестная операция"); // В целом можно и Exception тут выкинуть.
                        break;
                    }

            }
            return resultoperation;
        }
        public void GetMessage2()
        {
            // Аналогично Calc1 - ожидался другой интерфейс ввода
            Console.WriteLine("Введите первое число");
            var number1int = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите второе число.");
            var number2int = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ввведите оператор, операцию которого хотите провести. Варианты доступных операторов:\n" +
                "+,-,*,/,%");
            var operatorArif = Console.ReadLine(); // Лучше подойдёт ReadKey

            string resultoperation=GetResult2(operatorArif, number1int, number2int);
            Console.WriteLine($"Результат выражения: {number1int}{operatorArif}{number2int}={resultoperation}");
        }
    }
}
