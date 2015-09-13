using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace ConnectionCenter
{
    public class SQLServerConnection
    {
        private static string dBServerName;
        private static string dbCatalogName;
        private static string dBUserName;
        private static string dBPassword;

        

        //取得数据库连接
        public static SqlConnection GetSQLConnection()
        {
            string connString = "Data Source=" + DBServerName + ";Initial Catalog="
                + DbCatalogName + ";User ID =" + DBUserName + ";Password="
                + DBPassword + ";Integrated Security=false";
            SqlConnection conn = null;
            conn = new SqlConnection(connString);
            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn = null;
            }
            finally
            {
                if (conn != null)
                {
                    if (conn.Database == "" || conn.DataSource == "")
                    {
                        conn = null;
                    }
                    conn.Close();
                }
            }

            return conn;
        }
        public static DataTable GetDatabaseSchema()
        {
            DataTable dtSchema = new DataTable();
            dtSchema.Columns.Add("id", System.Type.GetType("System.Int32"));
            dtSchema.Columns.Add("TABLE_CATALOG", System.Type.GetType("System.String"));
            dtSchema.Columns.Add("TABLE_SCHEMA", System.Type.GetType("System.String"));
            dtSchema.Columns.Add("TABLE_NAME", System.Type.GetType("System.String"));
            dtSchema.Columns.Add("TABLE_TYPE", System.Type.GetType("System.String")); 

            SqlConnection conn = GetSQLConnection();
            if (conn == null)
            {
                dtSchema = null;
                return dtSchema;
            }
            try
            {
                conn.Open();
                //schema = conn.GetSchema("Tables");

                //SQL语句
                string sqlStr = "SELECT Row_Number() over (order by getdate()) as id,TABLE_CATALOG,TABLE_SCHEMA,TABLE_NAME,TABLE_TYPE FROM information_schema.tables";

                SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "TableList");
                dtSchema = ds.Tables[0];
            }
            catch
            {
                dtSchema = null;
                MessageBox.Show("获取数据库列表失败。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
            return dtSchema;
        }

        public static DataTable GetDataByTableName(string tableName)
        {
            DataTable dtData = new DataTable();

            SqlConnection conn = GetSQLConnection();
            if (conn == null)
            {
                dtData = null;
                return dtData;
            }
            try
            {
                conn.Open();
                //SQL语句
                string sqlStr = "SELECT * FROM "+tableName;

                SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "TableList");
                dtData = ds.Tables[0];
            }
            catch
            {
                dtData = null;
                MessageBox.Show("获取数据库列表失败。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
            return dtData;
        }

        //用户列表
        public static DataTable GetUserList()
        {
            DataTable dtUser = new DataTable();
            //dtUser.Columns.Add("id", System.Type.GetType("System.Int32"));
            //dtUser.Columns.Add("username", System.Type.GetType("System.String"));
            //dtUser.Columns.Add("relname", System.Type.GetType("System.String"));
            //dtUser.Columns.Add("sex", System.Type.GetType("System.String"));
            //dtUser.Columns.Add("pid", System.Type.GetType("System.Int32"));
            //dtUser.Columns.Add("tel", System.Type.GetType("System.String"));
            //dtUser.Columns.Add("deptname", System.Type.GetType("System.String"));
            //dtUser.Columns.Add("description", System.Type.GetType("System.String"));

            SqlConnection conn = GetSQLConnection();
            if (conn == null)
            {
                dtUser = null;
                return dtUser;
            }
            try
            {
                conn.Open();
                //schema = conn.GetSchema("Tables");

                //SQL语句
                string sqlStr = "select * from [user]";

                SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "用户列表");
                dtUser = ds.Tables[0];
            }
            catch
            {
                dtUser = null;
                MessageBox.Show("获取用户列表失败。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
            return dtUser;
        }



        public static string DBServerName
        {
            get { return dBServerName; }
            set { dBServerName = value; }
        }

        public static string DbCatalogName
        {
            get { return dbCatalogName; }
            set { dbCatalogName = value; }
        }
        public static string DBUserName
        {
            get { return dBUserName; }
            set { dBUserName = value; }
        }

        public static string DBPassword
        {
            get { return dBPassword; }
            set { dBPassword = value; }
        }
    }
}
