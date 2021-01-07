using System;
using System.Diagnostics;
using System.Net;

namespace HearthStone_Backend.Services
{
    public static class URLExistsChecker
    {
        
        
        public static bool Checker(string url)
        {
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    int statusCode = (int) response.StatusCode;
                    if (statusCode >= 100 && statusCode < 400)
                    {
                        return true;
                    }
                    else if (statusCode >= 500 && statusCode <= 510)
                    {
                        Debug.WriteLine("The remote server has thrown an internal error. Url is not valid: {0}", url);
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return false;

        }
    }
}