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
    }
}
