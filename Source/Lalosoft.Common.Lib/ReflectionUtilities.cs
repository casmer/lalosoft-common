using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Lalosoft.Common.Attributes;

namespace Lalosoft.Common.Lib
{
    public static class ReflectionUtilities
    {
        public static string GetAssemblyTitle()
        {
            return GetAssemblyTitle(Assembly.GetEntryAssembly());
        }

        public static string GetAssemblyTitle(Assembly assembly)
        {
            
            object[] results = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), true);
            if (results.Length == 1)
            {
                AssemblyTitleAttribute res = (AssemblyTitleAttribute)results[0];
                return res.Title;
            }
            else
            {
                throw new Lalosoft.Common.Exceptions.LalosException("Could not retrieve Assembly Title.");
            }

        }

        public static string GetAssemblyAttributeProperty<T>(Assembly assembly, string propertyName) where T : Attribute
        {

            Type objectInfo = typeof(T);
            
            PropertyInfo[] properties = objectInfo.GetProperties();

            object[] results = assembly.GetCustomAttributes(typeof(T), true);
            if (results.Length == 1)
            {
                T res = (T)results[0];
                foreach (PropertyInfo curProp in properties)
                {
                    if (curProp.Name == propertyName)
                    {
                        return (string)curProp.GetValue(res,null);
                    }
                }
                throw new Lalosoft.Common.Exceptions.LalosException(string.Format("Property {1} does not exist in {0}.", objectInfo.Name, propertyName));
            }
            else
            {
                throw new Lalosoft.Common.Exceptions.LalosException(string.Format("Could not retrieve Assembly {0}.{1}.", objectInfo.Name,propertyName));
            }
        }

        public static string GetAssemblyVersion()
        {
            return GetAssemblyVersion(Assembly.GetEntryAssembly());
        }

        public static string GetAssemblyAppDataPath()
        {
            return GetAssemblyAppDataPath(Assembly.GetEntryAssembly());
        }

        public static string GetAssemblyAppDataPath(Assembly assembly)
        {
            return GetAssemblyAttributeProperty<AssemblyLalosoftAppDataPathAttribute>(assembly, "Path");
        }

        public static string GetAssemblySettingsFileName(Assembly assembly)
        {
            return GetAssemblyAttributeProperty<AssemblyLalosoftSettingFileAttribute>(assembly, "FileName");
        }

        public static string GetAssemblySettingsFileName()
        {
            return GetAssemblySettingsFileName(Assembly.GetEntryAssembly());
        }


        public static string GetAssemblyCompanyName(Assembly assembly)
        {

            return GetAssemblyAttributeProperty<AssemblyCompanyAttribute>(assembly, "Company");
        }

        public static string GetAssemblyProductName(Assembly assembly)
        {

          return GetAssemblyAttributeProperty<AssemblyCompanyAttribute>(assembly, "Product");
        }

        public static string GetAssemblyProductName()
        {
          return GetAssemblyProductName(Assembly.GetEntryAssembly());
        }

        public static string GetAssemblyCompanyName()
        {
            return GetAssemblyCompanyName(Assembly.GetEntryAssembly());
        }


        //AssemblyVersion
        public static string GetAssemblyVersion(Assembly assembly)
        {

            return assembly.GetName().Version.ToString();
        }
        public static string GetAssemblyCopyright()
        {
            return GetAssemblyCopyright(Assembly.GetEntryAssembly());
        }

        public static string GetAssemblyCopyright(Assembly assembly)
        {
            object[] results = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true);
            if (results.Length == 1)
            {
                AssemblyCopyrightAttribute res = (AssemblyCopyrightAttribute)results[0];
                return res.Copyright;
            }
            else
            {
                throw new Lalosoft.Common.Exceptions.LalosException("Could not retrieve Assembly Title.");
            }
        } //AssemblyCopyright

        public static string GetAssemblyStartPath()
        {
            return GetAssemblyStartPath(Assembly.GetEntryAssembly());
        }

        private static string GetAssemblyStartPath(Assembly assembly)
        {
            string result = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (result.StartsWith("file:\\"))
                result = result.Substring(6, result.Length - 6);
            return result;
        }



        public static SortedList<string, PropertyInfo> GetSortedPeProperties<T>()
        {
          SortedList<string, PropertyInfo> res = new SortedList<string, PropertyInfo>();

          Type objectInfo = typeof(T);
          PropertyInfo[] properties = objectInfo.GetProperties();
          foreach (PropertyInfo curProp in properties)
          {
            res.Add(curProp.Name, curProp);
          }
          return res;

        }

    }
}
