using System;
using System.IO;
using Triple.Services;
using Triple.Entities.Charges;
using Microsoft.Extensions.Configuration;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Example Online.");

// Build the configuration
IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path to your app's root directory
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Load appsettings.json
    .Build();

// Access configuration values
string apiKey = configuration["TripleApiKey"];

Console.WriteLine($"API Key: {apiKey}");

// Example for charging
var service = new ChargeService();

var createOptions = new ChargeCreateOptions
{
    Amount = 123,
    CreditCardNumber = "4242424242424242",
    CardVerificationValue = "123",
    ExpirationMonth = "05",
    ExpirationYear = "29",
};

var result = service.Create(createOptions);

Console.WriteLine(result.ToString());