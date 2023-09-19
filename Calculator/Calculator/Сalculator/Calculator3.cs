using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Сalculator
{
    /// <summary>
    /// 3. Любое количество чисел с плюсом
    /// Названия методов ничего не говорят об их смысле
    /// </summary>
    internal class Calculator3
    {
        public void GetMessage3()
        {
            Console.WriteLine("Введите выражение, которое хотите посчитать (Сложение любого колличества чисел)");
            var expression=Console.ReadLine();
            var resultint=GetResult3(expression);
            Console.WriteLine($"Результат выражения:" +
                $"{expression}={resultint}");
        }
        public int GetResult3(string str)
        {
            var result = 0;
            int number = 0;
            int counter = 0;
            int firstNumberTurn = 0; // Лишние переменные
            int nextNumberTurn = 0; 
            // "322 / 228 + 8"
            foreach (var item in str) // Можно проще, либо через Split. Либо итерироваться до первого символа отличного от Char.IsDigit (игнорируем пробелы), перед этим запоминая все предществующие символы.
            { 
                if (int.TryParse(item.ToString(),out firstNumberTurn)&&counter==0)
                {
                    number = firstNumberTurn;
                    counter++;
                }
                else if(int.TryParse(item.ToString(), out nextNumberTurn) && counter>0)
                {
                    number = number * 10 + nextNumberTurn;
                }
                else
                {
                    counter = 0;
                    result += number;
                }
            }
            return result+number;
        }
    }
}
