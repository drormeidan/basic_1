using System;

public class Sauce
{
	public Sauce(string sname,int sidx, int samount, int sprice)
	{
		this.name = sname;
		this.idx = sidx;
		this.amount = samount;
		this.price = sprice;
		this.sales = 0;
	}

	public int sales { get; set; }
	public string name { get; set; }
	public int idx { get; set; } 
	public int amount { get; set; }
	public int price { get; set; }


}
