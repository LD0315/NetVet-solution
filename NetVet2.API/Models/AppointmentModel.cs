using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NetVet2.Domain.Entities;

namespace NetVet2.API.Models
{
    public class AppointmentModel
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("pet")]
        public PetModel Pet { get; set; }

        [JsonProperty("notes")]
        public List<string> Notes { get; set; }

        public AppointmentModel(Appointment appointment)
        {
            Date = appointment.AppointmentDateTime.ToString();
            Pet = new PetModel(appointment.Pet);
            Notes = new List<string>();

            if (appointment.Notes != null)
            {
                foreach (var note in appointment.Notes)
                {
                    Notes.Add(note.Summary);
                }
            }
            
        }
    }
}
