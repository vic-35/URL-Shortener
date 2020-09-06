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
        public void LoadDb()
        {

            try
            {
                Label1.Text = "";

               JObject ret = Util_l.GetJson(Request.Url.GetLeftPart(UriPartial.Authority) + "/api/Default/"+ HttpContext.Current.Request.AnonymousID);

                if (ret != null)
                {
                    Ret_info ret_info = ret.ToObject<Ret_info>();

                    if (ret_info.B_result)
                    {
                        if (ret_info.Db_list.Count > 0)
                        {
                            List<Db_view1> v_list = new List<Db_view1>();
                            foreach (Db db in ret_info.Db_list)
                            {
                                Db_view1 v1 = new Db_view1();
                                v1.S_short = Request.Url.GetLeftPart(UriPartial.Authority) + "/" + db.S_short;
                                v1.S_long = Util_l.From64(db.S_long);
                                v1.View_count = db.View_count;
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