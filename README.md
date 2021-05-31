# Paytrim.ValidationHelper  [![BuildStatus](https://github.com/ahakille/Paytrim.ValidationHelper/actions/workflows/dotnet.yml/badge.svg)](https://github.com/ahakille/Paytrim.ValidationHelper/actions/workflows/dotnet.yml) 

Validate Bankaccount
* Get name of bank
* Get clearing
* Get Account No

Validate Swedish National Id(Personnummer)
* Get IsSammorningsnummer
* Get DateOfBirth

Validate Swedish Corporate National Id (Organisationsnummer) 

## Getting Started
Check if valid
 ```csharp
    var isValid = Organisationsnummer.TryParse("XXXXXX-XXXX");
   ```
Check if valid
 ```csharp
    var isValid = Personnummer.TryParse("XXXXXXXX-XXXX");
   ```
Get bankname etc
 ```csharp
   var swedishBank = new SwedishBankAccount("xxxx-xxxxxxx");
   swedishBank.SwedishBank.Name;
   ```

## License

Distributed under the MIT License. See `LICENSE` for more information.
