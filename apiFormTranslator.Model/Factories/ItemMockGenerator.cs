using System;
using System.Collections.Generic;
using System.Linq;
using apiFormTranslator.Model.POCO;
using apiFormTranslator.Model.Services.WSHandlers;

namespace apiFormTranslator.Model.Factories
{
    public class ItemMockGenerator
    {
        #region private constants
        private const int STEM_INDEX = 0;
        private const int MASTER_CODE_INDEX = 5;
        private const string ENGLISH_510_PREFIX = "APVx";
        private const string ENGLISH_570_PREFIX = "APPx";
        private const string CHINESE = "Chinese";
        private const string SPANISH = "Spanish";
        private const string KOREAN = "Korean";
        private const string FRENCH = "French";
        private const string CHINESE_PREFIX = "PVC";
        private const string SPANISH_PREFIX = "PVS";
        private const string KOREAN_PREFIX = "PVK";
        private const string FRENCH_PREFIX = "FRE";
        private const int A_INDEX = 1;
        private const int B_INDEX = 2;
        private const int C_INDEX = 3;
        private const int D_INDEX = 4;
        private const string RIGHT_BRACKET = ")";
        private const string DOT = ".";
        private const string COLON = ":";
        private const int SHIFT_ONE_CHAR_RIGHT = 1;
        #endregion

        private IList<string> _newMasterCodes = new List<string>();

        #region Item Mock Export public methods

        public IList<ItemMock> MakeMockItems(IDictionary<string, ItemService.ItemMCQ> positinosAndItems)
        {
            var itemMocks = new List<ItemMock>();

            foreach (var item in positinosAndItems.Values)
            {
                var itemMock = new ItemMock()
                {
                    Position = positinosAndItems.FirstOrDefault(x => x.Value == item).Key,
                    MasterCode = item.mastercode,
                    Stem = item.stem,
                    Options = MakeOptions(item.ListOfOptions)
                };
                itemMocks.Add(itemMock);
            }
            return itemMocks;
        }

        public IList<ItemMock> MakeNewMockItems(IList<ItemMock> oldMockItems, string language)
        {
            var newItemMocks = MakeIntialNewItemMocks(oldMockItems, language);
            var itemIds = new SearchServiceHandler().GetItemIdsFromMasterCodes(_newMasterCodes);

            var items = new ItemServiceHandler().GetItems(itemIds);

            foreach (var itemMock in newItemMocks)
            {
                foreach (var item in items)
                {
                    if (itemMock.MasterCode == item.mastercode)
                    { 
                        itemMock.Stem = item.stem;
                        itemMock.Options = MakeOptions(item.ListOfOptions);
                    }
                }  
            }
            return newItemMocks;
        }
        #endregion

        #region Item Mock Imprt public method

        public IDictionary<string, ItemMock> MakeItemMocksFromParts(IList<string[]> itemMockParts)
        {
            var itemMocks = new Dictionary<string, ItemMock>();

            foreach (var partsArray in itemMockParts)
            {
                if (!(partsArray[MASTER_CODE_INDEX].Contains(ENGLISH_510_PREFIX) || partsArray[MASTER_CODE_INDEX].Contains(ENGLISH_570_PREFIX)))
                {
                    var masterCode = partsArray[MASTER_CODE_INDEX];
                    masterCode = masterCode.Substring(masterCode.IndexOf(COLON) + SHIFT_ONE_CHAR_RIGHT);
                    itemMocks.Add(masterCode, MakeItemMockFromItemParts(partsArray, masterCode));
                }
            }
            return itemMocks;
        }
        #endregion 

        #region Item Mock Exprot private Methods

        private IDictionary<string, string> MakeOptions(ItemService.ItemOption[] itemOption)
        {
            var optionsDic = new Dictionary<string, string>();
            optionsDic.Add("A", itemOption[0].OptionText);
            optionsDic.Add("B", itemOption[1].OptionText);
            optionsDic.Add("C", itemOption[2].OptionText);
            optionsDic.Add("D", itemOption[3].OptionText);
            return optionsDic;
        }

        private const int MASTER_CODE_PREFIX_START = 0;
        private const int MASTER_CODE_PREFIX_END = 4;

        private IList<ItemMock> MakeIntialNewItemMocks(IList<ItemMock> oldMockItems, string language)
        {
            var newItemMocks = new List<ItemMock>();

            var prefix = GetLanguagePrefix(language);

            foreach (var item in oldMockItems)
            {
                var newMasterCode = item.MasterCode.Replace(item.MasterCode.Substring(MASTER_CODE_PREFIX_START, MASTER_CODE_PREFIX_END), prefix);
                _newMasterCodes.Add(newMasterCode);
                var newItem = new ItemMock()
                {
                    Position = item.Position,
                    MasterCode = newMasterCode
                };
                newItemMocks.Add(newItem);
            }
            return newItemMocks;
        }

        private string GetLanguagePrefix(string language)
        {
            switch (language)
            {
                case CHINESE:
                    return CHINESE_PREFIX;
                case SPANISH:
                    return SPANISH_PREFIX;
                case KOREAN:
                    return KOREAN_PREFIX;
                case FRENCH:
                    return FRENCH_PREFIX;
                default: return "NA";
            }
        }
        #endregion

        #region Item Mock Import private Methods

        private ItemMock MakeItemMockFromItemParts(string[] itemParts, string code)
        {
            var stem = itemParts[STEM_INDEX];
            var masterCode = itemParts[MASTER_CODE_INDEX];
            var itemMock = new ItemMock()
            {
                Stem = GetCleanPart(itemParts, STEM_INDEX, DOT, code),
                Options = GetOptions(itemParts, code),
                MasterCode = GetCleanPart(itemParts, MASTER_CODE_INDEX, COLON, code),
            };
            return itemMock;
        }

        private string GetCleanPart(string[] itemParts, int partIndex, string deliminator, string masterCode)
        {
            var cleanPart = itemParts[partIndex];
            if (!cleanPart.Contains(deliminator))
            {
                throw new Exception(string.Format("Corrupt Item containd in Word Doc, Item with {0}, is missing a {1}", masterCode, deliminator));
            }
            return cleanPart.Substring((cleanPart.IndexOf(deliminator) + SHIFT_ONE_CHAR_RIGHT)).Trim();

        }

        private IDictionary<string, string> GetOptions(string[] itemParts, string masterCode)
        {
            var optionsDic = new Dictionary<string, string>();
            optionsDic.Add("A", GetCleanPart(itemParts, A_INDEX, RIGHT_BRACKET, masterCode));
            optionsDic.Add("B", GetCleanPart(itemParts, B_INDEX, RIGHT_BRACKET, masterCode));
            optionsDic.Add("C", GetCleanPart(itemParts, C_INDEX, RIGHT_BRACKET, masterCode));
            optionsDic.Add("D", GetCleanPart(itemParts, D_INDEX, RIGHT_BRACKET, masterCode));
            return optionsDic;
        }
        #endregion
    }
}
