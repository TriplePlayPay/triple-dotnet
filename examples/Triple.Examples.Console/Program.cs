using System;
using System.IO;
using Triple.Services;
using Triple.Tokens;
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
    Amount = "123.00",
    CreditCardNumber = "4242424242424242",
    CardVerificationValue = "123",
    ExpirationMonth = "05",
    ExpirationYear = "29",
};

Charge result = service.Create(createOptions);
string token = result.Message.Token;

string decodedToken = Decoder.DecodeTokenString(token);
Console.WriteLine(decodedToken);

// make a request with the existing base64 url encoded token
var secondChargeOptions = new ChargeCreateOptions
{
    Amount = "10.38",
    Token = token,
};

Charge secondCharge = service.Create(secondChargeOptions);

Console.WriteLine(secondCharge.ToString());

string reEncodedToken = Encoder.EncodeTokenString(decodedToken);

Console.WriteLine(reEncodedToken);

var thirdChargeOption = new ChargeCreateOptions
{
    Amount = "10.38",
    Token = reEncodedToken,
};

Charge thirdCharge = service.Create(thirdChargeOption);

Console.WriteLine(thirdCharge.ToString());

PaymentMethodToken decodedTokenEntity = Decoder.DecodeTokenEntity(token);

Console.WriteLine(result.ToString());
Console.WriteLine(decodedTokenEntity.ToString());