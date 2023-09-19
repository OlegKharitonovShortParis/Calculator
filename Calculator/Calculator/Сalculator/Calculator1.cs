using Calculator.MyInteraface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Сalculator
{
    internal class Calculator1 : ICalculator
    {
        /// <summary>
        /// Зачем это вынесено в отедельный метод?
        /// </summary>
        public void GetMessage()
        {
            Console.WriteLine("Вы вошли в програму пользования калькулятора\nПока у вась есть возможность посчитать только два числа" +
                "\nНо дальше я допилю еще и возможность пользоваться другими математическими операциями");
        }

        /// <summary>
        /// Предполагалось, что два числа будут даны в едином выражении типо пользователь вводит "2 + 4", в ответ видит ответ.
        /// </summary>
        public void GetResult()
        {
            GetMessage();
            Console.WriteLine("Введите первое число");
            var number1int=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число.");
            var number2int=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Результат выражения: {number1int} + {number2int}={number1int+number2int}");
        }
    }
}
