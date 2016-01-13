using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Configuration;
using System.Xml;

namespace DAL.ExcelProcessor.SmartBridge
{
    public static class APICalls
    {
        public static string callPostSmartBridge(string pUrl, string httpRequestMethod, StringBuilder postData, bool IsServiceFailedAttempt, int NumOfFailedAttempts = 3, string WhoIsCalling = "")
        {
            string response = String.Empty;
            string url = string.Empty;
            string user = string.Empty;
            string pass = string.Empty;
            try
            {
                using (var client = new WebClient())
                {
                    url = ConfigurationManager.AppSettings["UrlSmartBridge"] + pUrl;
                    user = ConfigurationManager.AppSettings["SmartBridgeUser"];
                    pass = ConfigurationManager.AppSettings["SmartBridgePass"];

                    client.BaseAddress = url;
                    client.Credentials = new NetworkCredential(user, pass);
                    client.Headers[HttpRequestHeader.ContentType] = "text/plain";
                    client.Headers[HttpRequestHeader.ContentEncoding] = "charset:UTF-8";

                    response = client.UploadString(url, httpRequestMethod, postData.ToString());
                }
            }
            catch (Exception ex)
            {
                if (IsServiceFailedAttempt)
                {
                    if (NumOfFailedAttempts >= 1)
                    {
                        NumOfFailedAttempts--;
                        response = callPostSmartBridge(pUrl, httpRequestMethod, postData, IsServiceFailedAttempt, NumOfFailedAttempts, WhoIsCalling);
                    }
                    else
                    {
                        //log.Error("callPostSmartBridge(" + url + "). WhoIsCalling:" + WhoIsCalling + " User:" + user + " .Password:" + pass + " .PostData:" + postData.ToString() + ". " + ex.Message, ex);
                    }
                }
            }

            return response;
        }

        public static string callGetSmartBridge(string pUrl, bool IsServiceFailedAttempt, int NumOfFailedAttempts = 3, string WhoIsCalling = "")
        {
            string response = String.Empty;
            string url = string.Empty;
            string user = string.Empty;
            string pass = string.Empty;
            try
            {
                using (var client = new WebClient())
                {
                    url = ConfigurationManager.AppSettings["UrlSmartBridge"] + pUrl;
                    user = ConfigurationManager.AppSettings["SmartBridgeUser"];
                    pass = ConfigurationManager.AppSettings["SmartBridgePass"];

                    client.BaseAddress = url;
                    client.Credentials = new NetworkCredential(user, pass);
                    client.Headers[HttpRequestHeader.ContentType] = "text/plain";
                    client.Headers[HttpRequestHeader.ContentEncoding] = "charset:UTF-8";

                    response = client.DownloadString(url);
                }
            }
            catch (Exception ex)
            {
                if (IsServiceFailedAttempt)
                {
                    if (NumOfFailedAttempts >= 1)
                    {
                        NumOfFailedAttempts--;
                        response = callGetSmartBridge(pUrl, IsServiceFailedAttempt, NumOfFailedAttempts, WhoIsCalling);
                    }
                    else
                    {
                        //log.Error("callGetSmartBridge(" + url + "). WhoIsCalling:" + WhoIsCalling + " User:" + user + " Password:" + pass + ". " + ex.Message, ex);
                    }
                }
            }

            return response;
        }

        //Helper Method for parsing XML response and get element innerText value.
        public static string getElementTextFromXMLResponse(string outputResponseInXML, string elementName)
        {
            string textResponse = string.Empty;

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(outputResponseInXML);

                if (doc != null)
                {
                    XmlNodeList elemList = doc.GetElementsByTagName(elementName);
                    textResponse = elemList[0].InnerText;
                }
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message, ex);
            }

            return textResponse;
        }
    }
}
