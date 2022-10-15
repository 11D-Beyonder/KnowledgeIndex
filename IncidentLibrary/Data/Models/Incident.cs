using System;
using System.Collections.Generic;

namespace IncidentLibrary.Data.Models
{
    /// <summary>
    /// 事件
    /// </summary>
    public partial class Incident
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 事件标题
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 每个标签用分号隔开
        /// </summary>
        public string Labels { get; set; } = null!;
        /// <summary>
        /// 事件详细描述
        /// </summary>
        public string Content { get; set; } = null!;
    }
}
