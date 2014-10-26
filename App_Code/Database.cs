using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


    public class Database
    {
        protected SqlConnection conn;
        protected SqlCommand comm;
        protected SqlDataReader reader;

        public Database()
        {
            this.Init();
        }

        public void Init()
        {
            this.conn = this.Connection();
            this.comm = this.Command();
            this.comm.Connection = conn;
        }

        public SqlConnection Connection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString);
        }

        public SqlCommand Command()
        {
            return new SqlCommand();
        }

        public void ExecuteQuery(String query)
        {
            this.conn.Open();
            this.comm.CommandText = query;
            this.reader = this.comm.ExecuteReader();
        }

        public void ExecuteNonQuery(String query)
        {
            this.conn.Open();
            this.comm.CommandText = query;
            this.comm.ExecuteNonQuery();
            this.conn.Close();
        }

        public void QueryClose()
        {
            this.comm.Dispose();
            this.conn.Close();
        }
    }
