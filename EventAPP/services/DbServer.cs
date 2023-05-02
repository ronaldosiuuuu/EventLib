namespace EventAPP.services
{
    public static class DbServer
    {
        public static String GetConnectionString =>
            @"Data Source=mssql3.unoeuro.com;User ID=khalidilmi_dk;Password=********;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
