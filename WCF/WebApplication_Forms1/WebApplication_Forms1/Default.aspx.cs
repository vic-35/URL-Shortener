using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace WebApplication_Forms1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Util_l.Secure_url( Util_l.Nvl(RouteData.Values["id"]));
                if (id.Length != 0)
                {
                    Response.Redirect("~/api/Default/" + HttpContext.Current.Request.AnonymousID + "/"+Util_l.To64(id)); return; // Выполнить переход на сервис для поиска короткой ссылки
                }
            
                Label1.Text = "Пользователь - " + HttpContext.Current.Request.AnonymousID;
                TextBox2.Visible = false;
            }

        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            TextBox2.Text = "";
            try
            {


                ServiceReference1.Db db = new ServiceReference1.Db();

                db.S_long = Util_l.To64(TextBox1.Text);
                db.S_short = "00";
                db.User_id = HttpContext.Current.Request.AnonymousID;
                db.View_count = 0;
                
                //JObject ret= Util_l.PostJson(Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/api/Default/"), JObject.FromObject(db));
                ServiceReference1.Service1Client v = new ServiceReference1.Service1Client();
                ServiceReference1.Ret_info ret_info =await  v.PostAsync(db);
                v.Close();
                

                if(ret_info != null)
                {
                    if( ret_info.B_result)
                    {
                        if( ret_info.Db_list.Count() > 0)
                        {
                            TextBox2.Text = Request.Url.GetLeftPart(UriPartial.Authority) + "/"+ ret_info.Db_list[0].S_short;
                        }                        
                    }
                    else
                    {
                        TextBox2.Text = ret_info.S_error;
                    }
                    
                }
                

            }
            catch (Exception ex)
            {
               
            }

            TextBox2.Visible = true;
        }
    }
}