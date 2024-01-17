using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ServiceAgent.Agents
{
    public class Middleware : IMiddleware
    {
        enum Commands
        {
            StartRead = 101,
            StopRead = 200
        }

        public bool StartRead(string checkpoint)
        {
            MiddlewareService.WebServiceHost sc = new MiddlewareService.WebServiceHost();
            sc.Url = "http://copperfield:28000/Middleware/Service";

            object[] obj = { };
            
            bool commandResult;
            bool resultSpecified;

            try
            {
                sc.SendCommand(checkpoint, "Read", true,  true, obj, out commandResult, out resultSpecified);

                if (resultSpecified)
                    return commandResult;

                //EventLogger.Instance.Info("Result: " + (resultSpecified ? commandResult.ToString() : "NOT resultSpecified"));
            }
            catch (Exception ex)
            {
                
            }


            return false;
        }
        public bool StopRead(string checkpoint)
        {
            MiddlewareService.WebServiceHost sc = new MiddlewareService.WebServiceHost();
            sc.Url = "http://copperfield:28000/Middleware/Service";

            object[] obj = { };

            bool commandResult;
            bool resultSpecified;

            try
            {
                sc.SendCommand(checkpoint, "Read", false, true, obj, out commandResult, out resultSpecified);

                if (resultSpecified)
                    return commandResult;

                //EventLogger.Instance.Info("Result: " + (resultSpecified ? commandResult.ToString() : "NOT resultSpecified"));
            }
            catch (Exception ex)
            {

            }


            return false;
        }
        //private int SendCommand(string cp, MdwCommand command)
        //{
        //    Middleware.WebServiceMessenger msgr = new Middleware.WebServiceMessenger();

        //    string ip = BusinessManager.GetCheckpointIpByCode(cp);

        //    msgr.Url = "http://" + ip + ":20000/Middleware/ServiceCommunication";

        //    object[] obj = { };
        //    int commandResult;
        //    bool resultSpecified;

        //    try
        //    {
        //        msgr.SendCommand("", cp, (int)command, true, obj, out commandResult, out resultSpecified);

        //        if (resultSpecified)
        //            return commandResult;

        //        //EventLogger.Instance.Info("Result: " + (resultSpecified ? commandResult.ToString() : "NOT resultSpecified"));
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLogger.Instance.Error("Error al ejecutar SendCommand: " + ex.ToString());
        //    }

        //    return 0;
        //}
    }
}
