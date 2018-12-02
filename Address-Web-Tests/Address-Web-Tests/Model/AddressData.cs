#pragma warning disable CS0169 // 'never used'
#pragma warning disable IDE0044 // 'make readonly'
#pragma warning disable IDE0041 // Use 'is null' check
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
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

        public AddressData() { }
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
        [Column(Name = "firstname"), NotNull]
        public string Firstname { get; set; }
        [Column(Name = "middlename"), NotNull]
        public string Lastname { get; set; }
        [Column(Name = "lastname"), NotNull]
        public string Middlename {get; set;}
        [Column(Name = "nickname"), NotNull]
        public string Nickname {get; set;}
        [Column(Name = "title"), NotNull]
        public string Title {get; set;}
        [Column(Name = "company"), NotNull]
        public string Company {get; set;}
        [Column(Name = "address"), NotNull]
        public string Address {get; set;}
        [Column(Name = "home"), NotNull]
        public string Home {get; set;}
        [Column(Name = "mobile"), NotNull]
        public string Mobile {get; set;}
        [Column(Name = "work"), NotNull]
        public string Work {get; set;}
        [Column(Name = "fax"), NotNull]
        public string Fax {get; set;}
        [Column(Name = "email"), NotNull]
        public string Email {get; set;}
        [Column(Name = "email2"), NotNull]
        public string Email2 {get; set;}
        [Column(Name = "email3"), NotNull]
        public string Email3 {get; set;}
        [Column(Name = "homepage"), NotNull]
        public string Homepage {get; set;}
        [Column(Name = "bday"), NotNull]
        public string Bday {get; set;}
        [Column(Name = "bmonth"), NotNull]
        public string Bmonth {get; set;}
        [Column(Name = "byear"), NotNull]
        public string Byear {get; set;}
        [Column(Name = "aday"), NotNull]
        public string Aday {get; set;}
        [Column(Name = "amonth"), NotNull]
        public string Amonth {get; set;}
        [Column(Name = "ayear"), NotNull]
        public string Ayear {get; set;}
        [Column(Name = "address2"), NotNull]
        public string Address2 {get; set;}
        [Column(Name = "phone2"), NotNull]
        public string Phone2 {get; set;}
        [Column(Name = "notes"), NotNull]
        public string Notes {get; set;}
        [Column(Name = "id"), PrimaryKey, Identity]
        internal string ID { get; set; }
        internal string AllPhones
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
        internal string AllEmails
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
            string temp = "";
            if (Firstname != "") { temp += "firstname: " + Firstname; }
            if (Middlename != "") { temp += "\nmiddlename " + Middlename; }
            if (Lastname != "") { temp += "\nlastname " + Lastname; }
            if (Nickname != "") { temp += "\nnickname: " + Nickname; }
            if (Title != "") { temp += "\ntitle: " + Title; }
            if (Company != "") { temp += "\ncompany: " + Company; }
            if (Address != "") { temp += "\naddress: " + Address; }
            if (Home != "") { temp += "\nhome: " + Home; }
            if (Mobile != "") { temp += "\nmobile " + Mobile; }
            if (Work != "") { temp += "\nwork " + Work; }
            if (Fax != "") { temp += "\nfax " + Fax; }
            if (Email != "") { temp += "\nemail1: " + Email; }
            if (Email2 != "") { temp += "\nemail2: " + Email2; }
            if (Email2 != "") { temp += "\nemail3: " + Email3; }
            if (Homepage != "") { temp += "\nhomepage: " + Homepage; }
            if (Bday != "" ) { temp += "\nbday: " + Bday; }
            if (Bmonth != "") { temp += "\nbmonth: " + Bmonth; }
            if (Byear != "") { temp += "\nbyear: " + Byear; }
            if (Aday != "") { temp += "\nbday: " + Aday; }
            if (Amonth != "") { temp += "\nbmonth: " + Amonth; }
            if (Ayear != "") { temp += "\nbyear: " + Ayear; }
            if (Address2 != "") { temp += "\naddress2: " + Address2; }
            if (Phone2 != "") { temp += "\nphone2 " + Phone2; }
            if (Notes != "") { temp += "\nnotes: " + Notes; }
            
            return temp;
        }

        public static List<AddressData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            { return (from a in db.Addresses select a).ToList(); }
        }
    }
}
