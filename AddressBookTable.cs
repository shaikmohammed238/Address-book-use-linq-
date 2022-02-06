using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem_linq_
{
    class AddressBookTable
    {
        DataTable table = new DataTable("AddressBookSystem");   // create a table
        /* UC2:- Ability to create a Address Book Table with first and last names, address, city, 
                state, zip, phone number and email as its attributes
       */
        public AddressBookTable()
        {
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(string));
            table.Columns.Add("PhoneNumber", typeof(string));
            table.Columns.Add("Email", typeof(string));

            /*UC3:-Ability to insert new Contacts to Address Book */
            table.Rows.Add("ghouse", "shaik", "alamaspet", "kadapa", "andhra", "516001", "8877367437", "sv@gmail.com");
            table.Rows.Add("Ekta", "Kumbhare", "Aund", "luv", "Mhaa", "125121", "8570934858", "ek@gmail.com");
            table.Rows.Add("Vi", "Singh", "Mjk", "Mumbai", "karnata", "442206", "7894561230", "hal@gmail.com.a");

        }
        public void GetAllContacts()
        {
            Console.WriteLine("\n\n");
            foreach (DataRow dataRow in table.AsEnumerable())
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("FirstName:- " + dataRow.Field<string>("firstName"));
                Console.WriteLine("LastName:- " + dataRow.Field<string>("lastName"));
                Console.WriteLine("Address:- " + dataRow.Field<string>("address"));
                Console.WriteLine("City:- " + dataRow.Field<string>("city"));
                Console.WriteLine("State:- " + dataRow.Field<string>("state"));
                Console.WriteLine("Zip:- " + dataRow.Field<string>("zip"));
                Console.WriteLine("PhoneNumber:- " + dataRow.Field<string>("phoneNumber"));
                Console.WriteLine("Email:- " + dataRow.Field<string>("eMail"));
            }

        }
        /*UC4:- Ability to edit existing contact person using their name
         */

        public void EditExistingContact(string firstName, string lastName, string column, string newValue)
        {
            DataRow contact = table.Select("FirstName = '" + firstName + "' and LastName = '" + lastName + "'").FirstOrDefault();
            contact[column] = newValue;
            Console.WriteLine("Record successfully Edit");
            GetAllContacts();

        }
        /* UC5:- Ability to delete a person using person's name.
        */

        public void DeleteContact(string firstName, string lastName)
        {
            try
            {
                DataRow contact = table.Select("FirstName = '" + firstName + "' and LastName = '" + lastName + "'").FirstOrDefault();
                table.Rows.Remove(contact);
                Console.WriteLine("Record Successfully Delete");
                GetAllContacts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
