namespace DevCamp.Services.Data
{
    using System.Threading.Tasks;

    using DevCamp.Data.Common.Repositories;
    using DevCamp.Data.Models;
    using DevCamp.Services.Data.Interfaces;

    public class ContactUsService : IContactUsService
    {
        private readonly IRepository<ContactForm> contactFormRepository;

        public ContactUsService(IRepository<ContactForm> contactFormRepository)
        {
            this.contactFormRepository = contactFormRepository;
        }

        public async Task CreateAsync(string name, string email, string title, string content)
        {
            var contactForm = new ContactForm
            {
                Name = name,
                Email = email,
                Title = title,
                Content = content,
            };

            await this.contactFormRepository.AddAsync(contactForm);
            await this.contactFormRepository.SaveChangesAsync();
        }
    }
}
