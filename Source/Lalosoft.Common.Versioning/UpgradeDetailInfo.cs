using System;
using System.Collections.Generic;
using System.Text;

namespace Lalosoft.Common.Versioning
{
    public class UpgradeDetailInfo : VersionInfo
    {
        private UpgradeEligibility _eligibility;
        private DownloadUrlInfo _downloadInfo = null;

        public DownloadUrlInfo DownloadInfo
        {
            get { return _downloadInfo; }
            set { _downloadInfo = value; }
        }
        private bool _getUpdate = true;

        private bool _alreadyDownloaded = false;

        public bool AlreadyDownloaded
        {
            get { return _alreadyDownloaded; }
            set { _alreadyDownloaded = value; }
        }

        public bool GetUpdate
        {
            get { return _getUpdate; }
            set { _getUpdate = value; }
        }
        public UpgradeEligibility Eligibility
        {
            get { return _eligibility; }
            set { _eligibility = value; }
        }


        public UpgradeDetailInfo()
            : base()
        {
        }

        public UpgradeDetailInfo(
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
            string subProductID,
            UpgradeEligibility eligibility
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
            _eligibility = eligibility;
            

        }

        public override object Clone()
        {
            UpgradeDetailInfo res = new UpgradeDetailInfo(_recordID, _productName, _assemblyName, _majorVersion, _minorVersion, _revision, _buildDateSerial, _buildNumber, _versionModifier, _versionModifier2, _mainProductID, _subProductID,_eligibility);
            if (_downloadInfo != null)
                res._downloadInfo = (DownloadUrlInfo)_downloadInfo.Clone();
            return res;
        }

        public UpgradeDetailInfo(VersionInfo baseVersionInfo, UpgradeEligibility eligibility)
        {
            _recordID = baseVersionInfo.RecordID;
            _productName = baseVersionInfo.ProductName;
            _assemblyName = baseVersionInfo.AssemblyName;
            _majorVersion = baseVersionInfo.MajorVersion;
            _minorVersion = baseVersionInfo.MinorVersion;
            _revision = baseVersionInfo.Revision;
            _buildDateSerial = baseVersionInfo.BuildDateSerial;
            _buildNumber = baseVersionInfo.BuildNumber;
            _versionModifier = baseVersionInfo.VersionModifier;
            _versionModifier2 = baseVersionInfo.VersionModifier2;
            _mainProductID = baseVersionInfo.MainProductID;
            _subProductID = baseVersionInfo.SubProductID;
            _eligibility = eligibility;
            
        }
    }
}
