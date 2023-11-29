using DataAccessLayer.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVienPhapLuat.Application.Service;

namespace ThuVienPhapLuat.Application.Helper
{
    public class SqlHelper: ServiceBase
    {
        //public string connectionString;
        public SqlHelper(thuVienPhapLuatDBContext context) : base(context)
        {
            //connectionString = context.
        }
        
        public SqlConnection GetConnection(string connStr)
        {
            //return new SqlConnection(connStr);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connStr;
            return conn;
        }
        public DataSet ExecuteDataSet(string sql)
        {
            SqlConnection con = GetConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            DataSet ds = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            try
            {
                adapt.Fill(ds);
            }
            catch
            {
                con.Close();
            }
            return ds;
        }
        public DataSet SearchStoreProcedure(string storeProcedureName, params SqlDBParameter[] inputParameters)
        {
            SqlCommand cmm = new SqlCommand(storeProcedureName);
            cmm.Connection = new SqlConnection(connectionString);
            cmm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmm;

            if (inputParameters != null && inputParameters.Length > 0)
            {
                foreach (SqlDBParameter param in inputParameters)
                {
                    if (param != null)
                    {
                        SqlDataParameter.AddParameter(cmm, param.ParameterName, param.SqlDbType, param.Value);
                    }
                }
            }
            DataSet result = new DataSet();
            try
            {
                if (cmm.Connection.State != ConnectionState.Open)
                {
                    cmm.Connection.Open();
                }
                adp.Fill(result);
            }
            catch (Exception ex)
            {
                result = null;
            }
            finally
            {
                if (cmm.Connection.State != ConnectionState.Closed)
                {
                    cmm.Connection.Close();
                }
                cmm.Connection.Dispose();
                cmm.Dispose();
            }
            return result;
        }

        public DataTable SearchStoreProcedureDataTable(string storeProcedureName, params SqlDBParameter[] inputParameters)
        {
            DataSet ds = SearchStoreProcedure(storeProcedureName, inputParameters);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
    }
}
