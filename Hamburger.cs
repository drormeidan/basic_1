using System;
using System.Collections.Generic;

public class Hamburger
{
	public Hamburger(int smeat, List<int> sextras, int sbread, List<Sauce> ssauces)
	{
		this.meat = smeat;
		this.extras = sextras;
		this.bread = sbread;
		this.SauceList = ssauces;
	}
	public List<Sauce> SauceList { get; set; }
	public int meat { get; set; } // 0-meat, 1-lamb, 2-tofo
	public List<int> extras { get; set; } // 0-cucamber, 1-tomato, 2-lettuce, 3-pickels, 4-onion
	public int bread { get; set; } // 0- brown, 1-white
	public int price(Dictionary<string,int> ExtraPrices, Dictionary<int, string> IdxExtra) 
	{
		//Console.WriteLine(ExtraPrices["tomato"]);
		int rprice = new int();
		switch (this.meat) 
		{
			case 0:
				rprice=50;
				break;

			case 1:
				rprice=55;
				break;

			case 2:
				rprice =60;
				break;
		}

		//Console.WriteLine(this.extras.Count);
		foreach (int Iextra in this.extras) 
		{
			Console.WriteLine(Iextra);
			rprice += ExtraPrices[IdxExtra[Iextra]];
		}

		foreach (Sauce sau in this.SauceList) 
		{
			rprice += sau.price;
		}

		return rprice;
			
	}

	public void ReduceAmmount(ref List<Sauce> sauces, ref Dictionary<int, string> IdxExtra, ref Dictionary<int, string> IdxMeat, ref Dictionary<int, string> IdxBread, ref Dictionary<string, int> ExtraAmount, ref Dictionary<string, int> MeatAmount, ref Dictionary<string, int> BreadAmount) 
	{
		MeatAmount[IdxMeat[this.meat]] += -1;
		BreadAmount[IdxBread[this.bread]] += -1;
		foreach(int item in this.extras) 
		{
			ExtraAmount[IdxExtra[item]] += -1;
		}

		foreach(Sauce item in this.SauceList) 
		{
			foreach (Sauce sau in sauces)
			{
				if (item.idx == sau.idx)
				{
					sau.amount += -1; 
				}
			}

		}
	}
}
