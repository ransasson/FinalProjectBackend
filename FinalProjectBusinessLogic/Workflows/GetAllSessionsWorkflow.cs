using FinalProjectContract.Data;
using FinalProjectModel.Components;
using FinalProjectModel.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectBusinessLogic.Workflows
{
    public class GetAllSessionsWorkflow : IGetAllSessionsWorkflow
    {
        private readonly ISessionHandler _sessionHander;
        public GetAllSessionsWorkflow(ISessionHandler sessionHander)
        {
            _sessionHander = sessionHander;
        }
        public Task<GetAllSessionsResponse> GetAllSessionsAsync(GetAllSessionsRequest request)
        {
            try
            {
                Console.WriteLine("Getting all sessions");
                return _sessionHander.GetAllSessions(request);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to get all sessions");
                throw;
            }
        }
    }
}
