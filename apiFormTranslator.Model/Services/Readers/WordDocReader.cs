using System.Collections.Generic;
using apiFormTranslator.Model.POCO;
using Microsoft.Office.Interop.Word;
using System;
using System.Linq;
using apiFormTranslator.Model.Factories;

namespace apiFormTranslator.Model.Services.Readers
{
    public class WordDocReader : IReader
    {
        private const char NEW_LINE = '\r';
        private const string PAGE_BREAK = "\\f";
        private const int ITEM_BLOCK_PARTS = 6;

        public IDictionary<string, ItemMock> GetItemMocksFromWordDoc(string wordDocPath)
        {
            var itemMockBlocks = BreakUpPartsIntoBlocks(GetWordDocParts(wordDocPath));
            return new ItemMockGenerator().MakeItemMocksFromParts(itemMockBlocks);
        }

        private IList<string> GetWordDocParts(string wordDocPath)
        {
            var app = new Application();
            var documentParts = new string[] {};
            try
            {
                var doc = app.Documents.Open(wordDocPath, ReadOnly: true);
                documentParts = doc.Range().Text.Split(new char[] { NEW_LINE }, StringSplitOptions.RemoveEmptyEntries);
            }
            finally
            {
                app.Quit();
            }

            var newParts = new List<string>();

            foreach (var part in documentParts)
            {
                var newPart = part.Trim();

                if (newPart != string.Empty && newPart != PAGE_BREAK)
                {
                    newParts.Add(newPart);
                }
            }
            return newParts;
        }

        private IList<string[]> BreakUpPartsIntoBlocks(IList<string> parts)
        {
            var blocks = new List<string[]>();

            for (int i = 0; i < parts.Count; i += ITEM_BLOCK_PARTS)
            {
                blocks.Add(parts.Skip(i).Take(ITEM_BLOCK_PARTS).ToArray());
            }
            return blocks;
        }
    }
}
