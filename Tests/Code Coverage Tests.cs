using System;
using System.IO;
using EnvDTE;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TFS.Policies;

namespace TFS.Policies.Tests
{
  [TestClass]
  public class CodeCoverageTests
  {
    #region Variable Declarations
    private const string RELATIVE_PROJECT_PATH = @"TFS Policies\Tests";
    private const string TEST_RESULTS_FOLDER = "TestResults";
    private string _projectPath;
    private _DTE _visualStudio;
    #endregion

    #region Test Initialization
    [TestInitialize]
    public void InitializeVisualStudio()
    {
      var visualStudioType = System.Type.GetTypeFromProgID("VisualStudio.DTE.12.0", true);
      var visualStudioInstance = Activator.CreateInstance(visualStudioType, true);
      _visualStudio = visualStudioInstance as _DTE;

      _projectPath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf(RELATIVE_PROJECT_PATH) + RELATIVE_PROJECT_PATH.Length);
    }
    #endregion

    [TestMethod]
    public void GetTestResultsPath()
    {
      // Arrange
      _visualStudio.Solution.Open(_projectPath + @"\Tests.sln");

      string solutionPath = Path.GetDirectoryName(_visualStudio.Solution.FullName);
      var testResultsPath = Path.Combine(solutionPath, TEST_RESULTS_FOLDER);
      var expectedResults = @"C:\Projects\TFS Policies\Tests\TestResults\4ce7f082-f763-4e63-bf41-2f03bdb6dd8f";

      var coverageVerifier = new PrivateObject(new CodeCoverage());

      // Act
      string testResults = coverageVerifier.Invoke("GetTestResultsPath", solutionPath) as string;

      // Assert
      Assert.AreEqual(expectedResults, testResults);
    }

    [TestMethod]
    public void GetCodeCoverageFile()
    {
      // Arrange
      _visualStudio.Solution.Open(_projectPath + @"\Tests.sln");

      string solutionPath = Path.GetDirectoryName(_visualStudio.Solution.FullName);
      var testResultsPath = Path.Combine(solutionPath, TEST_RESULTS_FOLDER);
      var expectedResults = @"C:\Projects\TFS Policies\Tests\TestResults\4ce7f082-f763-4e63-bf41-2f03bdb6dd8f\Tests 2015-02-02 13_17_33.coverage";

      var coverageVerifier = new PrivateObject(new CodeCoverage());

      // Act
      string testResults = coverageVerifier.Invoke("GetCodeCoverageFile", testResultsPath) as string;

      // Assert
      Assert.AreEqual(expectedResults, testResults);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void NoVisualStudio()
    {
      // Act
      var coverageVerifier = new CodeCoverage();
    }

    [TestMethod]
    public void NoCoverageFile()
    {
      // Arrange
      _visualStudio.Solution.Open(_projectPath + @"\Tests.sln");

      string solutionPath = Path.GetDirectoryName(_visualStudio.Solution.FullName);
      var testResultsPath = Path.Combine(_projectPath, TEST_RESULTS_FOLDER, "5ac0ce71-c8b0-4791-96b8-64c4a56ecf14");

      var coverageVerifier = new PrivateObject(new CodeCoverage());

      // Act
      string testResults = coverageVerifier.Invoke("GetCodeCoverageFile", testResultsPath) as string;

      // Assert
      Assert.IsNull(testResults);
    }

    [TestMethod]
    [ExpectedException(typeof(NotSupportedException))]
    public void MultipleCoverageFiles()
    {
      _visualStudio.Solution.Open(_projectPath + @"\Tests.sln");

      string solutionPath = Path.GetDirectoryName(_visualStudio.Solution.FullName);
      var testResultsPath = Path.Combine(_projectPath, TEST_RESULTS_FOLDER, "6667f082-f763-4791-96b8-64c4a56ecf14");

      var coverageVerifier = new PrivateObject(new CodeCoverage());

      // Act
      string testResults = coverageVerifier.Invoke("GetCodeCoverageFile", testResultsPath) as string;
    }

    [TestMethod]
    public void CalculateCoverage()
    {
      // Arrange
      _visualStudio.Solution.Open(_projectPath + @"\Tests.sln");

      string solutionPath = Path.GetDirectoryName(_visualStudio.Solution.FullName);
      var testResultsPath = Path.Combine(solutionPath, TEST_RESULTS_FOLDER, "4ce7f082-f763-4e63-bf41-2f03bdb6dd8f");

      var coverageVerifier = new PrivateObject(new CodeCoverage());
      string testResults = coverageVerifier.Invoke("GetCodeCoverageFile", testResultsPath) as string;

      // Act
      double codeCoverage = (double)coverageVerifier.Invoke("CalculateTotalCoverage", testResults);

      // Assert
      Assert.AreEqual(96.42223536369012, codeCoverage);
    }
  }
}
