using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace Lalosoft.VersionIncrementor
{
  //static class Extensions
  //{
  //  /// <summary>
  //  /// Get substring of specified number of characters on the right.
  //  /// </summary>
  //  public static string Right(this string value, int length)
  //  {
  //    return value.Substring(value.Length - length);
  //  }
  //}

  public class VersionBuildTask : Task
  {

    string m_AssemblyFileLocation; // This is the Assembly file that has the version info.
    string _configurationName;

    string _versionBaseFile=null;

    

    public override bool Execute()
    {
      try
      {
        if (_configurationName.ToLower().Contains("debug"))
        {
          Log.LogMessage(MessageImportance.High, "Configuration contains DEBUG in the name, canceling Increment");
          return true;
        }
        else
        {
          Log.LogMessage(MessageImportance.High, "Incrementing Version Number");
          return IncrementVersion();
        }
      }
      catch (Exception ex)
      {
        Log.LogError(ex.Message);
        return false;
      }
    } //Execute 

    [Required()]
    public string AssemblyFileLocation
    {
      get { return m_AssemblyFileLocation; }
      set { m_AssemblyFileLocation = value; }
    }
    [Required()]
    public string ConfigurationName
    {
      get { return _configurationName; }
      set { _configurationName = value; }
    }

    public string VersionBaseFile
    {
      get { return _versionBaseFile; }
      set { _versionBaseFile = value; }
    }

    private bool IncrementVersion()
    {
      int i;
      string[] FileData;
      string s;
      string Version;
      string[] v;
      bool ResetRevision = true;

      // All the commented msgbox lines are for debugging.
      // you don't need them.

      //If MsgBox("IncrementVersion Run on file " & m_AssemblyFileLocation & vbNewLine & vbNewLine & "Copy path to clipboard?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
      //    My.Computer.Clipboard.Clear()
      //    My.Computer.Clipboard.SetText(m_AssemblyFileLocation)
      //}
      string full_path = "";
      
      Log.LogMessage("Build Task Increment Version...");

      if (m_AssemblyFileLocation.ToLower().EndsWith("assemblyinfo.cs") == false)
      {


        full_path = Path.Combine(m_AssemblyFileLocation, "AssemblyInfo.cs");
        Debug.Print("BUILD MANEOAAEA");
        Console.Write("BUILD TASKS INCREMENT");
        Console.WriteLine(full_path);
        if (!File.Exists(full_path))
        {
          full_path = Path.Combine(m_AssemblyFileLocation, "Properties\\AssemblyInfo.cs");
          //MsgBox(m_AssemblyFileLocation)
        }
      }
      else
      {
        full_path = m_AssemblyFileLocation;

      }
      
      Log.LogMessage( MessageImportance.High, String.Format("Changing Version Information in {0}", full_path));
      

      // Ok, we have the assembly file, try to open it.
      if (File.Exists(full_path))
      {

        // Set build number to the number of days that have passed since Jan 1 2000
        // If you want to modifiy what the build number means or does, here is the place.
        int Major = 1;
        int Minor = 0;
        int BuildNumber = Math.Abs((DateTime.Now.Date - new DateTime(2000, 1, 1).Date).Days);
        int Revision = 0;

        //MsgBox("New build number = " & BuildNumber)

        try
        {
          FileData = File.ReadAllLines(full_path);

          //MsgBox("Read " & FileData.Length & " lines from " & m_AssemblyFileLocation)

          if (FileData.Length == 0) return false;
          // loop through each line and look for the version lines.
          for (i = 0; i <= FileData.Length - 1; i++)
          {
            s = FileData[i];
            if (s.Length > 2)
            {
              // Look to see if it contains one of the 2 version lines we want.
              //VB: <Assembly: AssemblyVersion("0.0.0.0")> 
              //VB: <Assembly: AssemblyFileVersion("0.0.0.0")> 
              //C#: [assembly: AssemblyFileVersion("1.0.0.0")]
              //C#: [assembly: AssemblyVersion("1.0.0.0")]
              if (!(s.Substring(0, 1) == "'") && !(s.Substring(0, 2) == "//"))
              {

                if (s.Contains("AssemblyVersion") || s.Contains("AssemblyFileVersion"))
                {

                  //MsgBox("Target line " & s & " found, parsing now.")

                  // Get the version from the line.
                  // we do this by getting the first " and losing everything before it.
                  // do the same after the next "
                  // everything left should be version info.
                  Match res = Regex.Match(s, @"[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+");
                  Version = res.Value;
                  //Version = s.Right(s.Length - s.IndexOf((char)34) - 1);
                  //Version = Version.Substring( Version.IndexOf((char)34));

                  //MsgBox("Version found = " & Version)
                  Log.LogMessage(MessageImportance.High, "Current Version: {0}", Version);
                  v = Version.Split(new char[] { '.' });
                  if (v.Length >= 0) Major = int.Parse(v[0]);
                  if (v.Length >= 1) Minor = int.Parse(v[1]);
                  if (v.Length >= 2) ResetRevision = (BuildNumber != int.Parse(v[2]));
                  if (v.Length >= 3) Revision = int.Parse(v[3]) + 1;
                  SetupVersionBaseFile(Major, Minor);
                  // ok, now that we have the version numbers in their variables
                  // it's time to update the build, if needed.
                  if (ResetRevision) Revision = 1;

                  //MsgBox("Replacing version with " & Major & "." & Minor & "." & BuildNumber & "." & Revision)

                  // ok, update the original line from the array.
                  VersionBase baseVer = GetVersionBase(Major, Minor);
                  string newVersion = baseVer.Major + "." + baseVer.Minor + "." + BuildNumber + "." + Revision;
                  Log.LogMessage(MessageImportance.High, "New Version: {0}", newVersion);
                  
                  FileData[i] = FileData[i].Replace(Version, newVersion);

                  //MsgBox("Filedata(" & i & ") = " & FileData[i])
                }
              }
            }
          }

          // ok, rewrite the assembly info back into the file, and let's home the compiler picks it up
          //MsgBox("writing all data back to file")
          File.WriteAllLines(full_path, FileData);

        }
        catch (Exception ex)
        {
          // hrm. Error. Fail please.

          MessageBox.Show("ERROR! " + ex.Message, "Build Tasks");
          //Log.LogError(ex.Message);
          //Log.LogErrorFromException(ex);
          Log.LogErrorFromException(ex, true, true, "VersionBuildTasks.cs");
          return false;
        }
      }

      // return success
      return true;
    }

    private void SetupVersionBaseFile(int major, int minor)
    {
      if (!string.IsNullOrEmpty(_versionBaseFile) && !File.Exists(_versionBaseFile))
      {
        VersionBase b = new VersionBase();
        b.Major = major;
        b.Minor = minor;
        XMLSerializeToFile<VersionBase>(b, _versionBaseFile);
      }
    }

    private VersionBase GetVersionBase(int major, int minor)
    {
      if (!string.IsNullOrEmpty(_versionBaseFile) && File.Exists(_versionBaseFile))
      {
        return XMLDeserializeFromFile<VersionBase>(_versionBaseFile);
      }
      else
        return new VersionBase(major, minor);
    }

    private T XMLDeserializeFromFile<T>(string path)
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
        XmlReader xReader = XmlTextReader.Create("file://" + path);

        result = (T)settingsSerializer.Deserialize(xReader);
        xReader.Close();
      }
      return result;
    }

    private void XMLSerializeToFile<T>(T toSerialize, string path)
    {
      XmlSerializer settingsSerializer = new XmlSerializer(typeof(T));
      XmlWriterSettings xWs = new XmlWriterSettings();
      xWs.Indent = true;
      XmlWriter xWr = XmlTextWriter.Create(path, xWs);
      settingsSerializer.Serialize(xWr, toSerialize);
      xWr.Flush();
      xWr.Close();
    }

  }
}

