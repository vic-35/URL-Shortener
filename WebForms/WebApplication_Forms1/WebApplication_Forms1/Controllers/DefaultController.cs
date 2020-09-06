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
        private readonly DbService db = new DbService();

        // получение списка всех ссылок пользователя
        public async Task<Ret_info> Get(string id)
        {
            Ret_info ret = new Ret_info();
            ret = await db.Get(id,"", true, false);
            return ret;
        }
        
        // получение короткой ссылки по имени
        public async Task<HttpResponseMessage> Get(string id, string id1)
        {
            // id- идентификатор пользователя id1-короткя ссылка
            Ret_info ret = new Ret_info();
            ret = await db.Get(id, Util_l.From64(id1),false,true);
            if (ret.Db_list.Count > 0)
            {
                //Если есть запись перенаправляем на 1 
                var response = Request.CreateResponse(HttpStatusCode.Moved);
                response.Headers.Location = new Uri(Util_l.From64(ret.Db_list[0].S_long));
                return response;
            }
            else
            {
                var response = Request.CreateResponse(HttpStatusCode.NotFound);
                return response;
            }

        }

        //POST: api/Default
        public async Task<Ret_info> Post(JObject j)
        {
            // Создать новую запись
            var ret = await db.Create(j.ToObject<Db>());
            return ret;
        }
    }
}
