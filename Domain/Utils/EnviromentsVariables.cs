namespace Domain.Utils
{
    public static class EnviromentsVariables
    {
        public static string Jwt_Key = Environment.GetEnvironmentVariable("JWT_KEY")
            ?? throw new Exception("Chave JWT não configurada");

        public static string Jwt_Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER")
            ?? throw new Exception("Issuer JWT não configurado");

        public static string Jwt_Audience = Environment.GetEnvironmentVariable("JWT_ISSUER")
            ?? throw new Exception("Audience JWT não configurado");

        public static string Connection_String = Environment.GetEnvironmentVariable("MONGO_CONNECTION")
            ?? throw new Exception("Conexão não foi configurada");

        public static string Mongo_DataBase = Environment.GetEnvironmentVariable("MONGO_DATABASE")
            ?? throw new Exception("Conexão com Mongo não foi configurada");

        //public static string Cors_Origins = Environment.GetEnvironmentVariable("CORS_ORIGINS")
        //    ?? throw new Exception("Conexão com Mongo não foi configurada");
    }
}