using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//4. Любое количество чисел с любым оператором
namespace Calculator.Сalculator
{
    internal class Calculator4newMaks2
    {
        //метод, возращающий на консоль собщения для пользователя
        public void GetMessage()
        {
            Console.WriteLine("Введите выражение, которое хотите посчитать. Доступные операторы:\n" +
                "+  -   *   /   %");
            var matExpression = Console.ReadLine();
            var result = GetResult(matExpression);
            Console.WriteLine($"Выражение: {matExpression}\nРезультат: {result}");
        }
        //метод, который возвращает лист операторов и лист чисел из строки полученной с консоли
        public void GetListOperatorsAndValues(string expression,out List<string> listOperators, out List<string> listNumbers)
        {
            char[] numbersInChar = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            char[] operatorsInChar = { '+', '-', '*', '/', '%' };
            //полчучаю лист чисел тип строка
            listNumbers = expression.Split(operatorsInChar).ToList();
            //тк цифры в строке повторяются, то в массив будут записанны элементы со значением empty, поэтому нужно их отсеить прежде чем создать лист
            //операторов
            var massOperators = expression.Split(numbersInChar);
            //Передаем листу операторов нужные значения
            listOperators = new List<string>();
            foreach(var matOperator in massOperators)
            {
                if (matOperator != String.Empty)
                {
                    listOperators.Add(matOperator);
                }
            }
        }
        //метод, который возвращает результат выражения
        public string GetResult(string expression)
        {
            GetListOperatorsAndValues(expression,out List<string> listOperators, out List<string> listNumbers);
            //так как арифметические операции имеют разный приоритет и все они левоассоциативны, то в данном случае я решил приумать цикл, который 
            //учтет эти ограничения и пройдется по листам чисел и операций только один раз
            for (int i = 0; i < listOperators.Count;)
            {
                //если первый оператор в листе равен  *, / или %, то операцию над числами соседствующими с этим оператором
                if (listOperators[i] != "+" && listOperators[i] != "-")
                {
                    GetNewListOperatorsAndValues(0, listNumbers, listOperators, out listNumbers, out listOperators);
                }
                //дальше, если второй оператор исходного выражения равен + или -, то мы в любом случае можем сразу провести операцию над числами,
                //которые соседствуют с первым оператором выражения 
                else if (listOperators.Count == 1 || listOperators[i + 1] == "+" || listOperators[i + 1] == "-")
                {
                    GetNewListOperatorsAndValues(0, listNumbers, listOperators, out listNumbers, out listOperators);
                }
                //в этот блок мы попадаем, если первый оператор равен + или -, а втрой оператор выражения отличен от раннее представленных, те прежде 
                //чем сложить или вычесть первое число от второго, нам нужно получить результат умножения, деления или получения остатка операции 
                //над вторым и третим числом выражениячс
                else
                {                   
                    GetNewListOperatorsAndValues(1, listNumbers, listOperators, out listNumbers, out listOperators);
                }
            }
            return listNumbers[0];
        }
        //Метод, который возвращает измененный лист операторов и чисел вытащенных из исходного выражения 
        public void GetNewListOperatorsAndValues(int index,List<string> oldListNumbers,List<string> oldListOperators,
            out List<string> newListNumbers,out List<string> newListOperators)
        {
            //проводим операцию над двумя операндами, обновляем значение первого операнда и удаляем из листа уже не нужные числа и операторы
            oldListNumbers[index] = GetResultOperation(oldListOperators[index], oldListNumbers[index], oldListNumbers[index + 1]);
            oldListOperators.RemoveAt(index);
            oldListNumbers.RemoveAt(index + 1);
            newListNumbers = oldListNumbers;
            newListOperators = oldListOperators;
        }
        //метод, который возвращает результат операции произведенный над двумя операндами
        public string GetResultOperation(string operationString, string number1, string number2)
        {
            int number1int = Convert.ToInt32(number1);
            int number2int = Convert.ToInt32(number2);
            int result = 0;
            string strResult = "";
            switch (operationString)
            {
                case "+":
                    {
                        result = number1int + number2int;
                        strResult = Convert.ToString(result);
                        return strResult;
                    }
                case "-":
                    {
                        result = number1int - number2int;
                        strResult = Convert.ToString(result);
                        return strResult;
                    }
                case "*":
                    {
                        result = number1int * number2int;
                        strResult = Convert.ToString(result);
                        return strResult;
                    }
                case "/":
                    {
                        result = number1int / number2int;
                        strResult = Convert.ToString(result);
                        return strResult;
                    }
                case "%":
                    {
                        result = number1int % number2int;
                        strResult = Convert.ToString(result);
                        return strResult;
                    }
                default:
                    {
                        throw new Exception("Неизвестная операция.");
                    }
            }
        }
    }
}
