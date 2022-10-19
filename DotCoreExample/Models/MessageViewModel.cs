﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotCoreExample.Models
{
    public class MessageViewModel : Controller
    {
        // GET: MessageViewModel
        public ActionResult message()
        {
            return View();
        }

        // GET: MessageViewModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MessageViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessageViewModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MessageViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MessageViewModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MessageViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MessageViewModel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
