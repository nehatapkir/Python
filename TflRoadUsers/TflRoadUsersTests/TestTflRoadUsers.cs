using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using TflRoadUsers;
namespace TflRoadUsersTests
{
    [TestClass]
    public class TestTflRoadUsers
    {
       private Uri uri;
       private TflRoadUsers.TflRoadUsers roadUsers;

        [TestMethod]
        public void GetData_CheckSendAsyncIsCalled()
        {
            var mockHandler = new Mock<HttpMessageHandler>();
            string content = "[{\"displayName\": \"A2\",  \"statusSeverity\": \"Good\",\"statusSeverityDescription\": \"No Exceptional Delays\" }]";

            mockHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                       .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(content, System.Text.Encoding.UTF8, "application/json") });
            HttpClient client = new HttpClient(mockHandler.Object);
            uri = new Uri("https://api.tfl.gov.uk/Road");
            client.BaseAddress = uri;
           
            roadUsers = new TflRoadUsers.TflRoadUsers(client);
            var result = roadUsers.GetRoadStatusAsync(uri.ToFullUrl("A2")).GetAwaiter().GetResult();
            mockHandler.Protected().Verify(
   "SendAsync",
   Times.Exactly(1), 
   ItExpr.Is<HttpRequestMessage>(req =>
      req.Method == HttpMethod.Get  

   ),
   ItExpr.IsAny<CancellationToken>());

        }


        [TestMethod]
        public void TestGetRoadStatus_ReturnsListofRoadType()
        {
            var mockHandler = new Mock<HttpMessageHandler>();

            string content = "[{\"displayName\": \"A2\",  \"statusSeverity\": \"Good\",\"statusSeverityDescription\": \"No Exceptional Delays\" }]";

            mockHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                       .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(content, System.Text.Encoding.UTF8, "application/json") });
            HttpClient client = new HttpClient(mockHandler.Object);
            uri = new Uri("https://api.tfl.gov.uk/Road");
            client.BaseAddress = uri;
           
            roadUsers = new TflRoadUsers.TflRoadUsers(client);
            var result =  roadUsers.GetRoadStatusAsync(uri.ToFullUrl("A2")).GetAwaiter().GetResult();
           
            Assert.IsTrue(result.GetType() == typeof(List<Road>));
        }

     
        [TestMethod]      
        public void GetData_CheckInvalidResponse_EmptyContent()
        {
            var mockHandler = new Mock<HttpMessageHandler>();

            string content = "[{\"exceptionType\": \"EntityNotFoundException\",\"httpStatusCode\": 404,\"httpStatus\": \"NotFound\" }]";

            mockHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                       .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(content, System.Text.Encoding.UTF8, "application/json") });
            HttpClient client = new HttpClient(mockHandler.Object);
            uri = new Uri("https://api.tfl.gov.uk/Road");
            client.BaseAddress = uri;
           
            roadUsers = new TflRoadUsers.TflRoadUsers(client);
            var result = roadUsers.GetRoadStatusAsync(uri.ToFullUrl("A2")).GetAwaiter().GetResult();

            Assert.IsTrue(result.GetType() == typeof(List<Road>));
            Assert.IsTrue(result.Count == 0);
                      
        }

       
  



    }
}
