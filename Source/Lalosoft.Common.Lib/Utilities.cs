/*
 * 
 * Author: Casey Gregoire
 * This Code Provided by Leave a Light on Software, Inc. (2007)
 * 
 * The Code in this class was created by lalosoft and is freely redistrubatable and reusable without any
 * special lease or license. No Warranty is given and this code is provided AS-IS. Use at your own risk.
 * 
 * Note for Tricast developers:
 * 
 * This is code from one of our common Libraries and we included it in your code to save time re-writing it for your use.
 * You will see this class and many parts of it through out the tricast code. This note here is provided to only clearly state
 * that this code is from our code base and was not developed on Tricast Time, nor was tricast billed for its creation.
 * 
 * There is absolutely no restriction on how this code is used or modified, nor is there any expectation of notifying users
 * of software that incorporates this class or snippets of code from this class that the code was provided by Leave a Light on Software, Inc.
 * 
 * */


using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using Lalosoft.Common.Exceptions;
using System.Xml.Serialization;
using System.Xml;
using System.Web.UI.WebControls;
using Lalosoft.Common.Attributes;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Lalosoft.Common.Lib;

namespace Lalosoft.Common
{
  public static class Utilities
  {
    [DllImport("odbc32.dll")]
    private static extern short SQLAllocHandle(short hType, IntPtr inputHandle, out IntPtr outputHandle);
    [DllImport("odbc32.dll")]
    private static extern short SQLSetEnvAttr(IntPtr henv, int attribute, IntPtr valuePtr, int strLength);
    [DllImport("odbc32.dll")]
    private static extern short SQLFreeHandle(short hType, IntPtr handle);
    [DllImport("odbc32.dll", CharSet = CharSet.Ansi)]
    private static extern short SQLBrowseConnect(IntPtr hconn, StringBuilder inString,
        short inStringLength, StringBuilder outString, short outStringLength,
        out short outLengthNeeded);

    private const short SQL_HANDLE_ENV = 1;
    private const short SQL_HANDLE_DBC = 2;
    private const int SQL_ATTR_ODBC_VERSION = 200;
    private const int SQL_OV_ODBC3 = 3;
    private const short SQL_SUCCESS = 0;

    private const short SQL_NEED_DATA = 99;
    private const short DEFAULT_RESULT_SIZE = 1024;
    private const string SQL_DRIVER_STR = "DRIVER=SQL SERVER";

    public const string sAppDataBasePath = "Leave a Light on Software, Inc";
    public const string DateFormat = "MM/dd/yyyy";
    public const string TimeFormat = "hh:mm:ss";
    public const string DecimalFormat = "#,###.00";


