using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Relativity.Test.Helpers;
using Relativity.Test.Helpers.Objects;
using Relativity.Test.Helpers.Configuration.Models;
using Relativity.Test.Helpers.Configuration;

namespace Relativity.Test.Helpers.Example
{
	[TestFixture]
	public class GlobalSetup
	{
		public ConfigurationModel LocalConfig;
		public TestHelper TestHelper;
		public ObjectHelper ObjectHelper;

		public int ClientID;
		public int MatterID;
		public int AgentID;

		public string ClientName = "Example Client";
		public string MatterName = "Example Matter";
		public string AgentName = "Case Manager";
		public string ApplicationName = "Test App";

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			Initialize();
			CreateWorkspace();
			InstallApplication();
			CreateAgent();
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			DeleteWorkspace();
			DeleteAgent();
		}

		public void Initialize()
		{
			LocalConfig = ConfigurationFactory.ReadConfigFromAppSettings();
			TestHelper = new TestHelper(LocalConfig);
			ObjectHelper = ObjectFactory.ObjectHelperInstance(TestHelper);
		}

		#region Workspace
		
		public void CreateWorkspace()
		{
			ClientID = ObjectHelper.Client.Create(ClientName);
			MatterID = ObjectHelper.Matter.Create(MatterName, ClientID);
			var templateWorkspaceDto = ObjectHelper.Workspace.ReadTemplateWorkspace();
			LocalConfig.WorkspaceID = ObjectHelper.Workspace.Create(LocalConfig.WorkspaceName, ClientID, MatterID, templateWorkspaceDto);
		}

		public void DeleteWorkspace()
		{
			bool success = ObjectHelper.Workspace.Delete(LocalConfig.WorkspaceID);
			ObjectHelper.Matter.Delete(MatterID);
			ObjectHelper.Client.Delete(ClientID);
		}

		#endregion Workspace

		#region Application

		public void InstallApplication()
		{
			ObjectHelper.Application.Import(LocalConfig.WorkspaceID, true, LocalConfig.ApplicationRAPPath, ApplicationName);
		}

		#endregion Application

		#region Agent

		public void CreateAgent()
		{
			var agentTypeResponse = ObjectHelper.Agent.ReadAgentTypeByName(AgentName);
			var agentServerResponse = ObjectHelper.Agent.ReadAgentServerByAgentType(agentTypeResponse.ArtifactID);
			AgentID = ObjectHelper.Agent.Create(agentTypeResponse.ArtifactID, agentServerResponse.ArtifactID);
		}

		public void DeleteAgent()
		{
			ObjectHelper.Agent.Delete(AgentID);
		}

		#endregion Agent
	}
}
