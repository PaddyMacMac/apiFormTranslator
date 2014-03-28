using System.Collections.Generic;
using System.Linq;
using apiFormTranslator.Service.Requests;
using apiFormTranslator.Service.Services;
using apiFormTranslator.View;

namespace apiFormTranslator.Presenter
{
    public class APITranslationsFormPresenter : IPresenter
    {
        private SecurityService _securityService;
        private IDictionary<string, string> _contextNamesAndIds;
        private IDictionary<string, string> _examNamesAndIds;
        private IDictionary<string, string> _formNamesAndIds;
        private IAPITranslationsForm _view;

        public APITranslationsFormPresenter(SecurityService securityService, IAPITranslationsForm view)
        {
            _securityService = securityService;
            _view = view;
        }

        public APITranslationsFormPresenter(IAPITranslationsForm view)
            : this(new SecurityService(), view)
        {
        }

        public IDictionary<string, string> LoadUserContexts()
        {
            var request = new UserContextsRequest()
            {
                UserId = _view.UserId
            };

            var response = _securityService.LoadUserContexts(request);

            if (response.Success)
            {
                _contextNamesAndIds = response.Contexts;
                return _contextNamesAndIds;
            }
            else
            {
                throw response.Error;
            }
        }

        public IDictionary<string, string> LoadContextExams()
        {
            var request = new LoadContextExamsRequest()
            {
                Context = _securityService.GetCurrentContext()
            };

            var response = new LoadContextExamsService().LoadContextExams(request);
            _examNamesAndIds = response.ExmaNamesAndIds;

            if (response.Success)
            {
                return response.ExmaNamesAndIds; 

            }
            else
            {
                throw response.Error;
            }
        }

        public IDictionary<string, string> LoadExamsForms()
        {
            var request = new LoadExamFormsRequest()
            {
                ExamId = GetIDFromName(_examNamesAndIds, _view.ExamCode)
            };

            var response = new LoadExamFormsService().LoadExamsForms(request);
            _formNamesAndIds = response.FormIdsAndCodes;

            if (response.Success)
            {
                return _formNamesAndIds;
            }
            else
            {
                throw response.Error;
            }
        }

        public void SetCurrentContext()
        {
            var request = new SetCurrentContextRequest()
            {
                ContextName = _view.CurrentContext,
                ContextId = GetIDFromName(_contextNamesAndIds, _view.CurrentContext)
            };

            _securityService.SetCurrentContext(request);
        }

        public string PerformExports()
        {
            var request = new ItemExportRequest()
            {
                OutputDir = _view.OutputDir,
                Language = _view.Language,
                FormCode = _view.FormCode,
                FormId = GetIDFromName(_formNamesAndIds, _view.FormCode)
            };

            var response = new ItemExportService().ExportItems(request);

            if (response.Success)
            {
                return response.Message;
            }
            else
            {
                throw response.Error;
            }
        }

        public string PerformImports()
        {
            var request = new ItemImportRequest()
            {
                WordDocPath = _view.OutputDir
            };

            var response = new ItemImportService().ImportItems(request);

            if (response.Success)
            {
                return response.Message;
            }
            else
            {
                throw response.Error;
            }
        }

        private string GetIDFromName(IDictionary<string, string> dic, string value)
        {
            return dic.Where(p => p.Value == value).Select(p => p.Key).FirstOrDefault();
        }
    }
}
