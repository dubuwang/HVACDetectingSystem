using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.IO;

namespace DAL
{
    /// <summary>
    /// SQLService数据库的访问类，在SQLHelper的基础上整合了一些方法。
    /// </summary>
    public class SQLHelperCommon
    {
        /// <summary>
        /// 数据库连接文本
        /// </summary>
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        /// <summary>
        /// 执行增、删、改操作
        /// </summary>
        /// <param name="sql">SQL 语句</param>
        /// <param name="param">SqlParameter参数，默认为空</param>
        /// <param name="isProcedure">是否存储过程，默认为false</param>
        /// <returns>受影响的行数</returns>
        public static int Update(string sql, SqlParameter[] param = null, bool isProcedure = false)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            if (isProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string errorInfo = string.Format("执行 {0} 方法 错误！具体信息：{1}", "public static int Update(string sql, SqlParameter[] param = null, bool isProcedure=false )", ex.Message);
                WriteErrorLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行SQL单一结果查询
        /// </summary>
        /// <param name="sql">SQL 语句</param>
        /// <param name="param">SqlParameter参数，默认为空</param>
        /// <param name="isProcedure">是否存储过程，默认为false</param>
        /// <returns>返回object对象</returns>
        public static object GetSingleResult(string sql, SqlParameter[] param = null, bool isProcedure = false)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            if (isProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                string errorInfo = string.Format("执行 {0} 方法 错误！具体信息：{1}", "public static int GetSingleResult(string sql, SqlParameter[] param = null, bool isProcedure=false )", ex.Message);
                WriteErrorLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行SQL只读查询
        /// </summary>
        /// <param name="sql">SQL 语句</param>
        /// <param name="param">SqlParameter参数，默认为空</param>
        /// <param name="isProcedure">是否存储过程，默认为false</param>
        /// <returns>返回SqlDataReader对象</returns>
        public static SqlDataReader GetReader(string sql, SqlParameter[] param = null, bool isProcedure = false)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            if (isProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                string errorInfo = string.Format("执行 {0} 方法 错误！具体信息：{1}", "public static int GetReader(string sql, SqlParameter[] param = null, bool isProcedure=false )", ex.Message);
                WriteErrorLog(errorInfo);
                throw new Exception(errorInfo);
            }
        }

        /// <summary>
        /// 执行SQL查询，获取数据集
        /// </summary>
        /// <param name="sql">SQL 语句</param>
        /// <param name="param">SqlParameter参数，默认为空</param>
        /// <param name="isProcedure">是否存储过程，默认为false</param>
        /// <returns>返回DataSet对象</returns>
        public static DataSet GetDataSet(string sql, SqlParameter[] param = null, bool isProcedure = false)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            if (isProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            try
            {
                conn.Open();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                string errorInfo = string.Format("执行 {0} 方法 错误！具体信息：{1}", "public static int GetDataSet(string sql, SqlParameter[] param = null, bool isProcedure=false )", ex.Message);
                WriteErrorLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        /// <summary>
        /// 获取DataSet查询，DataTable通过表的名称访问
        /// </summary>
        /// <param name="sqlDic">Dictionary 键值对分别为：表名称，查询语句</param>
        /// <returns>返回DataSet对象</returns>
        public static DataSet GetDataSet(Dictionary<string, string> sqlDic)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                foreach (string tableName in sqlDic.Keys)
                {
                    cmd.CommandText = sqlDic[tableName];
                    da.Fill(ds, tableName);
                }
                return ds;
            }
            catch (Exception ex)
            {
                string errorInfo = string.Format("执行 {0} 方法 错误！具体信息：{1}", " public static DataSet GetDataSet(Dictionary <string,string> sqlDic)", ex.Message);
                WriteErrorLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        /// <summary>
        /// 启用事务执行多条SQL语句
        /// </summary>
        /// <param name="sqlList">SQL语句集合</param>
        /// <returns></returns>
        public static bool UpdateByTran(List<string> sqlList)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();
                foreach (string sql in sqlList)
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback();
                }

                string errorInfo = string.Format("执行 {0} 方法 错误！具体信息：{1}", "public static bool UpdateByTran(List <string> sqlList)", ex.Message);
                WriteErrorLog(errorInfo);
                throw new Exception(errorInfo);
            }
            finally
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction = null;
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        #region 泛型的数据库插入
        /// <summary>
        /// 通过泛型方法，传入实体对象，但标识列必须为Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int InsertModel<T>(T model)
        {
            Type t = typeof(T);

            PropertyInfo[] propertyInfo = t.GetProperties();

            string sql = "insert into [{0}] ({1}) values({2})";
            sql = string.Format(sql, t.Name, string.Join(",", propertyInfo.Where(p => p.Name != "Id").Select(p => p.Name)), string.Join(",", propertyInfo.Where(p => p.Name != "Id").Select(p => "@" + p.Name)));

            List<SqlParameter> list = new List<SqlParameter>();

            foreach (PropertyInfo p in propertyInfo)
            {
                list.Add(new SqlParameter("@" + p.Name, p.GetValue(model, null)));
            }

            SqlParameter[] param = list.ToArray();

            return Update(sql, param);

        }

        #endregion

        /// <summary>
        /// 获取数据库服务器的时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDBServerTime()
        {
            string sql = "select getdate()";
            return Convert.ToDateTime(GetSingleResult(sql));
        }
        /// <summary>
        /// 写入错误日志 
        /// </summary>
        /// <param name="msg"></param>
        private static void WriteErrorLog(string msg)
        {

            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream("SqlError.log", FileMode.Append);
                sw = new StreamWriter(fs);
                sw.WriteLine(DateTime.Now.ToString() + ": " + msg);
            }
            catch (Exception)
            {
                //不作处理
            }
            finally
            {
                //在sw.Close()执行完毕后，其实fs已经被关闭了。因此fs.Close()其实是可以省略的。
                //当然，这样的写法不会有任何问题，因为Dispose不会被执行两次。
                if (sw != null) sw.Close();
                if (fs != null) fs.Close();//这两行代码不能交换顺序，必须先sw.Close()
            }
        }
    }
}
