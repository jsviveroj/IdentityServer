namespace IdentityServerApi.Models
{
    public class SecurityClient
    {
        public string ClientId { get; set; }
        public string[] ClientSecrets { get; set; }
        public string[] Scopes { get; set; }
    }
}
