using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WholeSalesWarehousing.Model
{
    public class Login
    {
        public string hash { get; set; }
        public bool auth { get; set; }
        public bool saved { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public int id { get; set; }
        public int ic_admin { get; set; }

        public CookieCollection Container;

        public static String URL_LOGIN { get { return "api/login";  } }

        public static Login DoLogin(String username, String password, String base_url)
        {
            try
            {
                String postData = WebConnection.GeneratePostData(
                   new Argument() { name = "username", value = username },
                   new Argument() { name = "password", value = password },
                   new Argument() { name = "device", value = "WindowsPC" },
                   new Argument() { name = "os", value = "Windows" },
                   new Argument() { name = "latitude", value = "" },
                   new Argument() { name = "longitude", value = "" }
                );

                WebConnection doRequests = WebConnection.GetRequestsAsPost(PathUtils.Join(base_url, Login.URL_LOGIN), postData);
                String content = doRequests.content;
                Login login = Login.FromJson(content);
                login.username = username;
                login.Container = doRequests.cookieContainer;
                return login;
            }
            catch (Exception ex)
            {

            }

            return new Login()
            {
                auth = false
            };
        }



        public Login Save()
        {
            this.saved = true;
            return this;
        }

        public static Login FromJson(String Json)
        {
            return JsonConvert.DeserializeObject<Login>(Json);
        }
    }
}
