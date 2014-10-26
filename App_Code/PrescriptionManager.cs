using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

    public class PrescriptionManager : Database
    {
        public void Save(Prescription obj)
        {
            String query = "INSERT INTO prescriptions";
                   query += "(patientId,dose,unit,frequency,medName,assessDate,noMedications)";
                   query += @" VALUES(" + 
                            obj.patientId + "," + 
                            obj.dose + ",'" +
                            obj.unit + "','" + 
                            obj.frequency + "','" + 
                            obj.medName + "','" +
                            obj.assessDate + "'," + 
                            obj.noMedications + ")";
            this.ExecuteNonQuery(query);
        }

        public List<Prescription> FetchAll()
        {
            List<Prescription> objs = new List<Prescription>();

            this.ExecuteQuery("SELECT * FROM prescriptions ORDER BY assessDate ASC");

            while(reader.Read())
            {
                Prescription temp = new Prescription();
                
                Int32.TryParse(reader["prescriptionId"].ToString(), out temp.prescriptionId);
                Int32.TryParse(reader["patientId"].ToString(), out temp.patientId);
                float.TryParse(reader["dose"].ToString(), out temp.dose);
                temp.unit = reader["unit"].ToString();
                temp.frequency = reader["frequency"].ToString();
                temp.medName = reader["medName"].ToString();
                temp.assessDate = reader["assessDate"].ToString();
                Int32.TryParse(reader["noMedications"].ToString(), out temp.noMedications);

                objs.Add(temp);
            }

            this.QueryClose();

            return objs;
        }

        public List<Prescription> FetchByPatientId(int id)
        {
            List<Prescription> objs = new List<Prescription>();

            this.ExecuteQuery("SELECT * FROM prescriptions WHERE patientId = " + id + " ORDER BY assessDate ASC");

            while (reader.Read())
            {
                Prescription temp = new Prescription();

                Int32.TryParse(reader["prescriptionId"].ToString(), out temp.prescriptionId);
                Int32.TryParse(reader["patientId"].ToString(), out temp.patientId);
                float.TryParse(reader["dose"].ToString(), out temp.dose);
                temp.unit = reader["unit"].ToString();
                temp.frequency = reader["frequency"].ToString();
                temp.medName = reader["medName"].ToString();
                temp.assessDate = reader["assessDate"].ToString();
                Int32.TryParse(reader["noMedications"].ToString(), out temp.noMedications);

                objs.Add(temp);
            }

            this.QueryClose();

            return objs;
        }
    }
