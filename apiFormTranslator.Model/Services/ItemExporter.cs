using System;
using System.Collections.Generic;
using apiFormTranslator.Model.Factories;
using apiFormTranslator.Model.Services.Writers;
using apiFormTranslator.Model.Services.WSHandlers;

namespace apiFormTranslator.Model.Services
{
    public class ItemExporter
    {
        private const int EMPTY_LIST = 0;

        private WordDocWriter _wordDocWriter;

        public ItemExporter(WordDocWriter wordDocReader)
        {
            _wordDocWriter = wordDocReader;
        }

        public ItemExporter()
            : this(new WordDocWriter())
        {
        }

        public string ExportItems(string outputDir, string formCode, string formId, string language)
        {
            var itemMockMaker = new ItemMockGenerator();
            var itemMocksOld = itemMockMaker.MakeMockItems(GetPositionsAndItems(formId));
            var itemMocksNew = itemMockMaker.MakeNewMockItems(itemMocksOld, language);
            return _wordDocWriter.WriteWordDoc(outputDir, formCode, language, itemMocksOld, itemMocksNew);
        }

        private IDictionary<string, ItemService.ItemMCQ> GetPositionsAndItems(string formId)
        {
            try
            {
                var itemListId = new ExamServiceHandler().GetItemListId(formId);
                var itemPositionsAndIds = new ListServiceHandler().GetItemPositionsAndIds(itemListId);
                return new ItemServiceHandler().GetOrdinalsAndItems(itemPositionsAndIds);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Unable to Load Form with Form Id: {0}", formId), ex);
            }
        }
    }
}
