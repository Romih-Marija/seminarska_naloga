using web.Models;
using web.Data;
using System;
using System.Linq;

namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(oaContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.UporabniskiRacuni.Any())
            {
                return;   // DB has been seeded
            }

            var uporabniskiRacuni = new UporabniskiRacun[]
            {
                new UporabniskiRacun{uporabniskoIme="Carson Alexander",eposta="carson@gmail.com",geslo="g1",EnrollmentDate=DateTime.Parse("2019-09-01")},
                new UporabniskiRacun{uporabniskoIme="Meredith Alonso",eposta="meredith@gmail.com",geslo="g2",EnrollmentDate=DateTime.Parse("2017-09-01")},
            };

            

            context.UporabniskiRacuni.AddRange(uporabniskiRacuni);
            context.SaveChanges();
            
            context.ObjaveIscemOa.AddRange(
                new ObjavaIscemOa{Ime="Jure",Priimek="Oblak",Lokacija="Koper",DelovniCas="polni delovni čas / dopoldan",Opis="Potrebujem asistenta z izpitom za avto. Hodim v službo za polovični delovni čas. Potrebujem asistenta, ki me lahko vozi do službe, mi nudi spremstvo in pomoč pri jutranji osebni negi.",AvtorObjave="Jure Oblak",DatumObjave=DateTime.Parse("2023-01-02")},
                new ObjavaIscemOa{Ime="Petra",
                    Priimek="Šinkar",
                    Lokacija="Ljubljana",
                    DelovniCas="polni delovni čas/ izmenično",
                    Opis="Potrebujem pomoč pri osebni negi in vsakodnevnih opravilih. Rada hodim na koncerte in rada imam živali. Imam psa spremljevalca, s katerim se veliko sprehajam po naravi.",
                    AvtorObjave="Petra Šinkar",
                    DatumObjave=DateTime.Parse("2023-05-12")},
                new ObjavaIscemOa{Ime="Ana",
                    Priimek="Novak",
                    Lokacija="Maribor",
                    DelovniCas="polovični delovni čas / popoldan",
                    Opis="Potrebujem pomoč pri vsakodnevnih opravilih.",
                    AvtorObjave="Ana Novak",
                    DatumObjave=DateTime.Parse("2024-01-02")}
            );
            context.SaveChanges();

            
        }
    }
}