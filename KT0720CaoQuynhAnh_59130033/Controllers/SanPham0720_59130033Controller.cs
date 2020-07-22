using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KT0720CaoQuynhAnh_59130033.Models;

namespace KT0720CaoQuynhAnh_59130033.Controllers
{
    public class SanPham0720_59130033Controller : Controller
    {
        private KT0720_59130033Entities db = new KT0720_59130033Entities();

        // GET: SanPham0720_59130033
        public ActionResult Index()
        {
            var sANPHAMs = db.SANPHAMs.Include(s => s.LOAISP);
            return View(sANPHAMs.ToList());
        }

        // GET: SanPham0720_59130033/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: SanPham0720_59130033/Create
        public ActionResult Create()
        {
            ViewBag.MaLSP = new SelectList(db.LOAISPs, "MaLSP", "TenLSP");
            return View();
        }

        // POST: SanPham0720_59130033/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,DVT,DonGia,XuatXu,NCC,GhiChu,MaLSP")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLSP = new SelectList(db.LOAISPs, "MaLSP", "TenLSP", sANPHAM.MaLSP);
            return View(sANPHAM);
        }

        // GET: SanPham0720_59130033/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLSP = new SelectList(db.LOAISPs, "MaLSP", "TenLSP", sANPHAM.MaLSP);
            return View(sANPHAM);
        }

        // POST: SanPham0720_59130033/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,DVT,DonGia,XuatXu,NCC,GhiChu,MaLSP")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLSP = new SelectList(db.LOAISPs, "MaLSP", "TenLSP", sANPHAM.MaLSP);
            return View(sANPHAM);
        }

        // GET: SanPham0720_59130033/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: SanPham0720_59130033/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult TimKiem_59130033()//---------------------------------------
        {
            ViewBag.MaLSP = new SelectList(db.LOAISPs, "MaLSP", "TenLSP");
            var sp = db.SANPHAMs.Include(n => n.LOAISP);
            return View(sp.ToList());
        }

        [HttpGet]
        public ActionResult TimKiem_59130033(String maQA = "", String tenQA = "", String MaLSP = "", int giaMin = 0, int giaMax = int.MaxValue)
        {
            ViewBag.MaLSP = new SelectList(db.LOAISPs, "MaLSP", "TenLSP");
            var sp = db.SANPHAMs.Where(s => s.MaLSP.Contains(MaLSP) && (s.MaSP.Contains(maQA)) && (s.TenSP.Contains(tenQA)))
                            .Where(s => s.DonGia >= giaMin && s.DonGia <= giaMax);

            return View(sp.ToList());
        }
    }
}
