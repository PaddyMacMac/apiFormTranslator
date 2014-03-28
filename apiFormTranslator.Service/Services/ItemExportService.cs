using System;
using apiFormTranslator.Model.Services;
using apiFormTranslator.Service.Requests;
using apiFormTranslator.Service.Responses;

namespace apiFormTranslator.Service.Services
{
    public class ItemExportService
    {
        private ItemExporter _apiFormTranslator;

        public ItemExportService(ItemExporter apiFormTranslator)
        {
            _apiFormTranslator = apiFormTranslator;
        }

        public ItemExportService() : this(new ItemExporter()) { }

        public APIResponse ExportItems(ItemExportRequest request)
        {
            APIResponse apiResponse = null;

            try
            {
                apiResponse = new APIResponse()
                {
                    Error = null,
                    Success = true,
                    Message = _apiFormTranslator.ExportItems(request.OutputDir,request.FormCode, request.FormId, request.Language)
                };
            }
            catch (Exception ex)
            {
                apiResponse = new APIResponse()
                {
                    Error = ex,
                    Success = false,
                };
            }
            return apiResponse;
        }
    }
}
