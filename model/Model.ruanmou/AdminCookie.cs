using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.ruanmou
{
    public class AdminCookie
    {
        private int _uid_admin = 0;
        private string _encryptPwd_admin = "";
        private string _uname_admin = "";
        private DateTime _laston_admin;

        /// <summary>
        /// id
        /// </summary>
        public int uid_admin
        {
            get { return _uid_admin; }
            set { _uid_admin = value; }
        }
        /// <summary>
        /// 加密密码
        /// </summary>
        public string EncryptPwd_admin
        {
            get { return _encryptPwd_admin; }
            set { _encryptPwd_admin = value; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string uname_admin
        {
            get { return _uname_admin; }
            set { _uname_admin = value; }
        }
        public DateTime laston_admin
        {
            get { return _laston_admin; }
            set { _laston_admin = value; }
        }
    }
}
