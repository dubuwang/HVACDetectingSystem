using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// HVACS数据表访问类
    /// </summary>
    public class HVACService
    {
        /// <summary>
        /// 添加1台HVAC
        /// </summary>
        /// <param name="objHVAC"></param>
        /// <returns>返回该台HVAC在数据库中的Id</returns>
        public int AddHVAC(HVAC objHVAC)
        {
            string sql = "insert into HVACS(Type,IsPassed,DetectTime) values(@Type,@IsPassed,@DetectTime);select SCOPE_IDENTITY() as id";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Type",objHVAC.Type),
                new SqlParameter("@IsPassed",objHVAC.IsPassed),
                new SqlParameter("@DetectTime",objHVAC.DetectTime)
            };

            try
            {
                return Convert.ToInt32(SQLHelperCommon.GetSingleResult(sql, param, false));
            }
            catch (SqlException ex)
            {

                throw new Exception("添加HVAC时，数据库操作出现异常，原因：" + ex.Message);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 添加1台HVAC的参数信息
        /// </summary>
        /// <param name="objHVAC"></param>
        /// <param name="HVACId"></param>
        /// <returns></returns>
        public bool AddParams(HVAC objHVAC, int HVACId)
        {
            List<string> listStr = new List<string>();
            StringBuilder sqlBuilder = new StringBuilder();

            sqlBuilder.Append("insert into Params(ParamName,Value,ValueUpper,ValueLower,ModubsAddr,IsDetected,Note,IsPassed,HvacId)");
            sqlBuilder.Append(" values('{0}',{1},{2},{3},'{4}','{5}','{6}','{7}',{8})");

            foreach (var item in objHVAC.Params)
            {
                string sql = string.Format(sqlBuilder.ToString(), item.ParamName, item.Value, item.ValueUpper, item.ValueLower, item.ModubsAddr, item.IsDetected, item.Note, item.IsPassed, HVACId);

                listStr.Add(sql);
            }

            try
            {
                return SQLHelperCommon.UpdateByTran(listStr);
            }
            catch (SqlException ex)
            {
                throw new Exception("添加HVAC的参数信息时，数据库操作出现异常，原因：" + ex.Message);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<HVAC> GetHVACSByTime(DateTime time, string reportType)
        {
            string sql = "select HvacId,Type,IsPassed,DetectTime from HVACS ";
            if (reportType == "日报表")
            {
                sql += "where datediff(day,'" + time + "',DetectTime)=0";
            }
            else if (reportType == "月度报表")
            {
                //where datepart(month,'2020-02-07')=DATEPART(month,'2008-02-07')
                sql += "where datepart(year,DetectTime)=DATEPART(year,'" + time + "') and datepart(month,DetectTime)=DATEPART(month,'" + time + "')";
            }
            else if (reportType == "年度报表")
            {
                sql += "where datepart(year,DetectTime)=DATEPART(year,'" + time + "')";
            }

            SqlDataReader reader = null;

            try
            {
                reader = SQLHelperCommon.GetReader(sql, null, false);

                List<HVAC> listHvac = new List<HVAC>();

                while (reader.Read())
                {
                    listHvac.Add(new HVAC()
                    {
                        HvacId = Convert.ToInt32(reader["HvacId"]),
                        Type = reader["Type"].ToString(),
                        IsPassed = reader["IsPassed"].ToString(),
                        DetectTime = Convert.ToDateTime(reader["DetectTime"])
                    });
                }
                return listHvac;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null) reader.Close();

            }

        }

        public List<Param> GetParamsByHvacId(int id)
        {
            string sql = "select ParamName,Value,ValueUpper,ValueLower,ModubsAddr,IsDetected,Note,IsPassed from Params where HvacId=" + id;

            SqlDataReader reader = null;

            try
            {
                reader = SQLHelperCommon.GetReader(sql, null, false);

                List<Param> listP = new List<Param>();

                while (reader.Read())
                {
                    listP.Add(new Param()
                    {
                        ParamName = reader["ParamName"].ToString(),
                        ModubsAddr = reader["ModubsAddr"].ToString(),
                        IsDetected = reader["IsDetected"].ToString(),
                        Note = reader["Note"].ToString(),
                        IsPassed = reader["IsPassed"].ToString(),
                        Value = Convert.ToSingle(reader["Value"]),
                        ValueUpper = Convert.ToSingle(reader["ValueUpper"]),
                        ValueLower = Convert.ToSingle(reader["ValueLower"]),
                    });
                }
                return listP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null) reader.Close();
            }

        }
    }
}
