namespace FreeCodeCampMAUITut.Models
{
    public static class ContactsRepository
    {
        static List<Contact> contacts = new List<Contact>
        {
            new Contact{Id = 1, Name="Ashar",Email="ashar@email.com"},
            new Contact{Id = 2, Name="Adil",Email="adil@email.com"},
            new Contact{Id = 3, Name="Ali",Email="ali@email.com"},
            new Contact{Id = 4, Name="Ehtisham",Email="ehtisham@email.com"}
        };

        public static List<Contact> GetContacts() => contacts;

        public static Contact GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.Id == id);
            if (contact != null)
            {
                return new Contact
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Email = contact.Email,
                    Address = contact.Address,
                    Phone = contact.Phone,
                };
            }
            return null;
        }
        public static void UpdateContact(int ContactId, Contact contact)
        {
            if (ContactId != contact.Id) return;

            var contactToUpdate = contacts.FirstOrDefault(x => x.Id == ContactId);
            if (contactToUpdate != null)
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Address = contact.Address;
            }
        }
        public static void AddContact(Contact contact)
        {
            if (contacts.Count > 0)
            {
                var maxId = contacts.Max(x => x.Id);
                contact.Id = maxId + 1;
            }
            else
            {
                contact.Id = 0;
            }
            contacts.Add(contact);
        }
        public static void DeleteContact(int Id)
        {
            var contact = contacts.FirstOrDefault(x => x.Id == Id);
            contacts.Remove(contact);
        }
        public static List<Contact> SearchContacts(string filter)
        {
            var searchedContacts = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            if (searchedContacts == null || searchedContacts.Count <= 0)
            {
                searchedContacts = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                return searchedContacts;
            }
            if (searchedContacts == null || searchedContacts.Count <= 0)
            {
                searchedContacts = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                return searchedContacts;
            }
            if (searchedContacts == null || searchedContacts.Count <= 0)
            {
                searchedContacts = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                return searchedContacts;
            }
            return searchedContacts;
        }
    }


}
