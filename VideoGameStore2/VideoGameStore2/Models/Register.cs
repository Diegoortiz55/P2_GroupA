using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace VideoGameStore2.Models
{
    public partial class Register
    {
        public Register()
        {
            OrderList = new HashSet<Order>();
        }
        public Register(string user) : this()
        {
            userName = user;
        }
        public string userName { get; set; } = null!;
        public string? userPassword { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? stAddress { get; set; }
        public string? city { get; set; }
        public string? customerState { get; set; }
        public int? AddressZip { get; set; }
        public virtual ICollection<Order> OrderList { get; set; }
        public async Task<string> AddCustomer(Register newRegister)
        {
            string url = "https://localhost:7001/api/Registers";

            var myContent = JsonConvert.SerializeObject(newRegister);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(url, byteContent))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null) { return "Customer added successfuly."; }
                    }
                }
            }
            return "Adding customer failed.";
        }
    }
}