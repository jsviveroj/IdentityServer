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
            public static string SecurityClients = "IdentityServer:SecurityClients";
        }

        public static class Clients
        {
            public const string ClientCredentialsClient = "Cc";
        }

        public static class Scopes
        {
            public static string All = "all";
            public static string Read = "read";
            public static string Write = "write";
            public static string Delete = "delete";
        }

        public static class Apiresources
        {
            public static string UsersApi = "usersApi";
        }

        public static class AuthController
        {
            public const string GetClientToken = "Auth/ApiToken";
        }


    }
}
