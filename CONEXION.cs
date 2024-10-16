using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;
using System.Configuration;

namespace rfcBaika
{
    public class CONEXION
    {
    }
    public static class GET_DESTINO
    {
        public static RfcCustomDestination mydestination(string user, string pass)
        {
            //"DEV" is the name of the destination in the web.config
            RfcDestination rfcDest = RfcDestinationManager.GetDestination("DDC");

            RfcCustomDestination _customDestination = rfcDest.CreateCustomDestination();
            _customDestination.User = user;

            _customDestination.Password = pass;

            return _customDestination;
        }

        public static RfcDestination pingWithSAPUserLogon(string un, string pw)
        {
            RfcDestination result = null;
            try
            {
                if (!(RfcDestinationManager.DestinationMonitors.Count > 0))
                {
                    RfcDestinationManager.RegisterDestinationConfiguration(new SAPConfig());
                }
                RfcDestination destFinal = null;
                RfcDestination destTest = RfcDestinationManager.GetDestination("DDC");

                RfcCustomDestination destCust = destTest.CreateCustomDestination();
                destCust.User = un;
                destCust.Password = pw;

                destFinal = destCust;

                destFinal.Ping();

                return destFinal;
            }
            catch (Exception ex)
            {
                // Log Exception                          }

                return result;
            }
        }
    }

    public class SAPConfig : IDestinationConfiguration
    {
        private string SAP_username = "";
        private string SAP_password = "";
        public SAPConfig()
        {

        }
        public bool ChangeEventsSupported()
        {
            return false;
        }

        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        public RfcConfigParameters GetParameters(string destinationName)
        {
            RfcConfigParameters parms = new RfcConfigParameters();

            if (destinationName.Equals("DDC"))
            {
                parms.Add(RfcConfigParameters.AppServerHost, ConfigurationManager.AppSettings["SAP_HOST"]); //"10.20.1.120"); 
                parms.Add(RfcConfigParameters.SystemNumber, ConfigurationManager.AppSettings["SAP_SYSTEMNUMBER"]); //"00");
                //parms.Add(RfcConfigParameters.SystemID, "ABC");
                parms.Add(RfcConfigParameters.Client, ConfigurationManager.AppSettings["SAP_CLIENT"]); //"120");
                parms.Add(RfcConfigParameters.Language, ConfigurationManager.AppSettings["SAP_IDIOMA"]); //"ES");
                parms.Add(RfcConfigParameters.PoolSize, ConfigurationManager.AppSettings["SAP_POOL_SIZE"]); //"20");
            }
            return parms;
        }
    }
}