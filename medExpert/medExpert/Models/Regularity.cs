using System;
using System.Collections.Generic;
using System.Text;

namespace medExpert.Models
{
    /// <summary>
    /// Поворяемость задачи
    /// </summary>
    public enum Regularity
    {
        /// <summary>
        /// Ежедневно
        /// </summary>
        Daily = 0,

        /// <summary>
        /// Еженедельно
        /// </summary>
        Weekly = 1,

        /// <summary>
        /// Ежемесячно
        /// </summary>
        Monthly = 2
    }
}