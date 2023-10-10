using Microsoft.EntityFrameworkCore;
using PkHiveLibrary.DataAccess;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkHiveLibrary.Services
{
    public class ContactData : IContactData
    {
        private readonly ApplicationDbContext _context;
        public ContactData(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task AddContactMessage(ContactUs contactUs)
        {
            _context.ContactUs.AddAsync(contactUs);
            return _context.SaveChangesAsync();
        }

        public async Task<List<ContactUs>> GetContactMessages()
        {
            return await _context.ContactUs.OrderByDescending(c => c.SubmitDateTime).ToListAsync();
        }
    }
}
