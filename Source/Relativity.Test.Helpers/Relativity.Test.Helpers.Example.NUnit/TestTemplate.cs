﻿using kCura.Relativity.Client;
using NUnit.Framework;
using Relativity.API;
using Relativity.Test.Helpers.Configuration;
using Relativity.Test.Helpers.Configuration.Models;
using Relativity.Test.Helpers.Import;
using Relativity.Test.Helpers.Objects.Folder;
using Relativity.Test.Helpers.Objects.Group;
using Relativity.Test.Helpers.Objects.User;
using Relativity.Test.Helpers.Objects.Workspace;
using Relativity.Test.Helpers.ServiceFactory.Extentions;
using System;
using System.IO;
using System.Reflection;
//using IServicesMgr = Relativity.Test.Helpers.Interface.IServicesMgr;
using IServicesMgr = Relativity.API.IServicesMgr;

namespace Relativity.Test.Helpers.Example.NUnit
{
	/*
	/// <summary>
	/// 
	/// Relativity Integration Test Helpers to assist you with writing good Integration Tests for your application. You can use this framework to test event handlers, agents and any workflow that combines agents and frameworks.
	/// 
	/// Before you get Started, fill out details for the following the app.config file
	/// "WorkspaceID", "RSAPIServerAddress", "RESTServerAddress",	"AdminUsername","AdminPassword", "SQLServerAddress" ,"SQLUsername","SQLPassword" "TestWorkspaceName"
	/// 
	/// </summary>

	[TestFixture, global::NUnit.Framework.Description("Fixture description here")]
	public class TestTemplate
	{

		#region Variables
		private IRSAPIClient _client;
		private int _workspaceId;
		private Int32 _rootFolderArtifactID;
		private string _workspaceName = $"IntTest_{Guid.NewGuid()}";
		private const ExecutionIdentity EXECUTION_IDENTITY = ExecutionIdentity.CurrentUser;
		private IDBContext dbContext;
		private IServicesMgr servicesManager;
		private IDBContext _eddsDbContext;
		private Int32 _numberOfDocuments = 5;
		private string _foldername = "Test Folder";
		private string _groupName = "Test Group";
		private int _userArtifactId;
		private int _groupArtifactId;
		private int _fixedLengthArtId;
		private int _longtextartid;
		private int _yesnoartid;
		private int _wholeNumberArtId;
		private ConfigurationModel _configs;

		#endregion


		#region TestfixtureSetup

		[TestFixtureSetUp]
		public void Execute_TestFixtureSetup()
		{
			//Setup for testing		
			_configs = ConfigurationFactory.ReadConfigFromAppSettings();
			var helper = new TestHelper(_configs);
			servicesManager = helper.GetServicesManager();
			_eddsDbContext = helper.GetDBContext(-1);

			// implement_IHelper
			//create client
			_client = helper.GetServicesManager().GetProxy<IRSAPIClient>(new Configuration.Models.ConfigurationModel());

			//Create new user 
			_userArtifactId = CreateUser.CreateNewUser(_client);

			//Create new group
			CreateGroup.Create_Group(_client, _groupName);


			//Create workspace
			_workspaceId = CreateWorkspace.CreateWorkspaceAsync(_workspaceName, _configs.WorkspaceTemplateName, servicesManager, _configs.AdminUsername, _configs.AdminPassword).Result;
			dbContext = helper.GetDBContext(_workspaceId);
			_client.APIOptions.WorkspaceID = _workspaceId;
			var executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			var nativeFilePath = "";
			var nativeName = @"\\\\FakeFilePath\Natives\SampleTextFile.txt"; ;
			if (executableLocation != null)
			{
				nativeFilePath = Path.Combine(executableLocation, nativeName);
			}
			var importAPIHelper = new ImportAPIHelper(_configs);
			//Create Documents with a given folder name
			importAPIHelper.CreateDocumentswithFolderName(_workspaceId, _numberOfDocuments, _foldername, nativeFilePath);

			//Create Documents with a given folder artifact id
			var folderName = new FolderHelper().GetFolderName(_rootFolderArtifactID, dbContext);
			importAPIHelper.CreateDocumentswithFolderName(_workspaceId, _numberOfDocuments, folderName, nativeFilePath);

			//Create Fixed Length field
			_fixedLengthArtId = Fields.FieldHelper.CreateField_FixedLengthText(_client, _workspaceId);

			//Create Long Text Field
			_longtextartid = Fields.FieldHelper.CreateField_LongText(_client, _workspaceId);

			//Create Whole number field
			_wholeNumberArtId = Fields.FieldHelper.CreateField_WholeNumber(_client, _workspaceId);

			//Create Yes/no field

			//Create Single Choice fields

			//Create Multiple Choice fields

		}

		#endregion

		#region TestfixtureTeardown


		[TestFixtureTearDown]
		public void Execute_TestFixtureTeardown()
		{
			//Delete Workspace
			DeleteWorkspace.DeleteTestWorkspace(_workspaceId, servicesManager, _configs.AdminUsername, _configs.AdminPassword);

			//Delete User
			DeleteUser.Delete_User(_client, _userArtifactId);

			//Delete Group
			DeleteGroup.Delete_Group(_client, _groupArtifactId);
		}


		#endregion

		#region region Golden Flow

		[Test, global::NUnit.Framework.Description("Test description here")]
		public void Integration_Test_Golden_Flow_Valid()
		{
			//Example for Arrange, Act, Assert

			//Arrange
			//CreateEmptyFolders();
			//countBeforeExecute = SQLHelper.GetFolderCount(_workspaceId);

			////Act
			//_Executeresult = TestHelpers.Execute.ExecuteRelativityScriptByNameThroughRsapi("Delete Empty Case Folders", _workspaceId);

			////Assert
			//Assert.AreEqual(_Executeresult, "Empty folders deleted with no errors.");
			//countAfterExecute = SQLHelper.GetFolderCount(_workspaceId);
			//Assert.AreEqual(countAfterExecute, 0);
			//Assert.AreNotEqual(countBeforeExecute, countAfterExecute);

		}

		#endregion

	}
	*/
}
