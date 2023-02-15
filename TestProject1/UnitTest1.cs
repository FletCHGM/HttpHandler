using Xunit;
using HttpLogHandler;
using HttpSecureDataCleaning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace HttpHandlerTest
{
    public class UnitTest1
    {
        public void HttpLogHandler_Process_BookingcomHttpResult_ClearSecureData()
        {
            //Arrange
            var data = new HttpResult
            {
                Url = "http://test.com/users/max/info?pass=123456",
                RequestBody = "http://test.com?user=max&pass=123456",
                ResponseBody = "http://test.com?user=max&pass=123456"
            };

            //Act
            httpLogHandler.Process(data.Url, data.RequestBody, data.ResponseBody); //„етвертый параметр €вл€етс€ необ€зательным и служит дл€ задани€ необходимости очистки данных(bool isSecured = default false)

            //Assert
            Assert.Equal("http://test.com/users/XXX/info?pass=XXXXXX", httpLogHandler.CurrentLog.Url);
            Assert.Equal("http://test.com?user=XXX&pass=XXXXXX", httpLogHandler.CurrentLog.RequestBody);
            Assert.Equal("http://test.com?user=XXX&pass=XXXXXX", httpLogHandler.CurrentLog.ResponseBody);
        }
    }
}