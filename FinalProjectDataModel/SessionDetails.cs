using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDataModel
{
    public class SessionDetails
    {
        public SessionIdentifier SessionIdentifier { get; set; }
        public List<PersonData> People { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
    }
}
