﻿using System;
using System.Collections.Generic;
using System.Linq;
using UscWebservices.Weixin.IServices;

namespace UscWebservices.Weixin.JingPinKeCheng
{
    public class DataAccess : IFindPwd
    {
        /// <summary>
        /// 由登录用户名，取密码
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetPasswordByUsername(string username)
        {
            using (var context = new JingPinKeChengEntities())
            {
                //只接受学生帐号
                var user = context.Users.First(t =>
                    t.logname == username && t.user_type == 2
                    );
                //处理帐号错误
                if (user == null)
                {
                    return string.Empty;
                }
                else
                {
                    return user.password_src;
                }

            }
        }
    }
}
