namespace CA2_WebAppUsingAPIs.Models
{
    public class Card
    {
        public string id { get; set; }
        public string name { get; set; }
        public string set { get; set; }
        public Variant[] variants { get; set; }
    }

    public class Variant
    {
        public decimal price { get; set; }
        public string printing { get; set; }
        public string condition { get; set; }
    }

}
