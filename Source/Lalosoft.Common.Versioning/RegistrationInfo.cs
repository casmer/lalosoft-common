using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Lalosoft.Common.Versioning
{
    public class RegistrationInfo : ICloneable
    {
        #region Private Vars
        private Guid _recordId;
        private long _registrationId;
        private string _userName;
        private string _userCompany;
        private string _emailAddress;
        private string _lastIp;
        private DateTime _createDate;
        private DateTime _modifyDate;

        #endregion Private Vars

        #region Properties
        [XmlElement("recordid")]
        public Guid RecordId
        {
            get { return _recordId; }
            set { _recordId = value; }
        }
        [XmlElement("registrationid")]
        public long RegistrationId
        {
            get { return _registrationId; }
            set { _registrationId = value; }
        }
        [XmlElement("UserName")]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        [XmlElement("usercompany")]
        public string UserComany
        {
            get { return _userCompany; }
            set { _userCompany = value; }
        }
        [XmlElement("emailaddress")]
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }
        [XmlElement("lastip")]
        public string LastIp
        {
            get { return _lastIp; }
            set { _lastIp = value; }
        }
        [XmlElement("createdate")]
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        [XmlElement("modifydate")]
        public DateTime ModifyDate
        {
            get { return _modifyDate; }
            set { _modifyDate = value; }
        }

        #endregion Properties

        #region Constructors
        public RegistrationInfo(Guid recordId, long registrationId, string userName, string userCompany, string emailAddress, string lastIp, DateTime createDate, DateTime modifyDate)
        {
            _recordId = recordId;
            _registrationId = registrationId;
            _userName = userName;
            _userCompany = userCompany;
            _emailAddress = emailAddress;
            _lastIp = lastIp;
            _createDate = createDate;
            _modifyDate = modifyDate;

        }
        public RegistrationInfo()
        {
            _recordId = Guid.NewGuid();
            _registrationId = 0;
            _userName = "";
            _userCompany = "";
            _emailAddress = "";
            _lastIp = "";
            _createDate = DateTime.Now;
            _modifyDate = DateTime.Now;

        }
        #endregion Constructors

        #region ICloneable Members

        public object Clone()
        {
            return new RegistrationInfo(
                _recordId, _registrationId, _userName, _userCompany, _emailAddress, _lastIp,
                _createDate, _modifyDate);
        }

        #endregion
    }
}
