using System.ComponentModel.DataAnnotations;

namespace AnimeCardAPI.Models
{
    public class BoosterBox
    {
        //I was having an error of having a execption of boosterbox requires a primary key and adding [key] Fixed it
        [Key]
        public int BoxID { get; set; }

        public string BoxName { get; set; }
        public int BoxPrice { get; set; }
        public string BoxDescription { get; set; }

    }
}
