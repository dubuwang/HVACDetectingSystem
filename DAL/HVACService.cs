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
            catch(Exception e)
            {
                throw e;
            }
            
        }
    }
}
