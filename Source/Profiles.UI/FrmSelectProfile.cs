using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lalosoft.Profiles.Common.InfoObjects;
using Lalosoft.Profiles.Common.DataObjects;
using Lalosoft.Profiles.Common;

namespace Lalosoft.Profiles.UI
{
  public partial class FrmSelectProfile : Form
  {
    public FrmSelectProfile()
    {
      InitializeComponent();
    }


    ProfileInfo _selectedProfile=null;
    ProfileList _profiles = null;

    bool _newProfile = false;
    bool _alwaysUse = false;
    private void btnCancel_Click(object sender, EventArgs e)
    {
      _selectedProfile = null;
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (cboProfile.SelectedItem == null)
      {
        MessageBox.Show(this, "Invlid Profile Selected, hit new to Create a new profile");
        return;
      }
      _alwaysUse = chkAlwaysUseThisProfile.Checked;
      _selectedProfile = (ProfileInfo)cboProfile.SelectedItem;
      this.DialogResult = System.Windows.Forms.DialogResult.OK;

    }

    private void FrmSelectProfile_Load(object sender, EventArgs e)
    {

      bsProfiles.DataSource =_profiles= ProfileManager.Instance.GetProfiles();
      bsProfiles.ResetBindings(false);
      cboProfile.SelectedIndex = 0;
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
      string newProfileName = cboProfile.Text;
      if (_profiles.Any<ProfileInfo>(a => a.Name.Equals(newProfileName, StringComparison.CurrentCultureIgnoreCase)))
      {
        MessageBox.Show(this, "Profile Already Exists");
        return;
      }
      _alwaysUse = chkAlwaysUseThisProfile.Checked;
      _selectedProfile = new ProfileInfo() { Name = newProfileName };
      _newProfile = true;
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    public Lalosoft.Profiles.Common.InfoObjects.ProfileInfo SelectedProfile
    {
      get { return this._selectedProfile; }
      set { this._selectedProfile = value; }
    }

    public Lalosoft.Profiles.Common.DataObjects.ProfileList Profiles
    {
      get { return this._profiles; }
      set { this._profiles = value; }
    }

    public bool NewProfile
    {
      get { return this._newProfile; }
      set { this._newProfile = value; }
    }

    public bool AlwaysUse
    {
      get { return this._alwaysUse; }
      set { this._alwaysUse = value; }
    }

    
  }
}
