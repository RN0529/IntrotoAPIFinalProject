using Microsoft.AspNetCore.Mvc;

namespace AnimeCardAPI.Models
{
    public class Response
    {
        public Response(int statusCode, string statusDescription, Task<List<BoosterBox>> returnBoosterBoxs)
        {
            this.statusCode = statusCode;
            this.statusDescription = statusDescription;
            this.returnBoosterBoxs = returnBoosterBoxs;
            
        }
        public Response(int statusCode, string statusDescription, Task<List<Card>> returnCards)
        {
            this.statusCode = statusCode;
            this.statusDescription = statusDescription;
            this.returnCards = returnCards;

        }
        public Response(int statusCode, string statusDescription, BoosterBox returnBoosterBox)
        {
            this.statusCode = statusCode;
            this.statusDescription = statusDescription;
            this.returnBoosterBox = returnBoosterBox;

        }
        public Response(int statusCode, string statusDescription, Card returnCard)
        {
            this.statusCode = statusCode;
            this.statusDescription = statusDescription;
            this.returnCard = returnCard;

        }
        public Response(int statusCode, string statusDescription)
        {
            this.statusCode = statusCode;
            this.statusDescription = statusDescription;
        }


        public int statusCode { get; set; }
        public string statusDescription { get; set; } 
        public Task<List<BoosterBox>> returnBoosterBoxs { get; set; }
        public Task<List<Card>> returnCards { get; set; }
        public BoosterBox returnBoosterBox { get; set; }
        public Card returnCard { get; set; }

    }
}
