using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutomaticCashMachine.BaseClasses;

namespace AutomaticCashMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello welcome to Automatic Cash Convert Machine ");
            Console.WriteLine("Please choose your method \n1. Iterative Method \n2. Recursive Method");
            GetBasicInformationFromTheUser();
            Console.WriteLine();
            Thread.Sleep(1000);
        }
        static void GetBasicInformationFromTheUser()
        {
            try
            {
                Container container = new Container();
                var iterative = container.GetInstance<IterativeMethod>();
                var recursive = container.GetInstance<RecursiveMethod>();
                var resultSet = container.GetInstance<ResultSet>();
                int temp, temp1,UserMethod, totalCash;

                List<int> liDenominations = new List<int>();
                UserMethod = GetUserInputAsInteger("your method");
                if (UserMethod != 1 && UserMethod != 2)
                {
                    Console.WriteLine("Invalid entry please choose correct option");
                    GetBasicInformationFromTheUser();
                }
                Console.WriteLine("Please enter number of denominators");
                temp = GetUserInputAsInteger("number of denominators");
                Console.WriteLine("Enter your cash denominators ");
                for (int i = 0; i < temp; i++)
                {
                    temp1 = GetUserInputAsInteger("your cash denominator");
                    liDenominations.Add(temp1);
                }
                Console.WriteLine("Please enter your money");
                totalCash = GetUserInputAsInteger("Money");
                liDenominations = liDenominations.OrderByDescending(x => x).ToList();

                if (UserMethod == 1)
                {
                    resultSet = iterative.LeastNoofDenominations(liDenominations.ToArray(), totalCash);
                }
                else
                {
                    resultSet = recursive.LeastNoofDenominations(liDenominations.ToArray(), totalCash);
                }

                liDenominations = liDenominations.Skip(resultSet.NoOfElementstoskip).ToList();
                Console.WriteLine("");
                if (resultSet.IsAmountSetteled)
                {   
                    Console.WriteLine("Please collect your minimum number of notes");
                    Console.WriteLine("");
                    for (int i = 0; i < liDenominations.Count; i++)
                    {
                        if (resultSet.NoteCounter[i] != 0)
                        {
                            Console.WriteLine(liDenominations[i] + " number of notes will be :  " + resultSet.NoteCounter[i]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No Solution Found! ");
                }
                Console.WriteLine();
                Console.WriteLine("1. Continue for more conversions");
                Console.WriteLine("Press any other integer(Not zero) to exit the application");

                temp = GetUserInputAsInteger("Valid (choose either 1 or 2) ");
                if(temp == 1)
                {
                    GC.Collect();
                    Console.WriteLine("Please choose your method \n1. Iterative Method \n2. Recursive Method");
                    GetBasicInformationFromTheUser();
                }
                else
                {
                    Console.WriteLine("Thank you");
                    GC.Collect();
                }
            }
            catch (Exception)
            {

            }
        }

        static int GetUserInputAsInteger(string reqMessage)
        {
            int returnInteger = 0;
            try
            {
                var userInput = Console.ReadLine();
                if (!int.TryParse(userInput.ToString(), out returnInteger))
                {
                    Console.WriteLine("Please enter " + reqMessage + " as Integer");
                    return GetUserInputAsInteger(reqMessage);
                }
                if(returnInteger == 0)
                {
                    Console.WriteLine("Zero(0) is not valid!");
                    Console.WriteLine("Please enter 1 or greater then 0");
                    return GetUserInputAsInteger(reqMessage);
                }

            }
            catch (Exception)
            {

            }
            return returnInteger;
        }
    }
}
