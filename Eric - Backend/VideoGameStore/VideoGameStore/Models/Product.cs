using System;
using System.Collections.Generic;

namespace VideoGameStore.Models
{
    public partial class Product
    {
        public Product()
        {
        }
        public int productId { get; set; }
        public string? productName { get; set; }
        public string? productType { get; set; }
        public string? productGenre { get; set; }
        public string? productPlatform { get; set; }
        public string? productManufacturer { get; set; }
        public int? productReleaseDate { get; set; }
        public float? productCost { get; set; }
        public int? productQty { get; set; }
        public bool? productIsInStock { get; set; }
        public async Task<string> ViewAllProducts()
        {
            string url = "https://localhost:7031/api/Product";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        return data;
                    }
                }
            }
        }
    }
}
