using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NichoShop.TestDataLoader.Features;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using NichoShop.Application.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.Hosting;
using NichoShop.Infrastructure;

namespace NichoShop.TestDataLoader;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
                config.SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{environment}.json", optional: true);
            })
            .ConfigureServices((context, services) =>
            {
                var configuration = context.Configuration;
                services.AddDbContext<NichoShopDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("NichoShopDB")));
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            })
            .Build();

        var mediator = host.Services.GetRequiredService<IMediator>();

        while (true)
        {
            DisplayMenu();

            int choice = GetMenuChoice();

            if (choice == 0)
            {
                Console.WriteLine("Exiting the application. Goodbye!");
                break;
            }
            else
            {
                var selectedOption = MenuOption.GetAll<MenuOption>().FirstOrDefault(option => option.Id == choice);

                if (selectedOption == null)
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }
                Console.WriteLine($"Executing: {selectedOption.Name}");
                try
                {
                    await mediator.Send(selectedOption.Command);
                    Console.WriteLine("Action completed.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("0. Exit");
        foreach (var option in MenuOption.GetAll<MenuOption>())
        {
            Console.WriteLine($"{option.Id}. {option.Name}");
        }
        Console.Write("Your choice: ");
    }

    static int GetMenuChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice)) { }
        return choice;
    }
}


