using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment03_Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Solution 1
            /////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Enter Your password :");
            string validationOfPassword = Console.ReadLine();

             validationOfPassword = validationOfPassword.Trim();

            int lower=0, upper=0, number=0, specialchar=0;
            if (validationOfPassword.Length >= 8)
            {
                foreach(char c in validationOfPassword)
                {
                    if (c >= 'a' && c <= 'z')
                    {
                        lower = 1;
                    }
                    else if(c >= 'A' && c <= 'Z')
                    {
                        upper = 1;
                    }
                    else if (c >= '0' && c <= '9')
                    {
                        number = 1;
                    }
                    else if((c==' '))
                    {
                        Console.WriteLine("password dont contain space");
                        return;
                    }
                    else
                    {
                        specialchar = 1;
                    }
                }

            }
            else
            {
                Console.WriteLine("Your Password is short");
                return;
            }
            int ans = lower + upper + number + specialchar;
            if (ans == 4)
            {
                Console.WriteLine("Your password is correct");
            }
            else {
                Console.WriteLine("Your password is Weak");
                Console.WriteLine();
                if(lower==0) Console.WriteLine("Your password is does't have Lower case");
                if(upper==0) Console.WriteLine("Your password is does't have upper case");
                if(specialchar==0) Console.WriteLine("Your password is does't have Special chracter case");
                if(lower==0) Console.WriteLine("Your password is does't have Lower case");

            }

            /////////////////////////////////////////////////////////////////////////////////////////////

            




            Console.ReadLine();
        }
    }
}
