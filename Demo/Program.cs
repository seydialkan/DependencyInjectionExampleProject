using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    #region DI Version 1 
    class Program
    {
        static void Main(string[] args)
        {
            CreditCard creditCard = new CreditCard();
            creditCard.Apply();
        }
    }

    public class CreditCard
    {
        ApplyFromBranch Branch;

        public CreditCard()
        {
            Branch = new ApplyFromBranch();
        }
        public void Apply()
        {
            Console.WriteLine(Branch.Apply());
            Console.ReadLine();
        }
    }

    public class ApplyFromBranch
    {
        public string Apply()
        {
            //Call Services or business class
            return "Successfull Applied From Branch.";
        }
    }

    #endregion

}
