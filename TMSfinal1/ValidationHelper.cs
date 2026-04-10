using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TMS
{
    public static class ValidationHelper
    {
        public static bool IsNotEmpty(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                MessageBox.Show($"? {fieldName} cannot be empty!", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsSelected(ComboBox comboBox, string fieldName)
        {
            if (comboBox.SelectedItem == null)
            {
                MessageBox.Show($"? Please select {fieldName}!", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsEndAfterStart(DateTime start, DateTime end, string startField, string endField)
        {
            if (end <= start)
            {
                MessageBox.Show($"? {endField} must be after {startField}!", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsValidTrainNumber(string value)
        {
            Regex regex = new Regex(@"^[0-9]{4,5}[A-Z]?$");
            if (!regex.IsMatch(value))
            {
                MessageBox.Show($"? Train Number must be 4-5 digits (e.g., 12727)!", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsInRange(int value, string fieldName, int min, int max)
        {
            if (value < min || value > max)
            {
                MessageBox.Show($"? {fieldName} must be between {min} and {max}!", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
