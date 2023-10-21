using Phonebook.Interfaces;
using Phonebook.Model;

namespace Phonebook.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InMemoryPersonRepository_GetAllEmpty_Success()
        {
            IContactRepository repository = new InMemoryContactRepository();
            Assert.That(repository.GetAll().Count, Is.EqualTo(0));
        }

        [Test]
        public void InMemoryPersonRepository_Add_Success()
        {
            IContactRepository repository = new InMemoryContactRepository();

            Contact contact = new()
            {
                FirstName = "Frodo Baggins",
                LastName = "",
                Address = "1 Bagshot Row, Bag End, Hobbiton"
            };

            repository.Add(contact);
            
            IEnumerable<Contact> contacts = repository.GetAll();
            Assert.That(contacts, Has.Exactly(1).EqualTo(contact));
        }

        [Test]
        public void InMemoryPersonRepository_GetById_Success()
        {
            IContactRepository repository = new InMemoryContactRepository();

            Contact contact = new()
            {
                FirstName = "Frodo Baggins",
                LastName = "",
                Address = "1 Bagshot Row, Bag End, Hobbiton"
            };

            int id = repository.Add(contact);

            Assert.That(id, Is.EqualTo(1));
            Assert.That(repository.GetById(id), Is.EqualTo(contact));
        }

        [Test]
        public void InMemoryPersonRepository_GetById_ReturnNull()
        {
            IContactRepository repository = new InMemoryContactRepository();
            Assert.That(repository.GetById(1), Is.Null);
        }

        [Test]
        public void InMemoryPersonRepository_GetAllOrderdByLastName_Success()
        {
            IContactRepository repository = new InMemoryContactRepository();

            Contact contact = new()
            {
                FirstName = "Frodo",
                LastName = "Baggins",
                Address = "1 Bagshot Row, Bag End, Hobbiton"
            };

            repository.Add(contact);

            Contact contact2 = new()
            {
                FirstName = "Samwise",
                LastName = "Gamgee",
                Address = "3 Bagshot Row, The Gamgees, Hobbiton"
            };

            repository.Add(contact2);

            IEnumerable<Contact> contacts = repository.GetAllOrderedByLastName();

            Assert.That(contacts.Count, Is.EqualTo(2));
            Assert.That(contacts.First(), Is.EqualTo(contact));
        }
    }
}