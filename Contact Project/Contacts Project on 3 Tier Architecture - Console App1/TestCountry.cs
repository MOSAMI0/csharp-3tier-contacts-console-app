using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts_Console_Project
{
    public class TestCountry
    {


        public static void testFindCountryByID(int ID)

        {
            clsCountry Country1 = clsCountry.Find(ID);

            if (Country1 != null)
            {
                Console.WriteLine("Name: " + Country1.CountryName);
                Console.WriteLine("Code: " + Country1.Code);
                Console.WriteLine("PhoneCode: " + Country1.PhoneCode);

            }

            else
            {
                Console.WriteLine("Country [" + ID + "] Not found!");
            }
        }


        public static void testFindCountryByName(string CountryName)

        {
            clsCountry Country1 = clsCountry.Find(CountryName);

            if (Country1 != null)
            {
                Console.WriteLine("Country [" + CountryName + "] isFound with ID = " + Country1.ID);
                Console.WriteLine("Name: " + Country1.CountryName);
                Console.WriteLine("Code: " + Country1.Code);
                Console.WriteLine("PhoneCode: " + Country1.PhoneCode);
            }

            else
            {
                Console.WriteLine("Country [" + CountryName + "] Is Not found!");
            }
        }
        public static void testAddNewCountry()


        {
            clsCountry Country1 = new clsCountry();

            Country1.CountryName = "Eygpt";
            Country1.Code = "222";
            Country1.PhoneCode = "001";


            if (Country1.Save())
            {

                Console.WriteLine("Country Added Successfully with id=" + Country1.ID);
            }

        }

        public static void testUpdateCountry(int ID)

        {
            clsCountry Country1 = clsCountry.Find(ID);

            if (Country1 != null)
            {
                //update whatever info you want
                Country1.CountryName = "Egypt";
                Country1.Code = "111";
                Country1.PhoneCode = "555";


                if (Country1.Save())
                {

                    Console.WriteLine("Country updated Successfully ");
                }

            }
            else
            {
                Console.WriteLine("Country is you want to update is Not found!");
            }
        }

        public static void testDeleteCountry(int ID)
        {
            if (clsCountry.Delete(ID))
                Console.WriteLine("Country Deleted Successfully.");
            else
                Console.WriteLine("Failed to delete country.");
        }

        //public static void ListCountries()
        //{
        //    DataTable dt = clsCountries.ListCountries();

        //    Console.WriteLine("Countries Data:");

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        Console.WriteLine($"{row["CountryID"]}, {row["CountryName"]}");
        //    }
        //}

        public static void ListCountries()
        {
            DataTable dataTable = clsCountry.ListCountries();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(
                $"{"ID",-6} {"Country Name",-26} {"Code",-10} {"PhoneCode",-12}"
            );

            Console.ResetColor();

            Console.WriteLine(new string('-', 60));

            int rowIndex = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                Console.ForegroundColor = (rowIndex % 2 == 0)
                    ? ConsoleColor.Gray
                    : ConsoleColor.DarkGray;

              
                string code = row["Code"] == DBNull.Value || string.IsNullOrWhiteSpace(row["Code"].ToString())
                    ? "NULL"
                    : row["Code"].ToString();

                string phoneCode = row["PhoneCode"] == DBNull.Value || string.IsNullOrWhiteSpace(row["PhoneCode"].ToString())
                    ? "NULL"
                    : row["PhoneCode"].ToString();

                Console.WriteLine(
                    $"{row["CountryID"],-6} " +
                    $"{row["CountryName"],-26} " +
                    $"{code,-10} " +
                    $"{phoneCode,-12}"
                );

                rowIndex++;
            }

            Console.ResetColor();
        }

        public static void testIsCountryExist(int ID)
        {
            if (clsCountry.isCountryExist(ID))
            {
                Console.WriteLine("Country with ID [" + ID + "] exists!");
            }
            else
            {
                Console.WriteLine("Country with ID [" + ID + "] NOT found!");
            }
        }

        public static void testIsCountryExist(string name)
        {
            if (clsCountry.isCountryExist(name))
            {
                Console.WriteLine("Country [" + name + "] exists!");
            }
            else
            {
                Console.WriteLine("Country [" + name + "] NOT found!");
            }
        }



    }
}
