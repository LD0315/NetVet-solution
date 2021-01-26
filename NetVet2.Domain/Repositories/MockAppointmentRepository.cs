using System;
using System.Collections.Generic;
using System.Linq;
using NetVet2.Domain.Entities;

namespace NetVet2.Domain.Repositories
{
    /// <summary>
    /// This class is provided as a proxy Mock of the appointment repository 
    /// for use in your implementation. It will return a set of sample data for
    /// appointments and their related details.
    /// </summary>
    public class MockAppointmentRepository : IAppointmentRepository
    {
        IQueryable<Appointment> IAppointmentRepository.GetAppointments(bool includeDeleted)
        {
            return GenerateSampleAppointments().AsQueryable();
        }


        private readonly string[] NAMES = { "Jack", "Lily", "Adam", "Billy" };
        private readonly string[] OWNER_F_NAMES = { "Mike", "Sarah", "Willie", "Rex" };
        private readonly string[] OWNER_L_NAMES = { "Steer", "Brown", "Smith", "Trump" };
        private readonly string[] HOSTS = { "gmail.com", "outlook.com", "uq.edu.au", "hotmail.com" };
        private List<Appointment> GenerateSampleAppointments(int count = 10)
        {
            List<Appointment> appointments = new List<Appointment>();
            for (int counter = 1; counter <= count; counter++)
            {
                var random = new Random(counter);
                var owner = GenerateSampleOwner(counter);
                appointments.Add(new Appointment
                {
                    AppointmentId = Guid.NewGuid(),
                    AppointmentDateTime = DateTime.Today.AddHours(8 + random.Next(8)).AddDays(random.Next(3)),
                    Pet = owner.Pets[random.Next(owner.Pets.Count)]
                });
            }
            return appointments;
        }

        private Owner GenerateSampleOwner(int id)
        {
            var random = new Random(id);
            var owner = new Owner
            {
                OwnerId = Guid.NewGuid(),
                //FirstName = "First" + id.ToString(),
                //LastName = "Last" + id.ToString(),
                FirstName = OWNER_F_NAMES[random.Next() % OWNER_F_NAMES.Length],
                LastName = OWNER_L_NAMES[random.Next() % OWNER_L_NAMES.Length],
                Notes = new List<Note>(),
                Pets = new List<Pet>(),
                IsOptInForNotifications = true,
                Contacts = new List<Contact>()
            };

            var animals = new List<Animal>(new[]
            {
                new Animal{ AnimalId = Guid.NewGuid(), Name = "Dog", Size =  AnimalSizes.Medium },
                new Animal{ AnimalId = Guid.NewGuid(), Name = "Cat", Size =  AnimalSizes.Medium },
                new Animal{ AnimalId = Guid.NewGuid(), Name = "Rat", Size =  AnimalSizes.Small },
                new Animal{ AnimalId = Guid.NewGuid(), Name = "Pig", Size =  AnimalSizes.Medium },
                new Animal{ AnimalId = Guid.NewGuid(), Name = "Horse", Size =  AnimalSizes.Large },
            });

            
            for (int count = 2; count < random.Next(4); count++)
            { // may have no notes.
                owner.Notes.Add(new Note { NoteId = Guid.NewGuid(), DateCreated = DateTime.Now, DateModified = DateTime.Now, Summary ="Some Note", Detail = "Some note, yadda, yadda." });
            }
            for (int count = 1; count <= random.Next(3)+1; count++)
            {
                //owner.Pets.Add(new Pet { PetId = Guid.NewGuid(), Name = "Pet" + count.ToString(), Age = count, Animal = animals[random.Next(4)], Breed = "Unknown", Owner = owner });
                owner.Pets.Add(new Pet { PetId = Guid.NewGuid(), Name = NAMES[random.Next() % NAMES.Length], Age = count, Animal = animals[random.Next(4)], Breed = "Unknown", Owner = owner });
            }

            var num = random.Next() % 100;
            var email = owner.LastName.ToLower() + num.ToString() + "@" + HOSTS[random.Next() % HOSTS.Length];

            bool preffered = random.Next() % 2 == 0;
            owner.Contacts.Add(new Contact { ContactId = Guid.NewGuid(), ContactType = ContactTypes.Mobile, ContactData = "04000000" + id.ToString("00"), IsPreferred = preffered });
            owner.Contacts.Add(new Contact { ContactId = Guid.NewGuid(), ContactType = ContactTypes.EMail, ContactData = email, IsPreferred = !preffered });

            return owner;
        }
    }
}
