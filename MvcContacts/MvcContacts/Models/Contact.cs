using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcContacts.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Tag { get; set; }
        public string Adresa { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        public DateTime Datum_rodenja { get; set; }
    }
    public class ContactsDBContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}