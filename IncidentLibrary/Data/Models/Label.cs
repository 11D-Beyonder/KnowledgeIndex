using System;
using System.Collections.Generic;

namespace IncidentLibrary.Data.Models
{
    /// <summary>
    /// 标签
    /// </summary>
    public partial class Label
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 标签颜色
        /// </summary>
        public int Color { get; set; }
    }
}
