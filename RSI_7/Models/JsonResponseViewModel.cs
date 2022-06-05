using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSI_7.Models
{
    [Serializable]
    public class JsonResponseViewModel
    {
        public int ResponseCode { get; set; }

        public string ResponseMessage { get; set; } = string.Empty;
    }
}
