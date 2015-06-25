using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
//using Lalosoft.Common.Exceptions;

namespace Lalosoft.Common.Versioning
{
    [XmlType("VersionInfo",IncludeInSchema=true,Namespace="https://www.lalosoft.com/Versioning/")]
    public class VersionInfo : Attribute, IComparable, ICloneable
    {

        #region Contructors
        public VersionInfo(
            Guid recordID,
            string productName,
            string assemblyName,
            int majorVersion,
            int minorVersion,
            Nullable<int> revision,
            Nullable<int> buildDateSerial,
            Nullable<int> buildNumber,
            string versionModifier,
            string versionModifier2,
            string mainProductID,
            string subProductID
            )
        {
            _recordID = recordID;
            _productName = productName;
            _assemblyName = assemblyName;
            _majorVersion = majorVersion;
            _minorVersion = minorVersion;
            _revision = revision;
            _buildDateSerial = buildDateSerial;
            _buildNumber = buildNumber;
            _versionModifier = versionModifier;
            _versionModifier2 = VersionModifier2;
            _mainProductID = mainProductID;
            _subProductID = subProductID;
            

        }

        public VersionInfo(
            
            string productName,
            string assemblyName,
            int majorVersion,
            int minorVersion,
            int revision,
            int buildDateSerial,
            int buildNumber,
            string versionModifier,
            string versionModifier2,
            string mainProductID,
            string subProductID
            )
        {
            _recordID = Guid.Empty;
            _productName = productName;
            _assemblyName = assemblyName;
            _majorVersion = majorVersion;
            _minorVersion = minorVersion;
            _revision = revision < 0 ? null : (Nullable<int>)revision;
            _buildDateSerial = buildDateSerial < 0 ? null : (Nullable<int>)buildDateSerial;
            _buildNumber = buildNumber < 0 ? null : (Nullable<int>)buildNumber;
            _versionModifier = versionModifier;
            _versionModifier2 = VersionModifier2;
            _mainProductID = mainProductID;
            _subProductID = subProductID;


        }

        public VersionInfo(
            string productName,
            string assemblyName,
            int majorVersion,
            int minorVersion,
            Nullable<int> revision,
            Nullable<int> buildDateSerial,
            Nullable<int> buildNumber,
            string versionModifier,
            string versionModifier2,
            string mainProductID,
            string subProductID
            )
        {
            _recordID = Guid.Empty;
            _productName = productName;
            _assemblyName = assemblyName;
            _majorVersion = majorVersion;
            _minorVersion = minorVersion;
            _revision = revision;
            _buildDateSerial = buildDateSerial;
            _buildNumber = buildNumber;
            _versionModifier = versionModifier;
            _versionModifier2 = VersionModifier2;
            _mainProductID = mainProductID;
            _subProductID = subProductID;


        }

        public VersionInfo(
            string productName,
            string assemblyName,
            int majorVersion,
            int minorVersion,
            Nullable<int> revision,
            string versionModifier,
            string versionModifier2
            )
        {
            _productName = productName;
            _assemblyName = assemblyName;
            _majorVersion = majorVersion;
            _minorVersion = minorVersion;
            _revision = revision;
            _buildDateSerial = null;
            _buildNumber = null;
            _versionModifier = versionModifier;
            _versionModifier2 = VersionModifier2;
            _mainProductID = Guid.NewGuid().ToString();
            _subProductID = Guid.NewGuid().ToString();

        }

        public VersionInfo(
            string productName,
            string assemblyName,
            int majorVersion,
            int minorVersion,
            string versionModifier,
            string versionModifier2
            )
        {
            _productName = productName;
            _assemblyName = assemblyName;
            _majorVersion = majorVersion;
            _minorVersion = minorVersion;
            _revision = null;
            _buildDateSerial = null;
            _buildNumber = null;
            _versionModifier = versionModifier;
            _versionModifier2 = VersionModifier2;
            _mainProductID = Guid.NewGuid().ToString();
            _subProductID = Guid.NewGuid().ToString();

        }

        public VersionInfo(
            string productName,
            string assemblyName,
            int majorVersion,
            int minorVersion
            )
        {
            _productName = productName;
            _assemblyName = assemblyName;
            _majorVersion = majorVersion;
            _minorVersion = minorVersion;
            _revision = null;
            _buildDateSerial = null;
            _buildNumber = null;
            _versionModifier = null;
            _versionModifier2 = null;
            _mainProductID = Guid.NewGuid().ToString();
            _subProductID = Guid.NewGuid().ToString();

        }

