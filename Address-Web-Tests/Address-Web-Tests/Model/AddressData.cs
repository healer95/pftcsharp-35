#pragma warning disable CS0169 // 'never used'
#pragma warning disable IDE0044 // 'make readonly'
#pragma warning disable IDE0041 // Use 'is null' check
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class AddressData : IEquatable<AddressData>, IComparable<AddressData>
    {
        //private string firstname, middlename, lastname,
        //    nickname, title, company, address,
        //    home, mobile, work, fax,
        //    email, email2, email3, homepage,
        //    bday, bmonth, byear,
        //    aday, amonth, ayear,
        //    address2, phone2, notes;
        private string allPhones, allEmails, allData;

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
        public string AllPhones
        {
            get
            {
                if (allPhones != null) { return allPhones; }
                else { return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work) + CleanUp(Phone2)).Trim(); }
            }
            set
            {
                allPhones = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null) { return allEmails; }
                else { return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim(); }
            }
            set
            {
                allEmails = value;
            }
        }

        private string CleanUp(string value)
        {
            if (value == null || value == "") { return ""; }
            return Regex.Replace(value, "[ -()]", "") + "\r\n";
        }
        
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

        public bool Equals(string other)
        {
            if (Object.ReferenceEquals(other, null)) { return false; }
            string temp="";
            //1name mname lname\r\
            if (Firstname != null) { temp += Firstname; }
            if (Middlename != null) { temp += " " + Middlename; }
            if (Lastname != null) { temp += " " + Lastname; }
            if (Firstname!=null || Middlename!=null || Lastname!=null) { temp += @"\r\"; }
            //nnname\r\
            if (Nickname != null) { temp += Nickname + @"\r\"; }
            //title\r\n
            if (Title != null) { temp += Title + @"\r\n"; }
            //companyname\r\n
            if (Company != null) { temp += Company + @"\r\n"; }
            //address\r\n
            if (Address != null) { temp += Address + @"\r\n"; }
            //\r\n
            temp += @"\r\n";
            //H: 5551\r\n
            if (Home != null) { temp += "H: " + Home + @"\r\n"; }
            //M: 5552\r\n
            if (Mobile != null) { temp += "M: " + Mobile + @"\r\n"; }
            //W: 5553\r\n
            if (Work != null) { temp += "W: " + Work + @"\r\n"; }
            //F: 5554\r\n\r\n
            if (Fax != null) { temp += "F: " + Fax + @"\r\n\r\n"; }
            //1@1.1\r\n
            if (Email != null) { temp += Email + @"\r\n"; }
            //2@2.2\r\n
            if (Email2 != null) { temp += Email2 + @"\r\n"; }
            //3@3.3\r\n
            if (Email2 != null) { temp += Email3 + @"\r\n"; }
            //Homepage:\r\n1.1\r\n\r\n
            if (Homepage != null) { temp += @"Homepage:\r\n" + Homepage + @"\r\n\r\n"; }
            //Birthday 1.January 1999(19)\r\n
            if (Bday != null || Bmonth != null || Byear != null)
            {
                DateTime Bdate = new DateTime(Convert.ToInt32(Byear), Convert.ToInt32(Bmonth), Convert.ToInt32(Bday));
                temp += "Birthday " + Bday + "." + 
                    System.Globalization.DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(Convert.ToInt32(Bmonth))
                    + " " + Byear + "(" + 
                    ((DateTime.MinValue + (DateTime.Today - Bdate)).Year - 1)
                    + @")\r\";
            }
            //Anniversary 2.February 2000(18)\r\n\r\n
            if (Aday != null || Amonth != null || Ayear != null)
            {
                DateTime Adate = new DateTime(Convert.ToInt32(Ayear), Convert.ToInt32(Amonth), Convert.ToInt32(Aday));
                temp += "Anniversary " + Bday + "." +
                    System.Globalization.DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(Convert.ToInt32(Amonth))
                    + " " + Byear + "(" +
                    ((DateTime.MinValue + (DateTime.Today - Adate)).Year - 1)
                    + @")\r\";
            }
            //address2\r\n\r\n
            if (Address2 != null) { temp += Address2 + @"\r\n\r\n"; }
            //P: 5555\r\n\r\n
            if (Phone2 != null) { temp += "P: " + Phone2 + @"\r\n\r\n"; }
            //hello
            if (Notes != null) { temp += Notes; }
            if (temp == other) { return true; }
            return false;
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
