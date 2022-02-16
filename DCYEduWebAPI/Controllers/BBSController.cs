using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DCYEduWebAPI.BLL;
using DCYEduWebAPI.Models;

namespace DCYEduWebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BBSController : ControllerBase
    {

        BBSBll bbll = new();
        [HttpPost]
        public bool AddDialogue([FromBody]Dialogue dialogue)
        {
            return bbll.AddDialogue(dialogue);
        }

        [Route("{className}")]
        [HttpGet]
        public List<Dialogue> GetDialoguesByClass(string className)
        {
            return bbll.GetDialoguesByClass(className);
        }

        [Route("{uid}")]
        [HttpGet]
        public List<Dialogue> GetDialoguesByUid(string uid)
        {
            return bbll.GetDialoguesByUid(uid);
        }

        [Route("{wxid}")]
        [HttpGet]
        public List<Dialogue> GetDialoguesByWxid(string wxid)
        {
            return bbll.GetDialoguesByWxid(wxid);
        }

        [HttpPost]
        public bool UpdateDialogue([FromBody] Dialogue dialogue)
        {
            return bbll.UpdateDialogue(dialogue);
        }

        [Route("{DID}")]
        [HttpGet]
        public List<DialogueSupport> GetSupports(int DID)
        {
            return bbll.GetSupports(DID);
        }

        [Route("{DID}")]
        [HttpGet]
        public List<DialogueReply> GetReply(int DID)
        {
            return bbll.GetReply(DID);
        }

        [Route("{DID}")]
        [HttpDelete]
        public bool DeleteDialogue(int DID)
        {
            return bbll.DeleteDialogue(DID);
        }
    }
}
