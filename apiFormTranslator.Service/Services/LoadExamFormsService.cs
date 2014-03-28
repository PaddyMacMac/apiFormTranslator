using System;
using apiFormTranslator.Model.Services.WSHandlers;
using apiFormTranslator.Service.Requests;
using apiFormTranslator.Service.Responses;

namespace apiFormTranslator.Service.Services
{
    public class LoadExamFormsService
    {
        public LoadExamFormsResponse LoadExamsForms(LoadExamFormsRequest request)
        {
            LoadExamFormsResponse loadExamFormsResponse = null;
            try
            {
                loadExamFormsResponse = new LoadExamFormsResponse()
                {
                    Error = null,
                    Success = true,
                    FormIdsAndCodes = new ExamServiceHandler().LoadFormCodesAndIds(request.ExamId)
                };
            }
            catch (Exception ex)
            {
                loadExamFormsResponse = new LoadExamFormsResponse()
                {
                    Error = ex,
                    Success = false,
                };
            }
            return loadExamFormsResponse;
        }
    }
}
