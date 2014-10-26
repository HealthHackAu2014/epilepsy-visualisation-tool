using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Utility
/// </summary>
public class Utility
{
	public Utility()
	{
	}

    public static String ConvertDateToAus(String date)
    {
        DateTime dt = DateTime.Parse(date);
        return dt.ToString("dd/MM/yy");
    
    }

    public static String GetDateIndex(List<String[]> dateline, String date)
    {
        date = Utility.ConvertDateToAus(date);
        String result = "";

        foreach (String[] data in dateline)
        {
            if(data[1].Equals(date))
            {
                result = data[0];
                break;
            }
        }

        return result;
    }
}