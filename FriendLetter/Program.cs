using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace FriendLetter //Note that both Startup.cs and Program.cs files contain code in the same FriendLetter namespace. 
{
    public class Program
  {
    public static void Main(string[] args)
    {
      var host = new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .Build();

      host.Run();
    }
  }
}