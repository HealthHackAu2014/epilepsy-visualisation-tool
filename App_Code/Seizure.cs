using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class Seizure
    {
        public int seizureId;
        public int patientId;
        public String assessDate;
        public int frequency;
        public int episode;
        public int confidence;

        public String getDate()
        {
            DateTime dateTime = DateTime.Parse(this.assessDate);

            return dateTime.ToString("MMMM dd");
        }
    }
