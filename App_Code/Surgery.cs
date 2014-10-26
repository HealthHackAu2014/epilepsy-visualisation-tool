using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class Surgery
    {
        public int surgeryId;
        public int patientId;
        public String surgeryDate;
        public String surgeryType;

        public String getDate()
        {
            DateTime dateTime = DateTime.Parse(this.surgeryDate);
            return dateTime.ToString("MMMM dd");
        }
    }
