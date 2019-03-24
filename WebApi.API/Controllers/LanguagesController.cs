using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.DAL;

namespace WebApi.API.Controllers
{
    public class LanguagesController : ApiController
    {
        LanguagesDAL languagesDAL=new LanguagesDAL();
        
        public IHttpActionResult GetSearchByName(string name)
        {
            return Ok("Name:"+name);
        }
        public IHttpActionResult GetSearchBySurname(string surname)
        {
            return Ok("Surname:" + surname);
        }


        [ResponseType(typeof(IEnumerable<Languages>))]
        public IHttpActionResult Get()
        {
            var language = languagesDAL.GetAlLanguageses();
            return Ok(language);
            //Request.CreateResponse(HttpStatusCode.OK, language);
        }
        [ResponseType(typeof(Languages))]
        public IHttpActionResult Get(int id)
        {
            var language= languagesDAL.GetLanguageById(id);
            if (language == null)
            {
                return NotFound();
            }

            return Ok(language);
        }
        [ResponseType(typeof(Languages))]
        public IHttpActionResult Post(Languages language)
        {
            if (ModelState.IsValid)
            {
                var createdlanguage = languagesDAL.CreateLanguage(language);
                return CreatedAtRoute("DefaultApi", new {id = createdlanguage.ID}, createdlanguage);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [ResponseType(typeof(Languages))]
        public IHttpActionResult Put(int id, Languages language)
        {
            //id ye ait kayıt yoksa
            if (languagesDAL.IsThereAnyLanguage(id) == false)
            {
                return NotFound();
            }
            //language modeli doğrulanmadıysa valid
            else if(ModelState.IsValid==false)
            {
                return BadRequest(ModelState);
            }
            //ok
            else
            {
                return Ok(languagesDAL.UpdateLanguage(id, language));
            }
        }

        public IHttpActionResult Delete(int id)
        {
            if (languagesDAL.IsThereAnyLanguage(id) == false)
            {
                return NotFound();
            }
            else
            {
                languagesDAL.DeleteLanguage(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
