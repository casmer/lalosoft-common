using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lalosoft.Common;
using Lalosoft.Common.Exceptions;
using Lalosoft.Profiles.Common.DataObjects;
using Lalosoft.Profiles.Common.InfoObjects;
using Lalosoft.Profiles.Common.Exceptions;
using System.IO;

namespace Lalosoft.Profiles.Common
{
  public class ProfileManager
  {

    public const string csSelectedProfileFilename = "SelectedProfile.xml";
    public const string csDefaultProfileName = "Default";


    private static string _AppDir=null;
    private static object _padLock = new object();
    private static ProfileManager _instance = null;

    public ProfileManager()
    {
      ProfileSelectionInfo selection = LoadProfileSelection();

    }

    public static ProfileManager Instance
    {
      get
      {
        lock (_padLock)
        {
          if (_instance == null)
          {
            _instance = new ProfileManager();
          }
          return _instance;
        }
      }
    }

    string _profileName = csDefaultProfileName;
    public static string GetProfileDir()
    {
      return Path.Combine(_AppDir, "Profiles");
    }
    public ProfileList GetProfiles()
    {
      ProfileList res = new ProfileList();
      AppDirCheck();
      if (Directory.Exists(GetProfileDir()))
      {
        DirectoryInfo dirInfo = new DirectoryInfo(GetProfileDir());
        DirectoryInfo[] dirs = dirInfo.GetDirectories();
        foreach (DirectoryInfo subDir in dirs)
        {
          res.Add(new ProfileInfo() { Name = subDir.Name });
        }
      }
      if (res.Count == 0)
      {
        res.Add(new ProfileInfo() { Name = csDefaultProfileName });
      }
      return res;
    }

    private static void AppDirCheck()
    {
      if (_AppDir == null)
        throw new LalosoftNoAppDirectorySetException("Must set the app directory using SetAppDirectory()");
    }

    public static void SetAppDirectory(string dir)
    {
      lock (_padLock)
      {
        _AppDir = dir;
      }
    }

    public string GetProfilePath()
    {
      AppDirCheck();
      return Path.Combine(GetProfileDir(), _profileName);
    }
  
    public void SaveProfileSelection()
    {
      AppDirCheck();
      ProfileSelectionInfo selection = new ProfileSelectionInfo();
      selection.Profile = new ProfileInfo() { Name = _profileName };
      
      Utilities.XMLSerializeToFile<ProfileSelectionInfo>(selection, GetProfileSelectionPath());
    }

    private static string GetProfileSelectionPath()
    {
      string profileSelectionPath = Path.Combine(GetProfileDir(), csSelectedProfileFilename);
      return profileSelectionPath;
    }

    public ProfileSelectionInfo LoadProfileSelection()
    {
      ProfileSelectionInfo res = null;
      AppDirCheck();
      string path = GetProfileSelectionPath();
      if (File.Exists(path))
      {
        try
        {
          res = Utilities.XMLDeserializeFromFile<ProfileSelectionInfo>(path);

        }
        catch (Exception )
        {
          
        }
      }
      if (res==null)
        res = new ProfileSelectionInfo() ;
      if (res!=null && res.Profile == null)
      {
        res = null;
        //res.Profile = new ProfileInfo() { Name = csDefaultProfileName };
      } else if (Lalosoft.Common.Utilities.IsNullOrWhiteSpace(res.Profile.Name))
      {
        res = null;
      }
      return res;
    }

    public static string AppDir
    {
      get {
        lock (_padLock)
        {
          return _AppDir;
        }
      }
    }
    public string ProfileName
    {
      get { return this._profileName; }
      set { this._profileName = value; }
    }




    public void ClearProfileSelection()
    {
     
      AppDirCheck();
      string path = GetProfileSelectionPath();
      if (File.Exists(path))
      {
        File.Delete(path);
      }
    }
  }
}
