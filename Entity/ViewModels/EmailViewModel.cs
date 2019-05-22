using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class EmailViewModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsHtml { get; set; }
    }
}
