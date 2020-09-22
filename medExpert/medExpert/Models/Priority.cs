using System;
using System.Collections.Generic;
using System.Text;

namespace medExpert.Models
{
    /// <summary>
    /// Приоритет задачи
    /// </summary>
    public enum Priority
    {
        /// <summary>
        /// Низкий приоритет
        /// </summary>
        Low = 0,

        /// <summary>
        /// Средний приоритет
        /// </summary>
        Medium = 1,

        /// <summary>
        /// Высокий приоритет
        /// </summary>
        High = 2,

        /// <summary>
        /// Срочный приоритет
        /// </summary>
        Urgent = 3,

        /// <summary>
        /// Критический приоритет
        /// </summary>
        Critical = 4
    }
}