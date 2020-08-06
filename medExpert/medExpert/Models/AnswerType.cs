using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace medExpert.Models
{
    public enum AnswerType
    {
        /// <summary>
        /// Да
        /// </summary>
        [Description("Да")]
        Yes = 1,

        /// <summary>
        /// Нет
        /// </summary>
        [Description("Нет")]
        No = 2,

        /// <summary>
        /// Не применимо
        /// </summary>
        [Description("Не применимо")]
        InApplicable = 3,
    }
}