        public VersionInfo(
           )
        {
            _productName = null;
            _assemblyName = null;
            _majorVersion = 0;
            _minorVersion = 0;
            _revision = null;
            _buildDateSerial = null;
            _buildNumber = null;
            _versionModifier = null;
            _versionModifier2 = null;
            _mainProductID = Guid.NewGuid().ToString();
            _subProductID = Guid.NewGuid().ToString();

        }

        #endregion Contructors
        #region Private Variables
        protected Guid _recordID;
        protected string _productName;
        protected string _assemblyName;
        protected int _majorVersion;
        protected int _minorVersion;
        protected Nullable<int> _revision;
        protected Nullable<int> _buildDateSerial;
        protected Nullable<int> _buildNumber;
        protected string _versionModifier;
        protected string _versionModifier2;
        protected string _mainProductID;
        protected string _subProductID;
        
        #endregion Private Variables

        #region Properties

        public Guid RecordID
        {
            get { return _recordID; }
            set { _recordID = value; }
        }

        public string ProductFullName
        {
            get
            {
                return this.ToString();
            }
        }
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public string AssemblyName
        {
            get { return _assemblyName; }
            set { _assemblyName = value; }
        }

        public int MajorVersion
        {
            get { return _majorVersion; }
            set { _majorVersion = value; }
        }

        public int MinorVersion
        {
            get { return _minorVersion; }
            set { _minorVersion = value; }
        }

        public Nullable<int> Revision
        {
            get { return _revision; }
            set { _revision = value; }
        }

        public Nullable<int> BuildDateSerial
        {
            get { return _buildDateSerial; }
            set { _buildDateSerial = value; }
        }

        public Nullable<int> BuildNumber
        {
            get { return _buildNumber; }
            set { _buildNumber = value; }
        }

        public string VersionModifier
        {
            get { return _versionModifier; }
            set { _versionModifier = value; }
        }

        public string VersionModifier2
        {
            get { return _versionModifier2; }
            set { _versionModifier2 = value; }
        }

        [XmlElement("mainProductID")]
        public string MainProductID
        {
            get { return _mainProductID; }
            set { _mainProductID = value; }
        }
        [XmlElement("subProductID")]
        public string SubProductID
        {
            get { return _subProductID; }
            set { _subProductID = value; }
        }

        #endregion Properties
        #region Overrides
        public override string ToString()
        {
            if (_buildNumber!=null && _buildDateSerial!=null)
                return string.Format("{0} {1}.{2}.{3} {4} {5} Build ({1}.{2}.{3}.{6}.{7})", 
                    _productName, //0
                    _majorVersion,  //1
                    _minorVersion, //2
                    _revision, //3
                    _versionModifier, //4
                    _versionModifier2, //5
                    _buildDateSerial, //6
                    _buildNumber //7
                    );
            else
                return string.Format("{0} {1}.{2}.{3} {4} {5}",
                _productName, //0
                _majorVersion,  //1
                _minorVersion, //2
                _revision, //3
                _versionModifier, //4
                _versionModifier2
                );
        }

        public override object TypeId
        {
            get
            {
                return new Guid("0A322B32-9558-4E2D-B64D-766F15546483");
            }
        }
        #endregion Overrides



        #region IComparable Members
        public override bool Equals(object obj)
        {
            if (obj is VersionInfo)
                return this._subProductID.Equals(((VersionInfo)obj)._subProductID);
            else
                return false;
            
        }

        public override int GetHashCode()
        {
            return this._subProductID.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (obj is VersionInfo)
            {
                VersionInfo cObj = (VersionInfo)obj;
                int res = 0;
                res = this._majorVersion.CompareTo(cObj._majorVersion);
                if (res == 0)
                    res = this._minorVersion.CompareTo(cObj._minorVersion);
                if (res == 0)
                    res = Nullable.Compare<int>(this._revision, cObj._revision);
                if (res == 0)
                    res = Nullable.Compare<int>(this._buildDateSerial, cObj._buildDateSerial);
                if (res == 0)
                    res = Nullable.Compare<int>(this._buildNumber, cObj._buildNumber);
                return res;
            }
            else
                throw new Exception("Must compare to a Version Info");
        }

        #endregion

        #region ICloneable Members

        public virtual object Clone()
        {
            return new VersionInfo(_recordID, _productName, _assemblyName, _majorVersion, _minorVersion, _revision, _buildDateSerial, _buildNumber, _versionModifier, _versionModifier2, _mainProductID, _subProductID);
        }

        #endregion
    }
}
