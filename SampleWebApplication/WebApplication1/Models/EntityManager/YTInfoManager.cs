using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MyWebApplication.Models.DB;
using MyWebApplication.Models.ViewModel;
using System;
using System.Linq;

namespace MyWebApplication.Models.EntityManager
{
    public class YTInfoManager
    {
        public void AddYTInfo(YTInfoModel info)
        {
            using (MyDBContext db = new MyDBContext())
            {
                YTInfo newInfo = new YTInfo
                {
                    YTLink = info.YTLink,
                    YTTitle = info.YTTitle,
                    YTUploader = info.YTUploader,
                    CreatedBy = 1,
                    CreatedDateTime = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDateTime = DateTime.Now
                };

                db.YTInfo.Add(newInfo);
                db.SaveChanges();

                /*int newUserId = db.YTInfo.First(u => u.LoginName == newSysUser.LoginName).UserID;

                Users newUser = new Users
                {
                    UserID = newUserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = "1",
                    CreatedBy = 1,
                    CreatedDateTime = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDateTime = DateTime.Now
                };

                db.Users.Add(newUser);
                db.SaveChanges();*/
            }
        }

        /*public void UpdateUserAccount(UserModel user)
        {
            using (MyDBContext db = new MyDBContext())
            {
                // Check if a user with the given login name already exists
                YTInfo existingSysUser = db.YTInfo.FirstOrDefault(u => u.LoginName == user.LoginName);
                Users existingUser = db.Users.FirstOrDefault(u => u.UserID == existingSysUser.UserID);

                if (existingSysUser != null && existingUser != null)
                {
                    // Update the existing user
                    existingSysUser.ModifiedBy = 1; // This has to be updated
                    existingSysUser.ModifiedDateTime = DateTime.Now;


                    // You can also update other properties of the user as needed
                    existingUser.FirstName = user.FirstName;
                    existingUser.LastName = user.LastName;
                    existingUser.Gender = user.Gender;

                    db.SaveChanges();
                }
                else
                {
                    // Add a new user since the user doesn't exist
                    YTInfo newSysUser = new YTInfo
                    {
                        LoginName = user.LoginName,
                        CreatedBy = 1,
                        PasswordEncryptedText = user.Password, // Update this to handle encryption
                        CreatedDateTime = DateTime.Now,
                        ModifiedBy = 1,
                        ModifiedDateTime = DateTime.Now
                    };

                    db.YTInfo.Add(newSysUser);
                    db.SaveChanges();

                    int newUserId = newSysUser.UserID;

                    Users newUser = new Users
                    {
                        UserID = newUserId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Gender = "1",
                        CreatedBy = 1,
                        CreatedDateTime = DateTime.Now,
                        ModifiedBy = 1,
                        ModifiedDateTime = DateTime.Now
                    };

                    db.Users.Add(newUser);
                    db.SaveChanges();
                }
            }

        }*/
        public YTInfosModel GetAllInfo()
        {
            YTInfosModel list = new YTInfosModel();

            using (MyDBContext db = new MyDBContext())
            {
                var info = db.YTInfo; // from i in db.YTInfo select new { i };

                list.YTInfos = info.Select(records => new YTInfoModel()
                {
                    YTLink = records.YTLink,
                    YTTitle = records.YTTitle,
                    YTUploader = records.YTUploader,
                    CreatedBy = records.CreatedBy
                }).ToList();
            }

            return list;
        }

        public bool IsLinkExist(string ytLink)
        {
            using (MyDBContext db = new MyDBContext())
            {
                return db.YTInfo.Where(u => u.YTLink.Equals(ytLink)).Any();
            }
        }

    }
}
