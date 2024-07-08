using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.BusinessLogic;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Poyi seru thagu...";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddPlayer()
        {
            return View();
        }

        public ActionResult DeletePlayer(int id)
        {
            PlayersLogic playersLogic = new PlayersLogic();
            var player = playersLogic.GetPlayer(id);

            return View(player);
        }

        public ActionResult EditPlayer(int id)
        {

            PlayersLogic playerLogic = new PlayersLogic();
            var player = playerLogic.GetPlayer(id);
            return View(player);
        }

        public ActionResult PlayersList()
        {
            PlayersLogic playersLogic = new PlayersLogic();
            var playersList = playersLogic.GetPlayersList();

            return View(playersList);
        }

        public ActionResult PlayerDetails(int id)
        {
            PlayersLogic playersLogic = new PlayersLogic();
            var player = playersLogic.GetPlayer(id);

            return View(player);
        }

        public ActionResult Create(Player player)
        {
            PlayersLogic playerLogic = new PlayersLogic();
            playerLogic.AddOrUpdatePlayer(player);

            return RedirectToAction("PlayersList");
        }
        public ActionResult Edit(Player player)
        {
            PlayersLogic playerLogic = new PlayersLogic();
            playerLogic.AddOrUpdatePlayer(player);

            return RedirectToAction("PlayersList");
        }

        public ActionResult Delete(int id)
        {
            PlayersLogic playerLogic = new PlayersLogic();
            playerLogic.DeletePlayer(id);

            return RedirectToAction("PlayersList");
        }


    }
}