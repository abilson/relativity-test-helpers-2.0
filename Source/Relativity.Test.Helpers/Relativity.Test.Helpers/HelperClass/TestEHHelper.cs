﻿using Relativity.API;
using System;

namespace Relativity.Test.Helpers.HelperClasses
{
	public class TestEHHelper : IEHHelper
	{

		//private readonly ConfigurationModel _configs;
		public int WorkspaceID { get; set; }
		public string AdminUsername { get; set; }
		public string AdminPassword { get; set; }
		private string SQLServerAddress { get; set; }
		private string SQLUserName { get; set; }
		private string SQLPassword { get; set; }
		private string SolutionSnapshotRAPUrl { get; set; }
		private string ServerHostName { get; set; }
		private string ServerHostBinding { get; set; }
		private string RAPFilesDirectory { get; set; }

		private IHelper _helper;

		public TestEHHelper(string username, string password)
		{
			AdminUsername = username;
			AdminPassword = password;
			_helper = new TestHelper(username, password);
		}

		public TestEHHelper(string configSectionName)
		{
			_helper = new TestHelper(configSectionName);
		}

		public int GetActiveCaseID()
		{
			return WorkspaceID;
		}

		public IAuthenticationMgr GetAuthenticationManager()
		{
			throw new NotImplementedException();
		}

		public IDBContext GetDBContext(int caseID)
		{
			return _helper.GetDBContext(caseID);
		}

		public Guid GetGuid(int workspaceID, int artifactID)
		{
			return _helper.GetGuid(workspaceID, artifactID);
		}

		public IInstanceSettingsBundle GetInstanceSettingBundle()
		{
			return _helper.GetInstanceSettingBundle();
		}

		public ILogFactory GetLoggerFactory()
		{
			return _helper.GetLoggerFactory();
		}

		public string GetSchemalessResourceDataBasePrepend(IDBContext context)
		{
			return _helper.GetSchemalessResourceDataBasePrepend(context);
		}

		public ISecretStore GetSecretStore()
		{
			return _helper.GetSecretStore();
		}

		public IServicesMgr GetServicesManager()
		{
			return _helper.GetServicesManager();
		}

		public IUrlHelper GetUrlHelper()
		{
			return _helper.GetUrlHelper();
		}

		public string ResourceDBPrepend()
		{
			return _helper.ResourceDBPrepend();
		}

		public string ResourceDBPrepend(IDBContext context)
		{
			return _helper.ResourceDBPrepend(context);
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
					_helper.Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.
				_helper = null;

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~TestEHHelper() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}

		public IStringSanitizer GetStringSanitizer(int workspaceID)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
