using System.ComponentModel.DataAnnotations;

namespace VideoGameStore.Models
{
    public class AuthenticateUser
    {
        [Key] public string Username { get; set; }
        public string Password { get; set; }
        public async Task<string> CheckUserLogin(string username, string password)
        {
            string url = "https://localhost:7031/api/Security/login/" + username + "/" + password;
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
