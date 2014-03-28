using System.Collections.Generic;

namespace apiFormTranslator.Model.POCO
{
    public class ItemMock
    {
        private IDictionary<string, string> optionsDictionary = new Dictionary<string, string>();

        public IDictionary<string, string> Options
        {
            get { return optionsDictionary; }
            set { optionsDictionary = value; }

        }
        public string MasterCode { get; set; }
        public string Stem { get; set; }
        public string Position { get; set; }
    }
}
