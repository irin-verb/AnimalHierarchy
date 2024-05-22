using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO
{
    /// <summary>
    /// Виды лошадиных сёдел
    /// </summary>
    public enum Saddle
    {
        /// <summary>
        /// Без седла
        /// </summary>
        [Description("Без седла")] None,
        /// <summary>
        /// Мягкое
        /// </summary>
        [Description("Мягкое")] Soft,
        /// <summary>
        /// Твердое
        /// </summary>
        [Description("Твердое")] Hard        
    }
}
