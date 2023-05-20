using FinalProjectContract.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectModel.Workflows
{
    public interface IGetSessionWorkflow
    {
        Task<GetSessionResponse> GetSessionAsync(GetSessionRequest request);
    }
}
