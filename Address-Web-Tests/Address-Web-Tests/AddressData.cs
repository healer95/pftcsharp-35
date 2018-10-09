using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AddressData
    {
        private string firstname;
        private string middlename = "";
        private string lastname = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string aday = "";
        private string amonth = "";
        private string ayear = "";
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";


        public AddressData (string firstname)
        {
            this.firstname = firstname;
        }
        public AddressData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }


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

        //maybe will work

        private string temp;

        public AddressData(string firstname, params string[] values)
        {
            this.firstname = firstname;
            foreach (string temp in values)
            {
                this.temp = temp;
            }
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
