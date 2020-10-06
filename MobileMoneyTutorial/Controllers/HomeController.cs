using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileMoneyTutorial.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace MobileMoneyTutorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private string AuthenticationToken { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

           AuthenticationToken = GenerateAuthToken();
           // AuthenticationToken = "zHb3doizYvxJewG6wvKFG7KkB7vx";
        }

        public IActionResult Index()
        {
            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private static string GenerateAuthToken()
        {
            try
            {
                string appKey = "QlHiWIAGRkirgnx91tGNB8eTXM4K5zDV";
                string appSecret = "FU7hRuvv1CorLO9B";

                var client = new RestClient()
                {
                    BaseUrl = new Uri("https://sandbox.safaricom.co.ke"),
                    Authenticator = new HttpBasicAuthenticator(appKey, appSecret)

                };

                var request = new RestRequest("/oauth/v1/generate", Method.GET);

                request.AddParameter("grant_type", "client_credentials", ParameterType.QueryString);

                IRestResponse response = client.Execute(request);

                if (response != null)
                {
                    TokenResponse tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(response.Content);

                    return tokenResponse.AccessToken;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return string.Empty;
            }
        }


        public IActionResult RegisterUrl()
        {
            RegisterUrl(AuthenticationToken);

            return RedirectToAction("Index");
        }

        public IActionResult SimulateC2B()
        {
            C2BRequest(AuthenticationToken);

            return RedirectToAction("Index");
        }



        private async void RegisterUrl(string AuthenticationToken)
        {
            try
            {
                RestClient restClient = new RestClient()
                {
                    BaseUrl = new Uri("https://sandbox.safaricom.co.ke")
                };

                RestRequest restRequest = new RestRequest() 
                {
                    Resource = "mpesa/c2b/v1/registerurl", 
                    Method = Method.POST
                };

                restRequest.AddHeader("Authorization", "Bearer " + AuthenticationToken);

                RegisterUrlRequestBody registerUrlRequestBody = new RegisterUrlRequestBody()
                {
                    ShortCode = "601426",
                    //ShortCode = "695656",
                    ResponseType = "Completed",
                    ConfirmationURL = "https://johncustomertobusiness.azurewebsites.net/api/ApiConfirmationResponses",
                    ValidationURL = "https://johncustomertobusiness.azurewebsites.net"
                };

                restRequest.AddJsonBody(registerUrlRequestBody);

               


                var response = await Task.Run(() =>
                {
                    return restClient.Execute(restRequest);
                });

                if (response.IsSuccessful)
                {
                    //do something
                    Console.WriteLine(response.Content);
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        private async void C2BRequest(string AuthenticationToken)
        {
            try
            {
                RestClient restClient = new RestClient()
                {
                    BaseUrl = new Uri("https://sandbox.safaricom.co.ke/")
                };

                RestRequest restRequest = new RestRequest()
                {
                    Resource = "/mpesa/c2b/v1/simulate",
                    Method = Method.POST
                };

                restRequest.AddHeader("Authorization", "Bearer " + AuthenticationToken);

                C2BSimulateRequestBody c2BSimulateRequestBody = new C2BSimulateRequestBody()
                {
                    ShortCode = "601426",
                    //ShortCode = "695656",
                    CommandID = "CustomerPayBillOnline",
                    Amount = "100",
                    Msisdn = "254708374149",
                    BillRefNumber = "account"
                };

                restRequest.AddJsonBody(c2BSimulateRequestBody);




                var response = await Task.Run(() =>
                {
                    return restClient.Execute(restRequest);
                });

                if (response.IsSuccessful)
                {
                    //do something
                    Console.WriteLine(response.Content);
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
    }
}
