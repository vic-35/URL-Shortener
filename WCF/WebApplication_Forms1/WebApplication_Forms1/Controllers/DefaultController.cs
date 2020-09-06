using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;


namespace WebApplication_Forms1.Controllers
{
   
    public class DefaultController : ApiController
    {

        // получение короткой ссылки по имени
        public async Task<HttpResponseMessage> Get(string id, string id1)
        {
            // id- идентификатор пользователя id1-короткя ссылка

            ServiceReference1.Service1Client v = new ServiceReference1.Service1Client();
            ServiceReference1.Ret_info ret_info = await v.Get1Async(id,id1);
            v.Close();


            if (ret_info.Db_list.Count() > 0)
            {
                //Если есть запись перенаправляем на 1 
                var response = Request.CreateResponse(HttpStatusCode.Moved);
                response.Headers.Location = new Uri(Util_l.From64(ret_info.Db_list[0].S_long));
                return response;
            }
            else
            {
                var response = Request.CreateResponse(HttpStatusCode.NotFound);
                return response;
            }

        }

    }
}
