using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace medExpert.Models
{
    /// <summary>
    /// Приоритет задачи
    /// </summary>
    public enum TaskPriority
    {
        /// <summary>
        /// Низкий
        /// </summary>
        [Description("Низкий")]
        Low = 1,

        /// <summary>
        /// Средний
        /// </summary>
        [Description("Средний")]
        Medium = 2,

        /// <summary>
        /// Высокий
        /// </summary>
        [Description("Высокий")]
        High = 3,

        /// <summary>
        /// Срочный
        /// </summary>
        [Description("Срочный")]
        Urgent = 4,

        /// <summary>
        /// Критичный
        /// </summary>
        [Description("Критичный")]
        Critical = 5,
    }
}
