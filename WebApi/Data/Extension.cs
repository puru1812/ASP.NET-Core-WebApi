namespace WebApi.Data
{
    public static class Extension
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<WebApiContext>();
                    context.Database.EnsureCreated();
                    DBInitializer.Initialize(context);
                }
            }
        }
    }
}
