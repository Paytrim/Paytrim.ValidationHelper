namespace Paytrim.ValidationHelper
{
    /// <summary>
    /// This section is a port of Kontonummer.js
    /// https://github.com/jop-io/kontonummer.js
    /// Licens: MIT Författare: @jop-io, http://jop.io
    /// </summary>
    public static class Banks
    {
        public static SwedishBank[] SwedishBanks => new SwedishBank[] {
            new SwedishBank(
                        name: "Svea Bank",
                        type: 1,
                        comment: 2,
                        regex: @"^966[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Avanza Bank",
                        type: 1,
                        comment: 2,
                        regex: @"^95[5-6][0-9]{8}$"
            ),
            new SwedishBank(
                        name: "BlueStep Finans",
                        type: 1,
                        comment: 1,
                        regex: @"^968[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "BNP Paribas SA.",
                        type: 1,
                        comment: 2,
                        regex: @"^947[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Citibank",
                        type: 1,
                        comment: 2,
                        regex: @"^904[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Danske Bank",
                        type: 1,
                        comment: 1,
                        regex: @"^(12|13|24)[0-9]{9}$"
            ),
            new SwedishBank(
                        name: "DNB Bank",
                        type: 1,
                        comment: 2,
                        regex: @"^(919|926)[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Ekobanken",
                        type: 1,
                        comment: 2,
                        regex: @"^970[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Erik Penser",
                        type: 1,
                        comment: 2,
                        regex: @"^959[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Forex Bank",
                        type: 1,
                        comment: 1,
                        regex: @"^94[0-4][0-9]{8}$"
            ),
            new SwedishBank(
                        name: "ICA Banken",
                        type: 1,
                        comment: 1,
                        regex: @"^927[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "IKANO Bank",
                        type: 1,
                        comment: 1,
                        regex: @"^917[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "JAK Medlemsbank",
                        type: 1,
                        comment: 2,
                        regex: @"^967[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Klarna Bank",
                        type: 1,
                        comment: 2,
                        regex: @"^978[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Landshypotek",
                        type: 1,
                        comment: 2,
                        regex: @"^939[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Lån & Spar Bank Sverige",
                        type: 1,
                        comment: 1,
                        regex: @"^963[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Länsförsäkringar Bank",
                        type: 1,
                        comment: 1,
                        regex: @"^(340|906)[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Länsförsäkringar Bank",
                        type: 1,
                        comment: 2,
                        regex: @"^902[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Marginalen Bank",
                        type: 1,
                        comment: 1,
                        regex: @"^923[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "MedMera Bank",
                        type: 1,
                        comment: 2,
                        regex: @"^965[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Nordax Bank",
                        type: 1,
                        comment: 2,
                        regex: @"^964[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Nordea",
                        type: 1,
                        comment: 1,
                        regex: @"^(?!3300|3782)(1[1456789][0-9]{2}|20[0-9]{2}|3[0-3][0-9]{2}|34[1-9][0-9]|3[5-9][0-9]{2})[0-9]{7}$"
            ),
            new SwedishBank(
                        name: "Nordea",
                        type: 1,
                        comment: 2,
                        regex: @"^4[0-9]{10}$"
            ),
            new SwedishBank(
                        name: "Nordnet Bank",
                        type: 1,
                        comment: 2,
                        regex: @"^910[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Resurs Bank",
                        type: 1,
                        comment: 1,
                        regex: @"^928[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Riksgälden",
                        type: 1,
                        comment: 2,
                        regex: @"^988[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Santander Consumer Bank",
                        type: 1,
                        comment: 1,
                        regex: @"^946[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "SBAB",
                        type: 1,
                        comment: 1,
                        regex: @"^925[0-9]{8}$"
            ),
            new SwedishBank(
                        name: "SEB",
                        type: 1,
                        comment: 1,
                        regex: @"^(5[0-9]{3}|912[0-4]|91[3-4][0-9])[0-9]{7}$"
            ),
            new SwedishBank(
                        name: "Skandiabanken",
                        type: 1,
                        comment: 2,
                        regex: @"^91[5-6][0-9]{8}$"
            ),
            new SwedishBank(
                        name: "Swedbank",
                        type: 1,
                        comment: 1,
                        regex: @"^7[0-9]{10}$"
            ),
            new SwedishBank(
                        name: "Ålandsbanken",
                        type: 1,
                        comment: 2,
                        regex: @"^23[0-9]{9}$"
            ),
            // Type 2
            new SwedishBank(
                        name: "Danske Bank",
                        type: 2,
                        comment: 1,
                        regex: @"^918[0-9]{11}$"
            ),
            new SwedishBank(
                        name: "Handelsbanken",
                        type: 2,
                        comment: 2,
                        regex: @"^6[0-9]{12}$"
            ),
            new SwedishBank(
                        name: "Nordea Plusgirot",
                        type: 2,
                        comment: 3,
                        regex: @"^(95[0-4]|996)[0-9]{8,11}$" // Clearing number 4 digits, billing number 7-10 digits
            ),
            new SwedishBank(
                        name: "Nordea",
                        type: 2,
                        comment: 1,
                        regex: @"^(3300|3782)[0-9]{10}$"
            ),
            new SwedishBank(
                        name: "Riksgälden",
                        type: 2,
                        comment: 1,
                        regex: @"^989[0-9]{11}$"
            ),
            new SwedishBank(
                        name: "Sparbanken Syd",
                        type: 2,
                        comment: 1,
                        regex: @"^957[0-9]{11}$"
            ),
            new SwedishBank(
                        name: "Swedbank",
                        type: 2,
                        comment: 3,
                        regex: @"^8[0-9]{10,14}$" // Clearing nubmer 5 digits, billing number 6-10 digits
            ),
            new SwedishBank(
                        name: "Swedbank",
                        type: 2,
                        comment: 1,
                        regex: @"^93[0-4][0-9]{11}$"
            ),
            new SwedishBank(
                        name: "Lunar Bank",
                        type: 1,
                        comment: 2,
                        regex: @"^971[0-9]{8}$"
            )
        };
    }
}
