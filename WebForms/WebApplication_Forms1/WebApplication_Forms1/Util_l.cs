using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace WebApplication_Forms1
{
    public static class Util_l
    {
        static public string Nvl(object obj, string is_nvl)
        {
            if (obj == null) return is_nvl;
            return obj.ToString();
        }
        static public string Nvl(object obj)
        {
            if (obj == null) return "";
            return obj.ToString();
        }
        static public bool Is_empty(object obj)
        {
            if ( Nvl(obj).Length == 0) return true;
            return false;
        }
        static public string Secure_url(string s)
        {
            // проверка корректности короткой ссылки 

            // пока ничего

            return s;
        }
        static public JObject GetJson(string Uri)
        {
            JObject rj = new JObject();

            try
            {               
                WebRequest request = WebRequest.Create(Uri);
                request.Method = "GET";
                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                response.Close();
                rj = JObject.Parse(responseString);
            }
            catch (Exception ex)
            {
                return null;
            }
            return rj;
        }
        static public JObject PostJson(string Uri, JObject post)
        {
            JObject rj = new JObject();
            try
            {
                WebRequest request = WebRequest.Create(Uri);
                request.Method = "POST";
                request.ContentType = "application/json";
                using (var stream = new StreamWriter(request.GetRequestStream()))
                {                   
                    stream.Write(post);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                response.Close();

                rj = JObject.Parse(responseString);
            }
            catch (Exception ex)
            {
                Ret_info err = new Ret_info();
                err.B_result = false;err.S_error = ex.ToString();
                return JObject.FromObject(err);
            }
            return rj;
        }

        public static string To64(string s)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(s));
        }
        public static string From64(string s)
        {
            return System.Text.Encoding.UTF8.GetString (Convert.FromBase64String(s));
        }
        public static string MD5(string s)
        {
            byte[] hash = System.Text.Encoding.ASCII.GetBytes(s);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string result = "";
            foreach (var b in hashenc)
            {
                result += b.ToString("x2");
            }
            return result;
        }
    }
}