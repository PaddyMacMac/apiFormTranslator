
namespace apiFormTranslator.Service.Requests
{
    public class ItemExportRequest
    {
        public string OutputDir { get; set; }
        public string Language { get; set; }
        public string FormId { get; set; }
        public string FormCode { get; set; }
    }
}
