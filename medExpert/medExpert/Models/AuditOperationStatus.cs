using System;
using System.Collections.Generic;
using System.Text;

namespace medExpert.Models
{
    public enum AuditOperationStatus
    {
        /// <summary>
        /// Создан
        /// </summary>
        Created = 0,

        /// <summary>
        /// Выполняется
        /// </summary>
        Running = 1,

        /// <summary>
        /// На подписи
        /// </summary>
        Signing = 2,

        /// <summary>
        /// Подписан
        /// </summary>
        Signed = 3,

        /// <summary>
        /// Проведен
        /// </summary>
        Executed = 4,
    }
}
