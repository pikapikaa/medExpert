using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace medExpert.Models
{
    /// <summary>
    /// Статус задачи
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// Создана
        /// </summary>
        [Description("Создана")]
        New = 1,

        /// <summary>
        /// Назначена
        /// </summary>
        [Description("Назначена")]
        Assigned = 2,

        /// <summary>
        /// В работе
        /// </summary>
        [Description("В работе")]
        InProgress = 3,

        /// <summary>
        /// Выполнена
        /// </summary>
        [Description("Выполнена")]
        Executed = 4,
    }
}
