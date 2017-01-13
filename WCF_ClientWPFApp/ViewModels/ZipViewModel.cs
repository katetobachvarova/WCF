using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WCF_Proxies;

namespace WCF_ClientWPFApp.ViewModels
{
    public class ZipViewModel : BindableBase
    {
        private string zipCode;

        public string ZipCode
        {
            get { return zipCode; }
            set { SetProperty(ref zipCode, value); }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { SetProperty(ref city, value); }
        }

        private GeoProxy proxy;

        public ZipViewModel()
        {
            proxy = new GeoProxy();
        }

        public ICommand GetStateTextCommand
        {
            get { return new DelegateCommand(GetStateText); }
        }

        private void GetStateText()
        {
            if (ZipCode != "")
            {
                try
                {
                    //proxy.ClientCredentials.Windows.ClientCredential.UserName = "wcfUser";
                    //proxy.ClientCredentials.Windows.ClientCredential.Password = "dotnet";

                    //GeoProxy proxy = new GeoProxy();
                    City = proxy.GetCity(ZipCode);
                    //proxy.Close();
                }
                catch (FaultException<ExceptionDetail> ex)
                {
                    MessageBox.Show("Exception thrown by service.\n\rException type: " +
                        "FaultException<ExceptionDetail>\n\r" +
                        "Message: " + ex.Detail.Message + "\n\r" +
                        "Proxy state: " + proxy.State.ToString());
                }
                catch (FaultException<ApplicationException> ex)
                {
                    MessageBox.Show("Exception thrown by service.\n\rException type: " +
                        "FaultException<ApplicationException>\n\r" +
                        "Reason: " + ex.Message + "\n\r" +
                        "Message: " + ex.Detail.Message + "\n\r" +
                        "Proxy state: " + proxy.State.ToString());
                }
                catch (FaultException<ArgumentException> ex)
                {
                    MessageBox.Show("Exception thrown by service.\n\rException type: " +
                        "FaultException<ArgumentException>\n\r" +
                        "Reason: " + ex.Message + "\n\r" +
                        "Message: " + ex.Detail.Message + "\n\r" +
                        "Proxy state: " + proxy.State.ToString());
                }
                catch (FaultException ex)
                {
                    MessageBox.Show("FaultException thrown by service.\n\rException type: " +
                        ex.GetType().Name + "\n\r" +
                        "Message: " + ex.Message + " \n\r" +
                        "Proxy state: " + proxy.State.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception thrown by service.\n\rException type: " +
                        ex.GetType().Name + "\n\r" +
                        "Message: " + ex.Message + "\n\r" +
                        "Proxy state: " + proxy.State.ToString());
                }

            }
        }

    }
}
