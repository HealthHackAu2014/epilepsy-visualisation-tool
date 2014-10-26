using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;


    public class SeizureManager : Database
    {
        public void Save(Seizure obj)
        {
            String query  = "INSERT INTO seizures";
                   query += "(patientId,assessDate,frequency,episode,confidence)";
                   query += @" VALUES( " +
                            obj.patientId + ",'" +
                            obj.assessDate + "'," +
                            obj.frequency + "," +
                            obj.episode + "," +
                            obj.confidence + ")";

            this.ExecuteNonQuery(query);
        }

        public List<Seizure> FetchByPatientId(int id)
        {
            List<Seizure> objs = new List<Seizure>();

            this.ExecuteQuery("SELECT * FROM seizures WHERE patientId = " + id + " ORDER BY assessDate ASC");

            while(reader.Read())
            {
                Seizure temp = new Seizure();
                
                Int32.TryParse(reader["seizureId"].ToString(), out temp.seizureId);
                Int32.TryParse(reader["patientId"].ToString(), out temp.patientId);
                temp.assessDate = reader["assessDate"].ToString();
                Int32.TryParse(reader["frequency"].ToString(), out temp.frequency);
                Int32.TryParse(reader["episode"].ToString(), out temp.episode);
                Int32.TryParse(reader["confidence"].ToString(), out temp.confidence);

                objs.Add(temp);
            }

            this.QueryClose();

            return objs;
        }

        public List<Seizure> FetchAll()
        {
            List<Seizure> objs = new List<Seizure>();

            this.ExecuteQuery("SELECT * FROM seizures ORDER BY assessDate ASC");

            while(reader.Read())
            {
                Seizure temp = new Seizure();

                Int32.TryParse(reader["seizureId"].ToString(), out temp.seizureId);
                Int32.TryParse(reader["patientId"].ToString(), out temp.patientId);
                temp.assessDate = reader["assessDate"].ToString();
                Int32.TryParse(reader["frequency"].ToString(), out temp.frequency);
                Int32.TryParse(reader["episode"].ToString(), out temp.episode);
                Int32.TryParse(reader["confidence"].ToString(), out temp.confidence);

                objs.Add(temp);
            }

            this.QueryClose();

            return objs;
        }
    }
