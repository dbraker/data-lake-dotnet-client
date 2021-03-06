using System.Collections.Generic;
using Microsoft.Azure.Management.DataLake.Analytics;
using MSADLA=Microsoft.Azure.Management.DataLake.Analytics;
using MSODATA = Microsoft.Rest.Azure.OData;

namespace AdlClient.Rest
{
    public class AnalyticsCatalogRestWrapper
    {
        public readonly MSADLA.DataLakeAnalyticsCatalogManagementClient RestClient;

        public AnalyticsCatalogRestWrapper(Microsoft.Rest.ServiceClientCredentials creds)
        {
            this.RestClient = new MSADLA.DataLakeAnalyticsCatalogManagementClient(creds);
        }

        public MSADLA.Models.USqlDatabase GetDatabase(AdlClient.Models.AnalyticsAccountRef account, string name)
        {
            var db = this.RestClient.Catalog.GetDatabase(account.Name, name);
            return db;
        }

        public IEnumerable<MSADLA.Models.USqlDatabase> ListDatabases(AdlClient.Models.AnalyticsAccountRef account)
        {
            var oDataQuery = new MSODATA.ODataQuery<MSADLA.Models.USqlDatabase>();

            string select_cols = null;
            bool? count = null;

            var page = this.RestClient.Catalog.ListDatabases(account.Name, oDataQuery, select_cols, count);
            foreach (var db in RestUtil.EnumItemsInPages(page, p => this.RestClient.Catalog.ListDatabasesNext(p.NextPageLink)))
            {
                yield return db;
            }
        }

        public IEnumerable<MSADLA.Models.USqlAssemblyClr> ListAssemblies(AdlClient.Models.AnalyticsAccountRef account, string dbname)
        {
            var oDataQuery = new MSODATA.ODataQuery<MSADLA.Models.USqlAssembly>();

            string select_cols = null;
            bool? count = null;

            var page = this.RestClient.Catalog.ListAssemblies(account.Name, dbname, oDataQuery, select_cols, count);
            foreach (var asm in RestUtil.EnumItemsInPages(page, p => this.RestClient.Catalog.ListAssembliesNext(p.NextPageLink)))
            {
                yield return asm;
            }
        }

        public IEnumerable<MSADLA.Models.USqlExternalDataSource> ListExternalDatasources(AdlClient.Models.AnalyticsAccountRef account, string dbname)
        {
            var oDataQuery = new MSODATA.ODataQuery<MSADLA.Models.USqlExternalDataSource>();

            string select_cols = null;
            bool? count = null;

            var page = this.RestClient.Catalog.ListExternalDataSources(account.Name, dbname, oDataQuery, select_cols, count);
            foreach (var ds in RestUtil.EnumItemsInPages(page, p => this.RestClient.Catalog.ListExternalDataSourcesNext(p.NextPageLink)))
            {
                yield return ds;
            }
        }

        public IEnumerable<MSADLA.Models.USqlProcedure> ListProcedures(AdlClient.Models.AnalyticsAccountRef account, string dbname, string schema)
        {
            var oDataQuery = new MSODATA.ODataQuery<MSADLA.Models.USqlProcedure>();

            string select_cols = null;
            bool? count = null;

            var page = this.RestClient.Catalog.ListProcedures(account.Name, dbname, schema, oDataQuery, select_cols, count);
            foreach (var proc in RestUtil.EnumItemsInPages(page, p => this.RestClient.Catalog.ListProceduresNext(p.NextPageLink)))
            {
                yield return proc;
            }
        }

        public IEnumerable<MSADLA.Models.USqlSchema> ListSchemas(AdlClient.Models.AnalyticsAccountRef account, string dbname)
        {
            var oDataQuery = new MSODATA.ODataQuery<MSADLA.Models.USqlSchema>();
            string select_cols = null;
            bool? count = null;

            var page = this.RestClient.Catalog.ListSchemas(account.Name, dbname, oDataQuery, select_cols, count);
            foreach (var schema in RestUtil.EnumItemsInPages(page, p => this.RestClient.Catalog.ListSchemasNext(p.NextPageLink)))
            {
                yield return schema;
            }
        }

        public IEnumerable<MSADLA.Models.USqlView> ListViews(AdlClient.Models.AnalyticsAccountRef account,string dbname, string schema)
        {
            var oDataQuery = new MSODATA.ODataQuery<MSADLA.Models.USqlView>();
            string select_cols = null;
            bool? count = null;


            var page = this.RestClient.Catalog.ListViews(account.Name, dbname, schema, oDataQuery, select_cols, count);
            foreach (var view in RestUtil.EnumItemsInPages(page, p => this.RestClient.Catalog.ListViewsNext(p.NextPageLink)))
            {
                yield return view;
            }
        }

