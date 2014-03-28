using System;
using System.Collections.Generic;
using apiFormTranslator.Model.Enums;

namespace apiFormTranslator.Model.Services.WSHandlers
{
    public class ListServiceHandler : IServiceHandler
    {
        public IDictionary<string, string> GetItemPositionsAndIds(string itemListId)
        {
            using (var service = new ListService.ListService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.ListService) as ListService.User;
                try
                {
                    var itemList = service.LoadItemList(itemListId);
                    var itemPositionsAndIds = new Dictionary<string, string>();

                    foreach (var item in itemList.ItemListElements)
                    {
                        itemPositionsAndIds.Add(item.Ordinal.ToString(), item.ItemId);
                    }
                    return itemPositionsAndIds;
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("Can't find an Item List with ID: {0}", itemListId), e);
                }
            }
        }
    }
}
