using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutDICodes
{
    #region Without DI
    class WithoutDI
    {
        static void Main1(string[] args)
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

namespace DICodeVersion1
{
    #region DI Version 1 

    namespace DIVersion1
    {


        class Program
        {
            static void Main2(string[] args)
            {
                CreditCard dm = new CreditCard(args[0].ToString());

                dm.Apply();
            }
        }


        public class CreditCard
        {
            string applySource;

            public CreditCard(string source)
            {
                applySource = source;

            }
            public void Apply()
            {
                if (applySource == "BRANCH")
                {
                    ApplyFromBranch branch = new ApplyFromBranch();
                    Console.WriteLine(branch.Apply());
                    Console.ReadLine();
                }
                else if (applySource == "CALLCENTER")
                {
                    ApplyFromCallCenter callCenter = new ApplyFromCallCenter();
                    Console.WriteLine(callCenter.Apply());
                    Console.ReadLine();
                }

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


        public class ApplyFromCallCenter
        {
            public string Apply()
            {
                //Call Services or business class
                return "Successfull Applied From CallCenter.";
            }
        }


    }

    #endregion
}

namespace DICode
{
    #region DI Code
    public interface IApplyCreditCard
    {
        string Apply();
    }


    class DICode
    {
        static void Main3(string[] args)
        {
            IApplyCreditCard _applyCreditCard;

            string source="";

            if (source.ToUpper() == "Branch")
            {
                _applyCreditCard = new ApplyFromBranch();
            }
            else if (source.ToUpper() == "CallCenter")
            {
                _applyCreditCard = new ApplyFromCallCenter();
            }
            else if (source.ToUpper() == "MobileApplication")
            {
                _applyCreditCard = new ApplyFromMobileApplication();
            }
            else
            {
                _applyCreditCard = new ApplyFromBranch();
            }

            CreditCard creditCard = new CreditCard(_applyCreditCard, source);
            creditCard.Apply();


        }
    }


    public class CreditCard
    {
        IApplyCreditCard IGLocal;
        string ApplicationSource;

        public CreditCard(IApplyCreditCard IG, string source)
        {
            IGLocal = IG;


        }
        public void Apply()
        {
            Console.WriteLine(IGLocal.Apply());

        }
    }

    public class ApplyFromBranch : IApplyCreditCard
    {
        public string Apply()
        {
            //Call Services or business class
            return "Successfull Applied From Branch.";
        }
    }


    public class ApplyFromCallCenter : IApplyCreditCard
    {
        public string Apply()
        {
            //Call Services or business class
            return "Successfull Applied From CallCenter.";
        }
    }

    public class ApplyFromMobileApplication : IApplyCreditCard
    {
        public string Apply()
        {
            //Call Services or business class
            return "Successfull Applied From MobileApplication.";
        }
    }

    #endregion
}