        public IEnumerable<MSADLA.Models.USqlTable> ListTables(AdlClient.Models.AnalyticsAccountRef account, string dbname, string schema)
        {
            var oDataQuery = new MSODATA.ODataQuery<MSADLA.Models.USqlTable>();
            string select_cols = null;
            bool? count = null;

            var page = this.RestClient.Catalog.ListTables(account.Name, dbname, schema, oDataQuery, select_cols, count);
            foreach (var table in RestUtil.EnumItemsInPages(page, p => this.RestClient.Catalog.ListTablesNext(p.NextPageLink)))
            {
                yield return table;
            }
        }

        public IEnumerable<MSADLA.Models.USqlType> ListTypes(AdlClient.Models.AnalyticsAccountRef account, string dbname, string schema)
        {
            var oDataQuery = new MSODATA.ODataQuery<MSADLA.Models.USqlType>();
            string select_cols = null;
            bool? count = null;


            var page = this.RestClient.Catalog.ListTypes(account.Name, dbname, schema, oDataQuery, select_cols, count);
            foreach (var type in RestUtil.EnumItemsInPages(page, p => this.RestClient.Catalog.ListTypesNext(p.NextPageLink)))
            {
                yield return type;
            }
        }

        public IEnumerable<MSADLA.Models.USqlTableType> ListTableTypes(AdlClient.Models.AnalyticsAccountRef account, string dbname, string schema)
        {
            var oDataQuery = new MSODATA.ODataQuery<MSADLA.Models.USqlTableType>();
            string select_cols = null;
            bool? count = null;

            var page = this.RestClient.Catalog.ListTableTypes(account.Name, dbname, schema, oDataQuery, select_cols, count);
            foreach (var tabletype in RestUtil.EnumItemsInPages(page, p => this.RestClient.Catalog.ListTableTypesNext(p.NextPageLink)))
            {
                yield return tabletype;
            }
        }

        public IEnumerable<MSADLA.Models.USqlTablePartition> ListTablePartitions(AdlClient.Models.AnalyticsAccountRef account, string dbname, string schema, string tablename)
        {
            var oDataQuery = new MSODATA.ODataQuery<MSADLA.Models.USqlTableType>();

            var page = this.RestClient.Catalog.ListTablePartitions(account.Name, dbname, schema, tablename);
            foreach (var part in RestUtil.EnumItemsInPages(page, p => this.RestClient.Catalog.ListTablePartitionsNext(p.NextPageLink)))
            {
                yield return part;
            }
        }

        public IEnumerable<MSADLA.Models.USqlTableStatistics> ListTableStatistics(AdlClient.Models.AnalyticsAccountRef account, string dbname, string schema, string tablename)
        {
            var oDataQuery = new MSODATA.ODataQuery<MSADLA.Models.USqlTableType>();

            var page = this.RestClient.Catalog.ListTableStatistics(account.Name, dbname, schema, tablename);
            foreach (var stats in RestUtil.EnumItemsInPages(page, p => this.RestClient.Catalog.ListTableStatisticsNext(p.NextPageLink)))
            {
                yield return stats;
            }
        }

        public void CreateCredential(AdlClient.Models.AnalyticsAccountRef account, string dbname, string credname, MSADLA.Models.DataLakeAnalyticsCatalogCredentialCreateParameters create_parameters)
        {
            this.RestClient.Catalog.CreateCredential(account.Name, dbname, credname, create_parameters);
        }

        public void DeleteCredential(AdlClient.Models.AnalyticsAccountRef account, string dbname, string credname, MSADLA.Models.DataLakeAnalyticsCatalogCredentialDeleteParameters delete_parameters)
        {
            this.RestClient.Catalog.DeleteCredential(account.Name, dbname, credname);
        }

        public void UpdateCredential(AdlClient.Models.AnalyticsAccountRef account, string dbname, string credname, MSADLA.Models.DataLakeAnalyticsCatalogCredentialUpdateParameters update_parameters)
        {
            this.RestClient.Catalog.UpdateCredential(account.Name, dbname, credname, update_parameters);
        }

        public MSADLA.Models.USqlCredential GetCredential(AdlClient.Models.AnalyticsAccountRef account, string dbname, string credname)
        {
            return this.RestClient.Catalog.GetCredential(account.Name, dbname, credname);
        }

        public IEnumerable<MSADLA.Models.USqlCredential> ListCredential(AdlClient.Models.AnalyticsAccountRef account, string dbname)
        {
            var oDataQuery = new MSODATA.ODataQuery<MSADLA.Models.USqlCredential>();
            string select_cols = null;
            bool? count = null;

            var page = this.RestClient.Catalog.ListCredentials(account.Name, dbname, oDataQuery, select_cols, count);
            foreach (var cred in RestUtil.EnumItemsInPages(page, p => this.RestClient.Catalog.ListCredentialsNext(p.NextPageLink)))
            {
                yield return cred;
            }
        }

    }
}