
namespace apiFormTranslator.View
{
    public interface IAPITranslationsForm
    {
        string UserId { get; set; }
        string CurrentContext { get; set; }
        string OutputDir { get; set; }
        string ExamCode { get; set; }
        string FormCode { get; set; }
        string Language { get; set; }
    }
}
