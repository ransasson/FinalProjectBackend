using FinalProjectContract.Data;
using FinalProjectModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectModel.Components
{
    public interface ISessionHandler
    {
        Task<SaveImageResponse> SaveImage(SaveImageRequest request);
        Task<GetAllSessionsResponse> GetAllSessions(GetAllSessionsRequest request);
        Task<GetSessionResponse> GetSession(GetSessionRequest request);
    }
}
