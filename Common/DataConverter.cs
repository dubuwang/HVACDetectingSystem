using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DataConverter
    {
        public static byte[] ReverseFormatCDBA(byte[] buff)
        {
            byte[] res = new byte[buff.Length];
            if (buff.Length == 4)
            {
                res[0] = buff[2];
                res[1] = buff[3];
                res[2] = buff[0];
                res[3] = buff[1];
            }
            return res;
        }

        public static byte[] ReverseFormatBADC(byte[] buff)
        {
            byte[] res = new byte[buff.Length];
            if (buff.Length == 4)
            {
                res[0] = buff[1];
                res[1] = buff[0];
                res[2] = buff[3];
                res[3] = buff[2];
            }
            return res;
        }

        public static byte[] ReverseFormatDCBA(byte[] buff)
        {
            byte[] res = new byte[buff.Length];
            if (buff.Length == 4)
            {
                res[0] = buff[3];
                res[1] = buff[2];
                res[2] = buff[1];
                res[3] = buff[0];
            }
            return res;
        }
    }
}
