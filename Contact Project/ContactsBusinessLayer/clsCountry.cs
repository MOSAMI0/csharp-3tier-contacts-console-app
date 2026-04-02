using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactDataAccessLayer;

namespace ContactsBusinessLayer
{
    public class clsCountry
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public string CountryName { get; set; }
        public string Code { set; get; }
        public string PhoneCode { set; get; }

        public clsCountry()
        {
            ID = -1;
            CountryName = "";
            Mode = enMode.AddNew;
        }

        private clsCountry(int ID, string CountryName, string Code, string PhoneCode)

        {
            this.ID = ID;
            this.CountryName = CountryName;
            this.Code = Code;
            this.PhoneCode = PhoneCode;

            Mode = enMode.Update;

        }


        public static clsCountry Find(int ID)
        {
            string Name = "";
            string Code = "";
            string PhoneCode = "";

            if (clsCountryDataAccess.GetCountryInfoByID(ID, ref Name, ref Code, ref PhoneCode))
                return new clsCountry(ID, Name, Code, PhoneCode);
            else
                return null;
        }

        public static clsCountry Find(string Name)
        {
            int ID = -1;
            string Code = "";
            string PhoneCode = "";

            if (clsCountryDataAccess.GetCountryInfoByName(Name, ref ID, ref Code, ref PhoneCode))
                return new clsCountry(ID, Name, Code, PhoneCode);
            else
                return null;
        }

        private bool _AddNew()
        {
            this.ID = clsCountryDataAccess.AddNewCountry(this.CountryName, this.Code, this.PhoneCode);
            return (this.ID != -1);
        }

        private bool _Update()
        {
            return clsCountryDataAccess.UpdateCountry(this.ID, this.CountryName, this.Code, this.PhoneCode);
        }

        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                if (_AddNew())
                {
                    Mode = enMode.Update;
                    return true;
                }
                return false;
            }
            else
            {
                return _Update();
            }
        }

        public static bool Delete(int ID)
        {
            return clsCountryDataAccess.DeleteCountry(ID);
        }

        public static DataTable ListCountries()
        {
            return clsCountryDataAccess.ListCountries();
        }

        public static bool isCountryExist(int ID)
        {
            return clsCountryDataAccess.isCountryExist(ID);
        }

        public static bool isCountryExist(string Name)
        {
            return clsCountryDataAccess.isCountryExist(Name);
        }
    }
}


 
