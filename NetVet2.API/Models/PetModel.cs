using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NetVet2.Domain.Entities;
namespace NetVet2.API.Models
{
    public class PetModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("breed")]
        public string Breed { get; set; }

        [JsonProperty("image")]
        public string ImageBase64 { get; set; }

        [JsonProperty("animal")]
        public AnimalModel Animal { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("contact")]
        public string Contact { get; set; }

        [JsonProperty("notes")]
        public List<string> Notes { get; set; }

        public PetModel(Pet pet)
        {
            Name = pet.Name;
            Age = pet.Age;
            Breed = pet.Breed;
            ImageBase64 = pet.ImageBase64;
            Animal = new AnimalModel(pet.Animal);
            Owner = string.Format("{0} {1}", pet.Owner.FirstName, pet.Owner.LastName);

            foreach (var contact in pet.Owner.Contacts)
            {
                if (contact.IsPreferred)
                {
                    Contact = contact.ContactData;
                }
            }
            //Owner = new OwnerModel(pet.Owner);
            Notes = new List<string>();
            if (pet.Notes != null)
            {
                foreach (var note in pet.Notes)
                {
                    Notes.Add(note.Summary);
                }
            }
            
        }
    }
}
