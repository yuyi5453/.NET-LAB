using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing;

namespace WebBookShop.Models
{
    public class User
    {

        public string UserID { get; set; }
        public string UserName { get ; set; }
        public string UserPwd { get; set; }
        public DateTime UserBirth { get; set; }
        public string UserAddress { get; set; }
        public string UserIdentity { get; set; }
        public string UserImgUrl { get; set; }
        public string UserSex { get; set; }
        public string UserSign { get; set; }
        public string  UserEmail { get; set; }
        public string UserTelephone { get; set; }

    }
}
