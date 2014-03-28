using System.Collections.Generic;
using System.Linq;
using apiFormTranslator.Model.Factories;
using apiFormTranslator.Model.POCO;
using apiFormTranslator.Model.Services.Readers;
using apiFormTranslator.Model.Services.WSHandlers;

namespace apiFormTranslator.Model.Services
{
    public class ItemImporter
    {
        private WordDocReader _wordDocReader;
        private ItemGenerator _itemGenerator;
        private IList<ItemService.ItemMCQ> _itemToSave;
        private IList<ItemMock> _itemMocksToCreate;

        public ItemImporter(WordDocReader wordDocReader, ItemGenerator itemGenerator)
        {
            _wordDocReader = wordDocReader;
            _itemGenerator = itemGenerator;
        }

        public ItemImporter() : this(new WordDocReader(), new ItemGenerator())
        {
        }

        public string ImportItems(string wordDoc)
        {
            var itemMocks = _wordDocReader.GetItemMocksFromWordDoc(wordDoc);
            var itemMocksAndItems = _itemGenerator.GetItemMocksAndItem(itemMocks);

            UpdateOrCreateItemFromItemMocks(itemMocksAndItems);

            if (_itemMocksToCreate != null)
            {
                foreach (var itemMock in _itemMocksToCreate)
                {
                    _itemToSave.Add(_itemGenerator.MakeItemFromItemMock(itemMock));
                }
            }
            if (_itemToSave != null)
            {
                new ItemServiceHandler().SaveItems(_itemToSave);
            }
            return "Items Imported and Saved to Intelitest";
        }

        private void UpdateOrCreateItemFromItemMocks(IDictionary<ItemMock, ItemService.ItemMCQ> itemMocksAndItems)
        {
            _itemToSave = new List<ItemService.ItemMCQ>();
            _itemMocksToCreate = new List<ItemMock>();

            foreach (var item in itemMocksAndItems.Values)
            {
                if (item != null)
                {
                    _itemToSave.Add(_itemGenerator.UpdateItemFromItemMock(itemMocksAndItems.FirstOrDefault(ItemMock => ItemMock.Value == item).Key, item));
                }
                else
                {
                    _itemMocksToCreate.Add(itemMocksAndItems.FirstOrDefault(ItemMock => ItemMock.Value == item).Key);
                }
            }
        }
    }
}
