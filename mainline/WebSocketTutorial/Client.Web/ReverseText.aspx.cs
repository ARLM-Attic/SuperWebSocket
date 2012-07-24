using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Client.Web
{
    public partial class ReverseText : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var nameCookie = Request.Cookies.Get("name");

            if (nameCookie == null)
                //Response.AppendCookie(new HttpCookie("name", Guid.NewGuid().ToString()));
                Response.Redirect("~/Default.aspx");
        }

        protected object WebSocketPort
        {
            get
            {
                var extPort = ConfigurationManager.AppSettings["extPort"];

                if (string.IsNullOrEmpty(extPort))
                    return Application["WebSocketPort"];
                else
                    return extPort;
            }
        }

        protected object SecureWebSocketPort
        {
            get
            {
                var extPort = ConfigurationManager.AppSettings["extSecurePort"];

                if (string.IsNullOrEmpty(extPort))
                    return Application["SecureWebSocketPort"];
                else
                    return extPort;
            }
        }
    }
}