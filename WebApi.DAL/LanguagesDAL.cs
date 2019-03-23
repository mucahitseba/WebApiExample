using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL
{
    public class LanguagesDAL
    {
        ProgrammingDbEntities db=new ProgrammingDbEntities();

        public IEnumerable<Languages> GetAlLanguageses()
        {
            return db.Languages;
        }

        public Languages GetLanguageById(int id)
        {
            return db.Languages.Find(id);
        }

        public Languages CreateLanguage(Languages language)
        {
            db.Languages.Add(language);
            db.SaveChanges();
            return language;
        }

        public Languages UpdateLanguage(int id,Languages language)
        {
            db.Entry(language).State = EntityState.Modified;
            db.SaveChanges();
            return language;
        }

        public void DeleteLanguage(int id)
        {
            db.Languages.Remove(db.Languages.Find(id));
            db.SaveChanges();
        }
    }
}
