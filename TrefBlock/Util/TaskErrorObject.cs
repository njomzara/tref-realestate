using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrefBlock.Util
{
    public class TaskErrorObject
    {   
        public string Title { get; set; }
        public string Text { get; set; }

        public TaskErrorObject(string text = "", string title = "")
        {   

            this.Title = title;
            this.Text = text;
        }

        public static dynamic Http400()
        {
            return new { text = "Something went wrong, contact the administrator", title = "HTTP 400" };
        }

        public static dynamic BadRequest(string title, string text)
        {
            return new { title, text };
        }

        public static dynamic Exception(Exception ex, string title = null)
        {
            if(title != null)
            {
                return new { text = ex.Message, title };
            }
            else
            {
                return new { text = ex.Message, title = ex.InnerException };
            }
        }

        // Login user
        public static dynamic RegisterUser()
        {
            return new { text = "User with this ID already exists!", title = "User ID Taken" };
        }
        // Login user
        public static dynamic LoginUser()
        {
            return new { text = "Username or password are wrong!", title = "Wrong credentials" };
        }

        // Set employee for a user
        public static dynamic SetEmployeeForAUser()
        {
            return new { text = "Username or password are wrong!", title = "Wrong credentials" };
        }


    }
}
