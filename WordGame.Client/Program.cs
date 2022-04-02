using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WordGame.Client.Dependencies;
using WordGame.Domain.Interfaces;

using IHost host = Host.CreateDefaultBuilder(args)
   .RegisterConfiguration()
   .ConfigureServices((_, services) => services.RegisterApiHadndlers().RegisterServices()).Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

var wordGame = provider.GetRequiredService<IWordGame>();
await wordGame.Start();