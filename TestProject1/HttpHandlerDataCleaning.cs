using HttpLogHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HttpSecureDataCleaning
{   class secureData 
    {
        public static HttpResult clearSecureData(HttpResult Data)
        {
            string[] secureObjects = { "users/", "Users/", "pass=", "user=" }; //can be supplemented
            
            //URL//
            /////////////////////////////////////////////////////////////////////////////////////////////////
            
            foreach (var item in secureObjects)
            {
                if (Data.Url.Contains(item))
                {
                    int i = Data.Url.IndexOf(item);
                    i = i + item.Length;
                    string Ended = Data.Url + "/";
                    char[] data = Ended.ToCharArray();
                    while (data[i] != '/' & data[i] != '&')
                    {
                        data[i] = 'X';
                        i++;
                    }
                    Data.Url = new string(data);
                    Data.Url = Data.Url.Remove(Data.Url.Length - 1);
                }
            }

            //REQUEST//
            ////////////////////////////////////////////////////////////////////////////////////////////////
            
            foreach (var item in secureObjects)
            {
                if (Data.RequestBody.Contains(item))
                {
                    int i = Data.RequestBody.IndexOf(item);
                    i = i + item.Length;
                    string Ended = Data.RequestBody + "/";
                    char[] data = Ended.ToCharArray();
                    while (data[i] != '/' & data[i] != '&')
                    {
                        data[i] = 'X';
                        i++;
                    }
                    Data.RequestBody = new string(data);
                    Data.RequestBody = Data.RequestBody.Remove(Data.RequestBody.Length - 1);
                }
            }

            //RESPONSE//
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            
            foreach (var item in secureObjects)
            {
                if (Data.ResponseBody.Contains(item))
                {
                    int i = Data.ResponseBody.IndexOf(item);
                    i = i + item.Length;
                    string Ended = Data.ResponseBody + "/";
                    char[] data = Ended.ToCharArray();
                    while (data[i] != '/' & data[i] != '&')
                    {
                        data[i] = 'X';
                        i++;
                    }
                    Data.ResponseBody = new string(data);
                    Data.ResponseBody = Data.ResponseBody.Remove(Data.ResponseBody.Length - 1);
                }
            }
            
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            
            return Data;

        }
    }
}
