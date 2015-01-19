using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFS.Policies.Models
{
  [Serializable]
  public class RequiredReview
  {
    #region Public Properties
    /// <summary>
    /// Gets/sets the TFS ID.
    /// </summary>
    public Guid Id
    {
      get;
      set;
    }

    /// <summary>
    /// Gets/sets the group name.
    /// </summary>
    public string Name
    {
      get;
      set;
    }

    /// <summary>
    /// Gets/sets the number of required code reviews.
    /// </summary>
    public byte Reviews
    {
      get;
      set;
    }
    #endregion
  }
}
