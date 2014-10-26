using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;


    public class SurgeryManager : Database
    {
        public SurgeryManager()
        {
            this.Init();
        }

        public void Save(Surgery obj)
        {
            String query  = "INSERT INTO surgeries";
                   query += "(patientId,surgeryDate,surgeryType)";
                   query += @" VALUES(" +
                            obj.patientId + ",'" +
                            obj.surgeryDate + "','" +
                            obj.surgeryType + "')";

            this.ExecuteNonQuery(query);
        }

        public List<Surgery> FetchByPatientId(int id)
        {
            List<Surgery> objs = new List<Surgery>();

            this.ExecuteQuery("SELECT * FROM surgeries WHERE patientId = " + id + " ORDER BY surgeryDate ASC");

            while(this.reader.Read())
            {
                Surgery temp = new Surgery();

                Int32.TryParse(reader["patientId"].ToString(), out temp.patientId);
                temp.surgeryDate = reader["surgeryDate"].ToString();
                temp.surgeryType = reader["surgeryType"].ToString();

                objs.Add(temp);
            }

            this.QueryClose();

            return objs;
        }

        public List<Surgery> FetchAll()
        {
            List<Surgery> objs = new List<Surgery>();

            this.ExecuteQuery("SELECT * FROM surgeries ORDER BY surgeryDate ASC");

            while(this.reader.Read())
            {
                Surgery temp = new Surgery();

                Int32.TryParse(reader["patientId"].ToString(), out temp.patientId);
                temp.surgeryDate = reader["surgeryDate"].ToString();
                temp.surgeryType = reader["surgeryType"].ToString();

                objs.Add(temp);
            }

            this.QueryClose();

            return objs;
        }
    }
