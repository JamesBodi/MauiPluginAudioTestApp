
namespace MauiPluginAudioTestApp.Models
{
    using System.Text.Json.Serialization;

    public class Subscriber
    {
        [JsonPropertyName("subscriberId")]
        public int SubscriberId { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }

        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("streetAddress")]
        public string StreetAddress { get; set; }

        [JsonPropertyName("cityName")]
        public string CityName { get; set; }

        [JsonPropertyName("stateName")]
        public string StateName { get; set; }

        [JsonPropertyName("zipCode")]
        public string ZipCode { get; set; }

        [JsonPropertyName("accountType")]
        public string AccountType { get; set; }

        [JsonPropertyName("expirationDate")]
        public string ExpirationDate { get; set; }

        [JsonPropertyName("isApproved")]
        public bool IsApproved { get; set; }

        [JsonPropertyName("createdDate")]
        public string CreatedDate { get; set; }

        [JsonPropertyName("isLoggedIn")]
        public bool IsLoggedIn { get; set; }

    }

}
