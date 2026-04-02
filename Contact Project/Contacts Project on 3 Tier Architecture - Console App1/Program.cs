using ContactsBusinessLayer;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_Console_Project
{
    internal class Program
    {

        static void testFindContact(int ID)

        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                Console.WriteLine(Contact1.FirstName + " " + Contact1.LastName);
                Console.WriteLine(Contact1.Email);
                Console.WriteLine(Contact1.Phone);
                Console.WriteLine(Contact1.Address);
                Console.WriteLine(Contact1.DateOfBirth);
                Console.WriteLine(Contact1.CountryID);
                Console.WriteLine(Contact1.ImagePath);
            }
            else
            {
                Console.WriteLine("Contact [" + ID + "] Not found!");
            }
        }

        static void testAddNewContact()


        {
            clsContact Contact1 = new clsContact
            {
                FirstName = "Fadi",
                LastName = "Maher",
                Email = "A@a.com",
                Phone = "010010",
                Address = "address1",
                DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0),
                CountryID = 1,
                ImagePath = ""
            };

            if (Contact1.Save())
            {

                Console.WriteLine("Contact Added Successfully with id=" + Contact1.ID);
            }

        }

        static void testUpdateContact(int ID)

        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                //update whatever info you want
                Contact1.FirstName = "Fadi2";
                Contact1.LastName = "Maher2";
                Contact1.Email = "A2@a.com";
                Contact1.Phone = "2222";
                Contact1.Address = "222";
                Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
                Contact1.CountryID = 1;
                Contact1.ImagePath = "";

                if (Contact1.Save())
                {

                    Console.WriteLine("Contact updated Successfully ");
                }

            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        static void testDeleteContact(int ID)

        {

            if (clsContact.DeleteContact(ID))

                Console.WriteLine("Contact Deleted Successfully.");
            else
                Console.WriteLine("Faild to delete contact.");

        }


        //static void ListContacts()
        //{

        //    DataTable dataTable = clsContact.ListContacts();

        //    Console.WriteLine("Contacts Data:");

        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        Console.WriteLine($"{row["ContactID"]},  {row["FirstName"]} {row["LastName"]}");
        //    }

        //}


        static void ListContacts()
        {
            DataTable dataTable = clsContact.ListContacts();

            // Header color
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(
                $"{"ID",-4} {"First",-10} {"Last",-10} {"Email",-20} {"Phone",-12} {"Country",-8}"
            );

            Console.ResetColor();

            Console.WriteLine(new string('-', 70));

            int rowIndex = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                // Alternate row colors
                Console.ForegroundColor = (rowIndex % 2 == 0)
                    ? ConsoleColor.Gray
                    : ConsoleColor.DarkGray;

                Console.WriteLine(
                    $"{row["ContactID"],-4} " +
                    $"{row["FirstName"],-10} " +
                    $"{row["LastName"],-10} " +
                    $"{row["Email"],-20} " +
                    $"{row["Phone"],-12} " +
                    $"{row["CountryID"],-8}"
                );

                rowIndex++;
            }

            Console.ResetColor();
        }

        static void testIsContactExist(int ID)
        {
            if (clsContact.isContactExist(ID))
            {
                Console.WriteLine("The contact with ID: [" + ID + "] is found!");
            }
            else
            {
                Console.WriteLine("The contact with ID: [" + ID + "] is not found :(");

            }

        }



        static void Main(string[] args)
        {


            //testFindContact(17);
            //testAddNewContact();
            //testUpdateContact(20);
            //testDeleteContact(20);
            //testIsContactExist(1);
            ListContacts();


            Console.WriteLine();

            //TestCountry.testFindCountryByID(1);
            //TestCountry.testFindCountryByName("Jorden");
            //TestCountry.testAddNewCountry();
            //TestCountry.testUpdateCountry(1);
            //TestCountry.testDeleteCountry(66);
            //TestCountry.testIsCountryExist(1);
            //TestCountry.testIsCountryExist("Germany");
            TestCountry.ListCountries();

            //Console.ReadKey();

        }
    }
}
