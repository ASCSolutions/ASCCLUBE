using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.Odbc;

namespace AscWeb.Util
{
    public static class DbMethods
    {
        public static DataTable FillDataTable(this OdbcCommand command, OdbcConnection conn)
        {
            OdbcDataAdapter da = new OdbcDataAdapter()
            {
                SelectCommand = command
            };
            command.Connection = conn;

            try
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                throw;
            }
        }

        public static string RetornaString(this OdbcCommand command, OdbcConnection conn)
        {
            OdbcDataAdapter da = new OdbcDataAdapter()
            {
                SelectCommand = command
            };
            command.Connection = conn;

            try
            {
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Array dados = ds.Tables[0].Rows[0].ItemArray;
                    return dados.GetValue(0).ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (OdbcException e)
            {
                throw new Exception("erro" + e.StackTrace);
            }
        }
    }
}
