 using System;

namespace AddressBookSystem_linq_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome The Address Book Use Linq");
            //uc1 create new table 
            AddressBookTable addressBookTable = new AddressBookTable();

            //   addressbookTable.GetAllContacts();//uc3
            addressBookTable.EditExistingContact("ghouse", "shaik", "PhoneNumber", "9921670015");

            Console.ReadLine();

        }
    }
}
