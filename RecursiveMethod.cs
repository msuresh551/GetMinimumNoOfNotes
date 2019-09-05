using AutomaticCashMachine.BaseClasses;
using System;
using System.Linq;

namespace AutomaticCashMachine
{
    public class RecursiveMethod
    {
        Container container;
        public RecursiveMethod()
        {
            container = new Container();
        }
        public ResultSet LeastNoofDenominations(int[] Coins, int amount, ResultSet objResultSet = null)
        {
            int yourAmount = amount;
            ResultSet resultSet;
            resultSet = objResultSet ?? container.GetInstance<ResultSet>();
            try
            {
                resultSet.NoteCounter = new int[Coins.Length];
                resultSet.ActualAmount = 0;
                for (int i = 0; i < Coins.Length; i++)
                {
                    if (amount >= Coins[i])
                    {
                        resultSet.NoteCounter[i] = amount / Coins[i];
                        amount = amount - resultSet.NoteCounter[i] * Coins[i];
                        resultSet.ActualAmount = resultSet.NoteCounter[i] * Coins[i] + resultSet.ActualAmount;
                    }
                }
                if (resultSet.ActualAmount == yourAmount)
                {
                    resultSet.IsAmountSetteled = true;
                }
                else
                {
                    if (Coins.Count() > 1)
                    {
                        resultSet.NoOfElementstoskip += 1;
                        return LeastNoofDenominations(Coins.Skip(1).ToArray(), yourAmount, resultSet); ;
                    }
                }
            }
            catch (Exception)
            {
            }
            return resultSet;
        }
    }
}
