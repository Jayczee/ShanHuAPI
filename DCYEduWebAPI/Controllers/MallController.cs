using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using DCYEduWebAPI.BLL;
using DCYEduWebAPI.Models;

namespace DCYEduWebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MallController : ControllerBase
    {
        private IHttpContextAccessor _accessor;
        private string _requestip;
        private readonly IWebHostEnvironment _hostingEnvironment;
        MallBll mbll = new();
        public MallController(IHttpContextAccessor accessor,IWebHostEnvironment hostingEnvironment)
        {
            _accessor = accessor;
            _requestip = accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]

        public async Task<IActionResult> FileUpload([FromForm(Name = "file")] IFormFile files)
        {
            if (files == null || files.Length <= 0)
            {
                throw new Exception("Files is Null");
            }

            var fileExt = Path.GetExtension(files.FileName);
            var newFileName = Guid.NewGuid().ToString() + fileExt;
            var path = _hostingEnvironment.WebRootPath + "\\UploadFile";
            var filepath = Path.Combine(path, newFileName);
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                await using var stream = System.IO.File.Create(filepath);
                await files.CopyToAsync(stream);
                string lurl=mbll.GetLocalFileURL(newFileName);
                string curl = mbll.UploadFileToCloud(filepath,stream);
                return Ok(new {fileName = newFileName ,localPath=lurl,cloudpath=curl});
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> FileUploadCloud([FromForm(Name = "file")] IFormFile files)
        {
            if (files == null || files.Length <= 0)
            {
                throw new Exception("Files is Null");
            }

            var fileExt = Path.GetExtension(files.FileName);
            var newFileName = Guid.NewGuid().ToString() + fileExt;
            var path = _hostingEnvironment.WebRootPath + "\\CloudFiles";
            var filepath = Path.Combine(path, newFileName);
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                await using var stream = System.IO.File.Create(filepath);
                await files.CopyToAsync(stream);
                string cloudurl = mbll.GetCloudFileURL(newFileName);
                return Ok(new {fileName = newFileName,cloudpath = cloudurl });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("{uid}")]
        public List<Goods> GetGoodsInfo(string uid)
        {
            return mbll.GetGoodsInfo(uid,_requestip);
        }

        [HttpPost]
        [Route("{uid}")]
        public bool AddGoodsInfo([FromBody]Goods goods,string uid)
        {
            return mbll.AddGoodsInfo(goods,uid,_requestip);
        }

        [HttpPost]
        [Route("{uid}")]
        public bool UpdateGoodsInfo([FromBody] Goods goods, string uid)
        {
            return mbll.UpdateGoodsInfo(goods, uid, _requestip);
        }

        [HttpDelete]
        [Route("{GoodsID}/{uid}")]
        public bool DeleteGoodsInfo(string GoodsID,string uid)
        {
            return mbll.DeleteGoodsInfoByID(GoodsID, uid, _requestip);
        }

        [HttpGet]
        [Route("{classname}/{uid}")]
        public List<GoodsBoughtRecord> GetBoughtRecordByClass(string classname,string uid)
        {
            return mbll.GetBoughtRecordByClass(classname, uid, _requestip);
        }

        [HttpPost]
        [Route("{boughtid}/{con}/{uid}")]
        public bool UpdateBoughtRecord(int boughtid,string con,string uid)
        {
            return mbll.UpdateBoughtRecord(boughtid, con,uid, _requestip);
        }

        [HttpGet]
        [Route("{GoodsID}/{WxId}")]
        public int BuyGoods(int GoodsID,string WxId)
        {
            return mbll.BuyGoods(GoodsID,WxId);
        }
    }
}
