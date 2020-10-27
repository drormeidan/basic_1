using System;
using System.Collections.Generic;

public class Salad
{
	public Salad(List<int> sextras, int ssize, List<Sauce> ssauces)
	{
		this.extras = sextras;
		this.size = ssize;
		this.SauceList = ssauces;
	}
	public List<int> extras { get; set; } // 0-cucamber, 1-tomato, 2-lettuce, 3-pickels, 4-onion
	public int size { get; set; } // 0- small , 1-medium, 2- big.

	public List<Sauce> SauceList { get; set; }

	public int price()
	{
		//Console.WriteLine(ExtraPrices["tomato"]);
		int rprice = new int();
		switch (this.size)
		{
			case 0:
				rprice = 30;
				break;

			case 1:
				rprice = 40;
				break;

			case 2:
				rprice = 50;
				break;
		}

		foreach (Sauce sau in this.SauceList)
		{
			rprice += sau.price;
		}


		return rprice;

	}

	public void ReduceAmmount(ref List<Sauce> sauces,ref Dictionary<int, string> IdxExtra, ref Dictionary<string, int> ExtraAmount)
	{
		foreach (int item in this.extras)
		{
			ExtraAmount[IdxExtra[item]] += -2;
		}

		foreach (Sauce item in this.SauceList)
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

