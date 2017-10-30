﻿using System;
using Relativity.API;
using Relativity.Test.Helpers.ServiceFactory;
using kCura.Relativity.Client;
// IHelper = Relativity.Test.Helpers.Interface.IHelper;
//using IServicesMgr = Relativity.Test.Helpers.Interface.IServicesMgr;

namespace Relativity.Test.Helpers
{
	public class TestHelper : IHelper
	{
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IDBContext GetDBContext(int caseID)
		{
			kCura.Data.RowDataGateway.Context context = new kCura.Data.RowDataGateway.Context(SharedTestHelpers.ConfigurationHelper.SQL_SERVER_ADDRESS, string.Format("EDDS{0}", caseID == -1 ? "" : caseID.ToString()), SharedTestHelpers.ConfigurationHelper.SQL_USER_NAME, SharedTestHelpers.ConfigurationHelper.SQL_PASSWORD);
			return new DBContext(context);
		}

		public Guid GetGuid(int workspaceID, int artifactID)
		{
			throw new NotImplementedException();
		}

		public ILogFactory GetLoggerFactory()
		{
			throw new NotImplementedException();
		}

		public string GetSchemalessResourceDataBasePrepend(IDBContext context)
		{
			throw new NotImplementedException();
		}

		public IServicesMgr GetServicesManager()
		{
			return new ServicesManager();
		}

		public IUrlHelper GetUrlHelper()
		{
            return new URLHelper();
		}

		public string ResourceDBPrepend()
		{
			throw new NotImplementedException();
		}

        public string ResourceDBPrepend(IDBContext context)
        {
            throw new NotImplementedException();
        }

        API.IServicesMgr IHelper.GetServicesManager()
        {
            Relativity.Test.Helpers.ServiceFactory.ServicesManager mgr = new ServicesManager();
            return mgr;

        }
    }


}
