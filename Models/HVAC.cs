using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HVAC
    {
        /// <summary>
        /// 型号
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 检测参数
        /// </summary>
        public List<Param> Params { get; set; }

        /// <summary>
        /// 是否合格
        /// </summary>
        public string IsPassed { get; set; }

        public DateTime DetectTime { get; set; }
    }
}
