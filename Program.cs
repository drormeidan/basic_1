using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;

namespace BasicProject_1
{
    class Program
    {
        public void SubmitInvitation(Dictionary<string, int> ExtraPrices, Dictionary<int, string> IdxExtra, ref Dictionary<int, string> IdxMeat, ref Dictionary<int, string> IdxBread, ref Dictionary<string, int> ExtraAmount, ref Dictionary<string, int> MeatAmount, ref Dictionary<string, int> BreadAmount,ref Dictionary<int,Worker> IdxWorker)
        {
            Console.WriteLine("Welcome to Hamburger resturant");
            List<Hamburger> hamburgers = new List<Hamburger>();
            List<Salad> salads = new List<Salad>();
            int contD = new int();
            contD = 1;
            int smeat = new int();
            List<int> sextras = new List<int>();
            int sbread = new int();
            int contE = new int();
            int HoS = new int();
            int ssize = new int();

            while (Convert.ToBoolean(contD))
            {
                Console.WriteLine("0-salad 1-Hamburger");
                HoS = Convert.ToInt32(Console.ReadLine());

                if (Convert.ToBoolean(HoS)) 
                {
                    foreach (KeyValuePair<int, string> valuePair in IdxMeat)
                    {
                        if (MeatAmount[valuePair.Value] > 0)
                        {
                            Console.WriteLine("{0} -{1}", valuePair.Key, valuePair.Value);
                        }
                    }
                    smeat = Convert.ToInt32(Console.ReadLine());
                    //Console.WriteLine("choose bread: 0- brown, 1-white");
                    foreach (KeyValuePair<int, string> valuePair in IdxBread)
                    {
                        if (BreadAmount[valuePair.Value] > 0)
                        {
                            Console.WriteLine("{0} -{1}", valuePair.Key, valuePair.Value);
                        }
                    }
                    sbread = Convert.ToInt32(Console.ReadLine());
                    contE = 1;
                    while (Convert.ToBoolean(contE))
                    {
                        foreach (KeyValuePair<int, string> valuePair in IdxExtra)
                        {
                            if (ExtraAmount[valuePair.Value] > 0)
                            {
                                Console.WriteLine("{0} -{1}", valuePair.Key, valuePair.Value);
                            }
                        }
                        sextras.Add(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("add extra?: 0-No, 1-Yes");
                        contE = Convert.ToInt32(Console.ReadLine());
                    }

                    hamburgers.Add(new Hamburger(smeat, sextras, sbread));

                }
                else 
                {
                    Console.WriteLine("choose size: 0- small, 1-medium, 2-big");
                    ssize = Convert.ToInt32(Console.ReadLine());
                    contE = 1;
                    while (Convert.ToBoolean(contE))
                    {
                        foreach (KeyValuePair<int, string> valuePair in IdxExtra)
                        {
                            if (ExtraAmount[valuePair.Value] > 0)
                            {
                                Console.WriteLine("{0} -{1}", valuePair.Key, valuePair.Value);
                            }
                        }
                        sextras.Add(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("add extra?: 0-No, 1-Yes");
                        contE = Convert.ToInt32(Console.ReadLine());
                    }

                    salads.Add(new Salad(sextras,ssize));

                }



                sextras = new List<int>();
                sextras.Clear();
                Console.WriteLine("add diner?: 0-No, 1-Yes");
                contD = Convert.ToInt32(Console.ReadLine());
            }

            int Tprice = new int();
            Tprice = 0;
            foreach (Hamburger item in hamburgers)
            {
                item.ReduceAmmount(ref IdxExtra, ref IdxMeat, ref IdxBread, ref ExtraAmount, ref MeatAmount, ref BreadAmount);
                Tprice += item.price(ExtraPrices, IdxExtra);
            }

            foreach (Salad item in salads)
            {
                item.ReduceAmmount(ref IdxExtra, ref ExtraAmount);
                Tprice += item.price();
            }

            Console.WriteLine("submit the serving worker");
            foreach (KeyValuePair<int, Worker> valuePair in IdxWorker)
            {
                Console.WriteLine("{0} -{1}", valuePair.Key, valuePair.Value.name);
            }
            int servingWorker = new int();
            servingWorker = Convert.ToInt32(Console.ReadLine());
            IdxWorker[servingWorker].NumInvetation += 1;

            Console.WriteLine("The total price");
            Console.WriteLine(Tprice);

        }

        public void ManagerRules(ref Dictionary<string, int> ExtraPrices, ref Dictionary<int, string> IdxExtra)
        {
            int IdxOperation = new int();
            int COperation = new int();
            int ExtraChange = new int();
            int PriceChange = new int();
            string NewExtraName = new string("aaa");
            int NewExtraPrice = new int();
            COperation = 1;
            while (Convert.ToBoolean(COperation))
            {
                Console.WriteLine("choose operation: 0-change extra prices, 1-new extra");
                IdxOperation = Convert.ToInt32(Console.ReadLine());
                switch (IdxOperation)
                {
                    case 0:
                        Console.WriteLine("choose which extra to change:");
                        foreach (KeyValuePair<int, string> valuePair in IdxExtra)
                        {
                            Console.WriteLine("{0} -{1}", valuePair.Key, valuePair.Value);
                        }
                        ExtraChange = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("new price:");
                        PriceChange = Convert.ToInt32(Console.ReadLine());
                        ExtraPrices[IdxExtra[ExtraChange]] = PriceChange;
                        break;

                    case 1:
                        Console.WriteLine("the name of the new extra:");
                        NewExtraName = Console.ReadLine();
                        Console.WriteLine("the price of new extra:");
                        NewExtraPrice = Convert.ToInt32(Console.ReadLine());
                        ExtraPrices.Add(NewExtraName, NewExtraPrice);
                        IdxExtra.Add(IdxExtra.Count, NewExtraName);
                        break;
                }

                Console.WriteLine("add operation?: 0-No, 1-Yes");
                COperation = Convert.ToInt32(Console.ReadLine());

            }

        }

        public void WorkersRules(ref Dictionary<int, string> IdxExtra, ref Dictionary<int, string> IdxMeat, ref Dictionary<int, string> IdxBread, ref Dictionary<string, int> ExtraAmount, ref Dictionary<string, int> MeatAmount, ref Dictionary<string, int> BreadAmount)
        {
            int Ckind = new int();
            int AddAmount = new int();
            int CAmount = new int();
            Console.WriteLine("hello worker, choose kind to add amount: 0-meat, 1-extra, 2-bread");
            Ckind = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("new amount");
            AddAmount = Convert.ToInt32(Console.ReadLine());


            switch (Ckind)
            {
                case 0:
                    Console.WriteLine("choose which meat to add amount:");
                    foreach (KeyValuePair<int, string> valuePair in IdxMeat)
                    {
                        Console.WriteLine("{0} -{1}", valuePair.Key, valuePair.Value);
                    }
                    CAmount = Convert.ToInt32(Console.ReadLine());
                    MeatAmount[IdxMeat[CAmount]] += AddAmount;
                    break;

                case 1:
                    Console.WriteLine("choose which extra to add amount:");
                    foreach (KeyValuePair<int, string> valuePair in IdxExtra)
                    {
                        Console.WriteLine("{0} -{1}", valuePair.Key, valuePair.Value);
                    }
                    CAmount = Convert.ToInt32(Console.ReadLine());
                    ExtraAmount[IdxExtra[CAmount]] += AddAmount;
                    break;

                case 2:
                    Console.WriteLine("choose which bread to add amount:");
                    foreach (KeyValuePair<int, string> valuePair in IdxMeat)
                    {
                        Console.WriteLine("{0} -{1}", valuePair.Key, valuePair.Value);
                    }
                    CAmount = Convert.ToInt32(Console.ReadLine());
                    BreadAmount[IdxBread[CAmount]] += AddAmount;
                    break;
            }
        }

        public void ManageWorker(ref Dictionary<int,Worker> IdxWorker) 
        {
            int HoF = new int(); // hire or fire
            int Wfire = new int();
            Console.WriteLine("0- hire, 1- fire");
            HoF = Convert.ToInt32(Console.ReadLine());
            if (Convert.ToBoolean(HoF)) 
            {
                Console.WriteLine("choose which worker to fire");
                foreach (KeyValuePair<int, Worker> valuePair in IdxWorker)
                {
                    Console.WriteLine("{0} -{1}", valuePair.Key, valuePair.Value.name);
                }
                Wfire = Convert.ToInt32(Console.ReadLine());
                IdxWorker.Remove(Wfire);
            }
            else 
            {
                Console.WriteLine("hire worker");
                Console.WriteLine("submit name");
                string sname = new string("aaa");
                sname = Console.ReadLine();
                Console.WriteLine("submit seniority");
                int sseniority = new int();
                sseniority = Convert.ToInt32(Console.ReadLine());
                IdxWorker.Add(IdxWorker.Keys.Last() + 1, new Worker(sname, sseniority));
            }

        }
        static void Main(string[] args)
        {
            Dictionary<string, int> ExtraPrices = new Dictionary<string, int>();
            ExtraPrices.Add("cucambers", 0);
            ExtraPrices.Add("tomato", 0);
            ExtraPrices.Add("lettuce", 0);
            ExtraPrices.Add("pickels", 0);
            ExtraPrices.Add("onion", 0);
            Dictionary<int, string> IdxExtra = new Dictionary<int, string>();
            IdxExtra.Add(0, "cucambers");
            IdxExtra.Add(1, "tomato");
            IdxExtra.Add(2, "lettuce");
            IdxExtra.Add(3, "pickels");
            IdxExtra.Add(4, "onion");
            Dictionary<int, string> IdxMeat = new Dictionary<int, string>();
            IdxMeat.Add(0, "meat");
            IdxMeat.Add(1, "lamb");
            IdxMeat.Add(2, "tofo");
            Dictionary<int, string> IdxBread = new Dictionary<int, string>();
            IdxBread.Add(0, "brown");
            IdxBread.Add(1, "white");

            Dictionary<int, Worker> IdxWorker = new Dictionary<int, Worker>();
            IdxWorker.Add(0, new Worker("dror meidan", 1));
            IdxWorker.Add(1, new Worker("ori cohen", 3));

            Dictionary<string, int> ExtraAmount = new Dictionary<string, int>();
            foreach (KeyValuePair<int, string> valuePair in IdxExtra)
            {
                ExtraAmount.Add(valuePair.Value, 10);
            }

            Dictionary<string, int> BreadAmount = new Dictionary<string, int>();
            foreach (KeyValuePair<int, string> valuePair in IdxBread)
            {
                BreadAmount.Add(valuePair.Value, 10);
            }

            Dictionary<string, int> MeatAmount = new Dictionary<string, int>();
            foreach (KeyValuePair<int, string> valuePair in IdxMeat)
            {
                MeatAmount.Add(valuePair.Value, 10);
            }


            Program p = new Program();
            //p.ManagerRules(ref ExtraPrices, ref IdxExtra);
            //foreach (KeyValuePair<string, int> valuePair in MeatAmount)
            //{
            //    Console.WriteLine("{0} -{1}", valuePair.Key, valuePair.Value);
            //}

            //Console.WriteLine(ExtraPrices["tomato"]);
            // p.WorkersRules(ref IdxExtra, ref IdxMeat, ref IdxBread, ref ExtraAmount, ref MeatAmount, ref BreadAmount);

            //foreach (KeyValuePair<string, int> valuePair in MeatAmount)
            //{
            //    Console.WriteLine("{0} -{1}", valuePair.Key, valuePair.Value);
            //}
            p.ManageWorker(ref IdxWorker);

            p.SubmitInvitation(ExtraPrices, IdxExtra, ref IdxMeat, ref IdxBread, ref ExtraAmount, ref MeatAmount, ref BreadAmount, ref IdxWorker);

            //foreach (KeyValuePair<string, int> valuePair in MeatAmount)
            //{
            //    Console.WriteLine("{0} -{1}", valuePair.Key, valuePair.Value);
            //}
        }
    }
}
