using System;
using NetVet2.Domain.Entities;
using Newtonsoft.Json;

namespace NetVet2.API.Models
{
    public class AnimalModel
    {


        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        public AnimalModel(Animal animal)
        {
            this.Name = animal.Name;
            this.Size = animal.Size.ToString();
        }
    }
}
