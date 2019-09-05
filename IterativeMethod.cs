using AutomaticCashMachine.BaseClasses;
using System;
using System.Linq;

namespace AutomaticCashMachine
{
    public class IterativeMethod
    {
        Container container;
        public IterativeMethod()
        {
            container = new Container();
        }
        public ResultSet LeastNoofDenominations(int[] Coins, int amount)
        {
            var cLenght = Coins.Length;
            ResultSet resultSet = container.GetInstance<ResultSet>();
            resultSet.NoteCounter = new int[Coins.Length];
            int yourAmount = amount;
            try
            {
                for (int j = 0; j < cLenght; j++)
                {
                    resultSet.ActualAmount = 0;
                    for (int i = 0; i < Coins.Length; i++)
                    {

                        if (amount >= Coins[i])
                        {
                            resultSet.NoteCounter[i] = amount / Coins[i];
                            amount -= resultSet.NoteCounter[i] * Coins[i];
                            resultSet.ActualAmount = resultSet.NoteCounter[i] * Coins[i] + resultSet.ActualAmount;
                        }
                    }
                    if (resultSet.ActualAmount == yourAmount)
                    {
                        resultSet.IsAmountSetteled = true;
                        break;
                    }
                    resultSet.NoOfElementstoskip += 1;
                    Coins = Coins.Skip(1).ToArray();
                    for (int i = 0; i < resultSet.NoteCounter.Length; i++)
                    {
                        resultSet.NoteCounter[i] = 0;
                    }
                    amount = yourAmount;
                }
            }
            catch (Exception)
            {
            }
            return resultSet;
        }
    }
}