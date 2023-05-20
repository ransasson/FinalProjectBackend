using FinalProjectDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectContract.Data
{
    public class GetAllSessionsResponse
    {
        public List<SessionIdentifier> Sessions { get; set; } = new List<SessionIdentifier>();
    }
}
