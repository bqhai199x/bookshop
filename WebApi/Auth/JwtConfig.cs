namespace WebApi.Auth
{
    public static class JwtConfig
    {
        public static int ExpireTime { get; set; } = 0;

        public static string SecretKey { get; set; } = string.Empty;
    }
}
