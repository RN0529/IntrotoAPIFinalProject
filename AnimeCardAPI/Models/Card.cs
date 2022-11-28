using System.ComponentModel.DataAnnotations;

namespace AnimeCardAPI.Models
{
    public class Card
    {
        [Key]
        public int CardID { get; set; }
        public int BoxID { get; set; }
        public string AnimeSoruce { get; set; }
        public string CardName { get; set; }
        public int CardPrice { get; set; }
        public string CardRarity { get; set; }
        public string CardDescription { get; set; }
        

    }
}
