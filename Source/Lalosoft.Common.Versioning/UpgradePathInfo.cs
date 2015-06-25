using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
//using Lalosoft.Common.Exceptions;

namespace Lalosoft.Common.Versioning
{
    public class UpgradePathInfo : IComparable
    {
        #region Private Vars
       
        private string _mainProductID;
        private string _subProductIdCurrentVersion;
        private string _subProductIdNewVersion;
        private UpgradeEligibility _upgradeEligibility;

        #endregion Private Vars

        #region Properties
       
        [XmlElement("mainProductID")]
        public string MainProductID
        {
            get { return _mainProductID; }
            set { _mainProductID = value; }
        }
        [XmlElement("subProductIdCurrentVersion")]
        public string SubProductIdCurrentVersion
        {
            get { return _subProductIdCurrentVersion; }
            set { _subProductIdCurrentVersion = value; }
        }
        [XmlElement("subProductIdNewVersion")]
        public string SubProductIdNewVersion
        {
            get { return _subProductIdNewVersion; }
            set { _subProductIdNewVersion = value; }
        }
        [XmlElement("upgradeEligibility")]
        public UpgradeEligibility UpgradeEligibility
        {
            get { return _upgradeEligibility; }
            set { _upgradeEligibility = value; }
        }

        #endregion Properties

        #region Constructors
        public UpgradePathInfo(string mainProductID, string subProductIdCurrentVersion, string subProductIdNewVersion, UpgradeEligibility upgradeEligibility)
        {
            _mainProductID = mainProductID;
            _subProductIdCurrentVersion = subProductIdCurrentVersion;
            _subProductIdNewVersion = subProductIdNewVersion;
            _upgradeEligibility = upgradeEligibility;

        }

        public UpgradePathInfo()
        {
            _mainProductID = null;
            _subProductIdCurrentVersion = null;
            _subProductIdNewVersion = null;
            _upgradeEligibility = 0;

        }
        #endregion Constructors

        #region IComparable Members

        public override bool Equals(object obj)
        {
            return this.CompareTo(obj)==0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (obj is UpgradePathInfo)
            {
                UpgradePathInfo cObj = (UpgradePathInfo)obj;
                int res = this._mainProductID.CompareTo(cObj._mainProductID);
                if (res == 0)
                    res = this._subProductIdCurrentVersion.CompareTo(cObj._subProductIdCurrentVersion);
                if (res == 0)
                    res = this._subProductIdNewVersion.CompareTo(cObj._subProductIdNewVersion);
                return res;
            }
            else
                throw new Exception("Must compare to another upgrade path info");
        }

        #endregion
    }

    public enum UpgradeEligibility
    {
        None = 0,
        Free = 1,
        UpgradePurchaseAvailable=2,
        
    }
}
