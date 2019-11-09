using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Models.Responses
{
    public class EditResponse: Response
    {
        public Order UpdatedOrder { get; set; }
        public Order OldOrder { get; set; }
    }
}
