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
        /*UC6:- Ability to Retrieve Person belonging to a City or State from the Address Book*/

        public void RetrieveByCityOrState(string Cityi, string Statei)
        {
            try
            {
                var retrieveData = from records in table.AsEnumerable()
                                   where (records.Field<string>("City").Equals(Cityi) || records.Field<string>("State").Equals(Statei))
                                   select records;
                //Printing data
                Console.WriteLine("\nRetrieved contactact details by city or state name");
                foreach (DataRow dataRow in table.AsEnumerable())
                {
                    Console.WriteLine("\n");
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /* UC7:- Ability to understand the size of address book by City and State 
                - Here size indicates the count
       */
        public void CountByCityOrState(string city, string state)
        {
            var contact = from c in table.AsEnumerable()
                          where c.Field<string>("City") == city && c.Field<string>("State") == state
                          select c;

            Console.WriteLine("Count of contacts in {0}, {1} is {2}", city, state, contact.Count());
        }
        /*UC8:- Ability to retrieve entries sorted alphabetically by Person’s name for a given city
        */
        public void SortedContactsByNameForAgivenCity(string City)
        {
            Console.WriteLine("Sorting by name for City");
            var retrievedData = from records in table.AsEnumerable()
                                where records.Field<string>("City") == City
                                orderby records.Field<string>("FirstName"), records.Field<string>("LastName")
                                select records;
            ///Print Data
            foreach (var dr in retrievedData)
            {
                Console.WriteLine("\n");
                Console.WriteLine("FirstName:- " + dr.Field<string>("firstName"));
                Console.WriteLine("LastName:- " + dr.Field<string>("lastName"));
                Console.WriteLine("Address:- " + dr.Field<string>("address"));
                Console.WriteLine("City:- " + dr.Field<string>("city"));
                Console.WriteLine("State:- " + dr.Field<string>("state"));
                Console.WriteLine("Zip:- " + dr.Field<string>("zip"));
                Console.WriteLine("PhoneNumber:- " + dr.Field<string>("phoneNumber"));
                Console.WriteLine("Email:- " + dr.Field<string>("eMail"));
            }
        }
        /*UC9:- Ability to identify each Address Book with name and Type.
        *      - Here the type could Family, Friends, Profession, etc.
               - Alter Address Book to add name and type.
       */

        public void AddAddressBookNameType()
        {
            try
            {

                DataColumn column;
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "addressBookName";
                column.AllowDBNull = false;
                column.DefaultValue = "Home";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "type";
                column.AllowDBNull = false;
                column.DefaultValue = "Friend";
                table.Columns.Add(column);
                GetAllContacts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
