using OGCP.Curriculums.BlazorServer.Extensions;

namespace OGCP.Curriculums.BlazorServer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        try
        {
            builder
                .ConfigureServices()
                .ConfigurePipeline()
                .Run();
        }
        catch (Exception)
        {

            throw;
        }




        var app = builder.Build();
    }
}
