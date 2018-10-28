#pragma warning disable CS0169 // 'never used'
#pragma warning disable IDE0044 // 'make readonly'
#pragma warning disable IDE0041 // Use 'is null' check
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AddressData : IEquatable<AddressData>, IComparable<AddressData>
    {
        private string firstname, middlename, lastname,
            nickname, title, company, address,
            home, mobile, work, fax,
            email, email2, email3, homepage,
            bday, bmonth, byear,
            aday, amonth, ayear,
            address2, phone2, notes;

        public AddressData(string firstname)
        {
            Firstname = firstname;
            Lastname = "";
        }
        public AddressData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public AddressData(string firstname, string lastname, string middlename, string nickname, 
            string title, string company, string address,
            string home, string mobile, string work, string fax, 
            string email, string email2, string email3, string homepage, 
            string bday, string bmonth, string byear, string aday, string amonth, string ayear, 
            string address2, string phone2, string notes)
        {
            Firstname = firstname; Lastname = lastname; Middlename = middlename; Nickname = nickname;
            Title = title; Company = company; Address = address;
            Email = email; Email2 = email2; Email3 = email3;
            Bday = bday; Bmonth = bmonth; Byear = byear;
            Aday = aday; Amonth = amonth; Ayear = ayear;
            Address2 = address2; Phone2 = phone2; Notes = notes;
        }

        //Declairing get/set
        public string Firstname { get; set; }
        public string Lastname { get; set; }
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

        public int CompareTo(AddressData other)
        {
            if (Object.ReferenceEquals(other, null)) { return 1; }
            if (Firstname.CompareTo(other.Firstname) == 0 && Lastname.CompareTo(other.Lastname) == 0) { return 0; }
            else return 1;
        }

        public bool Equals(AddressData other)
        {
            if (Object.ReferenceEquals(other, null)) { return false; }
            if (Object.ReferenceEquals(this, other)) { return true; }
            return Firstname.Equals(other.Firstname) && Lastname.Equals(other.Lastname);
            //return (Firstname == other.Firstname && Lastname == other.Lastname);
        }

        public bool NotEquals(AddressData other)
        {
            if (Object.ReferenceEquals(other, null)) { return true; }
            if (Object.ReferenceEquals(this, other)) { return false; }
            return (!Firstname.Equals(other.Firstname) || Lastname != other.Lastname);
        }

        public override int GetHashCode()
        {
            return (Lastname.GetHashCode() + Firstname.GetHashCode());
        }

        public override string ToString()
        {
            return Lastname + ' ' + Firstname;
        }
    }
}
