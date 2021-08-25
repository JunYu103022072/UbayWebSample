﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNote.Auth
{
    public class UserInfoModel
    {
        public Guid ID { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int UserLevel { get; set; }

        public DateTime DateTime { get; set; }

        public string MobilePhone { get; set; }

        //public Guid UserGuid        //把ID轉成GUID
        //{
        //    get
        //    {
        //        return this.ID;
        //        //if (Guid.TryParse(this.ID, out Guid tempGuid)) 
        //        //    return tempGuid;
        //        //else
        //        //    return Guid.Empty;
        //    }
        //}

    }
}
