using System;
using System.Linq;
using System.Collections.Generic;
using apiFormTranslator.Model.Enums;

namespace apiFormTranslator.Model.Services.WSHandlers
{
    public class ItemServiceHandler : IServiceHandler
    {
        public IList<ItemService.ItemMCQ> GetItems(IList<string> itemIds)
        {
            var items = new List<ItemService.ItemMCQ>();

            foreach (string itemId in itemIds)
            {
                try
                {
                    using (var service = new ItemService.ItemService())
                    {
                        service.user = GetServiceUser(ServiceTypesEnum.ItemService) as ItemService.User;
                        var item = service.LoadItem(itemId) as ItemService.ItemMCQ;
                        items.Add(item);
                    }
                }
                catch (Exception e)
                {
                    //Do nothing...
                }
            }
            return items;
        }

        public IDictionary<string, ItemService.ItemMCQ> GetOrdinalsAndItems(IDictionary<string, string> itemPositionsAndIds)
        {
            var positionsAndItems = new Dictionary<string, ItemService.ItemMCQ>();

            using (var service = new ItemService.ItemService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.ItemService) as ItemService.User;

                foreach (string itemId in itemPositionsAndIds.Values)
                {
                    try
                    {
                        var item = service.LoadItem(itemId) as ItemService.ItemMCQ;
                        positionsAndItems.Add(GetKeyFromValue(itemPositionsAndIds, itemId), item);
                    }

                    catch (Exception e)
                    {
                        throw new Exception(string.Format("The provided Item Id: {0}, does not match any Item, please provide only valid Item Ids", itemId), e);
                    }
                }
            }
            return positionsAndItems;
        }

        public IDictionary<string, ItemService.ItemMCQ> GetMasterCodesAndItems(IDictionary<string, string> mastersCodeAndIds)
        {
            var masterCodesAndItems = new Dictionary<string, ItemService.ItemMCQ>();

            using (var service = new ItemService.ItemService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.ItemService) as ItemService.User;

                foreach (string itemId in mastersCodeAndIds.Values)
                {
                    try
                    {
                        var item = service.LoadItem(itemId) as ItemService.ItemMCQ;
                        masterCodesAndItems.Add(GetKeyFromValue(mastersCodeAndIds, itemId), item);
                    }
                    catch (Exception e)
                    {
                        masterCodesAndItems.Add(GetKeyFromValue(mastersCodeAndIds, itemId), null);
                    }
                }
            }
            return masterCodesAndItems;
        }

        public void SaveItems(IList<ItemService.ItemMCQ> items)
        {
            using (var service = new ItemService.ItemService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.ItemService) as ItemService.User;
                foreach (var item in items)
                {
                    service.SaveItem(item);
                }
            }
        }

        private string GetKeyFromValue(IDictionary<string, string> dictionary, string value)
        {
            return dictionary.FirstOrDefault(x => x.Value == value).Key;
        }
    }
}
