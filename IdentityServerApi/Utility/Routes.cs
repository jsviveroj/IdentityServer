namespace IdentityServerApi.Utility
{
    public static class Routes
    {
        public const string ProducesJson = "application/json";

        public static class Sections
        {
            public const string IdentityServer = "IdentityServer";
            public static string IdentityServerBase = $"{IdentityServer}:Base";
            public static string IdentityServerClientCredentials = $"{IdentityServer}:ClientCredentials";
        }

        public static class Clients
        {
            public const string ClientCredentialsClient = "Cc";
        }

        public static class Scopes
        {
            public const string UsersApiScope = "UsersApi";
        }

        public static class AuthController
        {
            public const string GetClientToken = "Auth/ApiToken";
        }


    }
}
