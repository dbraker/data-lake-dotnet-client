using MSAZURERM = Microsoft.Azure.Management.ResourceManager;
using System.Collections.Generic;
using Microsoft.Azure.Management.ResourceManager; // Needed for extension methods

namespace AdlClient
{
    public class AzureClient: ClientBase
    {
        private readonly AdlClient.Rest.AnalyticsAccountManagmentRestWrapper _adlaAccountMgmtClientWrapper;
        private readonly AdlClient.Rest.StoreManagementRestWrapper _adls_account_mgmt_client;
        private MSAZURERM.ResourceManagementClient rmclient;

        public readonly Subscription Subscription;
        public readonly AnalyticsResourceCommands Analytics;
        public readonly StoreResourceCommands Store;

        public AzureClient(Subscription subscription, AdlClient.Authentication.AuthenticatedSession authSession) :
            base(authSession)
        {
            this.Subscription = subscription;
            this._adlaAccountMgmtClientWrapper = new AdlClient.Rest.AnalyticsAccountManagmentRestWrapper(subscription, authSession.Credentials);
            this._adls_account_mgmt_client = new AdlClient.Rest.StoreManagementRestWrapper(subscription, authSession.Credentials);

            this.Analytics = new AnalyticsResourceCommands(subscription, authSession, _adlaAccountMgmtClientWrapper);
            this.Store = new StoreResourceCommands(subscription,authSession,this._adls_account_mgmt_client);

            this.rmclient = new MSAZURERM.ResourceManagementClient(authSession.Credentials);
            this.rmclient.SubscriptionId = subscription.Id;
        }

        public IEnumerable<MSAZURERM.Models.ResourceGroup> ListResourceGroups()
        {
            var rgs = this.rmclient.ResourceGroups.List();
            foreach (var rg in rgs)
            {
                yield return rg;
            }
        }

    }
}