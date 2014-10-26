using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBManager
/// </summary>
public class DBManager : Database
{
    public String[] getDatesByPatientId(int id)
    {
        List<String> dates = new List<String>();

        String query = @"SELECT DISTINCT assessDate AS DATES FROM  seizures  WHERE patientId = " + id + " UNION ALL " +
                         "SELECT DISTINCT assessDate AS DATES FROM prescriptions  WHERE patientId = " + id + "  UNION ALL " +
                         "SELECT DISTINCT surgeryDate AS DATES FROM surgeries  WHERE patientId = " + id + " ORDER BY DATES";

        this.ExecuteQuery(query);

        while(this.reader.Read())
        {
            dates.Add(reader["DATES"].ToString());
        }

        return dates.ToArray();
    }
}