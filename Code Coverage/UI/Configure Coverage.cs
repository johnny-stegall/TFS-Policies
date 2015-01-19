using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFS.Policies.UI
{
  public partial class ConfigureCoverage : Form
  {
    #region Public Properties
    /// <summary>
    /// Gets/sets the required percentage of code that must be covered by unit
    /// tests.
    /// </summary>
    public int CoverageThreshold
    {
      get
      {
        return (int)nudCoverage.Value;
      }
      set
      {
        nudCoverage.Value = value;
      }
    }
    #endregion

    #region Constructors
    /// <summary>
    /// Creates an empty instance of the object.
    /// </summary>
    public ConfigureCoverage()
    {
      InitializeComponent();
    }
    #endregion
  }
}
