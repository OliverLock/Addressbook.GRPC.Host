using Addressbook.GRPC.Host;
using Grpc.Core;

namespace Addressbook.GRPC.Host.Services
{
    public class ContactsService : Contacts.ContactsBase
    {
        private readonly ILogger<ContactsService> _logger;
        public ContactsService(ILogger<ContactsService> logger)
        {
            _logger = logger;
        }

        public override Task<AddContactResponse> AddContact(AddContactRequest requestBody, ServerCallContext context)
        {
            Random rnd = new Random();

            var response = new AddContactResponse {
                Message = "Succesfully Added Contact",
                FirstName = requestBody.FirstName,
                LastName = requestBody.LastName,
                Id = rnd.Next()
            };

            return Task.FromResult(response);

        }
        public override Task<GetContactsResponse> GetContacts(Empty requestBody, ServerCallContext context)
        {
            Random rnd = new Random();

            var response = new GetContactsResponse
            {
                Message = "Success",
            };
            var contact1 = new Contact
            {
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "0123456789",
                PostCode = "AB12 3CD",
                Id = 12
            };
            response.Contacts.Add(contact1);

            var contact2 = new Contact
            {
                FirstName = "Jane",
                LastName = "Doe",
                PhoneNumber = "9876543210",
                PostCode = "AB12 3CD",
                Id = 13
            };
            response.Contacts.Add(contact2);


            return Task.FromResult(response);

        }
    }
}
