namespace CA2_WebAppUsingAPIs.Models
{
    public class YgoCard
    {
        public class CardImage
        {
            public int id { get; set; }
            public string image_url { get; set; }
            public string image_url_small { get; set; }
            public string image_url_cropped { get; set; }
        }

        public class CardInfo
        {
            public int id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string desc { get; set; }
            public int? atk { get; set; }
            public int? def { get; set; }

            public List<CardImage> card_images { get; set; }
        }

        public class CardInfoResponse
        {
            public List<CardInfo> data { get; set; }
        }

    }
}
