using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation;
using TFS.Policies.Models;
using TFS.Policies.UI;

namespace TFS.Policies
{
  [Serializable]
  public class CodeReview : PolicyBase
  {
    #region Variable Declarations
    private List<RequiredReview> _requiredCodeReviews;

    [NonSerialized]
    private IIdentityManagementService _identityManagement;
    #endregion

    #region PolicyBase Properties
    public override bool CanEdit
    {
      get
      {
        return true;
      }
    }

    public override string Description
    {
      get
      {
        return "Requires code to be reviewed before being checked-in.";
      }
    }

    public override string InstallationInstructions
    {
      get
      {
        return "Execute install.cmd";
      }
    }

    public override string Type
    {
      get
      {
        return "Code Review Policy";
      }
    }

    public override string TypeDescription
    {
      get
      {
        return this.Description;
      }
    }
    #endregion Properties

    #region PolicyBase Methods
    public override bool Edit(IPolicyEditArgs policyEditArgs)
    {
      if (policyEditArgs == null)
        throw new ArgumentNullException("policyEditArgs");

      using (var dialog = new ConfigureReviews())
      {
        GetProjectGroups(policyEditArgs.TeamProject);

        // Add to the list so changes don't effect live settings and so the
        // data binding doesn't get interrupted
        dialog.RequiredCodeReviews = _requiredCodeReviews.ToList();

        if (dialog.ShowDialog(policyEditArgs.Parent) == DialogResult.OK)
        {
          _requiredCodeReviews = dialog.RequiredCodeReviews.ToList();
          return true;
        }
        else
          return false;
      }
    }

    public override PolicyFailure[] Evaluate()
    {
      var failures = new List<PolicyFailure>();

      var codeReviewRequests = this.PendingCheckin.WorkItems.CheckedWorkItems
        .Where(wi => wi.WorkItem.Type.Name == "Code Review Response");

      if (!codeReviewRequests.Any())
        failures.Add(new PolicyFailure("There are no code reviews associated with this check in.", this));
      else if (codeReviewRequests.Count() < _requiredCodeReviews.Sum(kvp => kvp.Reviews))
        failures.Add(new PolicyFailure("You haven't requested all required code reviews.", this));
      else if (codeReviewRequests.Any(wi => wi.WorkItem.Fields["Assigned To"].Value.ToString() == wi.WorkItem.CreatedBy))
        failures.Add(new PolicyFailure("You can't review your code.", this));

      var codeReviewResponses = this.PendingCheckin.WorkItems.CheckedWorkItems
        .Where(wi => wi.WorkItem.Type.Name == "Code Review Response");

      if (codeReviewResponses.Any(wi => wi.WorkItem.State != "Closed"))
        failures.Add(new PolicyFailure("There are outstanding code reviews.", this));

      var approvedStatuses = new string[] { "Looks Good", "With Comments" };
      foreach (var reviewGroup in _requiredCodeReviews)
      {
        var tfsGroup = new IdentityDescriptor("Group", reviewGroup.Name);

        if (codeReviewResponses.Any(wi => wi.WorkItem.State == "Closed"
         && _identityManagement.IsMember(tfsGroup, new IdentityDescriptor("Member", wi.WorkItem.Fields["Reviewed By"].Value.ToString()))
         && approvedStatuses.Contains(wi.WorkItem.Fields["Closed Status Code"].Value)))
          failures.Add(new PolicyFailure(string.Format("Not all code reviews by {0} are approved.", reviewGroup.Name), this));
      }

      return failures.ToArray();
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Gets the groups that belong to the TFS project.
    /// </summary>
    /// <param name="tfsProject">The TFS project.</param>
    private void GetProjectGroups(TeamProject tfsProject)
    {
      if (_identityManagement == null)
        _identityManagement = tfsProject.TeamProjectCollection.GetService<IIdentityManagementService>();

      if (_requiredCodeReviews == null)
      {
        _requiredCodeReviews = _identityManagement.ListApplicationGroups(tfsProject.ArtifactUri.ToString(), ReadIdentityOptions.None)
          .Select(r => new RequiredReview
          {
            Id = r.TeamFoundationId,
            Name = r.DisplayName,
            Reviews = 0
          })
          .ToList();
      }
    }
    #endregion
  }
}
