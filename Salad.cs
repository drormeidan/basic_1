using System;
using System.Collections.Generic;

public class Salad
{
	public Salad(List<int> sextras, int ssize)
	{
		this.extras = sextras;
		this.size = ssize;
	}
	public List<int> extras { get; set; } // 0-cucamber, 1-tomato, 2-lettuce, 3-pickels, 4-onion
	public int size { get; set; } // 0- small , 1-medium, 2- big.


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

		return rprice;

	}

	public void ReduceAmmount(ref Dictionary<int, string> IdxExtra, ref Dictionary<string, int> ExtraAmount)
	{
		foreach (int item in this.extras)
		{
			ExtraAmount[IdxExtra[item]] += -2;
		}
	}


}

