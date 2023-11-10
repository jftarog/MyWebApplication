using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.IdentityModel.Tokens;
using MyWebApplication.Models.DB;
using MyWebApplication.Models.EntityManager;
using MyWebApplication.Models.ViewModel;
using MyWebApplication.Security;
using System.Security.Claims;

namespace MyWebApplication.Controllers
{
    public class YTInfoController : Controller
    {
        public ActionResult AddLink()
        {
            return View();
        }

        [AuthorizeRoles("Admin")]
        public ActionResult Links()
        {
            YTInfoManager um = new YTInfoManager();
            YTInfosModel YTInfo = um.GetAllInfo();

            return View(YTInfo);
        }

        [HttpPost]
        public ActionResult AddLink(YTInfoModel info)
        {
            if (ModelState.IsValid)
            {
                YTInfoManager um = new YTInfoManager();
                if (!um.IsLinkExist(info.YTLink))
                {
                    um.AddYTInfo(info);
                    // FormsAuthentication.SetAuthCookie(YTInfo.YTLink, false);
                    return RedirectToAction("", "Home");
                }
                else
                    ModelState.AddModelError("", "This link already exists.");
            }
            return View();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] YTInfoModel ytinfoData)
        {
            YTInfoManager um = new YTInfoManager();
            if (um.IsLinkExist(ytinfoData.YTLink))
            {
                um.UpdateYTInfo(ytinfoData);
                return RedirectToAction("Index"); // Redirect to a relevant action after successful update.
            }
            // Handle the case when the login name doesn't exist, e.g., return a relevant error view.
            return RedirectToAction("LoginNameNotFound");
        }

    }
}
