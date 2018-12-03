using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace WebAddressbookTests
{
    class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("AddressBook") { }

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }
        public ITable<AddressData> Addresses { get { return GetTable<AddressData>(); } }
        public ITable<GroupAddressRelation> GAR { get { return GetTable<GroupAddressRelation>(); } }
    }
}
