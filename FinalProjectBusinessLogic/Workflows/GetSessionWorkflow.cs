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
    public class GetSessionWorkflow : IGetSessionWorkflow
    {
        private readonly ISessionHandler _sessionHendler;

        public GetSessionWorkflow(ISessionHandler sessionHendler)
        {
			_sessionHendler = sessionHendler;
        }
        public async Task<GetSessionResponse> GetSessionAsync(GetSessionRequest request)
        {
			try
			{

				if (request == null || request.SessionId == null)
				{

					throw new ArgumentNullException("Get Session must include id!");
				}
                Console.WriteLine("Trying to get session with id:" + request.SessionId);

                return await _sessionHendler.GetSession(request);
			}
			catch (Exception)
			{
                Console.WriteLine("Failed to get session with id:" + request.SessionId);
                throw;
			}
        }
    }
}
