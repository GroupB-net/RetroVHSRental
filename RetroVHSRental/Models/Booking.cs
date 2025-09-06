namespace RetroVHSRental.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int FilmId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public film Film { get; set; }
        public Customer Customer { get; set; }

    }
}
