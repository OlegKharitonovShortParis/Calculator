using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 4. Любое количество чисел с любым оператором
/// </summary>
namespace Calculator.Сalculator
{
    internal class Calculator4newMaks2
    {
        /// <summary>
        /// метод, возращающий на консоль собщения для пользователя
        /// </summary>
        public void CalculateForUserInput()
        {
            Console.WriteLine("Введите выражение, которое хотите посчитать. Доступные опураторы match");
            var matExpression = Console.ReadLine();
            var result = GetCalculationResult(matExpression);
            Console.WriteLine($"Выражение: {matExpression}\nРезультат: {result}");
        }
        /// <summary>
        /// метод, который возвращает экзепляр типа, который представляет хранилище чисел и операторов, 
        /// полученных из строки полученной с консоли
        /// </summary>
        private StorageNumbersAndOperators GetStorageNumbersAndOperators(string expression)
        {
            CheckingEmpty(expression);
            var storage=new StorageNumbersAndOperators();
            char[] numbersInChar = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            char[] operatorsInChar = { '+', '-', '*', '/', '%' };
            /// <summary>
            /// полчучаю лист чисел тип строка
            /// </summary>
            storage.Numbers = expression.Split(operatorsInChar).ToList();
            ///<summary>
            ///тк цифры в строке повторяются, то в массив будут записанны элементы со значением empty, поэтому нужно их отсеить 
            ///прежде чем создать лист операторов
            /// </summary>
            var massOperators = expression.Split(numbersInChar);
            ///<summary>
            ///Передаем листу операторов нужные значения
            ///</summary>
            storage.Operators = new List<string>();
            foreach(var matOperator in massOperators)
            {
                if (matOperator != String.Empty)
                {
                    storage.Operators.Add(matOperator);
                }
            }
            return storage;
        }
        /// <summary>
        /// метод, который возвращает результат выражения
        /// </summary>
        private string GetCalculationResult(string expression)
        {
            CheckingEmpty(expression);
            var storage=GetStorageNumbersAndOperators(expression);
            ///<summary>
            ///так как арифметические операции имеют разный приоритет и все они левоассоциативны, то в данном случае я решил 
            ///приумать цикл, который учтет эти ограничения и пройдется по листам чисел и операций только один раз
            /// </summary>
            int index=0;
            while (index < storage.Operators.Count)
            {
                ///<summary>
                ///если первый оператор в хранилище равен  *, / или %, то проводим операцию над числами соседствующими с этим оператором
                /// </summary>
                if (storage.Operators[index] != "+" && storage.Operators[index] != "-")
                {
                    storage=GetNewStorageNumbersAndOperators(0, storage);
                }
                ///<summary>
                ///дальше, если второй оператор хранилища равен + или -, то мы в любом случае можем сразу провести 
                ///операцию над числами,которые соседствуют с первым оператором выражения 
                /// </summary>
                else if (storage.Operators.Count == 1 || storage.Operators[index + 1] == "+" || storage.Operators[index + 1] == "-")
                {
                    storage=GetNewStorageNumbersAndOperators(0, storage);
                }
                ///<summary>
                ///в этот блок мы попадаем, если первый оператор равен + или -, а втрой оператор выражения отличен от раннее 
                ///представленных, те прежде чем сложить или вычесть первое число от второго, нам нужно получить результат 
                ///умножения, деления или получения остатка операции над вторым и третим числом выражениячс
                /// </summary>
                else
                {
                    storage=GetNewStorageNumbersAndOperators(1, storage);
                }
            }
            return storage.Numbers[0];
        }
        /// <summary>
        /// /Метод, который возвращает измененное хранилище 
        /// </summary>
        private StorageNumbersAndOperators GetNewStorageNumbersAndOperators(int index, StorageNumbersAndOperators storage)
        {
            ///<summary>
            ///проводим операцию над двумя операндами, обновляем значение первого операнда и удаляем из хранилища уже не нужные 
            ///числа и операторы
            /// </summary>
            storage.Numbers[index] = GetResultOfOperation(storage.Operators[index], storage.Numbers[index], storage.Numbers[index+1]);
            storage.Operators.RemoveAt(index);
            storage.Numbers.RemoveAt(index+1);
            
            return storage;
        }
        /// <summary>
        /// метод, который возвращает результат операции произведенный над двумя операндами
        /// </summary>
        private string GetResultOfOperation(string operationString, string number1, string number2)
        {
            CheckingEmpty(operationString);
            CheckingEmpty(number1);
            CheckingEmpty(number2);
            var number1int = Convert.ToInt32(number1);
            var number2int = Convert.ToInt32(number2);
            var result = 0;
            string strResult = "";
            switch (operationString)
            {
                case "+":
                    {
                        result = number1int + number2int;
                        break;
                    }
                case "-":
                    {
                        result = number1int - number2int;
                        break;
                    }
                case "*":
                    {
                        result = number1int * number2int;
                        break;
                    }
                case "/":
                    {
                        result = number1int / number2int;
                        break;
                    }
                case "%":
                    {
                        result = number1int % number2int;
                        break;
                    }
                default:
                    {
                        throw new Exception("Неизвестная операция.");
                    }
            }
            return strResult = Convert.ToString(result);
        }
        /// <summary>
        /// Метод для проверки выражения
        /// </summary>
        private void CheckingEmpty(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                throw new Exception("The expression is empty.");
            }
        }
    }
}
