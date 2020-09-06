using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;


namespace WebApplication_Forms1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if( !IsPostBack)
            {
                LoadDb();

              
            }
        }
        public async void LoadDb()
        {

            try
            {
                Label1.Text = "";

               //JObject ret = Util_l.GetJson(Request.Url.GetLeftPart(UriPartial.Authority) + "/api/Default/"+ HttpContext.Current.Request.AnonymousID);

                ServiceReference1.Service1Client v = new ServiceReference1.Service1Client();
                ServiceReference1.Ret_info ret_info =await v.GetAsync(HttpContext.Current.Request.AnonymousID);
                v.Close();


                if (ret_info != null)
                {

                    if (ret_info.B_result)
                    {
                        if (ret_info.Db_list.Count() > 0)
                        {
                            List<Db_view1> v_list = new List<Db_view1>();

                            for(int i=0;i < ret_info.Db_list.Count();i++)
                            {
                                Db_view1 v1 = new Db_view1();
                                v1.S_short = Request.Url.GetLeftPart(UriPartial.Authority) + "/" + ret_info.Db_list[i].S_short;
                                v1.S_long = Util_l.From64(ret_info.Db_list[i].S_long);
                                v1.View_count = ret_info.Db_list[i].View_count;
                                v_list.Add(v1);
                            }
                            GridView1.DataSource = v_list;
                            GridView1.DataBind();


                        }
                    }
                    else
                    {
                        Label1.Text = ret_info.S_error;
                    }

                }


            }
            catch (Exception ex)
            {
                Label1.Text = ex.ToString();
            }
        }

        protected void GridView1_Load(object sender, EventArgs e)
        {

        }
    }
}