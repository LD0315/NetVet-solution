using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using NetVet2.Domain.Entities;

namespace NetVet2.API.Models
{
    public class OwnerModel
    {

        [JsonProperty("first_name")]
        public string FName { get; set; }

        [JsonProperty("last_name")]
        public string LName { get; set; }

        [JsonProperty("name")]
        public string PName { get; set; }

        [JsonProperty("contacts")]
        public List<ContactModel> Contacts { get; set; }

        [JsonProperty("pets")]
        public List<PetModel> Pets { get; set; }

        [JsonProperty("notes")]
        public List<string> Notes { get; set; }


        public OwnerModel(Owner owner)
        {
            FName = owner.FirstName;
            LName = owner.LastName;
            PName = owner.PreferredName;
            Contacts = new List<ContactModel>();
            Pets = new List<PetModel>();
            Notes = new List<string>();

            foreach(var c in owner.Contacts)
            {
                Contacts.Add(new ContactModel(c));
            }

            foreach(var pet in owner.Pets)
            {
                Pets.Add(new PetModel(pet));
            }
            if (owner.Notes != null)
            {
                foreach (var note in owner.Notes)
                {
                    Notes.Add(note.Summary);
                }
            }
            
        }
    }
}