    public static int ExecuteNonQuery(string connectionString, bool isUsp, int commandTimeout, string command, params object[] sqlParams)
    {
      try
      {
        SqlCommand sCmd = BuildSQLCommand(command, connectionString, commandTimeout);

        DeriveAndFillParams(sCmd, isUsp, sqlParams);
        int retval = sCmd.ExecuteNonQuery();
        if (isUsp)
        {
          retval = (int)sCmd.Parameters[0].Value;
        }
        try
        {
         
        }
        catch { }
        finally
        {
          sCmd.Connection.Close();
          sCmd.Dispose();
        }

        return retval;

      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static object ToDBNull(object value)
    {
      return (value == null ? DBNull.Value : value);
    }

    public static void DeriveAndFillParams(SqlCommand sCmd, bool isUsp, object[] sqlParams)
    {
      if (isUsp)
      {
        sCmd.CommandType = CommandType.StoredProcedure;
        if (sCmd.Parameters.Count == 0)
          SqlCommandBuilder.DeriveParameters(sCmd);
        if (sqlParams.Length > 0)
        {
          //foreach (object paramValue in sqlParams)
          for (int i = 0; i < sqlParams.Length; i++)
          {
            if (sqlParams[i] is SqlParameter)
              sCmd.Parameters[i + 1].Value = ToDBNull(((SqlParameter)sqlParams[i]).Value);
            else
              sCmd.Parameters[i + 1].Value = ToDBNull(sqlParams[i]);

          }
        }
      }
      else
      {
        List<string> paramList = new List<string>();
        Regex macther = new Regex("@[A-Za-z0-9_]*", RegexOptions.Singleline);
        MatchCollection matches = macther.Matches(sCmd.CommandText);
        sCmd.Parameters.Clear();
        foreach (Match curMatch in matches)
        {
          if (!paramList.Contains(curMatch.Value))
            paramList.Add(curMatch.Value);
        }

        if (sqlParams != null && sqlParams.Length > 0)
        {
          //foreach (object paramValue in sqlParams)
          for (int i = 0; i < sqlParams.Length; i++)
          {
            if (sqlParams[i] is SqlParameter)
              sCmd.Parameters.AddWithValue(paramList[i], ToDBNull(((SqlParameter)sqlParams[i]).Value));
            else
              sCmd.Parameters.AddWithValue(paramList[i], ToDBNull(sqlParams[i]));
          }
        }



      }
    }
    //example of use (to explain how params are defined and filled
    //string cmd = "select * from timeentries where username=@username and recid = @recid or @username='neils mom'"
    //ExecuteNonQuery(sqlconn, false, 30, cmd, username, recordid);

    public static int ExecuteNonQuery(SqlConnection sqlCon, bool isUsp, int commandTimeout, string command, params object[] sqlParams)
    {
      try
      {
        SqlCommand sCmd = BuildSQLCommand(command, sqlCon, commandTimeout);
        DeriveAndFillParams(sCmd, isUsp, sqlParams);


        int retval = sCmd.ExecuteNonQuery();
        if (isUsp)
        {
          retval = (int)sCmd.Parameters[0].Value;
        }
        try
        {
          sCmd.Dispose();
        }
        catch { }
        finally
        {
         
          sCmd.Dispose();
        }
        return retval;

      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static int ExecuteNonQuery(SqlCommand sCmd, bool isUsp, params object[] sqlParams)
    {
      try
      {
        //  SqlCommand sCmd = BuildSQLCommand(command, sqlCon, commandTimeout);
        DeriveAndFillParams(sCmd, isUsp, sqlParams);


        int retval = sCmd.ExecuteNonQuery();
        if (isUsp)
        {
          retval = (int)sCmd.Parameters[0].Value;
        }
        try
        {
          
        }
        catch { }
        finally
        {
        
        }
        return retval;

      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static void Main(string[] args)
    {
      //SqlDataReader dr = 
    }

    public static SqlDataReader ExecuteReader(string connectionString, bool isUsp, int commandTimeout, string command, params object[] sqlParams)
    {
      try
      {
        SqlCommand sCmd = BuildSQLCommand(command, connectionString, commandTimeout);
        DeriveAndFillParams(sCmd, isUsp, sqlParams);
        SqlDataReader dr = sCmd.ExecuteReader(CommandBehavior.CloseConnection);
        try
        {
          sCmd.Dispose();
        }
        catch { }
        
        return dr;
      }
      catch (Exception ex)
      {
        
        throw ex;
      }
      
    }

    public static SqlDataReader ExecuteReader(SqlConnection _sqlCon, bool isUsp, int commandTimeout, string command, params object[] sqlParams)
    {
      try
      {

        SqlCommand sCmd = BuildSQLCommand(command, _sqlCon, commandTimeout);
        DeriveAndFillParams(sCmd, isUsp, sqlParams);
        SqlDataReader dr = sCmd.ExecuteReader();
        try
        {
          sCmd.Dispose();
        }
        catch { }
        return dr;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static SqlDataReader ExecuteReader(SqlCommand sCmd, bool isUsp, params object[] sqlParams)
    {
      try
      {


        DeriveAndFillParams(sCmd, isUsp, sqlParams);
        SqlDataReader dr = sCmd.ExecuteReader();

        return dr;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static object ExecuteScalar(string connectionString, bool isUsp, int commandTimeout, string command, params object[] sqlParams)
    {
      try
      {
        SqlCommand sCmd = BuildSQLCommand(command, connectionString, commandTimeout);
        DeriveAndFillParams(sCmd, isUsp, sqlParams);
        object result = sCmd.ExecuteScalar();
        try
        {
          sCmd.Connection.Close();
          sCmd.Connection.Dispose();
          sCmd.Dispose();
        }
        catch { }
        return result;
      }
      catch (Exception ex)
      {
        throw new Exception("Execute Reader", ex);
      }
    }

    public static object ExecuteScalar(SqlConnection _sqlCon, bool isUsp, int commandTimeout, string command, params object[] sqlParams)
    {
      try
      {
        SqlCommand sCmd = BuildSQLCommand(command, _sqlCon, commandTimeout);
        DeriveAndFillParams(sCmd, isUsp, sqlParams);
        object result = sCmd.ExecuteScalar();
        try
        {
          sCmd.Dispose();
        }
        catch { }
        return result;
      }
      catch (Exception ex)
      {
        throw new Exception("Execute Reader", ex);
      }
    }

    public static object ExecuteScalar(SqlCommand sCmd, bool isUsp, params object[] sqlParams)
    {
      try
      {
        DeriveAndFillParams(sCmd, isUsp, sqlParams);
        object result = sCmd.ExecuteScalar();

        return result;
      }
      catch (Exception ex)
      {
        throw new Exception("Execute Reader", ex);
      }
    }

    /// <summary>
    /// Returns a SqlCommand Object setup with the correct time and connectiong settings.
    /// </summary>
    /// <param name="cmd">Command Text to set.</param>
    /// <returns></returns>
    public static SqlCommand BuildSQLCommand(string cmd, string connectionString, int commandTimeout)
    {

      SqlCommand Cmd = new SqlCommand();
      SqlConnection sqlCon = null;
      sqlCon = new SqlConnection(connectionString);
      sqlCon.Open();
      Cmd.Connection = sqlCon;
      Cmd.CommandText = cmd;
      Cmd.CommandTimeout = commandTimeout;
      return Cmd;
    }

    public static SqlCommand BuildSQLCommand(string cmd, SqlConnection sqlCon, int commandTimeout)
    {

      SqlCommand Cmd = new SqlCommand();
      if (sqlCon.State == ConnectionState.Broken)
        sqlCon.Close();
      if (sqlCon.State != ConnectionState.Open)
        sqlCon.Open();

      Cmd.Connection = sqlCon;
      Cmd.CommandText = cmd;
      Cmd.CommandTimeout = commandTimeout;
      return Cmd;
    }

    public static object IsDBNull(object value)
    {
      if (value != null && value == DBNull.Value)
        return null;
      else
        return value;
    }

    public static List<T> FillList<T>(IDataReader dReader, T cloneFrom, bool useConvertType) where T : ICloneable
    {
      List<T> result = new List<T>();
      Type objectInfo = typeof(T);
      PropertyInfo[] properties = objectInfo.GetProperties();

      List<string> fieldNames = GetFieldNames(dReader,true);
      List<PropertyFieldPair> propertyFields = BuildPropertyFields(properties, fieldNames);
      while (dReader.Read())
      {
        T newItem = (T)cloneFrom.Clone();
        newItem = FillItem<T>(newItem, dReader, objectInfo, propertyFields, useConvertType);
        result.Add(newItem);
      }
      dReader.Close();
      return result;
    }

    public static List<T> FillList<T>(IDataReader dReader, bool useConvertType)
    {
      List<T> result = new List<T>();
      Type objectInfo = typeof(T);
      PropertyInfo[] properties = objectInfo.GetProperties();

      List<string> fieldNames = GetFieldNames(dReader,true);
      List<PropertyFieldPair> propertyFields = BuildPropertyFields(properties, fieldNames);
      while (dReader.Read())
      {
        T newItem = Activator.CreateInstance<T>();
        newItem = FillItem<T>(newItem, dReader, objectInfo, propertyFields, useConvertType);
        result.Add(newItem);
      }
      dReader.Close();
      return result;
    }
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dReader"></param>
    /// <param name="objectInfo"></param>
    /// <param name="properties"></param>
    /// <param name="fieldNames"></param>
    /// <remarks>This function looks for the table column in this order:
    /// SqlColumnNameAttribute.ColumnName, Property Name, then XmlElement.ElementName
    /// The performance is expected from explicitly difining a SqlColumnNameAttribute
    /// </remarks>
    /// <returns></returns>
    private static T FillItem<T>(T newItem, IDataReader dReader, Type objectInfo, List<PropertyFieldPair> propertyFields, bool useConvertType)
    {

      foreach (PropertyFieldPair curPropPair in propertyFields)
      {
        try
        {

          if (useConvertType)
          {
            curPropPair.Property.SetValue(newItem, Utilities.ChangeType(IsDBNull(dReader[curPropPair.Field]), curPropPair.Property.PropertyType), null);
          }
          else
          {
            curPropPair.Property.SetValue(newItem, IsDBNull(dReader[curPropPair.Field]), null);
          }
        }
        catch (Exception ex)
        {
          throw new LalosException(string.Format("Failed to set property '{0}'('{3}') using the value from field '{1}'('{4}'). Value: '{2}'",
            curPropPair.Property.Name, curPropPair.Field, dReader[curPropPair.Field], curPropPair.Property.PropertyType.Name,
            dReader[curPropPair.Field].GetType().Name), ex);
        }
      }
      return newItem;
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dReader"></param>
    /// <param name="objectInfo"></param>
    /// <param name="properties"></param>
    /// <param name="fieldNames"></param>
    /// <remarks>This function looks for the table column in this order:
    /// SqlColumnNameAttribute.ColumnName, Property Name, then XmlElement.ElementName
    /// The performance is expected from explicitly difining a SqlColumnNameAttribute
    /// </remarks>
    /// <returns></returns>
    public static T FillItem<T>(T newItem, IDataReader dReader, Type objectInfo, List<PropertyFieldPair> propertyFields)
    {

      foreach (PropertyFieldPair curPropPair in propertyFields)
      {
        try
        {
          curPropPair.Property.SetValue(newItem, IsDBNull(dReader[curPropPair.Field]), null);
        }
        catch (Exception ex)
        {
          throw new LalosException(string.Format("Failed to set property '{0}'('{3}') using the value from field '{1}'('{4}'). Value: '{2}'",
             curPropPair.Property.Name, curPropPair.Field, dReader[curPropPair.Field], curPropPair.Property.PropertyType.Name,
             dReader[curPropPair.Field].GetType().Name), ex);
        }
      }
      return newItem;
    }

    public static T FillItem<T>(IDataReader dReader, T newItem, bool useConvertType)
    {
      Type objectInfo = typeof(T);
      T result = default(T);
      PropertyInfo[] properties = objectInfo.GetProperties();

      List<string> fieldNames = GetFieldNames(dReader,true);
      List<PropertyFieldPair> propertyFields = BuildPropertyFields(properties, fieldNames);
      if (dReader.Read())
      {
        result = FillItem<T>(newItem, dReader, objectInfo, propertyFields, useConvertType);
      }

      return result;
    }

    public static T FillItem<T>(IDataReader dReader, bool useConvertType = false)
    {
      T newItem = Activator.CreateInstance<T>();
      return FillItem<T>(dReader, newItem, useConvertType);
    }

    public static List<T> FillList<T>(IDataReader dReader, T cloneFrom) where T : ICloneable
    {
      List<T> result = new List<T>();
      Type objectInfo = typeof(T);
      PropertyInfo[] properties = objectInfo.GetProperties();

      List<string> fieldNames = GetFieldNames(dReader,true);
      List<PropertyFieldPair> propertyFields = BuildPropertyFields(properties, fieldNames);
      while (dReader.Read())
      {
        T newItem = (T)cloneFrom.Clone();
        newItem = FillItem<T>(newItem, dReader, objectInfo, propertyFields);
        result.Add(newItem);
      }
      dReader.Close();
      return result;
    }

    public static T FillItem<T>(SortedList<string, string> values, Type objectInfo, PropertyInfo[] properties)
    {
      T newItem = Activator.CreateInstance<T>();
      foreach (PropertyInfo curProp in properties)
      {

        if (curProp.GetIndexParameters().Length == 0)
        {
          if (values.ContainsKey(curProp.Name))
          {
            try
            {
              curProp.SetValue(newItem, Utilities.ChangeType(values[curProp.Name], curProp.PropertyType), null);
            }
            catch (Exception ex)
            {
              throw new Exception(string.Format("Could not Set {0}({1}) from {2}. - {3}", curProp.Name, curProp.PropertyType.Name, values[curProp.Name], ex.Message), ex);
            }
          }
        }
      }
      return newItem;
    }

    public static List<T> FillList<T>(IDataReader dReader)
    {
      List<T> result = new List<T>();
      Type objectInfo = typeof(T);
      PropertyInfo[] properties = objectInfo.GetProperties();

      List<string> fieldNames = GetFieldNames(dReader,true);
      List<PropertyFieldPair> propertyFields = BuildPropertyFields(properties, fieldNames);
      while (dReader.Read())
      {
        T newItem = Activator.CreateInstance<T>();
        newItem = FillItem<T>(newItem, dReader, objectInfo, propertyFields);
        result.Add(newItem);
      }
      dReader.Close();
      return result;
    }

    public static List<PropertyFieldPair> BuildPropertyFields(PropertyInfo[] properties, List<string> fieldNames)
    {
      List<PropertyFieldPair> result = new List<PropertyFieldPair>();
      foreach (PropertyInfo property in properties)
      {
        string fieldName = GetPropertyField(property, fieldNames,true);
        if (fieldName != null)
          result.Add(new PropertyFieldPair(property, fieldName));
      }
      return result;
    }

    private static string GetPropertyField(PropertyInfo curProp, List<string> fieldNames, bool fieldsAreAllLowerCase=false)
    {
      string fieldNameToUse = null;
      string XmlElementName = null;
      string SqlColumnName = null;
      object[] colAttribs = curProp.GetCustomAttributes(typeof(SqlColumnNameAttribute), false);
      if (colAttribs.Length > 0)
      {
        SqlColumnName = ((SqlColumnNameAttribute)colAttribs[0]).ColumnName;
      }
      object[] attribs = curProp.GetCustomAttributes(typeof(XmlElementAttribute), false);
      if (attribs.Length > 0)
        XmlElementName = ((XmlElementAttribute)attribs[0]).ElementName;
      if (curProp.GetIndexParameters().Length == 0)
      {
        if (SqlColumnName != null && fieldNames.Contains(fieldsAreAllLowerCase ? SqlColumnName.ToLower(): SqlColumnName))
        {

          fieldNameToUse = SqlColumnName;
          //curProp.SetValue(newItem, IsDBNull(dReader[SqlColumnName]), null);
        }
        else
          if (fieldNames.Contains(fieldsAreAllLowerCase ? curProp.Name.ToLower() : curProp.Name))
            fieldNameToUse = curProp.Name;
          //curProp.SetValue(newItem, IsDBNull(dReader[curProp.Name]), null);
          else if (XmlElementName != null && fieldNames.Contains(fieldsAreAllLowerCase ? XmlElementName.ToLower() : XmlElementName))
            fieldNameToUse = XmlElementName;
        //curProp.SetValue(newItem, IsDBNull(dReader[XmlElementName]), null);
      }
      return fieldNameToUse;
    }



    public static T FillItem<T>(IDataReader dReader, T newItem)
    {
      Type objectInfo = typeof(T);
      T result = default(T);
      PropertyInfo[] properties = objectInfo.GetProperties();

      List<string> fieldNames = GetFieldNames(dReader,true);
      List<PropertyFieldPair> propertyFields = BuildPropertyFields(properties, fieldNames);
      if (dReader.Read())
      {
        result = FillItem<T>(newItem, dReader, objectInfo, propertyFields);
      }
      return result;
    }


    public static List<string> GetFieldNames(IDataReader dReader, bool asLowerCase = false)
    {
      List<string> result = new List<string>();
      for (int i = 0; i < dReader.FieldCount; i++)
      {
        if (asLowerCase)
          result.Add(dReader.GetName(i).ToLower());
        else
          result.Add(dReader.GetName(i).ToLower());

      }



      return result;
    }

    public static string FormatNullableDateTime(DateTime? value, string format)
    {
      if (value == null)
        return "";
      else
        return value.Value.ToString(format);
    }

    public static string FormatNullableDecimal(decimal? value, string format)
    {
      if (value == null)
        return "";
      else
        return value.Value.ToString(format);
    }

    public static string FormatNullableInt(int? value)
    {
      if (value == null)
        return "";
      else
        return value.Value.ToString();
    }

    public static T XMLDeserializeFromFile<T>(string path)
    {
      T result = default(T);
      FileInfo pathInfo = null;
      pathInfo = new FileInfo(path);
      if (!pathInfo.Exists)
      {
        try
        {
          if (!pathInfo.Directory.Exists)
            pathInfo.Directory.Create();
          result = Activator.CreateInstance<T>();
          XMLSerializeToFile(result, path);
          //Debug.Write("Should be creating default XML File");
        }
        catch (NullReferenceException e)
        {
          throw e;
        }
      }
      else
      {
        XmlSerializer settingsSerializer = new XmlSerializer(typeof(T));
        using (XmlReader xReader = XmlTextReader.Create("file://" + path))
          try
          {
            result = (T)settingsSerializer.Deserialize(xReader);
          }
          finally
          {
            if (xReader != null)
              xReader.Close();
          }
      }
      return result;
    }

    public static void XMLSerializeToFile<T>(T toSerialize, string path)
    {
      XmlSerializer settingsSerializer = new XmlSerializer(typeof(T));
      XmlWriterSettings xWs = new XmlWriterSettings();
      xWs.Indent = true;
      using (XmlWriter xWr = XmlTextWriter.Create(path, xWs))
        try
        {
          settingsSerializer.Serialize(xWr, toSerialize);
        }
        finally
        {
          if (xWr != null)
          {
            xWr.Flush();
            xWr.Close();
          }
        }
    }

    public static string XMLSerializeToString<T>(T toSerialize)
    {
      StringBuilder result = new StringBuilder();
      XmlSerializer settingsSerializer = new XmlSerializer(typeof(T));
      XmlWriterSettings xWs = new XmlWriterSettings();
      xWs.Indent = true;

      XmlWriter xWr = XmlTextWriter.Create(result, xWs);
      settingsSerializer.Serialize(xWr, toSerialize);
      xWr.Flush();
      xWr.Close();
      return result.ToString();
    }

    public static string XMLSerializeToString<T>(T toSerialize, bool omitXmlDeclaration)
    {
      StringBuilder result = new StringBuilder();
      XmlSerializer settingsSerializer = new XmlSerializer(typeof(T));
      XmlWriterSettings xWs = new XmlWriterSettings();
      xWs.Indent = true;

      xWs.OmitXmlDeclaration = omitXmlDeclaration;
      XmlWriter xWr = XmlTextWriter.Create(result, xWs);
      settingsSerializer.Serialize(xWr, toSerialize);
      xWr.Flush();
      xWr.Close();
      return result.ToString();
    }


    public static T XMLDeserializeFromString<T>(string data)
    {
      T result = default(T);
      XmlSerializer settingsSerializer = new XmlSerializer(typeof(T));
      StringReader sReader = new StringReader(data);
      result = (T)settingsSerializer.Deserialize(sReader);
      sReader.Close();
      return result;
    }


    /// <summary>
    /// Checks to see if the value in 'pathfile' is a valid path.
    /// </summary>
    /// <param name="pathfile"></param>
    /// <returns></returns>
    public static bool IsValidPath(string pathfile)
    {
      if (pathfile == null)
      {
        return false;
      }
      Regex regex = new Regex(@"^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w ]*))$");
      Match m = regex.Match(pathfile);
      return m.Success;
    }

    public static List<T> ListFromDelimitedString<T>(string values, string delimiter, bool trimEmptyValues, Converter<string, T> converter)
    {
      List<T> result = new List<T>();

      if (string.IsNullOrEmpty(values))
        return null;



      string[] list = values.Split(new string[] { delimiter }, trimEmptyValues ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);

      foreach (string curitem in list)
      {
        result.Add(converter(curitem));
      }
      return result;
    }

    /// <summary>
    /// Creates a delimited string from the List of type T.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="delimiter"></param>
    /// <param name="trimValues"></param>
    /// <returns></returns>
    public static string ListToDelimitedString<T>(IList<T> list, string delimiter, bool trimValues)
    {
      StringBuilder result = new StringBuilder();
      if (list == null)
        return null;
      bool firstItem = true;
      foreach (T curitem in list)
      {
        if (curitem != null)
        {
          string valueValueString = curitem.ToString();
          if (firstItem)
            firstItem = false;
          else
            result.Append(delimiter);
          if (trimValues)
            result.Append(valueValueString.Trim());
          else
            result.Append(valueValueString);

        }

      }
      return result.ToString(); ;
    }

    /// <summary>
    /// Gets the error within a sql "Execute Reader" error. if the error is 'Execute Reader' this function will
    /// get the the inner exception that is more descriptive, otherwise
    /// it just returns the message in ex.
    /// </summary>
    /// <param name="ex">Exception to get the message from.</param>
    /// <returns></returns>
    public static Exception GetRealError(Exception ex)
    {
      if (ex.Message == "Execute Reader" && ex.InnerException != null)
      {
        return ex.InnerException;
      }
      else
      {
        return ex;
      }
    }
    /// <summary>
    /// Gets the error within a sql error. if the error is 'Execute Reader' this function will
    /// get the message returned by the inner exception that is more descriptive, otherwise
    /// it just returns the message in ex.
    /// </summary>
    /// <param name="ex">Exception to get the message from.</param>
    /// <returns></returns>
    public static string GetRealMessage(Exception ex)
    {
      if (ex.Message == "Execute Reader" && ex.InnerException != null)
      {
        return ex.InnerException.Message;
      }
      else
      {
        return ex.Message;
      }
    }

    public static Nullable<DateTime> ToNullableDateTime(string value, bool dateonly)
    {
      DateTime dateValue = new DateTime();
      if (DateTime.TryParse(value, out dateValue))
      {
        return dateonly ? dateValue.Date : dateValue;
      }
      else
      {
        return null;
      }



    }

    public static DateTime ToDateTime(string value, bool dateonly, bool nowOnInvalidDate)
    {
      DateTime dateValue = new DateTime();
      if (DateTime.TryParse(value, out dateValue))
      {
        return dateonly ? dateValue.Date : dateValue;
      }
      else
      {
        if (!nowOnInvalidDate)
          throw new Exception("Invalid Date/Time Value");
        return dateonly ? DateTime.Now.Date : DateTime.Now;
      }



    }
    /// <summary>
    /// Nullable compartor, supports comparing of values that are null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>returns the same value as CompareTo for T, 
    /// but if a is null and b is null it returns 0, 
    /// if a is not null and b is it returns -1,
    /// if b is not null and a is it returns 1,
    /// compareTo normally returns a NullReferenceException.</returns>
    public static int NullableCompare<T>(Nullable<T> a, Nullable<T> b) where T : struct, IComparable
    {
      int res = 0;
      if (a == null && b == null)
        res = 0;
      else if (a == null && b != null)
        res = 1;
      else if (a != null && b == null)
        res = -1;
      else
        res = a.Value.CompareTo(b.Value);
      return res;
    }

    public static int NullableStringCompare(string a, string b)
    {
      int res = 0;
      if (a == null && b == null)
        res = 0;
      else if (a == null && b != null)
        res = 1;
      else if (a != null && b == null)
        res = -1;
      else
        res = a.CompareTo(b);
      return res;
    }

    public static Nullable<int> ToNullableInt(string value)
    {
      int resultvalue = 0;
      if (int.TryParse(value, out resultvalue))
        return (Nullable<int>)resultvalue;
      else
        return null;
    }


    /// <summary>
    /// Convert a string to an int, defaulting the result to 0 if
    /// the string value can not be parsed.
    /// </summary>
    /// <param name="value">string value to convert to int</param>
    /// <returns></returns>
    public static int ToInt(string value)
    {
      return ToInt(value, 0);
    }


    /// <summary>
    /// Convert a string to an int, defaulting the result to default value if
    /// the string value can not be parsed.
    /// </summary>
    /// <param name="value">string value to convert to int</param>
    /// <param name="defaultValue">value to use if parse fails.</param>
    /// <returns></returns>
    public static int ToInt(string value, int defaultValue)
    {
      int resultvalue = 0;
      if (int.TryParse(value, out resultvalue))
        return resultvalue;
      else
        return defaultValue;

    }
    /// <summary>
    /// Convert a string to a decimal, defaulting the result to 0 if
    /// the string value can not be parsed.
    /// </summary>
    /// <param name="value">value to parse</param>
    /// <returns>Decimal value</returns>
    public static decimal ToDecimal(string value)
    {
      return ToDecimal(value, 0M);
    }

    /// <summary>
    /// Convert a string to a decimal, defaulting the result to default value if
    /// the string value can not be parsed.
    /// </summary>
    /// <param name="value">string value to convert to decimal</param>
    /// <param name="defaultValue">value to use if parse fails.</param>
    /// <returns></returns>
    public static decimal ToDecimal(string value, decimal defaultValue)
    {
      decimal resultvalue = 0;
      if (decimal.TryParse(value, out resultvalue))
        return resultvalue;
      else
        return defaultValue;

    }

    public static Nullable<decimal> ToNullableDecimal(string value)
    {
      decimal resultvalue = 0;
      if (decimal.TryParse(value, out resultvalue))
        return (Nullable<decimal>)resultvalue;
      else
        return null;
    }


    public static LinkButton AddOptionToCell(TableCell theCell, string command, string argument, string text, bool addConfirm)
    {
      LinkButton newLinkButton = new LinkButton();
      newLinkButton.Text = text;
      newLinkButton.CommandName = command;
      newLinkButton.CommandArgument = argument;

      if (addConfirm)
        newLinkButton.OnClientClick = "javascript:return confirm('Are you sure you want to " + text.ToLower() + " this?');";
      theCell.Controls.Add(newLinkButton);
      Label newLabel = new Label();
      newLabel.Text = "&nbsp;&nbsp;";
      theCell.Controls.Add(newLabel);
      return newLinkButton;
    }

    public static LinkButton AddOptionToCell(TableCell theCell, string command, string argument, string text, bool addConfirm, string imageUrl)
    {
      LinkButton newLinkButton = new LinkButton();
      Image newImage = new Image();
      newImage.ImageUrl = imageUrl;
      newImage.AlternateText = text;
      newLinkButton.Controls.Add(newImage);
      newLinkButton.CommandName = command;
      newLinkButton.CommandArgument = argument;

      if (addConfirm)
        newLinkButton.OnClientClick = "javascript:return confirm('Are you sure you want to " + text.ToLower() + " this?');";
      theCell.Controls.Add(newLinkButton);
      Label newLabel = new Label();
      newLabel.Text = "&nbsp;&nbsp;";
      theCell.Controls.Add(newLabel);
      return newLinkButton;
    }
    public static SortedList<TKey, TValue> MakeSortedList<TKey, TValue>(IList<TValue> list, string keyPropertyName)
    {
      return MakeSortedList<TKey, TValue>(list, keyPropertyName, false);
    }

    /// <summary>
    /// Makes a sorted list keyed by the property name listed.
    /// </summary>
    /// <typeparam name="TKey">Type of the Key value in the result list</typeparam>
    /// <typeparam name="TValue">Type of the value in the list</typeparam>
    /// <param name="list">List of values of type TValue</param>
    /// <param name="keyPropertyName">name of the property in TValue that the list will be keyed by.</param>
    /// <param name="keyToLowerString">if the key is a string, then convert it to lower case.</param>
    /// <returns></returns>
    public static SortedList<TKey, TValue> MakeSortedList<TKey, TValue>(IList<TValue> list, string keyPropertyName, bool keyToLowerString)
    {
      SortedList<TKey, TValue> result = new SortedList<TKey, TValue>();
      Type objectInfo = typeof(TValue);
      if (keyToLowerString && typeof(TKey) != typeof(string))
        throw new Exception("To use keyToLowerString as true the Key must be a string");
      PropertyInfo[] properties = objectInfo.GetProperties();
      PropertyInfo keyProperty = null;
      foreach (PropertyInfo curProp in properties)
      {
        if (curProp.Name == keyPropertyName)
          keyProperty = curProp;
      }
      if (keyProperty == null)
        throw new Exception("Invalid Property Name");
      if (keyProperty.PropertyType != typeof(TKey))
        throw new Exception("Property Must have same type as key");
      bool useToLowerStringAdd = typeof(TKey) == typeof(string) && keyToLowerString;
      foreach (TValue curValue in list)
      {
        TKey key = (TKey)keyProperty.GetValue(curValue, null);
        if (useToLowerStringAdd)
        {
          string lKey = key.ToString().ToLower();
          result.Add((TKey)((object)lKey), curValue);
        }
        else
        {
          result.Add(key, curValue);
        }
      }


      return result;
    }

    /// <summary>
    /// Returns a list of he MS-SQL servers found on the network.
    /// </summary>
    /// <returns>A string array of servers found.</returns>
    public static string[] GetServers()
    {
      string[] retval = null;
      string txt = string.Empty;
      IntPtr henv = IntPtr.Zero;
      IntPtr hconn = IntPtr.Zero;
      StringBuilder inString = new StringBuilder(SQL_DRIVER_STR);
      StringBuilder outString = new StringBuilder(DEFAULT_RESULT_SIZE);
      short inStringLength = (short)inString.Length;
      short lenNeeded = 0;

      try
      {
        if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_ENV, henv, out henv))
        {
          if (SQL_SUCCESS == SQLSetEnvAttr(henv, SQL_ATTR_ODBC_VERSION, (IntPtr)SQL_OV_ODBC3, 0))
          {
            if (SQL_SUCCESS == SQLAllocHandle(SQL_HANDLE_DBC, henv, out hconn))
            {
              if (SQL_NEED_DATA == SQLBrowseConnect(hconn, inString, inStringLength, outString,
                  DEFAULT_RESULT_SIZE, out lenNeeded))
              {
                if (DEFAULT_RESULT_SIZE < lenNeeded)
                {
                  outString.Capacity = lenNeeded;
                  if (SQL_NEED_DATA != SQLBrowseConnect(hconn, inString, inStringLength, outString,
                      lenNeeded, out lenNeeded))
                  {
                    throw new ApplicationException("Unabled to aquire SQL Servers from ODBC driver.");
                  }
                }
                txt = outString.ToString();
                int start = txt.IndexOf("{") + 1;
                int len = txt.IndexOf("}") - start;
                if ((start > 0) && (len > 0))
                {
                  txt = txt.Substring(start, len);
                }
                else
                {
                  txt = string.Empty;
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        //Throw away any error if we are not in debug mode
        throw ex;
        //txt = string.Empty;
      }
      finally
      {
        if (hconn != IntPtr.Zero)
        {
          SQLFreeHandle(SQL_HANDLE_DBC, hconn);
        }
        if (henv != IntPtr.Zero)
        {
          SQLFreeHandle(SQL_HANDLE_ENV, hconn);
        }
      }

      if (txt.Length > 0)
      {
        retval = txt.Split(",".ToCharArray());
      }

      return retval;
    }

    public static bool GuidIsNullOrEmpty(Guid? value)
    {
      return (value == null || value == Guid.Empty);
    }
    /// <summary>
    /// Calculates the duration of a start time and end time in fractional hours.
    /// </summary>
    /// <param name="startDateTime">The starting time</param>
    /// <param name="endDateTime">The ending time</param>
    /// <returns>A decimal value that represents the hours between start and end. null if either input is null.</returns>
    public static decimal? CalculateDuration(DateTime? startDateTime, DateTime? endDateTime)
    {
      if (startDateTime == null || endDateTime == null)
        return null;

      DateTime start = startDateTime.Value;
      DateTime end = endDateTime.Value;

      TimeSpan timespan = end - start;

      //Convert the time span to decimals
      decimal hours = decimal.Parse(timespan.TotalHours.ToString());
      // Round seconds                

      hours = decimal.Round(hours, 2, MidpointRounding.AwayFromZero);



      return hours;
    }


    // Hash an input string and return the hash as
    // a 32 character hexadecimal string.
    public static string getMd5Hash(string input)
    {
      // Create a new instance of the MD5CryptoServiceProvider object.
      MD5 md5Hasher = MD5.Create();

      // Convert the input string to a byte array and compute the hash.
      byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

      // Create a new Stringbuilder to collect the bytes
      // and create a string.
      StringBuilder sBuilder = new StringBuilder();

      // Loop through each byte of the hashed data 
      // and format each one as a hexadecimal string.
      for (int i = 0; i < data.Length; i++)
      {
        sBuilder.Append(data[i].ToString("x2"));
      }

      // Return the hexadecimal string.
      return sBuilder.ToString();
    }

    // Verify a hash against a string.
    public static bool verifyMd5Hash(string input, string hash)
    {
      // Hash the input.
      string hashOfInput = getMd5Hash(input);

      // Create a StringComparer an comare the hashes.
      StringComparer comparer = StringComparer.OrdinalIgnoreCase;

      if (0 == comparer.Compare(hashOfInput, hash))
      {
        return true;
      }
      else
      {
        return false;
      }
    }





    /// <summary>
    /// Splits a string respecting Quoted values as that.
    /// </summary>
    /// <param name="text">string to split</param>
    /// <param name="delimiters">delimiters to use, to split by , and ; pass ,; here</param>
    /// <returns>Returns a split list of values respecting quoted boundries. Removes the quotes from each quoted item as well.</returns>
    public static string[] SplitQuoted(string text, string delimiter)
    {

      if (text == null)
        throw new ArgumentNullException("text", "text is null.");

      // Default delimiters are a space and tab (e.g. " \t").
      // All delimiters not inside quote pair are ignored.  
      // Default quotes pair is two double quotes ( e.g. '""' ).
      if (delimiter == null || delimiter.Length < 1)
        delimiter = ","; //default is comma
      string qualifier = "\"";
      string _Statement = string.Format("{0}(?=(?:[^{1}]*{1}[^{1}]*{1})*(?![^{1}]*{1}))",
        Regex.Escape(delimiter), Regex.Escape(qualifier));
      RegexOptions _Options = RegexOptions.Compiled;//| RegexOptions.Multiline;     
      // if (ignoreCase) _Options = _Options | RegexOptions.IgnoreCase;      
      Regex _Expression = new Regex(_Statement, _Options);
      return _Expression.Split(text);


    }

    /// <summary>
    /// Splits a string respecting Quoted values as that.
    /// </summary>
    /// <param name="text">string to split</param>
    /// <param name="delimiter">delimiters to use, to split by , and ; pass ,; here</param>
    /// <param name="cachedRegex">Pass in a regex object to store the cached regex used to do the split.(For large operations)</param>
    /// <returns>Returns a split list of values respecting quoted boundries. Removes the quotes from each quoted item as well.</returns>
    public static string[] SplitQuoted(string text, string delimiter, ref Regex cachedRegex)
    {

      if (text == null)
        throw new ArgumentNullException("text", "text is null.");

      // Default delimiters are a space and tab (e.g. " \t").
      // All delimiters not inside quote pair are ignored.  
      // Default quotes pair is two double quotes ( e.g. '""' ).
      if (cachedRegex == null)
      {
        if (delimiter == null || delimiter.Length < 1)
          delimiter = ","; //default is comma
        string qualifier = "\"";
        string _Statement = string.Format("{0}(?=(?:[^{1}]*{1}[^{1}]*{1})*(?![^{1}]*{1}))",
          Regex.Escape(delimiter), Regex.Escape(qualifier));
        RegexOptions _Options = RegexOptions.Compiled;//| RegexOptions.Multiline;     
        // if (ignoreCase) _Options = _Options | RegexOptions.IgnoreCase;      
        cachedRegex = new Regex(_Statement, _Options);
      }
      return cachedRegex.Split(text);


    }

    /// <summary>
    /// This function is it like Convert.ChangeType, but it handles nullable types such as
    /// int? and decimal?
    /// </summary>
    /// <param name="value">Value to convert</param>
    /// <param name="conversionType">The type of value to return.</param>
    /// <returns>Returns the value converted to the new type, throws an exception if it fails.</returns>
    public static object ChangeType(object value, Type conversionType)
    {
      if (conversionType.IsGenericType &&
          conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
      {

        if (value == null)
          return null;

        System.ComponentModel.NullableConverter nullableConverter
            = new System.ComponentModel.NullableConverter(conversionType);

        conversionType = nullableConverter.UnderlyingType;
      }

      return Convert.ChangeType(value, conversionType);
    }
    //public static int NullCompareTo(object obj1, object obj2)
    //{
    //    if (obj1 != null && obj12 != null)
    //    {
    //        IComparable cObj1 = (IComparable)obj1;
    //        IComparable cObj2 = (IComparable)obj2;
    //        return cObj1.CompareTo(cObj2);
    //    }
    //    if (obj1 == null && obj12 == null)
    //        return 0;
    //    if (obj1 != null && obj2 == null)
    //        return 1;
    //    else
    //        return -1;
    //}
    private static int ccLeftBracket = 123;
    private static int ccRightBracket = 125;
    private static int ccA = 65;
    //private static int ccI = 73;
    private static int ccJ = 74;
    private static int ccR = 82;

    public static Decimal OverPunchConverter(string value, int decimals)
    {
      decimal result = 0M;
      if (!string.IsNullOrEmpty(value))
      {
        Decimal modifier = 1M;
        value = value.Trim();
        if (value.Length > 0)
        {

          char lastChar = value.ToCharArray(value.Length - 1, 1)[0];

          int charCode = (int)lastChar;
          if (charCode != ccLeftBracket && charCode != ccRightBracket && (charCode < ccA || charCode > ccR))
            throw new Exception("Invalid Over Punch Value");
          if (charCode == ccRightBracket || (charCode >= ccJ && charCode <= ccR))
            modifier = -1M;
          lastChar = (charCode == ccLeftBracket || charCode == ccRightBracket) ? '0' :
              (charCode >= ccJ && charCode <= ccR) ? Convert.ToChar((charCode - ccJ + 1).ToString())
                  : Convert.ToChar((charCode - ccA + 1).ToString());
          value = value.Substring(0, value.Length - 1) + lastChar.ToString();
          result = modifier * decimal.Parse(value) / (decimal)Math.Pow(10, decimals);
        }

      }

      return result;
    }

    public static List<string> GetStringList<T>(IList<T> list, string propertyName)
    {
      object value = null;
      List<string> values = new List<string>();
      Type tT = typeof(T);
      PropertyInfo prop = GetSortedListOfProperties(tT)[propertyName];
      foreach (T curItem in list)
      {
        value = prop.GetValue(curItem, null);
        if (value != null)
        {
          values.Add(value.ToString());
        }
      }
      return values;
    }
    public static bool IsNullOrWhiteSpace(string value)
    {
      bool res = false;
      if (value == null)
      {
        res = true;
      }
      else
      {
        res = (value.Trim() == "");
      }

      return res;
    }
    private static SortedList<string, PropertyInfo> GetSortedListOfProperties(Type tT)
    {
      PropertyInfo[] props = tT.GetProperties();
      SortedList<string, PropertyInfo> res = new SortedList<string, PropertyInfo>();
      foreach (PropertyInfo prop in props)
        res.Add(prop.Name, prop);
      return res;
    }
  }


}
