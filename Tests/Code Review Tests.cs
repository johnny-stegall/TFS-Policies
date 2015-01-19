using System;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TFS.Policies;

namespace Tests
{
  [TestClass]
  public class CodeReviewTests
  {
    [TestMethod]
    public void GetProjectGroups()
    {
      // Arrange
      var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("https://cmr.wkglobal.com:8088/tfs/FS3"));
      tfs.Authenticate();

      var versionControl = tfs.GetService<VersionControlServer>();
      var sandboxProject = versionControl.TryGetTeamProject("TS3");

      var requireReviews = new PrivateObject(new CodeReview());
      
      // Act
      requireReviews.Invoke("GetProjectGroups", sandboxProject);

      // Assert - if no exceptions are thrown, pass the test
      Assert.IsTrue(true);
    }
  }
}
