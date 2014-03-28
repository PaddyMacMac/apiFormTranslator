using System;
using System.Collections.Generic;
using apiFormTranslator.Model.Enums;

namespace apiFormTranslator.Model.Services.WSHandlers
{
    public class ExamServiceHandler : IServiceHandler
    {
        public IDictionary<string, string> LoadFormCodesAndIds(string examId)
        {
            using (var service = new ExamService.ExamService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.ExamService) as ExamService.User;
                var formCodesAndNames = new Dictionary<string, string>();
                try
                {
                    var examForms = service.LoadExamFormList(examId);

                    foreach (var form in examForms)
                    {
                        formCodesAndNames.Add(form.UUID, form.FormCode);
                    }
                    return formCodesAndNames;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Unable to load Exam with ExmaId: {0}.", examId), ex);
                }
            }
        }

        public string GetItemListId(string formId)
        {
            using (var service = new ExamService.ExamService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.ExamService) as ExamService.User;
                var formCodesAndNames = new Dictionary<string, string>();
                try
                {
                    return service.LoadExamForm(formId).ItemListUUID;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Unable to load Exam with ExmaId: {0}.", formId), ex);
                }
            }
        
        }
    }
}
