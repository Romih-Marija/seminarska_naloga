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
                    DatumObjave=DateTime.Parse("2024-01-02")},
                new ObjavaIscemOa{Ime="Ana",
                    Priimek="Arh",
                    Lokacija="Ljubljana",
                    DelovniCas="polni delovni čas/ izmenično",
                    Opis="",
                    AvtorObjave="Ana Arh",
                    DatumObjave=DateTime.Parse("2023-05-12"),
                    }
            );
            context.SaveChanges();

            context.ObjaveNudimOa.AddRange(
                new ObjavaNudimOa{Ime="Julija",
                    Priimek="Oblak",
                    Lokacija="Koper",
                    Opis="Po izobrazbi sem medicinska sestra, vendar že od začetka delam kot osebna asistentka in imam 5 let izkušenj dela z osebami s posebnimi potrebami. Imam izpit za avto.",
                    AvtorObjave="Julija Oblak",
                    DatumObjave=DateTime.Parse("2023-12-02")},
                new ObjavaNudimOa{Ime="Peter",
                    Priimek="Bogataj",
                    Lokacija="Ljubljana",
                    Opis="Rad bi se preizkusil v delu osebnega asistenta. Izkušenj z osebno aasistenco nimam, rad pa pomagam ljudem, sem prilagodljiv in sem se pripravljen učiti.",
                    AvtorObjave="Peter Bogataj",
                    DatumObjave=DateTime.Parse("2023-06-12")},
                new ObjavaNudimOa{Ime="Mateja",
                    Priimek="Novak",
                    Lokacija="Maribor",
                    Opis="Zanimam se za delo osebne asistentke.",
                    AvtorObjave="Mateja Novak",
                    DatumObjave=DateTime.Parse("2024-01-02")},
                new ObjavaNudimOa{Ime="Anže",
                    Priimek="Lapajne",
                    Lokacija="Postojna",
                    Opis="",
                    AvtorObjave="Anže Lapajne",
                    DatumObjave=DateTime.Parse("2023-07-12"),
                    }
            );
            context.SaveChanges();

            context.NudimNadomescanje.AddRange(
                new NudimNadomescanje{Ime="Julči",
                    Priimek="Mrak",
                    Lokacija="Postojna",
                    AvtorObjave="Julči Mrak",
                    OdDatuma=DateTime.Parse("2024-02-01"),
                    DoDatuma=DateTime.Parse("2024-02-20"),
                    },
                new NudimNadomescanje{Ime="Jure",
                    Priimek="Trelec",
                    Lokacija="Črnomelj",
                    AvtorObjave="Jure Trelec",
                    OdDatuma=DateTime.Parse("2024-01-12"),
                    DoDatuma=DateTime.Parse("2024-02-02"),
                    },
                new NudimNadomescanje
                {
                    Ime = "Nejc",
                    Priimek = "Novak",
                    Lokacija = "Maribor",
                    AvtorObjave = "Nejc Novak",
                    OdDatuma = DateTime.Parse("2024-01-15"),
                    DoDatuma = DateTime.Parse("2024-02-28"),
                },
                new NudimNadomescanje
                {
                    Ime = "Lea",
                    Priimek = "Mlakar",
                    Lokacija = "Kranj",
                    AvtorObjave = "Lea Mlakar",
                    OdDatuma = DateTime.Parse("2024-02-10"),
                    DoDatuma = DateTime.Parse("2024-02-25"),
                },
                new NudimNadomescanje
                {
                    Ime = "Tine",
                    Priimek = "Kovač",
                    Lokacija = "Ljubljana",
                    AvtorObjave = "Tine Kovač",
                    OdDatuma = DateTime.Parse("2024-02-05"),
                    DoDatuma = DateTime.Parse("2024-02-15"),
                }
            );
            context.SaveChanges();
            
            context.IscemNadomescanje.AddRange(
                new IscemNadomescanje{Ime="Anita",
                    Priimek="Mrak",
                    Lokacija="Postojna",
                    AvtorObjave="Anita Mrak",
                    OdDatuma=DateTime.Parse("2024-02-01"),
                    DoDatuma=DateTime.Parse("2024-02-20"),
                    },
                new IscemNadomescanje{Ime="Mark",
                    Priimek="Trelec",
                    Lokacija="Črnomelj",
                    AvtorObjave="Mark Trelec",
                    OdDatuma=DateTime.Parse("2024-01-12"),
                    DoDatuma=DateTime.Parse("2024-02-02"),
                    },
                new IscemNadomescanje
                {
                    Ime = "Tina",
                    Priimek = "Novak",
                    Lokacija = "Maribor",
                    AvtorObjave = "Tina Novak",
                    OdDatuma = DateTime.Parse("2024-02-15"),
                    DoDatuma = DateTime.Parse("2024-02-28"),
                },
                new IscemNadomescanje
                {
                    Ime = "Luka",
                    Priimek = "Mlakar",
                    Lokacija = "Kranj",
                    AvtorObjave = "Luka Mlakar",
                    OdDatuma = DateTime.Parse("2024-02-10"),
                    DoDatuma = DateTime.Parse("2024-02-25"),
                },
                new IscemNadomescanje
                {
                    Ime = "Živa",
                    Priimek = "Kovač",
                    Lokacija = "Ljubljana",
                    AvtorObjave = "Živa Kovač",
                    OdDatuma = DateTime.Parse("2024-02-05"),
                    DoDatuma = DateTime.Parse("2024-02-15"),
                }
                );
            context.SaveChanges();
        }
    }
}