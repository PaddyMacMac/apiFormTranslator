using System;
using apiFormTranslator.Model.Services;
using apiFormTranslator.Service.Requests;
using apiFormTranslator.Service.Responses;

namespace apiFormTranslator.Service.Services
{
    public class ItemImportService
    {
        private ItemImporter _itemImporter;

        public ItemImportService(ItemImporter itemImporter)
        {
            _itemImporter = itemImporter;
        }

        public ItemImportService() : this(new ItemImporter()) { }

        public APIResponse ImportItems(ItemImportRequest request)
        {
            APIResponse apiResponse = null;

            try
            {
                apiResponse = new APIResponse()
                {
                    Error = null,
                    Success = true,
                    Message = _itemImporter.ImportItems(request.WordDocPath)
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
