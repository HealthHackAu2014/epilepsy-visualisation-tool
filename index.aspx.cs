using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for flot_charts
/// </summary>
public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String[] Meds = new String[]{ "Med1", "Med2", "Med3"
                                        };

        string json2 = Newtonsoft.Json.JsonConvert.SerializeObject(Meds);

        HiddenField jsonField2 = new HiddenField { ID = "data2" };
        jsonField2.Value = json2;
        this.Controls.Add(jsonField2);

        DBManager dbman = new DBManager();

        String[] datelist = dbman.getDatesByPatientId(1);


        List<string[]> timeline = new List<string[]>();

        for (int i = 0; i < datelist.Length; i++)
        {
            string[] x = new string[2];
            x[0] = i.ToString();
            x[1] = Utility.ConvertDateToAus(datelist[i]);
            timeline.Add(x);
        }


        SeizureManager seizureman = new SeizureManager();

        List<Seizure> lseizure = seizureman.FetchByPatientId(1);

        List<string[]> stimeline = new List<string[]>();

        List<string[]> badnesstimeline = new List<string[]>();

        List<string[]> eptimeline = new List<string[]>();

        for (int i = 0; i < lseizure.Count; i++)
        {
            string[] x = new string[2];
            x[1] = lseizure[i].frequency.ToString();
            x[0] = Utility.GetDateIndex(timeline, lseizure[i].assessDate);

            stimeline.Add(x);

            string[] y = new string[2];

            y[0] = Utility.GetDateIndex(timeline, lseizure[i].assessDate);

            switch (lseizure[i].episode.ToString())
            {
                case "0":
                    y[1] = "Nocturnal";
                    break;
                case "1":
                    y[1] = "Not disabling";
                    break;
                case "2":
                    y[1] = "Not disabling";
                    break;
                case "3":
                    y[1] = "Short brief disabling";
                    break;
                case "4":
                    y[1] = "Short brief disabling";
                    break;
                case "5":
                    y[1] = "Convulsion";
                    break;
                case "6":
                    y[1] = "Convulsion";
                    break;
            }

            eptimeline.Add(y);

            string[] z = new string[2];

            z[0] = Utility.GetDateIndex(timeline, lseizure[i].assessDate);

            switch (lseizure[i].confidence.ToString())
            {







                case "0":
                    z[1] = "Definetly not an epilpetic seizure";
                    break;
                case "1":
                    z[1] = "Unsure if epileptic";
                    break;
                case "2":
                    z[1] = "Unsure if epileptic";
                    break;
                case "3":
                    z[1] = "Posibbilty epilepsti";
                    break;
                case "4":
                    z[1] = "Posibbilty epilepsti";
                    break;
                case "5":
                    z[1] = "Epileptic seizure";
                    break;

            }

            badnesstimeline.Add(z);



        }


        PrescriptionManager psc = new PrescriptionManager();
        List<Prescription> pscPatient = psc.FetchByPatientId(1);

        List<string[]> pscLine = new List<string[]>();

        for (int i = 0; i < pscPatient.Count; i++)
        {
            string[] x = new string[2];
            x[1] = Convert.ToString(0.5);
            x[0] = Utility.GetDateIndex(timeline, pscPatient[i].assessDate);
            pscLine.Add(x);
        }


        SurgeryManager surman = new SurgeryManager();
        List<Surgery> surgery = surman.FetchByPatientId(1);
        List<String[]> surgeryTimeline = new List<String[]>();

        for (int i = 0; i < timeline.Count; i++)
        {
            String[] t = new String[2];

            for (int ii = 0; ii < surgery.Count; ii++)
            {
                if (timeline.ElementAt(i)[1].Equals(Utility.ConvertDateToAus(surgery[ii].surgeryDate)))
                {
                    t[0] = i + "";
                    t[1] = "7";
                }
                else if (i == 10)
                {
                    t[0] = i + "";
                    t[1] = "7";
                }
                else
                {
                    t[0] = i + "";
                    t[1] = "0";
                }
            }

            surgeryTimeline.Add(t);
        }

        string jsonsurgeryTimeline = Newtonsoft.Json.JsonConvert.SerializeObject(surgeryTimeline);

        HiddenField jsonFieldsurgeryTimeline = new HiddenField { ID = "dataSurgery" };
        jsonFieldsurgeryTimeline.Value = jsonsurgeryTimeline;
        this.Controls.Add(jsonFieldsurgeryTimeline);

        string jsonmed = Newtonsoft.Json.JsonConvert.SerializeObject(pscLine);

        HiddenField jsonMedField = new HiddenField { ID = "meddata" };
        jsonMedField.Value = jsonmed;
        this.Controls.Add(jsonMedField);

        string jsonepisode = Newtonsoft.Json.JsonConvert.SerializeObject(eptimeline);

        HiddenField episodeField = new HiddenField { ID = "dataepisode" };
        episodeField.Value = jsonepisode;
        this.Controls.Add(episodeField);

        string json = Newtonsoft.Json.JsonConvert.SerializeObject(stimeline);

        HiddenField jsonField = new HiddenField { ID = "data" };
        jsonField.Value = json;
        this.Controls.Add(jsonField);

        string jsonbadness = Newtonsoft.Json.JsonConvert.SerializeObject(badnesstimeline);

        HiddenField badnessField = new HiddenField { ID = "databadness" };
        badnessField.Value = jsonbadness;
        this.Controls.Add(badnessField);


        string json5 = Newtonsoft.Json.JsonConvert.SerializeObject(timeline);

        HiddenField jsonField5 = new HiddenField { ID = "data5" };
        jsonField5.Value = json5;
        this.Controls.Add(jsonField5);


        }

        public override void VerifyRenderingInServerForm(Control control)
        {
           
        }

        protected DataSet ScrapeData(string FilePath)
        {
            OleDbConnection Connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=Excel 12.0 XML");
            DataSet TableData = new DataSet();
            using (Connection)
            {
                Connection.Open();
                OleDbCommand Reader = new OleDbCommand();
                Reader.Connection = Connection;
                DataTable dtSheet = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                foreach (DataRow dr in dtSheet.Rows)
                {
                    string Sheet = dr["TABLE_NAME"].ToString();
                    if (!Sheet.EndsWith("$"))
                        continue;
                    else if (Sheet == "Seizures$" || Sheet == "Meds$" || Sheet == "Surgery$")
                    {
                        Reader.CommandText = "SELECT * FROM [" + Sheet + "]";
                        DataTable SubSheet = new DataTable();
                        SubSheet.TableName = Sheet;
                        OleDbDataAdapter Writer = new OleDbDataAdapter(Reader);
                        Writer.Fill(SubSheet);
                        TableData.Tables.Add(SubSheet);
                    }
                }
                Reader = null;
                Connection.Close();
            }
            return TableData;
        }

        protected void Import(DataSet SpreadsheetTables)
        {
            foreach (DataTable Table in SpreadsheetTables.Tables)
            {
                if (Table.TableName == "Seizures$")
                {
                    SeizureManager sm = new SeizureManager();
                    foreach (DataRow Row in Table.Rows)
                    {
                        if (!String.IsNullOrWhiteSpace(Row[0].ToString()) || !String.IsNullOrWhiteSpace(Row[1].ToString()))
                        {
                            Seizure s = new Seizure();
                            Int32.TryParse(Row[0].ToString(), out s.seizureId);
                            Int32.TryParse(Row[1].ToString(), out s.patientId);

                            DateTime dateTime = DateTime.Parse(Row[2].ToString());
                            s.assessDate = dateTime.ToString("MM/dd/yyyy");
                            Int32.TryParse(Row[3].ToString(), out s.frequency);
                            if (String.IsNullOrEmpty(Row[4].ToString()))
                                s.episode = 0;
                            else Int32.TryParse(Row[4].ToString(), out s.episode);

                            if (String.IsNullOrEmpty(Row[5].ToString()))
                                s.confidence = 0;
                            else Int32.TryParse(Row[5].ToString(), out s.confidence);
                          
                            sm.Save(s);
                        }
                    }
                }
                else if (Table.TableName == "Meds$")
                {
                    PrescriptionManager pm = new PrescriptionManager();
                    foreach (DataRow Row in Table.Rows)
                    {
                        if (!String.IsNullOrWhiteSpace(Row[0].ToString()) || !String.IsNullOrWhiteSpace(Row[1].ToString()))
                        {
                            Prescription p = new Prescription();

                            Int32.TryParse(Row[0].ToString(), out p.prescriptionId);
                            Int32.TryParse(Row[1].ToString(), out p.patientId);
                            float.TryParse(Row[2].ToString(), out p.dose);
                            p.unit = Row[3].ToString();
                            p.frequency = Row[4].ToString();
                            p.medName = Row[5].ToString();
                            DateTime dt = DateTime.Parse(Row[6].ToString());
                            p.assessDate = dt.ToString("MM/dd/yyyy");
                            Int32.TryParse(Row[7].ToString(), out p.noMedications);

                            pm.Save(p);
                            // Debug.WriteLine("adding meds " + Row[0].ToString() + " " + Row[1].ToString());
                        }
                    }
                }
                else if (Table.TableName == "Surgery$")
                {
                    SurgeryManager surm = new SurgeryManager();
                    foreach (DataRow Row in Table.Rows)
                    {
                        if (!String.IsNullOrWhiteSpace(Row[0].ToString()) || !String.IsNullOrWhiteSpace(Row[1].ToString()))
                        {
                            Surgery s = new Surgery();

                            Int32.TryParse(Row[0].ToString(), out s.surgeryId);
                            Int32.TryParse(Row[1].ToString(), out s.patientId);
                            DateTime dateTime = DateTime.Parse(Row[2].ToString());
                            s.surgeryDate = dateTime.ToString("MM/dd/yyyy");
                            s.surgeryType = Row[3].ToString();

                            surm.Save(s);
                            //Debug.WriteLine("adding surgery " + Row[0].ToString() + " " + Row[1].ToString());
                        }
                    }
                }
                else
                    throw new ApplicationException("Invalid Worksheet Name: Only Seizures, Meds and Surgery");
            }
        }

        protected void Upload(object sender, EventArgs e)
        {
            try
            {
                string savePath = Path.GetTempPath();
                if (FileUpload1.HasFile)
                {
                    string FileName = Server.HtmlEncode(FileUpload1.FileName);
                    string FileExtension = System.IO.Path.GetExtension(FileName);
                    if ((FileExtension == ".xlsx"))
                    {
                        savePath += FileName;
                        FileUpload1.SaveAs(savePath);
                        Import(ScrapeData(savePath));

                        UploadStatusLabel.Text = "File was uploaded and processed successfully.";
                    }
                    else
                        UploadStatusLabel.Text = "File was not in a valid .xlsx format";
                }
            }
            catch (Exception ex)
            {
                
            }

        }
    }
