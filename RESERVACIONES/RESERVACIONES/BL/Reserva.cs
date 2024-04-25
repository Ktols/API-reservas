using System.Text.Json.Serialization;

namespace RESERVACIONES.BL
{
    public class Reservacion
    {
        [JsonPropertyName("bookingid")]
        public int Id { get; set; }

        [JsonPropertyName("booking")]
        public BookingDetails Details { get; set; }
    }

    public class BookingDetails
    {
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("totalprice")]
        public int TotalPrice { get; set; }

        [JsonPropertyName("depositpaid")]
        public bool DepositPaid { get; set; }

        [JsonPropertyName("bookingdates")]
        public BookingDates Dates { get; set; }

        [JsonPropertyName("additionalneeds")]
        public string AdditionalNeeds { get; set; }
    }

    public class BookingDates
    {
        [JsonPropertyName("checkin")]
        public DateTime CheckIn { get; set; }

        [JsonPropertyName("checkout")]
        public DateTime CheckOut { get; set; }
    }
}
