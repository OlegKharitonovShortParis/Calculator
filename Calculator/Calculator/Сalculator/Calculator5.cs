using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//5. Любое количество чисел с любым оператором и со скобками
namespace Calculator.Сalculator
{
    internal class Calculator5
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
        private void GetListOperatorsAndValues(string expression, out List<string> listOperators, out List<string> listNumbers)
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
            foreach (var matOperator in massOperators)
            {
                if (matOperator != String.Empty)
                {
                    listOperators.Add(matOperator);
                }
            }
        }
        //метод, который возвращает результат выражения ограниченного скобками
        private string GetResultExpressionInParentheses(List<string> listOperators, List<string> listNumbers)
        {
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
        private void GetNewListOperatorsAndValues(int index, List<string> oldListNumbers, List<string> oldListOperators,
            out List<string> newListNumbers, out List<string> newListOperators)
        {
            //проводим операцию над двумя операндами, обновляем значение первого операнда и удаляем из листа уже не нужные числа и операторы
            oldListNumbers[index] = GetResultOperation(oldListOperators[index], oldListNumbers[index], oldListNumbers[index + 1]);
            oldListOperators.RemoveAt(index);
            oldListNumbers.RemoveAt(index + 1);
            newListNumbers = oldListNumbers;
            newListOperators = oldListOperators;
        }
        //метод, который возвращает результат операции произведенный над двумя операндами
        private string GetResultOperation(string operationString, string number1, string number2)
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
        //метод, который возвращает результат выражения полученного от пользователя
        private string GetResult(string expression)
        {
            List<string> listNumbers = new List<string>();
            List<string> listOperators;
            string result = "";
            while(result==string.Empty)
            {
                int indexFirstParantheses = expression.IndexOf(')');
                if (indexFirstParantheses == -1)
                {
                    GetListOperatorsAndValues(expression, out listOperators, out listNumbers);
                    result = GetResultExpressionInParentheses(listOperators, listNumbers);
                }
                else if (indexFirstParantheses != -1)
                {
                    //-3 так как длина строки в скобках минимум будет равна 3 элементам в идеальних условиях
                    for (int i = indexFirstParantheses-4; i > -1; i--)
                    {
                        if (expression[i] == '(')
                        {
                            string expressionInParentheses = expression.Substring(i + 1, indexFirstParantheses - i - 1);
                            GetListOperatorsAndValues(expressionInParentheses, out listOperators, out listNumbers);
                            var resultExpressionInParentheses = GetResultExpressionInParentheses(listOperators, listNumbers);
                            expression = expression.Remove(i, indexFirstParantheses-i+1);
                            expression = expression.Insert(i, resultExpressionInParentheses);
                            indexFirstParantheses=expression.IndexOf(')');
                            i = indexFirstParantheses - 4;
                        }
                    }
                }
            }
            return result;
        }
    }
}
