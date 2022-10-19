using DotCoreExample.Models;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;

namespace DotCoreExample.Controllers
{
    public class DBConnectionController : Controller
    {
        


        
        public void executeStoreDB(string storedProcedure, List<OracleParameter> param)
        {
            DBCredentialsModel credential = new DBCredentialsModel();

            string user = credential.GetUser();
            string pass=credential.getPass();
            string conexion = "user id =" +user+ "; password ="+pass+" ; data source = (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = orcl)))";



            try
            {
                OracleConnection con = new OracleConnection(conexion);
                OracleCommand cmd = new OracleCommand(storedProcedure, con);
                cmd.CommandText = storedProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                if (param != null)
                {
                    foreach (OracleParameter item in param)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            

        }

        public DataTable fillStoreDb(string storedProcedure, List<OracleParameter> param)
        {

            DBCredentialsModel credential = new DBCredentialsModel();

            string user = credential.GetUser();
            string pass = credential.getPass();
            string conexion = "user id =" + user + "; password =" + pass + " ; data source = (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = orcl)))";


            try
            {
                OracleConnection con = new OracleConnection(conexion);
                OracleCommand cmd = new OracleCommand(storedProcedure, con);
                cmd.CommandText = storedProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                if (param != null)
                {
                    foreach (OracleParameter item in param)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                cmd.ExecuteNonQuery();
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;



            }
            catch (Exception)
            {

                throw;
            }
           

        }
    }
}
