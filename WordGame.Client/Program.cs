using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WordGame.Client;
using WordGame.Domain.Interfaces;
using WordGame.Domain.Interfaces.ApiHandlers;
using WordGame.Domain.Interfaces.Services;
using WordGame.Service.ApiHandlers;
using WordGame.Service.Services;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.
         AddTransient<IDictionaryApiHandler, DictionaryApiHandler>()
        .AddTransient<IWordService, WordService>()
        .AddTransient<IWordGame, ConsoleWordGame>())
    .Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

var wordGame = provider.GetRequiredService<IWordGame>();
await wordGame.Start(90);
