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
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = DateTime.Now
                };

                db.YTInfo.Add(newInfo);
                db.SaveChanges();
            }
        }

        public void UpdateYTInfo(YTInfoModel info)
        {
            using (MyDBContext db = new MyDBContext())
            {
                // Check if a user with the given login name already exists
                YTInfo existingLink = db.YTInfo.FirstOrDefault(u => u.YTLink == info.YTLink);

                if (existingLink != null)
                {
                    // Update the existing user
                    existingLink.ModifiedDateTime = DateTime.Now;

                    // You can also update other properties of the user as needed
                    existingLink.YTLink = info.YTLink;
                    existingLink.YTTitle = info.YTTitle;
                    existingLink.YTUploader = info.YTUploader;

                    db.SaveChanges();
                }
                else
                {
                    // Add a new user since the user doesn't exist
                    YTInfo newInfo = new YTInfo
                    {
                        YTLink = info.YTLink,
                        YTTitle = info.YTTitle,
                        YTUploader = info.YTUploader,
                        CreatedDateTime = DateTime.Now,
                        ModifiedDateTime = DateTime.Now
                    };  

                    db.YTInfo.Add(newInfo);
                    db.SaveChanges();
                }
            }

        }
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
                    YTUploader = records.YTUploader
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
