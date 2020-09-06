using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json.Linq;


namespace WebApplication_Forms1
{
    // Класс структуры данных в  хранилище
    public class Db 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string User_id { get; set; }
        public string S_short { get; set; }
        public string S_long { get; set; }
        public int View_count { get; set; }

    }
    // Класс структуры для отображения
    public class Db_view1
    {
        public string S_short { get; set; }
        public string S_long { get; set; }
        public int View_count { get; set; }
    }
    // Класс используется при возврате JSON из контроллера для обработки результатов операции клиентом
    public class Ret_info 
    {
        public Ret_info()
        { 
            B_result = true;
            Db_list = new List<Db>();
            S_error = "";
        }
        public bool B_result { get; set; } // false=  ошибка 
        public string S_error { get; set;} // текст ошибки
        public List<Db> Db_list { get; set; } // список записей затронутых операцией
    }


    // класс СRUD операций с базой
    public class DbService
    {
        private readonly IMongoCollection<Db> _db;

        public DbService()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("db");
            _db = database.GetCollection<Db>("store");
        }



        // получение списка записей
        // id- идентификатор пользователя id1-короткя ссылка
        // find_all_for_user искать все записи пользователя
        // update_View_count обновить счетчик просмотров
        public async Task<Ret_info> Get(string id,string id1, bool find_all_for_user,bool update_View_count)
        {
            Ret_info ret = new Ret_info();
            try
            {
                BsonDocument filter;
                if (find_all_for_user) // поиск всех документов пользователя или по идентификатору короткой ссылки
                {

                    filter = new BsonDocument(new BsonDocument("User_id", id));
                }
                else
                {
                    filter = new BsonDocument("$and", new BsonArray{
                        new BsonDocument("User_id", id),
                        new BsonDocument("S_short", id1)});
                }
                ret.Db_list = await _db.Find(filter).ToListAsync<Db>(); // поиск по условию filter

                if (update_View_count && ret.Db_list.Count > 0 )
                {
                    // у всех найденных записей повышаем счетчик  при условии update_View_count
                    foreach (Db db in ret.Db_list)
                    {
                        db.View_count += 1;
                        Ret_info ret_tmp = await Update(db);
                        // обработка ошибки 
                    }
                }

            }
            catch(Exception ex)
            {
                ret.B_result = false;
                ret.S_error = ex.ToString();
            }
            return ret; // 
        }

        public async Task<Ret_info> Update(Db db_new)
        {
            Ret_info ret = new Ret_info();
            try
            {
                // параметр фильтрации 
                var filter = new BsonDocument("_id",new ObjectId(db_new.Id));
                // параметр обновления
                var update = new BsonDocument("$set", new BsonDocument("View_count", db_new.View_count));

                // обновление данных
               var result = await _db.UpdateOneAsync(filter, update);
               //обработка  при нулевом обновлении 
               //if( result.ModifiedCount
               //обработка  при нулевом обновлении 

            }
            catch (Exception ex)
            {
                ret.B_result = false;
                ret.S_error = ex.ToString();
            }
            return ret;
        }

        public async Task<Ret_info> Create(Db db_new)
        {
            Ret_info ret = new Ret_info();
            try
            {
                db_new.S_short = Util_l.MD5(db_new.S_long);
                ret.Db_list.Add(db_new);
                
                var filter = new BsonDocument("$and", new BsonArray{
                        new BsonDocument("User_id", db_new.User_id),
                        new BsonDocument("S_short", db_new.S_short)
                });
                List<Db> l_db = await _db.Find( filter ).ToListAsync<Db>(); // Поиск короткой ссылки - создаем новую только при отсутствии старой
                if (l_db.Count == 0)
                {
                    await _db.InsertOneAsync(db_new); // добавление записи
                }
            }
            catch (Exception ex)
            {
                ret.B_result = false;
                ret.S_error = ex.ToString();
            }
            return ret;
       }
    }


}