using System;

namespace foodTrackerApi.Models
{
    public class FoodRecord
    {
        public int Id { get; set; }

        public string Name{ get; set; }

        public decimal Value { get; set; }

        public DateTime dateTime { get; set; }
        

    }
}