using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;


namespace WcfService1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        Task<Ret_info> Get(string id);

        [OperationContract]
        Task<Ret_info> Get1(string id, string id1);

        [OperationContract]
        Task<Ret_info> Post(Db j);


        // TODO: Добавьте здесь операции служб
    }


    // Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.
    [DataContract]
    public class Db
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [DataMember]
        public string User_id { get; set; }
        [DataMember] 
        public string S_short { get; set; }
        [DataMember] 
        public string S_long { get; set; }
        [DataMember] 
        public int View_count { get; set; }

    }

    //// Класс структуры для отображения
    //public class Db_view1
    //{
    //    public string S_short { get; set; }
    //    public string S_long { get; set; }
    //    public int View_count { get; set; }
    //}
    // Класс используется при возврате JSON из контроллера для обработки результатов операции клиентом

    public class Ret_info
    {
        public Ret_info()
        {
            B_result = true;
            Db_list = new List<Db>();
            S_error = "";
        }
        [DataMember] 
        public bool B_result { get; set; } // false=  ошибка 
        [DataMember] 
        public string S_error { get; set; } // текст ошибки
        [DataMember] 
        public List<Db> Db_list { get; set; } // список записей затронутых операцией
    }


}
