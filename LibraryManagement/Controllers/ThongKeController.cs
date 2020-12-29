using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryManagement.Controllers
{
    public class ThongKeController : ApiController
    {
        LibraryDBDataContext DB = new LibraryDBDataContext();
        // GET: api/ThongKe
        [HttpGet]
        [Route("api/TheLoai")]
        public List<TheLoai> Get_TheLoai()
        {
            return DB.TheLoais.ToList() ;
        }


        [HttpGet]
        [Route("api/PhanLoai")]
        public List<Sach> Get_PhanLoai()
        {
            List<Sach> list = new List<Sach>();
            List<TheLoai_DauSach> theloaidausach = new List<TheLoai_DauSach>();
            TheLoai theloai = new TheLoai();
            theloai = DB.TheLoais.Where(p =>p.TenTheLoai== "Toán học").FirstOrDefault();

            theloaidausach = DB.TheLoai_DauSaches.Where(p=>p.MaTheLoai==theloai.MaTheLoai).ToList();
            foreach(var item in theloaidausach) 
            {
                List<Sach> temp = new List<Sach>();
                temp = DB.Saches.Where(p => p.MaDauSach == item.MaDauSach).ToList();
                list.AddRange(temp);
            }
            return list;
        }
        // GET: api/ThongKe/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ThongKe
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ThongKe/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ThongKe/5
        public void Delete(int id)
        {
        }
    }
}
