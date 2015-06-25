using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
//using Lalosoft.Common.Exceptions;

namespace Lalosoft.Common.Versioning
{
    public class DownloadUrlInfo : IComparable, ICloneable
    {
        #region Private Vars
        private string _subProductID;
        private string _downloadUrl;

        #endregion Private Vars

        #region Properties
        [XmlElement("subProductID")]
        public string SubProductID
        {
            get { return _subProductID; }
            set { _subProductID = value; }
        }
        [XmlElement("downloadUrl")]
        public string DownloadUrl
        {
            get { return _downloadUrl; }
            set { _downloadUrl = value; }
        }

        #endregion Properties

        #region Constructors
        public DownloadUrlInfo(string subProductID, string downloadUrl)
        {
            _subProductID = subProductID;
            _downloadUrl = downloadUrl;

        }

        public DownloadUrlInfo()
        {
            _subProductID = null;
            _downloadUrl = null;

        }
        #endregion Constructors

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is DownloadUrlInfo)
            {
                return _subProductID.CompareTo(((DownloadUrlInfo)obj)._subProductID);
            }
            else
            {
                throw new Exception("Must Compare Download Url Infos to objects of their type");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is DownloadUrlInfo)
                return CompareTo(obj) == 0;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        #endregion

        #region ICloneable Members

        public object Clone()
        {
            return new DownloadUrlInfo(_subProductID, _downloadUrl);
        }

        #endregion
    }
}
