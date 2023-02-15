using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpSecureDataCleaning; //подключение библиотеки с методом очистки Secure-данных

namespace HttpLogHandler
{
    class HttpResult
    { 
        public string Url { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
    }


    class httpLogHandler
    {
        static HttpResult _currentLog;
        public static HttpResult CurrentLog { get { return _currentLog; } }

        protected static void Log(HttpResult result)
        {
            _currentLog = new HttpResult
            {
                Url = result.Url,
                RequestBody = result.RequestBody,
                ResponseBody = result.ResponseBody
            };
        }


        public static string Process(string url, string body, string response, bool isSecured = false)
        {
            var httpResult = new HttpResult
            {
                Url = url,
                RequestBody = body,
                ResponseBody = response,
            };

            if (!isSecured)
            {
              httpResult = secureData.clearSecureData(httpResult);
            }

            Log(httpResult);

            return response;
        }

    }
}

