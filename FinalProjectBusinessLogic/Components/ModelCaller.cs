using FinalProjectModel.Components;
using FinalProjectModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectBusinessLogic.Components
{
    public class ModelCaller : IModelCaller
    {
        public CallModelResponse CallModel(CallModelRequest request)
        {
            return new CallModelResponse();
        }
    }
}
