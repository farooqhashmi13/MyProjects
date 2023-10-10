using PkHiveLibrary.Models;

namespace PkHiveLibrary.Interfaces
{
    public interface IContactData
    {
        Task AddContactMessage(ContactUs contactUs);
        Task<List<ContactUs>> GetContactMessages();
    }
}