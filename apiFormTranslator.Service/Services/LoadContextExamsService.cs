using System;
using apiFormTranslator.Model.Services.Persistance;
using apiFormTranslator.Service.Requests;
using apiFormTranslator.Service.Responses;

namespace apiFormTranslator.Service.Services
{
    public class LoadContextExamsService
    {
        public LoadContextExamsResponse LoadContextExams(LoadContextExamsRequest request)
        {
            LoadContextExamsResponse loadContextExamsResponse = null;
            try
            {
                loadContextExamsResponse = new LoadContextExamsResponse()
                {
                    Error = null,
                    Success = true,
                    ExmaNamesAndIds = new ExamFacade().LoadContextExamsNamesAndIds(request.Context)
                };
            }
            catch (Exception ex)
            {
                loadContextExamsResponse = new LoadContextExamsResponse()
                {
                    Error = ex,
                    Success = false,
                };
            }
            return loadContextExamsResponse;
        }
    }
}
