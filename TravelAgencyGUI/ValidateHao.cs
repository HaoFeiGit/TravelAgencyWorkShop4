using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// if use this validator in the future, don't forget to change the namespace to match specific project.
// Write validator from scratch
namespace ProductMaintenanceGUI
{
    public static class ValidateHao // define a new class called ValidateHao, no need ValidateHao(), no need paranthesis
    {

        // method that determine if char can be put into text box for name
        public static bool IsSingleNameBoxProve(char c)
        {
            bool proved = false;
                                     // check if charactor:
            if (Char.IsLetter(c) ||                     // is letter
                Char.IsControl(c) ||                    // is back space, ctrl+c, etc...
                c == '\'' ||                            // is '
                c == '-')                               // is -
                proved = true; // if char meets all above requirement, return true. 
            return proved;
        }

        // method that check if the text of the input box is non negative decimal. 
        public static bool IsNonNegDecimal(TextBox tb, string name)
        {
            bool isPositiveDecimal = false; // guilty until proven innocent
            decimal code; 
            if (!Decimal.TryParse(tb.Text, out code)) // Decimal.TryParse is false if it fails to parse
            {
                MessageBox.Show($"{name} must be a number!");
                tb.SelectAll(); // like cntr+a
                tb.Focus();     // focus the cursor on the text input box
            }
            else if (code < 0) // cannot be negative
            {
                MessageBox.Show($"{name} must be positive number");
                tb.SelectAll();
                tb.Focus();
            }
            else
                isPositiveDecimal = true;              
            return isPositiveDecimal;
        }

        internal static bool checkLength(TextBox tb, int length, string name)
        {
            bool ok = true;
            if (tb.TextLength > length)
            {
                MessageBox.Show($"{name} length cannot be greater than {length.ToString()}");
                ok = false;
            }
            return ok;

        }

        // method that checks if the text box is empty
        public static bool isPresence(TextBox tb, string name)
        {
            bool isThere = true;

            if (tb.Text == "")
            {
                isThere = false;
                MessageBox.Show($"{name} is required!");
                tb.SelectAll();
                tb.Focus();
            }
            return isThere;
        }

       
    }
}
