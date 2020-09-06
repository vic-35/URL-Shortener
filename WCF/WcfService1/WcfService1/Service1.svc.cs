using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WcfService1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        private readonly DbService db = new DbService();

        // получение списка всех ссылок пользователя
        public async Task<Ret_info> Get(string id)
        {
            Ret_info ret = new Ret_info();
            ret = await db.Get(id, "", true, false);
            return ret;
        }

        // получение короткой ссылки по имени
        public async Task<Ret_info> Get1(string id, string id1)
        {
            // id- идентификатор пользователя id1-короткя ссылка
            Ret_info ret = new Ret_info();
            ret = await db.Get(id, Util_l.From64(id1), false, true);
            return ret;
        }

        //POST: api/Default
        public async Task<Ret_info> Post(Db j)
        {
            // Создать новую запись
            var ret = await db.Create(j);
            return ret;
        }

    }
}
