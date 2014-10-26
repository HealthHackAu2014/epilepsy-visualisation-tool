using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Prescription
    {
        public int prescriptionId;
        public int patientId;
        public float dose;
        public int noMedications;
        public String unit;
        public String frequency;
        public String medName;
        public String assessDate;

        public String getDate()
        {
            DateTime dateTime = DateTime.Parse(this.assessDate);
            return dateTime.ToString("MMMM dd");
        }
    }
