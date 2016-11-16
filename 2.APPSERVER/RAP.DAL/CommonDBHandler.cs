﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RAP.Core.Common;
using RAP.Core.DataModels;

namespace RAP.DAL
{
    public class CommonDBHandler : ICommonDBHandler
    {
        private readonly string _connString;
        public CommonDBHandler()
        {
            _connString = ConfigurationManager.AppSettings["RAPDBConnectionString"];
        }
        /// <summary>
        /// Gets the data needed to to display on the tenant petition form
        /// </summary>
        /// <returns></returns>

        private int SaveUserInfo(UserInfoM userInfo)
        {
            int userID = 0;
            using (CommonDataContext db = new CommonDataContext())
            {
                var user = db.UserInfos.Where(x => (x.FirstName == userInfo.FirstName
                                                        && x.LastName == userInfo.LastName
                                                        && x.AddressLine1 == userInfo.AddressLine1
                                                        && x.AddressLine2 == userInfo.AddressLine2
                                                        && x.City == userInfo.City
                                                        && x.State == userInfo.State
                                                        && x.Zip == userInfo.Zip)).FirstOrDefault();

                if (user != null)
                {
                    userID = user.UserID;
                }
                else
                {
                    UserInfo userInfoDB = new UserInfo();
                    userInfoDB.FirstName = userInfo.FirstName;
                    userInfoDB.LastName = userInfo.LastName;
                    userInfoDB.AddressLine1 = userInfo.AddressLine1;
                    userInfoDB.AddressLine2 = userInfo.AddressLine2;
                    userInfoDB.City = userInfo.City;
                    userInfoDB.State = userInfo.State;
                    userInfoDB.Zip = userInfo.Zip;
                    userInfoDB.PhoneNumber = userInfo.PhoneNumber;
                    userInfoDB.ContactEmail = userInfo.Email;

                    db.UserInfos.InsertOnSubmit(userInfoDB);
                    db.SubmitChanges();
                    userID = userInfoDB.UserID;
                }
            }
            return userID;
        }

    }
}