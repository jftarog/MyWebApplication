using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models.EntityManager;
using MyWebApplication.Models.ViewModel;

namespace MyWebApplication.Controllers
{
    public class YTInfoController : Controller
    {
        /*public ActionResult SignUp()
        {
            return View();
        }*/

        public ActionResult YTInfos()
        {
            YTInfoManager um = new YTInfoManager();
            YTInfosModel YTInfo = um.GetAllInfo();

            return View(YTInfo);
        }

        [HttpPost]
        public ActionResult AddLink(YTInfoModel YTInfo)
        {
            if (ModelState.IsValid)
            {
                YTInfoManager um = new YTInfoManager();
                if (!um.IsLinkExist(YTInfo.YTLink))
                {
                    um.AddYTInfo(YTInfo);
                    // FormsAuthentication.SetAuthCookie(YTInfo.YTLink, false);
                    return RedirectToAction("", "Home");
                }
                else
                    ModelState.AddModelError("", "This link already exists.");
            }
            return View();
        }

        /*[HttpPut]
        public async Task<ActionResult> Update([FromBody] YTInfoModel YTInfoData)
        {
            YTInfoManager um = new YTInfoManager();
            if (um.IsLoginNameExist(YTInfoData.LoginName))
            {
                um.UpdateYTInfoAccount(YTInfoData);
                return RedirectToAction("Index"); // Redirect to a relevant action after successful update.
            }
            // Handle the case when the login name doesn't exist, e.g., return a relevant error view.
            return RedirectToAction("LoginNameNotFound");
        }*/

    }
}
