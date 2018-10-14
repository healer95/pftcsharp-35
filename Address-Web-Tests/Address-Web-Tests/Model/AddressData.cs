using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AddressData
    {
        #pragma warning disable CS0169 // 'never used'
        #pragma warning disable IDE0044 // 'make readonly'
        private string firstname, middlename, lastname,
            nickname, title, company, address,
            home, mobile, work, fax,
            email, email2, email3, homepage,
            bday, bmonth, byear,
            aday, amonth, ayear,
            address2, phone2, notes;

        public AddressData (string firstname)
        {
            this.firstname = firstname;
        }
        public AddressData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        private string temp;
        public AddressData(string firstname, params string[] values)
        {
            this.firstname = firstname;
            foreach (string temp in values)
            {
                this.temp = temp;
            }
        }

        //Declairing get/set
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Middlename {get; set;}
        public string Nickname {get; set;}
        public string Title {get; set;}
        public string Company {get; set;}
        public string Address {get; set;}
        public string Home {get; set;}
        public string Mobile {get; set;}
        public string Work {get; set;}
        public string Fax {get; set;}
        public string Email {get; set;}
        public string Email2 {get; set;}
        public string Email3 {get; set;}
        public string Homepage {get; set;}
        public string Bday {get; set;}
        public string Bmonth {get; set;}
        public string Byear {get; set;}
        public string Aday {get; set;}
        public string Amonth {get; set;}
        public string Ayear {get; set;}
        public string Address2 {get; set;}
        public string Phone2 {get; set;}
        public string Notes {get; set;}
    }
}
