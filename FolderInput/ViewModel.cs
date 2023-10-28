using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FolderInput
{
    public class ViewModel: IDataErrorInfo
    {
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                // NotifyPropertyChanged if implemented
            }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                // NotifyPropertyChanged if implemented
            }
        }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "Email")
                {
                    if(!string.IsNullOrEmpty(Email))
                    {
                        if (!Regex.IsMatch(Email, @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$"))
                        {
                            result = "Custom Please enter a valid email address";
                        }
                    }
                }
                if (columnName == "Age")
                {
                    if(Age!=0)
                    {
                        if (Age <= 0 || Age > 18)
                        {
                            result = "Please enter a valid age";
                        }
                    }
                }
                return result;
            }
        }
    }
}
