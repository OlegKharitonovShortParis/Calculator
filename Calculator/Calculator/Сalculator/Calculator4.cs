using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//4. Любое количество чисел с любым оператором
//вроде не работает, не помню
namespace Calculator.Сalculator
{
    internal class Calculator4
    {
        public void GetMessage4()
        {
            Console.WriteLine("Введите выражение, результат которого хотите получить\n(доступные операторы:\n" +
                "+   -   *   /   %");
            var expression=Console.ReadLine();
            GetResult4(expression);
            Console.WriteLine();
            Console.WriteLine($"Выражение: {expression}\n Результат операций: ");
        }
        public void GetResult4(string expression)
        {
            var Numbers = new List<int>();
            var Operations=new List<char>();
            var firstNumberTurn = 0;
            var nextNumberTurn = 0;
            int count = 0;
            int number=0;
            foreach(var item in expression)
            {
                char[] operationsArif = new char[] { '-', '+', '/', '*', '%' };
                expression.Split(operationsArif);
                if(int.TryParse(item.ToString(),out firstNumberTurn) && count == 0)
                {
                    number = firstNumberTurn;
                    count++;
                }
                else if(int.TryParse(item.ToString(),out nextNumberTurn)&&count>0)
                {
                    number = number * 10 + nextNumberTurn;
                }
                else
                {
                    Operations.Add(item);
                    Numbers.Add(number);
                    count = 0;
                }
            }
            Numbers.Add(number);
        }
    }
}
