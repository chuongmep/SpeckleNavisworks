using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using Speckle.Core.Api;
using Speckle.Core.Credentials;
using SpeckleCore;
using Account = SpeckleCore.Account;

namespace SpeckleNavisworks
{
    [PluginAttribute(
        "SpeckleCreateStreamNavisworks",
        "C5590956-6D30-4B50-8105-E6E346F3140E",
        ToolTip = "Connection to Speckle",
        DisplayName = "Speckle Navisworks")]
    public class CreateNewSpeckleStream : AddInPlugin
    {
        private static Speckle.Core.Credentials.Account defaultAccount;
        private static SpeckleApiClient client;

        public override int Execute(params string[] parameters)
        {
            SpeckleCore.SpeckleInitializer.Initialize();

            Models.NavisworksWrapper.Document = Autodesk.Navisworks.Api.Application.ActiveDocument;
            Models.NavisworksWrapper.DocumentGUID = SpeckleCore.Converter.getMd5Hash(Autodesk.Navisworks.Api.Application.ActiveDocument.FileName);

            try
            {
                defaultAccount = AccountManager.GetDefaultAccount();
            }
            catch (Exception ex)
            {
                //TODO
                MessageBox.Show(ex.ToString());
                // List<Account> accounts = LocalContext.GetAccountsByEmail("julian.bolliger@mum.ch");
                // account = accounts.FirstOrDefault();
            }
            var client = new Client(defaultAccount);

            Models.StreamController.Client = client;

            var mainWindow = new Views.MainWindow();
            mainWindow.ShowDialog();

            return 0;
        }
    }
}
