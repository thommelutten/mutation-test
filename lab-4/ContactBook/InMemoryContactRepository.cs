using Phonebook.Interfaces;
using Phonebook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    public class InMemoryContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts = new();

        public int Add(Contact contact)
        {
            contact.Id = _contacts.Count + 1;
            _contacts.Add(contact);
            return contact.Id;
        }

        public Contact GetById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contacts;
        }

        public IEnumerable<Contact> GetAllOrderedByLastName()
        {
            return _contacts.OrderBy(c => c.LastName);
        }
    }
}
