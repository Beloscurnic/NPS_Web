using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Global_Models
{
    /// <summary>
    /// Класс, представляющий базовый JSON-ответ.
    /// </summary>
    public class BaseJsonResponse
    {
        /// <summary>
        /// Получает или задает код результата выполнения.
        /// </summary>
        public virtual ExecutionResult Result { get; set; }

        /// <summary>
        /// Получает или устанавливает сообщение о выполнении.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Получает или задает значение, указывающее, следует ли показывать 
        /// всплывающее сообщение во внешнем интерфейсе.
        /// </summary>
        public bool ShowToast { get; set; }
    }
}
