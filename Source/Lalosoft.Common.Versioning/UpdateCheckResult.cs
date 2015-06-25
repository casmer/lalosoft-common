using System;
using System.Collections.Generic;
using System.Text;

namespace Lalosoft.Common.Versioning
{
    public class UpdateCheckResult
    {
        private UpgradeDetailList _upgradeDetails;

        public UpgradeDetailList UpgradeDetails
        {
            get { return _upgradeDetails; }
            set { _upgradeDetails = value; }
        }
        private RegistrationInfo _registrationInfo;

        public RegistrationInfo Registration
        {
            get { return _registrationInfo; }
            set { _registrationInfo = value; }
        }

        public UpdateCheckResult(UpgradeDetailList upgradeDetails,
            RegistrationInfo registration)
        {
            _registrationInfo = registration;
            _upgradeDetails = upgradeDetails;
        }

        public UpdateCheckResult()
        {
           
        }

    }
}
