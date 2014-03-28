using System;
using System.Collections.Generic;
using System.Linq;
using apiFormTranslator.Model.POCO;
using apiFormTranslator.Model.Services.WSHandlers;

namespace apiFormTranslator.Model.Factories
{
    public class ItemGenerator
    {
        public ItemService.ItemMCQ UpdateItemFromItemMock(ItemMock itemMock, ItemService.ItemMCQ item)
        {
            item.stem = itemMock.Stem;
            item.ListOfOptions = GetOptions(item.ListOfOptions, itemMock.Options);
            return item;
        }

        public IDictionary<ItemMock, ItemService.ItemMCQ> GetItemMocksAndItem(IDictionary<string, ItemMock> itemMocks)
        {
            var masterCodesAndItemIds = new SearchServiceHandler().TryFindIdsFromMasterCodes(itemMocks.Keys.ToList());
            var itemMocksAndItems = new Dictionary<ItemMock, ItemService.ItemMCQ>();
            var masterCodesAndItems = new ItemServiceHandler().GetMasterCodesAndItems(masterCodesAndItemIds);

            foreach (var masterCode in masterCodesAndItems.Keys)
            {
                var itemMockFromMasterCode = itemMocks.Values.ToList().FirstOrDefault(itemMock => itemMock.MasterCode.Trim() == masterCode.Trim());
                itemMocksAndItems.Add(itemMockFromMasterCode, masterCodesAndItems[masterCode]);
            }

            return itemMocksAndItems;
        }

        private const string NEW_ITEM_STATE = "New";

        public ItemService.ItemMCQSR MakeItemFromItemMock(ItemMock itemMock)
        {
            if (EnsureMaterCodeDoesExist(itemMock.MasterCode))
            {
                return new ItemService.ItemMCQSR()
                {
                    mastercode = itemMock.MasterCode,
                    stem = itemMock.Stem,
                    ListOfOptions = MakeItemOptions(itemMock.Options).ToArray(),
                    state = NEW_ITEM_STATE,
                    //ownerid = User.Instance.ContextId,
                    folderuuid = new ICSServiceHandler().GetDefaultIcsRootId()
                };
            }
            throw new Exception(string.Format("Master Code: {0}, already contained within Intelitest...", itemMock.MasterCode));
        }

        private bool EnsureMaterCodeDoesExist(string masterCode)
        {
            return new AutoGenCodeServiceHandler().CheckCodeExist(masterCode);
        }

        private ItemService.ItemOption[] GetOptions(ItemService.ItemOption[] itemOptions, IDictionary<string, string> itemMockOptions)
        {
            for (int i = 0; i < itemOptions.Length; i++)
            {
                itemOptions[i].OptionText = itemMockOptions.ElementAt(i).Value;
            }
            return itemOptions;
        }

        private IList<ItemService.ItemOption> MakeItemOptions(IDictionary<string, string> itemMockOptions)
        {
            var itemOptions = new List<ItemService.ItemOption>();

            foreach(var optionText in itemMockOptions.Values)
            {
                var itemOption = new ItemService.ItemOption()
                    {
                        OptionText = optionText
                    };
                itemOptions.Add(itemOption);
            }

            return itemOptions;
        }
    }
}
