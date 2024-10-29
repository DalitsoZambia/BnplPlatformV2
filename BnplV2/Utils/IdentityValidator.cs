using System.Text;
using System.Text.RegularExpressions;

namespace BnplV2.Utils;

public class IdentityValidator
{
    public static bool AddCountryCode(string phoneNumber, out string data)
    {
        var isValid = ValidatePhoneNumber(phoneNumber);
        if (isValid == false)
        {
            data = phoneNumber;
            return false;
        }
        var phoneNumberArray = phoneNumber.ToCharArray();
        var builder = new StringBuilder();

        if (phoneNumberArray[0] == '+')
        {
            for (int i = 1; i < phoneNumberArray.Length; i++)
            {
                builder.Append(phoneNumberArray[i]);
            }

            data = builder.ToString();
            return true;
        }

        if (phoneNumberArray[0] == '2')
        {
            data = phoneNumber;
            return true;
        }
        
        builder.Append("26");
        builder.Append(phoneNumberArray);

        data = builder.ToString();
        return true;
        
    }


    private static bool ValidatePhoneNumber(string phoneNumber)
    {
        /*
         * the character (+) should be optional
         * the numbers 2 and 6 are optional
         * should have the number 0
         *  should be followed by a 7 or 9
         * should be followed by a 5 or 6 or 7
         * should be followed by 7 digits that are from 1 to 9
         */
        string pattern = @"^\+?(260|0)[7|9][5-7][0-9]{7}$";
        return Regex.IsMatch(phoneNumber, pattern);
    }
}