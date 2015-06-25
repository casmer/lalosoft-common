using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Lalosoft.Common.Lib
{
    public static class FormsUtilities
    {
        public static void SetComboBoxSelectedValue(ComboBox comboBox, object value)
        {
            if (value == null)
                comboBox.SelectedValue = 0;
            else
                comboBox.SelectedValue = value;
        }
    }
}
