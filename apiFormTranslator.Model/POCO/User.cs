using System;

namespace apiFormTranslator.Model.POCO
{
    public class User
    {
        private static volatile User _instance;
        private static object _syncRoot = new Object();

        public string ContextId { get; set; }
        public string Context { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public bool Authenticated { get; set; }

        public static User Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new User();
                    }
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private User() { }
    }   
}
