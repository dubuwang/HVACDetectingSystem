using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    /// <summary>
    /// Users数据表访问类
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// 用户登陆方法
        /// </summary>
        /// <param name="objUser">封装了登陆id和pwd的管理员对象</param>
        /// <returns>查询到的管理员对象，如果为null，则未查询到</returns>
        public User AdminLogin(User objUser)
        {
            //1.编写sql语句
            string sql = "select UserName from Users where UserId = {0} and UserPwd = '{1}'";
            sql = string.Format(sql, objUser.UserId, objUser.UserPwd);

            try
            {
                //2.调用数据访问类，执行sql语句
                SqlDataReader objReader = SQLHelperCommon.GetReader(sql, null, false);

                //3.封装对象，返回结果
                if (objReader.Read())
                {
                    objUser.UserName = objReader["UserName"].ToString();
                    objReader.Close();
                }
                else
                {
                    objUser = null;
                }

            }
            catch (SqlException ex)
            {
                objUser = null;
                throw ex;
            }
            catch (Exception ex)
            {
                objUser = null;
                throw ex;
            }

            return objUser;
        }
    }
}
