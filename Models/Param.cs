using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 检测参数
    /// </summary>
    public class Param
    {
        public string ParamName { get; set; }

        public float Value { get; set; }

        public float ValueUpper { get; set; }

        public float ValueLower { get; set; }

        public string ModubsAddr { get; set; }

        /// <summary>
        /// 需上下限检测的参数
        /// </summary>
        public string IsDetected { get; set; }

        public string Note { get; set; }

        /// <summary>
        /// 该参数是否合格
        /// </summary>
        public string IsPassed { get; set; }
    }
}
