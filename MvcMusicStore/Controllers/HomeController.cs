﻿using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        // GET: Home
        private List<Album> GetTopSellingAlbums(int count)
        {     // Group the order details by album and return     // the albums with the highest count 

            return storeDB.Albums.OrderByDescending(a => a.OrderDetails.Count()).Take(count).ToList();
        }
        public ActionResult Index()
        {
            var albums = GetTopSellingAlbums(5);

            return View(albums);
        }
    }
}