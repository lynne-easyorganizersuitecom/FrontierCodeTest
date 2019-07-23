using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Linq;
using System.Net;

namespace Mvc_5_Empty_Template1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Models.HomeModel accounts = GetAccounts();
            return View(accounts);
        }

        public Models.HomeModel GetAccounts()
        {
            IEnumerable<Models.AccountModel> accounts = null;
            Models.HomeModel accountGroups = new Models.HomeModel();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://frontiercodingtests.azurewebsites.net/api/accounts/getall");

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    System.Net.ServicePointManager.Expect100Continue = false;

                    //Called Member default GET All records  
                    //GetAsync to send a GET request   
                    // PutAsync to send a PUT request  
                    var responseTask = client.GetAsync(client.BaseAddress);
                    responseTask.Wait();

                    //To store result of web api response.   
                    var result = responseTask.Result;

                    //If success received   
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Models.AccountModel>>();
                        readTask.Wait();

                        accounts = readTask.Result;
                        accountGroups.ActiveAccounts = accounts.Where(m => m.AccountStatusId == 0).ToList();
                        accountGroups.InactiveAccounts = accounts.Where(m => m.AccountStatusId == 1).ToList();
                        accountGroups.OverdueAccounts = accounts.Where(m => m.AccountStatusId == 2).ToList();

                    }
                    else
                    {
                        //Error response received   
                        accounts = Enumerable.Empty<Models.AccountModel>();
                        ModelState.AddModelError(string.Empty, "Server error try after some time.");
                    }
                }
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                var stackTrace = ex.StackTrace;
            }

            return accountGroups;
        }


    }
}