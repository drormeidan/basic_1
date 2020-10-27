using System;

public class Worker
{
	public Worker(string sname, int sseniority)
	{
		this.name = sname;
		this.seniority = sseniority;
		this.NumInvetation = 0;
	}

	public string name { get; set; }
	public int seniority { get; set; }
	public int NumInvetation { get; set; }

	public int salary() 
	{
		return (10 * this.seniority) + this.NumInvetation;
	}

}
