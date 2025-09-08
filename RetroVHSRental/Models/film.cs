namespace RetroVHSRental.Models
{
    public class film
    {
        public int film_id { get; set; }
        public  string title { get; set; }
        public string description { get; set; }
        public int release_year { get; set; }
        public bool IsAvailable { get; set; }


    }
}
