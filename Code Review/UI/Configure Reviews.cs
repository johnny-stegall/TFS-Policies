using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TFS.Policies.Models;

namespace TFS.Policies.UI
{
  public partial class ConfigureReviews : Form
  {
    #region Variable Declarations
    private List<RequiredReview> _codeReviews = new List<RequiredReview>();
    #endregion

    #region Public Properties
    /// <summary>
    /// Gets/sets the groups in the project and the number of code reviews
    /// required by that group.
    /// </summary>
    public List<RequiredReview> RequiredCodeReviews
    {
      get
      {
        return _codeReviews;
      }
      set
      {
        _codeReviews = value;
        BindGrid();
      }
    }
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance with default values.
    /// </summary>
    public ConfigureReviews()
    {
      InitializeComponent();
    }
    #endregion

    #region Events
    /// <summary>
    /// Ensures that users enter numeric characters only in the second column.
    /// </summary>
    private void gvCodeReviews_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex != 1 || e.RowIndex < 0)
        return;

      var dirtyCell = gvCodeReviews.Rows[e.RowIndex].Cells[e.ColumnIndex];

      byte enteredValue = 0;
      if (byte.TryParse(dirtyCell.Value.ToString(), out enteredValue))
      {
        this.RequiredCodeReviews[e.RowIndex].Reviews = enteredValue;
        return;
      }

      MessageBox.Show(string.Format("Code reviews cannot be done {0} times.", dirtyCell.Value));
      dirtyCell.Value = 0;
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Manually binds the <see cref="DataGridView" />.
    /// </summary>
    /// <remarks>
    /// Manually binding is necessary because there appears to be a bug with
    /// Visual Studio or TFS such that when letting the framework handle the
    /// databinding, user's can only scroll the <see cref="DataGridView " />.
    /// Any click or keypresses cause the dialog to be destroyed.
    /// </remarks>
    private void BindGrid()
    {
      gvCodeReviews.Rows.Clear();

      foreach (var review in this.RequiredCodeReviews)
      {
        var newRow = new DataGridViewRow();
        newRow.Cells.AddRange(new DataGridViewTextBoxCell[]
        {
          new DataGridViewTextBoxCell
          {
            Value = review.Name
          },
          new DataGridViewTextBoxCell
          {
            Value = review.Reviews
          },
        });

        gvCodeReviews.Rows.Add(newRow);
      }
    }
    #endregion
  }
}
