using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.DAL;

namespace WebApi.API.Controllers
{
    public class LanguagesController : ApiController
    {
        LanguagesDAL languagesDAL=new LanguagesDAL();
        public IEnumerable<Languages> Get()
        {
            return languagesDAL.GetAlLanguageses();
        }

        public Languages Get(int id)
        {
            return languagesDAL.GetLanguageById(id);
        }

        public Languages Post(Languages language)
        {
            return languagesDAL.CreateLanguage(language);
            

        }

        public Languages Put(int id, Languages language)
        {
            return languagesDAL.UpdateLanguage(id, language);
        }

        public void Delete(int id)
        {
            languagesDAL.DeleteLanguage(id);
        }
    }
}
