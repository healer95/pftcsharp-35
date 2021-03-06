﻿#pragma warning disable IDE0041 // Use 'is null' check
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null)) { return false; }
            if (Object.ReferenceEquals(this, other)) { return true; }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name: " + Name + "\nheader: " + Header + "\nfooter: " + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null)) { return 1; }
            return Name.CompareTo(other.Name);
        }

        public GroupData(string name)
        {
            Name = name;
        }
        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }
        public GroupData() { }
        [Column(Name = "group_name"), NotNull]
        public string Name { get; set; }
        [Column(Name = "group_header"), NotNull]
        public string Header { get; set; }
        [Column(Name = "group_footer"), NotNull]
        public string Footer { get; set; }
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string ID { get; set; }
        [Column(Name = "deprecated")]
        public string Depricated { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups.Where(x => x.Depricated == "0000 - 00 - 00 00:00:00") select g).ToList();
            }
        }

        public List<AddressData> GetAddresses()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from a in db.Addresses
                        from gar in db.GAR.Where(p => p.GroupID == ID && p.AddresssID == a.ID)
                        select a).Distinct().ToList();
            }
        }
    }
}
