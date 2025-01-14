using Serilog;

namespace RuiChen.AbpPro.Admin.HttpApi.Host
{
    public class Program
    {
        public async static Task<int> Main(string[] args)
        {
            try
            {
                Console.Title = "RuiChenAdmin";
                Log.Information("Starting RuiChen.AbpPro.Admin.HttpApi.Host.");

                var builder = WebApplication.CreateBuilder(args);
                builder.Host.AddAppSettingsSecretsJson()
                    .UseAutofac()
                    .UseSerilog((context, provider, config) =>
                    {
                        config.ReadFrom.Configuration(context.Configuration);
                    });
                await builder.AddApplicationAsync<RuiChenAbpProAdminHttpApiHostModule>();
                var app = builder.Build();
                await app.InitializeApplicationAsync();
                await app.RunAsync();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly!");
                Console.WriteLine("Host terminated unexpectedly!");
                Console.WriteLine(ex.ToString());
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
