using System;
using System.Collections.Generic;
using System.Linq;
using apiFormTranslator.Model.POCO;
using Microsoft.Office.Interop.Word;

namespace apiFormTranslator.Model.Services.Writers
{
    public class WordDocWriter : IWriter
    {
        private const string TIMES_NEW_ROMAN = "Times New Roman";
        private const string DATE_FORMAT = "yyyy_MM_dd_hh_ss";
        private const int FONT_SIZE = 12;

        public string WriteWordDoc(string outputDir, string formCode, string language, IList<ItemMock> itemMocksOld, IList<ItemMock> itemMocksNew)
        {
            var word = new Application();
            word.Visible = true;
            var missing = System.Reflection.Missing.Value;
            var doc = word.Documents.Add(missing, missing, missing, missing);
            doc.Content.Font.Size = FONT_SIZE;
            doc.Content.Font.Name = TIMES_NEW_ROMAN;

            itemMocksOld = itemMocksOld.OrderBy(o => o.Position).ToList();
            foreach (var itemMock in itemMocksOld)
            {
                doc = MakeDocText(itemMock, doc);
                doc = MakeDocText(GetMatchingNewItemMock(itemMock, itemMocksNew), doc);
                doc.Words.Last.InsertBreak(WdBreakType.wdPageBreak);
            }

            var fileName = string.Format("{0}/{1}_{2}_{3}.docx", outputDir, formCode, language, DateTime.Now.ToString(DATE_FORMAT));
            doc.SaveAs(fileName);
            return string.Format("Word Document Created and Saved to: {0}", fileName);
        }

        private ItemMock GetMatchingNewItemMock(ItemMock oldItemMock, IList<ItemMock> itemMocksNew)
        {
            return itemMocksNew.Single(newItem => newItem.Position == oldItemMock.Position);
        }

        private const string OPTION_A = "A";
        private const string OPTION_B = "B";
        private const string OPTION_C = "C";
        private const string OPTION_D = "D";
        private const int FOUR_OPTIONS = 4;

        private Document MakeDocText(ItemMock itemMock, Document doc)
        {
            doc.Content.Text += string.Format("{0}. {1}", itemMock.Position, itemMock.Stem);
            if (itemMock.Options.Count == FOUR_OPTIONS)
            {
                doc.Content.Text += string.Format("(A) {0}", itemMock.Options[OPTION_A]);
                doc.Content.Text += string.Format("(B) {0}", itemMock.Options[OPTION_B]);
                doc.Content.Text += string.Format("(C) {0}", itemMock.Options[OPTION_C]);
                doc.Content.Text += string.Format("(D) {0}", itemMock.Options[OPTION_D]);
            }
            else
            {
                doc.Content.Text += "(A)";
                doc.Content.Text += "(B)";
                doc.Content.Text += "(C)";
                doc.Content.Text += "(D)";
            }
            doc.Words.Last.InsertBreak(WdBreakType.wdLineBreak);
            doc.Content.Text += string.Format("Master Code: {0}", itemMock.MasterCode);

            return doc;
        }
    }
}
