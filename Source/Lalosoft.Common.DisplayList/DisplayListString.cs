using System;
using System.Collections.Generic;

using System.Text;
using System.Reflection;

namespace Lalosoft.Common.DisplayListString
{
    public class DisplayListString : SortableBindingList<DisplayListStringItem>
    {
        public DisplayListString()
            : base()
        {
        }

        public DisplayListString(IList<DisplayListStringItem> list)
            : base(list)
        {

        }
        /// <summary>
        /// Creates a Display List from an a List of type T
        /// </summary>
        /// <typeparam name="T">The Type that the sourceList is a list of.</typeparam>
        /// <param name="sourceList">The list to create a display list from.</param>
        /// <param name="displayPropertyName">The name of the Property in T to use for the Display value in 
        /// list items. (If null then T.ToString() is used.)</param>
        /// <param name="valuePropertyName">The Property to use for the Value in list items. The function will fail if this is not supplied.</param>
        /// <param name="noneItem">If not null this item is added to the beginning for the list. </param>
        /// <returns>noneItem is intended for grid drop downs that need an item for the null value of the linked field, or any other such drop down.
        /// This makes it easy to have DisplayListString.NoneItem added to the front of the list. This can be any item you want though.</returns>
        public static DisplayListString CreateDisplayList<T>(IList<T> sourceList, string displayPropertyName, string valuePropertyName, DisplayListStringItem noneItem) 
        {
            DisplayListString result = new DisplayListString();
            if (noneItem != null)
                result.Add(noneItem);
            Type objectType = typeof(T);
            PropertyInfo displayField =null;
            if (displayPropertyName != null)
                displayField = objectType.GetProperty(displayPropertyName);
            PropertyInfo valueField = objectType.GetProperty(valuePropertyName);
            PropertyInfo[] fields = objectType.GetProperties();


            foreach (T curValue in sourceList)
            {
                
                string displayValue = (displayField == null ? curValue.ToString() : displayField.GetValue(curValue,null).ToString());
                object valueValue =  valueField.GetValue(curValue,null);
                
                result.Add(new DisplayListStringItem(valueValue == null ? null: valueValue.ToString(), displayValue)); ;
            }

            return result;
        }

        public static DisplayListStringItem NoneItem
        {
            get { return new DisplayListStringItem(null, "<NONE>"); }
        }

        public static DisplayListStringItem AllItem
        {
            get { return new DisplayListStringItem("A", "All"); }
        }
        
    }
}
