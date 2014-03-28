using System;
using System.Collections.Generic;
using apiFormTranslator.Model.Enums;
using apiFormTranslator.Model.POCO;

namespace apiFormTranslator.Model.Services.WSHandlers
{
    public class SearchServiceHandler : IServiceHandler
    {
        private const string MASTER_CODE = "MASTERCODE";
        private const string EXAM_CODE = "ExamCode";
        private const string MCQSR = "Prometric.Intelitest.ItemMCQSR";
        private const string MCQMR = "Prometric.Intelitest.ItemMCQMR";
        private const string MCMRD = "Prometric.Intelitest.ItemMCMRD";
        private const string HOT_SPOT = "Prometric.Intelitest.ItemHotSpot";
        private const string DRAG_DROP = "Prometric.Intelitest.ItemDragAndDrop";
        private const string FORM_ESSAY = "Prometric.Intelitest.ItemFreeFormEssay";
        private const string SHORT_ANSWER = "Prometric.Intelitest.ItemFreeFormShortAnswer";
        private const string EXAM = "Prometric.Intelitest.Exam";
        private const string NOT_FOUND = "NA";

        private const int FIRST_INDEX = 0;

        public IList<string> GetItemIdsFromMasterCodes(IList<string> masterCodes)
        {
            var itemIds = new List<string>();

            using (var service = new SearchService.SearchService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.SearchService) as SearchService.User;
                var locationId = new ICSServiceHandler().GetDefaultIcsRootId();
                var emptyStringSearchList = new SearchService.StringSearch[FIRST_INDEX];
                var emptyStringStatisticList = new SearchService.Statistic[FIRST_INDEX];
                var emptyStringList = new string[FIRST_INDEX];

                foreach (string masterCode in masterCodes)
                {
                    SearchService.SearchReference[] searchRefs = null;
                    searchRefs = service.ContentSearch(locationId,
                                                SearchService.enumSearchDepth.Deep,
                                                GetItemContentTypes(),
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                MakeMasterCodeAttribute(masterCode),
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                emptyStringStatisticList,
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                true,
                                                true
                                        );
                    try
                    {
                        itemIds.Add(searchRefs[FIRST_INDEX].value);
                    }
                    catch (Exception e)
                    {
                        //Do nothing...
                    }
                }
            }
            return itemIds;
        }

        public IDictionary<string, string> TryFindIdsFromMasterCodes(IList<string> masterCodes)
        {
            var mastterCodesAndIds = new Dictionary<string, string>();

            using (var service = new SearchService.SearchService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.SearchService) as SearchService.User;
                var locationId = new ICSServiceHandler().GetDefaultIcsRootId();
                var emptyStringSearchList = new SearchService.StringSearch[FIRST_INDEX];
                var emptyStringStatisticList = new SearchService.Statistic[FIRST_INDEX];
                var emptyStringList = new string[FIRST_INDEX];

                foreach (string masterCode in masterCodes)
                {
                    SearchService.SearchReference[] searchRefs = null;
                    searchRefs = service.ContentSearch(locationId,
                                                SearchService.enumSearchDepth.Deep,
                                                GetItemContentTypes(),
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                MakeMasterCodeAttribute(masterCode.Trim()),
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                emptyStringStatisticList,
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                emptyStringSearchList,
                                                true,
                                                true
                                        );
                    try
                    {
                        mastterCodesAndIds.Add(masterCode, searchRefs[FIRST_INDEX].value);
                    }
                    catch (Exception e)
                    {
                        mastterCodesAndIds.Add(masterCode, string.Empty);
                    }
                }
            }
            return mastterCodesAndIds;
        }

        private string[] GetItemContentTypes()
        {
            var contentTypes = new List<string>();
            contentTypes.Add(MCQSR);
            contentTypes.Add(MCQMR);
            contentTypes.Add(MCMRD);
            contentTypes.Add(HOT_SPOT);
            contentTypes.Add(DRAG_DROP);
            contentTypes.Add(FORM_ESSAY);
            contentTypes.Add(SHORT_ANSWER);
            return contentTypes.ToArray();
        }

        private SearchService.Attribute[] MakeMasterCodeAttribute(string masterCode)
        {
            return new SearchService.Attribute[] 
            { 
                new SearchService.Attribute
                {
                    searchType = SearchService.enumSearchType.Exact,
                    name = MASTER_CODE,
                    Value = masterCode,
                }
           };
        }
    }
}

