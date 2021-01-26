using System;
using Newtonsoft.Json;
using NetVet2.Domain.Entities;
namespace NetVet2.API.Models
{
    public class ContactModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("preferred")]
        public bool IsPreferred { get; set; }

        public ContactModel(Contact contact)
        {
            Type = contact.ContactType.ToString();
            Data = contact.ContactData;
            IsPreferred = contact.IsPreferred;
        }
    }
}
