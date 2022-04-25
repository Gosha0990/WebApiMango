using System;

namespace WebApiMango.ApiMango
{
    public class Call
    {
        public string entry_id { get; set; }
        public string call_id { get; set; }
        public DateTime timestamp { get; set; }
        public string seq { get; set; }
        public Form form { get; set; }
        public To to { get; set; }

    }
    public class Form
    { 
        public string extension { get; set; }
    }
    public class To
    {
        public string number { get; set; }
    }
}
