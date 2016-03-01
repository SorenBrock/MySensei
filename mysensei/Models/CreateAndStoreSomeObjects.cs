using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace mysensei.Models
{
    public partial class Repository
    {
        readonly Random _rnd = new Random();

        public void CreateAndStoreSomeObjects()
        {
            #region [Destroy Data]

            foreach (var course in _db.CourseSet.ToList())
                course.Tag.ToList().ForEach(x => x.Course.Remove(course));
            foreach (var tagGroupSet in _db.TagGroupSet.ToList())
                tagGroupSet.Tag.ToList().ForEach(x => x.TagGroup.Remove(tagGroupSet));

            _db.TagSet.RemoveRange(_db.TagSet);
            _db.TagGroupSet.RemoveRange(_db.TagGroupSet);
            _db.AdministratorSet.RemoveRange(_db.AdministratorSet);
            _db.RatingSet.RemoveRange(_db.RatingSet);

            // Destroy chat
            _db.LogChatReadSet.RemoveRange(_db.LogChatReadSet);
            _db.ChatSet.RemoveRange(_db.ChatSet);
            foreach (var chatRoom in _db.ChatRoomSet.ToList())
                chatRoom.Person.ToList().ForEach(x => x.ChatRoom.Remove(chatRoom));
            _db.ChatRoomSet.RemoveRange(_db.ChatRoomSet);

            _db.SaveChanges();

            foreach (var person in _db.PersonSet.ToList())
                person.StudentCourse.ToList().ForEach(x => x.Student.Remove(person));

            _db.CourseSet.RemoveRange(_db.CourseSet);
            _db.LocationCitySet.RemoveRange(_db.LocationCitySet);
            _db.LocationGroupSet.RemoveRange(_db.LocationGroupSet);
            _db.PersonSet.RemoveRange(_db.PersonSet);

            _db.SaveChanges();

            #endregion [Destroy Data]

            #region [Create Data] 

            #region [Tags]

            // TagGroup
            var tgMusic = new TagGroup
            {
                Name = "Musik",
            };

            _db.TagGroupSet.Add(tgMusic);

            var tgLanguage = new TagGroup
            {
                Name = "Sprog",
            };

            _db.TagGroupSet.Add(tgLanguage);

            var tgFood = new TagGroup
            {
                Name = "Mad",
            };

            _db.TagGroupSet.Add(tgFood);

            var tgBusiness = new TagGroup
            {
                Name = "Erhverv",
            };

            _db.TagGroupSet.Add(tgBusiness);

            var tgWine = new TagGroup
            {
                Name = "Vin",
            };

            _db.TagGroupSet.Add(tgWine);

            var tgTec = new TagGroup
            {
                Name = "Teknik",
            };

            _db.TagGroupSet.Add(tgTec);

            var tgMindfullness = new TagGroup
            {
                Name = "Livet",
            };

            _db.TagGroupSet.Add(tgMindfullness);

            var tgSchool = new TagGroup
            {
                Name = "Folkeskole",
            };

            _db.TagGroupSet.Add(tgSchool);

            var tgSport = new TagGroup
            {
                Name = "Sport",
            };

            _db.TagGroupSet.Add(tgSport);

            var tgGymnasium = new TagGroup
            {
                Name = "Gymnasium",
            };

            _db.TagGroupSet.Add(tgGymnasium);

            var tgUni = new TagGroup
            {
                Name = "Universitet",
            };

            _db.TagGroupSet.Add(tgUni);

            //tagList
            var listTags = new List<Tag>
            {
new Tag {Name = "Akupunktur", TagGroup = new[] {tgMindfullness}},
new Tag {Name = "Almen Biologi", TagGroup = new[] {tgSchool, tgGymnasium}},
new Tag {Name = "Arabisk", TagGroup = new[] {tgLanguage, tgFood, tgSchool}},
new Tag {Name = "Arbejdslivsstudier", TagGroup = new[] {tgBusiness, tgUni}},
new Tag {Name = "Babyrytmik", TagGroup = new[] {tgMusic}},
new Tag {Name = "Banjo", TagGroup = new[] {tgMusic}},
new Tag {Name = "Billedkunst", TagGroup = new[] {tgSchool, tgGymnasium}},
new Tag {Name = "Biologi", TagGroup = new[] {tgSchool, tgGymnasium, tgUni}},
new Tag {Name = "Blokfløjte", TagGroup = new[] {tgMusic}},
new Tag {Name = "Blæsergruppe", TagGroup = new[] {tgMusic}},
new Tag {Name = "Bratsch", TagGroup = new[] {tgMusic}},
new Tag {Name = "Cello", TagGroup = new[] { tgMusic}},
new Tag {Name = "Computermusik", TagGroup = new[] {tgMusic}},
new Tag {Name = "Dansk", TagGroup = new[] {tgLanguage, tgSchool, tgGymnasium}},
new Tag {Name = "Datalogi ", TagGroup = new[] {tgTec, tgUni}},
new Tag {Name = "Datamatiker", TagGroup = new[] {tgTec}},
new Tag {Name = "El-bas", TagGroup = new[] {tgMusic}},
new Tag {Name = "El-guitar", TagGroup = new[] {tgMusic}},
new Tag {Name = "Engelsk", TagGroup = new[] {tgLanguage, tgFood, tgSchool, tgGymnasium, tgUni}},
new Tag {Name = "Entreprenørskab", TagGroup = new[] {tgBusiness,tgTec, tgGymnasium, tgUni}},
new Tag {Name = "Erhvervsøkonomi (HA)", TagGroup = new[] {tgBusiness, tgGymnasium, tgUni}},
new Tag {Name = "Filosofi og Videnskabsteori", TagGroup = new[] {tgBusiness, tgMindfullness, tgGymnasium, tgUni}},
new Tag {Name = "Forvaltning", TagGroup = new[] {tgBusiness}},
new Tag {Name = "Fransk", TagGroup = new[] {tgLanguage, tgFood, tgWine, tgSchool, tgGymnasium, tgUni}},
new Tag {Name = "Fysik", TagGroup = new[] {tgSchool, tgGymnasium, tgUni}},
new Tag {Name = "Fysik/kemi", TagGroup = new[] {tgSchool, tgGymnasium}},
new Tag {Name = "Geografi", TagGroup = new[] {tgSchool, tgGymnasium, tgUni}},
new Tag {Name = "Global Studies", TagGroup = new[] {tgGymnasium, tgUni}},
new Tag {Name = "Guitar", TagGroup = new[] {tgMusic}},
new Tag {Name = "Guitarsammenspil", TagGroup = new[] {tgMusic}},
new Tag {Name = "Harmonika", TagGroup = new[] {tgMusic}},
new Tag {Name = "Healing", TagGroup = new[] {tgMindfullness}},
new Tag {Name = "Historie", TagGroup = new[] {tgSchool, tgGymnasium, tgUni}},
new Tag {Name = "Hjemkundskab", TagGroup = new[] {tgSchool, tgGymnasium}},
new Tag {Name = "Håndarbejde", TagGroup = new[] {tgSchool, tgGymnasium}},
new Tag {Name = "Idræt", TagGroup = new[] {tgSchool, tgSport, tgGymnasium, tgUni}},
new Tag {Name = "Italiensk", TagGroup = new[] {tgLanguage, tgFood, tgWine, tgUni }},
new Tag {Name = "Informatik", TagGroup = new[] {tgBusiness, tgUni}},
new Tag {Name = "Interventionsstudier", TagGroup = new[] {tgBusiness, tgUni}},
new Tag {Name = "IT-Concept", TagGroup = new[] {tgBusiness, tgTec, tgUni}},
new Tag {Name = "IT-Teknolog", TagGroup = new[] {tgTec, tgUni}},
new Tag {Name = "Japansk", TagGroup = new[] {tgLanguage, tgFood, tgSchool, tgUni}},
new Tag {Name = "Journalistik", TagGroup = new[] {tgUni}},
new Tag {Name = "Kemi", TagGroup = new[] {tgSchool, tgGymnasium, tgUni}},
new Tag {Name = "Keyboard", TagGroup = new[] {tgMusic}},
new Tag {Name = "Kinesisk", TagGroup = new[] {tgLanguage, tgFood, tgUni }},
new Tag {Name = "Klaver", TagGroup = new[] {tgMusic}},
new Tag {Name = "Klaveriolin", TagGroup = new[] {tgMusic}},
new Tag {Name = "Kommunikation", TagGroup = new[] {tgGymnasium, tgUni}},
new Tag {Name = "Kontrabas", TagGroup = new[] {tgMusic}},
new Tag {Name = "Kristendomskundskab", TagGroup = new[] {tgSchool, tgGymnasium, tgUni}},
new Tag {Name = "Krystaller", TagGroup = new[] {tgMindfullness}},
new Tag {Name = "Kultur- og Sprogmødestudier", TagGroup = new[] { tgUni}},
new Tag {Name = "Matematik", TagGroup = new[] {tgSchool, tgGymnasium, tgUni}},
new Tag {Name = "Medicinalbiologi", TagGroup = new[] {tgUni}},
new Tag {Name = "Meditation", TagGroup = new[] {tgMindfullness}},
new Tag {Name = "Miljøbiologi ", TagGroup = new[] {tgSchool, tgUni}},
new Tag {Name = "Mad", TagGroup = new[] {tgFood, tgWine}},
new Tag {Name = "Vin ", TagGroup = new[] {tgFood, tgWine}},
new Tag {Name = "Multimedie", TagGroup = new[] {tgTec, tgUni}},
new Tag {Name = "Musik", TagGroup = new[] {tgMusic, tgSchool, tgGymnasium, tgUni}},
new Tag {Name = "Musikalsk legestue", TagGroup = new[] {tgMusic}},
new Tag {Name = "Musikkarrussel", TagGroup = new[] {tgMusic}},
new Tag {Name = "Natur/teknik", TagGroup = new[] {tgSchool}},
new Tag {Name = "Norsk", TagGroup = new[] {tgLanguage}},
new Tag {Name = "Orkester", TagGroup = new[] {tgMusic}},
new Tag {Name = "Performance-design", TagGroup = new[] {tgUni}},
new Tag {Name = "Plan, By og Proces", TagGroup = new[] {tgUni}},
new Tag {Name = "Politik", TagGroup = new[] {tgUni}},
new Tag {Name = "Psykologi", TagGroup = new[] {tgSchool, tgGymnasium, tgUni}},
new Tag {Name = "Pædagogik", TagGroup = new[] {tgUni}},
new Tag {Name = "Rockgruppe", TagGroup = new[] {tgMusic}},
new Tag {Name = "Rockgruppekeyboard", TagGroup = new[] {tgMusic}},
new Tag {Name = "Samfundsfag", TagGroup = new[] {tgSchool}},
new Tag {Name = "Sang", TagGroup = new[] {tgMusic}},
new Tag {Name = "Skole", TagGroup = new[] { tgSchool, tgGymnasium, tgUni}},
new Tag {Name = "Sløjd", TagGroup = new[] {tgSchool}},
new Tag {Name = "Socialvidenskab", TagGroup = new[] { tgUni}},
new Tag {Name = "Spansk", TagGroup = new[] {tgLanguage, tgFood, tgWine, tgSchool, tgUni}},
new Tag {Name = "Sprog", TagGroup = new[] {tgSchool, tgGymnasium, tgUni}},
new Tag {Name = "Svensk", TagGroup = new[] {tgLanguage}},
new Tag {Name = "TekSam", TagGroup = new[] {tgTec}},
new Tag {Name = "Teknik", TagGroup = new[] {tgTec}},
new Tag {Name = "Trommer", TagGroup = new[] {tgMusic}},
new Tag {Name = "Trompet", TagGroup = new[] {tgMusic}},
new Tag {Name = "Trækbasun", TagGroup = new[] {tgMusic}},
new Tag {Name = "Tværfløjte", TagGroup = new[] {tgMusic}},
new Tag {Name = "Tyrkisk", TagGroup = new[] {tgLanguage, tgFood}},
new Tag {Name = "Tysk", TagGroup = new[] {tgLanguage, tgFood, tgWine, tgSchool, tgGymnasium, tgUni}},
new Tag {Name = "Ukulele", TagGroup = new[] {tgMusic}},
new Tag {Name = "Valdhorn", TagGroup = new[] {tgMusic}},
new Tag {Name = "Violin", TagGroup = new[] {tgMusic}},
new Tag {Name = "Virksomhedsledelse", TagGroup = new[] {tgBusiness, tgUni}},
new Tag {Name = "Virksomhedsstudier", TagGroup = new[] {tgBusiness, tgGymnasium, tgUni}}
    };

            foreach (var tag in listTags)
                _db.TagSet.Add(tag);
            _db.SaveChanges();

            #endregion [Tags]

            #region [PostNr]
            var listPostNr = new List<LocationCity> {
new LocationCity {ZipcodeStart = 1000,ZipcodeEnd = 1499,City = "København K"},
new LocationCity {ZipcodeStart = 1500,ZipcodeEnd = 1799,City = "København V"},
new LocationCity {ZipcodeStart = 1800,ZipcodeEnd = 1999,City = "Frederiksberg C"},
new LocationCity {ZipcodeStart = 2000,City = "Frederiksberg"},
new LocationCity {ZipcodeStart = 2100,City = "København Ø"},
new LocationCity {ZipcodeStart = 2200,City = "København N"},
new LocationCity {ZipcodeStart = 2300,City = "København S"},
new LocationCity {ZipcodeStart = 2400,City = "København NV"},
new LocationCity {ZipcodeStart = 2450,City = "København SV"},
new LocationCity {ZipcodeStart = 2500,City = "Valby"},
new LocationCity {ZipcodeStart = 2600,City = "Glostrup"},
new LocationCity {ZipcodeStart = 2605,City = "Brøndby"},
new LocationCity {ZipcodeStart = 2610,City = "Rødovre"},
new LocationCity {ZipcodeStart = 2620,City = "Albertslund"},
new LocationCity {ZipcodeStart = 2625,City = "Vallensbæk"},
new LocationCity {ZipcodeStart = 2630,City = "Taastrup"},
new LocationCity {ZipcodeStart = 2633,City = "Taastrup Nordsjællands Postcenter"},
new LocationCity {ZipcodeStart = 2635,City = "Ishøj"},
new LocationCity {ZipcodeStart = 2640,City = "Hedehusene"},
new LocationCity {ZipcodeStart = 2650,City = "Hvidovre"},
new LocationCity {ZipcodeStart = 2660,City = "Brøndby Strand"},
new LocationCity {ZipcodeStart = 2665,City = "Vallensbæk Strand"},
new LocationCity {ZipcodeStart = 2670,City = "Greve"},
new LocationCity {ZipcodeStart = 2680,City = "Solrød Strand"},
new LocationCity {ZipcodeStart = 2690,City = "Karlslunde"},
new LocationCity {ZipcodeStart = 2700,City = "Brønshøj"},
new LocationCity {ZipcodeStart = 2720,City = "Vanløse"},
new LocationCity {ZipcodeStart = 2730,City = "Herlev"},
new LocationCity {ZipcodeStart = 2740,City = "Skovlunde"},
new LocationCity {ZipcodeStart = 2750,City = "Ballerup"},
new LocationCity {ZipcodeStart = 2760,City = "Måløv"},
new LocationCity {ZipcodeStart = 2765,City = "Smørum"},
new LocationCity {ZipcodeStart = 2770,City = "Kastrup"},
new LocationCity {ZipcodeStart = 2791,City = "Dragør"},
new LocationCity {ZipcodeStart = 2800,City = "Kongens Lyngby"},
new LocationCity {ZipcodeStart = 2820,City = "Gentofte"},
new LocationCity {ZipcodeStart = 2830,City = "Virum"},
new LocationCity {ZipcodeStart = 2840,City = "Holte"},
new LocationCity {ZipcodeStart = 2850,City = "Nærum"},
new LocationCity {ZipcodeStart = 2860,City = "Søborg"},
new LocationCity {ZipcodeStart = 2870,City = "Dyssegård"},
new LocationCity {ZipcodeStart = 2880,City = "Bagsværd"},
new LocationCity {ZipcodeStart = 2900,City = "Hellerup"},
new LocationCity {ZipcodeStart = 2920,City = "Charlottenlund"},
new LocationCity {ZipcodeStart = 2930,City = "Klampenborg"},
new LocationCity {ZipcodeStart = 2942,City = "Skodsborg"},
new LocationCity {ZipcodeStart = 2950,City = "Vedbæk"},
new LocationCity {ZipcodeStart = 2960,City = "Rungsted Kyst"},
new LocationCity {ZipcodeStart = 2970,City = "Hørsholm"},
new LocationCity {ZipcodeStart = 2980,City = "Kokkedal"},
new LocationCity {ZipcodeStart = 2990,City = "Nivå"},
new LocationCity {ZipcodeStart = 3000,City = "Helsingør"},
new LocationCity {ZipcodeStart = 3050,City = "Humlebæk"},
new LocationCity {ZipcodeStart = 3060,City = "Espergærde"},
new LocationCity {ZipcodeStart = 3070,City = "Snekkersten"},
new LocationCity {ZipcodeStart = 3080,City = "Tikøb"},
new LocationCity {ZipcodeStart = 3100,City = "Hornbæk"},
new LocationCity {ZipcodeStart = 3120,City = "Dronningmølle"},
new LocationCity {ZipcodeStart = 3140,City = "Ålsgårde"},
new LocationCity {ZipcodeStart = 3150,City = "Hellebæk"},
new LocationCity {ZipcodeStart = 3200,City = "Helsinge"},
new LocationCity {ZipcodeStart = 3210,City = "Vejby"},
new LocationCity {ZipcodeStart = 3220,City = "Tisvildeleje"},
new LocationCity {ZipcodeStart = 3230,City = "Græsted"},
new LocationCity {ZipcodeStart = 3250,City = "Gilleleje"},
new LocationCity {ZipcodeStart = 3300,City = "Frederiksværk"},
new LocationCity {ZipcodeStart = 3310,City = "Ølsted"},
new LocationCity {ZipcodeStart = 3320,City = "Skævinge"},
new LocationCity {ZipcodeStart = 3330,City = "Gørløse"},
new LocationCity {ZipcodeStart = 3360,City = "Liseleje"},
new LocationCity {ZipcodeStart = 3370,City = "Melby"},
new LocationCity {ZipcodeStart = 3390,City = "Hundested"},
new LocationCity {ZipcodeStart = 3400,City = "Hillerød"},
new LocationCity {ZipcodeStart = 3450,City = "Allerød"},
new LocationCity {ZipcodeStart = 3460,City = "Birkerød"},
new LocationCity {ZipcodeStart = 3480,City = "Fredensborg"},
new LocationCity {ZipcodeStart = 3490,City = "Kvistgård"},
new LocationCity {ZipcodeStart = 3500,City = "Værløse"},
new LocationCity {ZipcodeStart = 3520,City = "Farum"},
new LocationCity {ZipcodeStart = 3540,City = "Lynge"},
new LocationCity {ZipcodeStart = 3550,City = "Slangerup"},
new LocationCity {ZipcodeStart = 3600,City = "Frederikssund"},
new LocationCity {ZipcodeStart = 3630,City = "Jægerspris"},
new LocationCity {ZipcodeStart = 3650,City = "Ølstykke"},
new LocationCity {ZipcodeStart = 3660,City = "Stenløse"},
new LocationCity {ZipcodeStart = 3670,City = "Veksø Sjælland"},
new LocationCity {ZipcodeStart = 3700,City = "Rønne"},
new LocationCity {ZipcodeStart = 3720,City = "Aakirkeby"},
new LocationCity {ZipcodeStart = 3730,City = "Nexø"},
new LocationCity {ZipcodeStart = 3740,City = "Svaneke"},
new LocationCity {ZipcodeStart = 3751,City = "Østermarie"},
new LocationCity {ZipcodeStart = 3760,City = "Gudhjem"},
new LocationCity {ZipcodeStart = 3770,City = "Allinge"},
new LocationCity {ZipcodeStart = 3782,City = "Klemensker"},
new LocationCity {ZipcodeStart = 3790,City = "Hasle"},
new LocationCity {ZipcodeStart = 4000,City = "Roskilde"},
new LocationCity {ZipcodeStart = 4040,City = "Jyllinge"},
new LocationCity {ZipcodeStart = 4050,City = "Skibby"},
new LocationCity {ZipcodeStart = 4060,City = "Kirke Såby"},
new LocationCity {ZipcodeStart = 4070,City = "Kirke Hyllinge"},
new LocationCity {ZipcodeStart = 4100,City = "Ringsted"},
new LocationCity {ZipcodeStart = 4105,City = "Ringsted Midtsjællands Postcenter"},
new LocationCity {ZipcodeStart = 4130,City = "Viby Sjælland"},
new LocationCity {ZipcodeStart = 4140,City = "Borup"},
new LocationCity {ZipcodeStart = 4160,City = "Herlufmagle"},
new LocationCity {ZipcodeStart = 4171,City = "Glumsø"},
new LocationCity {ZipcodeStart = 4173,City = "Fjenneslev"},
new LocationCity {ZipcodeStart = 4174,City = "Jystrup Midtsjælland"},
new LocationCity {ZipcodeStart = 4180,City = "Sorø"},
new LocationCity {ZipcodeStart = 4190,City = "Munke Bjergby"},
new LocationCity {ZipcodeStart = 4200,City = "Slagelse"},
new LocationCity {ZipcodeStart = 4220,City = "Korsør"},
new LocationCity {ZipcodeStart = 4230,City = "Skælskør"},
new LocationCity {ZipcodeStart = 4241,City = "Vemmelev"},
new LocationCity {ZipcodeStart = 4242,City = "Boeslunde"},
new LocationCity {ZipcodeStart = 4243,City = "Rude"},
new LocationCity {ZipcodeStart = 4250,City = "Fuglebjerg"},
new LocationCity {ZipcodeStart = 4261,City = "Dalmose"},
new LocationCity {ZipcodeStart = 4262,City = "Sandved"},
new LocationCity {ZipcodeStart = 4270,City = "Høng"},
new LocationCity {ZipcodeStart = 4281,City = "Gørlev"},
new LocationCity {ZipcodeStart = 4291,City = "Ruds Vedby"},
new LocationCity {ZipcodeStart = 4293,City = "Dianalund"},
new LocationCity {ZipcodeStart = 4295,City = "Stenlille"},
new LocationCity {ZipcodeStart = 4296,City = "Nyrup"},
new LocationCity {ZipcodeStart = 4300,City = "Holbæk"},
new LocationCity {ZipcodeStart = 4320,City = "Lejre"},
new LocationCity {ZipcodeStart = 4330,City = "Hvalsø"},
new LocationCity {ZipcodeStart = 4340,City = "Tølløse"},
new LocationCity {ZipcodeStart = 4350,City = "Ugerløse"},
new LocationCity {ZipcodeStart = 4360,City = "Kirke Eskilstrup"},
new LocationCity {ZipcodeStart = 4370,City = "Store Merløse"},
new LocationCity {ZipcodeStart = 4390,City = "Vipperød"},
new LocationCity {ZipcodeStart = 4400,City = "Kalundborg"},
new LocationCity {ZipcodeStart = 4420,City = "Regstrup"},
new LocationCity {ZipcodeStart = 4440,City = "Mørkøv"},
new LocationCity {ZipcodeStart = 4450,City = "Jyderup"},
new LocationCity {ZipcodeStart = 4460,City = "Snertinge"},
new LocationCity {ZipcodeStart = 4470,City = "Svebølle"},
new LocationCity {ZipcodeStart = 4480,City = "Store Fuglede"},
new LocationCity {ZipcodeStart = 4490,City = "Jerslev Sjælland"},
new LocationCity {ZipcodeStart = 4500,City = "Nykøbing Sjælland"},
new LocationCity {ZipcodeStart = 4520,City = "Svinninge"},
new LocationCity {ZipcodeStart = 4532,City = "Gislinge"},
new LocationCity {ZipcodeStart = 4534,City = "Hørve"},
new LocationCity {ZipcodeStart = 4540,City = "Fårevejle"},
new LocationCity {ZipcodeStart = 4550,City = "Asnæs"},
new LocationCity {ZipcodeStart = 4560,City = "Vig"},
new LocationCity {ZipcodeStart = 4571,City = "Grevinge"},
new LocationCity {ZipcodeStart = 4572,City = "Nørre Asmindrup"},
new LocationCity {ZipcodeStart = 4573,City = "Højby"},
new LocationCity {ZipcodeStart = 4581,City = "Rørvig"},
new LocationCity {ZipcodeStart = 4583,City = "Sjællands Odde"},
new LocationCity {ZipcodeStart = 4591,City = "Føllenslev"},
new LocationCity {ZipcodeStart = 4592,City = "Sejerø"},
new LocationCity {ZipcodeStart = 4593,City = "Eskebjerg"},
new LocationCity {ZipcodeStart = 4600,City = "Køge"},
new LocationCity {ZipcodeStart = 4621,City = "Gadstrup"},
new LocationCity {ZipcodeStart = 4622,City = "Havdrup"},
new LocationCity {ZipcodeStart = 4623,City = "Lille Skensved"},
new LocationCity {ZipcodeStart = 4632,City = "Bjæverskov"},
new LocationCity {ZipcodeStart = 4640,City = "Fakse"},
new LocationCity {ZipcodeStart = 4652,City = "Hårlev"},
new LocationCity {ZipcodeStart = 4653,City = "Karise"},
new LocationCity {ZipcodeStart = 4654,City = "Fakse Ladeplads"},
new LocationCity {ZipcodeStart = 4660,City = "Store Heddinge"},
new LocationCity {ZipcodeStart = 4671,City = "Strøby"},
new LocationCity {ZipcodeStart = 4672,City = "Klippinge"},
new LocationCity {ZipcodeStart = 4673,City = "Rødvig Stevns"},
new LocationCity {ZipcodeStart = 4681,City = "Herfølge"},
new LocationCity {ZipcodeStart = 4682,City = "Tureby"},
new LocationCity {ZipcodeStart = 4683,City = "Rønnede"},
new LocationCity {ZipcodeStart = 4684,City = "Holmegaard"},
new LocationCity {ZipcodeStart = 4690,City = "Haslev"},
new LocationCity {ZipcodeStart = 4700,City = "Næstved"},
new LocationCity {ZipcodeStart = 4720,City = "Præstø"},
new LocationCity {ZipcodeStart = 4733,City = "Tappernøje"},
new LocationCity {ZipcodeStart = 4735,City = "Mern"},
new LocationCity {ZipcodeStart = 4736,City = "Karrebæksminde"},
new LocationCity {ZipcodeStart = 4750,City = "Lundby"},
new LocationCity {ZipcodeStart = 4760,City = "Vordingborg"},
new LocationCity {ZipcodeStart = 4771,City = "Kalvehave"},
new LocationCity {ZipcodeStart = 4772,City = "Langebæk"},
new LocationCity {ZipcodeStart = 4773,City = "Stensved"},
new LocationCity {ZipcodeStart = 4780,City = "Stege"},
new LocationCity {ZipcodeStart = 4791,City = "Borre"},
new LocationCity {ZipcodeStart = 4792,City = "Askeby"},
new LocationCity {ZipcodeStart = 4793,City = "Bogø By"},
new LocationCity {ZipcodeStart = 4800,City = "Nykøbing Falster"},
new LocationCity {ZipcodeStart = 4840,City = "Nørre Alslev"},
new LocationCity {ZipcodeStart = 4850,City = "Stubbekøbing"},
new LocationCity {ZipcodeStart = 4862,City = "Guldborg"},
new LocationCity {ZipcodeStart = 4863,City = "Eskilstrup"},
new LocationCity {ZipcodeStart = 4871,City = "Horbelev"},
new LocationCity {ZipcodeStart = 4872,City = "Idestrup"},
new LocationCity {ZipcodeStart = 4873,City = "Væggerløse"},
new LocationCity {ZipcodeStart = 4874,City = "Gedser"},
new LocationCity {ZipcodeStart = 4880,City = "Nysted"},
new LocationCity {ZipcodeStart = 4891,City = "Toreby Lolland"},
new LocationCity {ZipcodeStart = 4892,City = "Kettinge"},
new LocationCity {ZipcodeStart = 4894,City = "Øster Ulslev"},
new LocationCity {ZipcodeStart = 4895,City = "Errindlev"},
new LocationCity {ZipcodeStart = 4900,City = "Nakskov"},
new LocationCity {ZipcodeStart = 4912,City = "Harpelunde"},
new LocationCity {ZipcodeStart = 4913,City = "Horslunde"},
new LocationCity {ZipcodeStart = 4920,City = "Søllested"},
new LocationCity {ZipcodeStart = 4930,City = "Maribo"},
new LocationCity {ZipcodeStart = 4941,City = "Bandholm"},
new LocationCity {ZipcodeStart = 4943,City = "Torrig Lolland"},
new LocationCity {ZipcodeStart = 4944,City = "Fejø"},
new LocationCity {ZipcodeStart = 4951,City = "Nørreballe"},
new LocationCity {ZipcodeStart = 4952,City = "Stokkemarke"},
new LocationCity {ZipcodeStart = 4953,City = "Vesterborg"},
new LocationCity {ZipcodeStart = 4960,City = "Holeby"},
new LocationCity {ZipcodeStart = 4970,City = "Rødby"},
new LocationCity {ZipcodeStart = 4983,City = "Dannemare"},
new LocationCity {ZipcodeStart = 4990,City = "Sakskøbing"},
new LocationCity {ZipcodeStart = 5000,City = "Odense C"},
new LocationCity {ZipcodeStart = 5090,City = "Odense C Fyns Postcenter"},
new LocationCity {ZipcodeStart = 5200,City = "Odense V"},
new LocationCity {ZipcodeStart = 5210,City = "Odense NV"},
new LocationCity {ZipcodeStart = 5220,City = "Odense SØ"},
new LocationCity {ZipcodeStart = 5230,City = "Odense M"},
new LocationCity {ZipcodeStart = 5240,City = "Odense NØ"},
new LocationCity {ZipcodeStart = 5250,City = "Odense SV"},
new LocationCity {ZipcodeStart = 5260,City = "Odense S"},
new LocationCity {ZipcodeStart = 5270,City = "Odense N"},
new LocationCity {ZipcodeStart = 5290,City = "Marslev"},
new LocationCity {ZipcodeStart = 5300,City = "Kerteminde"},
new LocationCity {ZipcodeStart = 5320,City = "Agedrup"},
new LocationCity {ZipcodeStart = 5330,City = "Munkebo"},
new LocationCity {ZipcodeStart = 5350,City = "Rynkeby"},
new LocationCity {ZipcodeStart = 5370,City = "Mesinge"},
new LocationCity {ZipcodeStart = 5380,City = "Dalby"},
new LocationCity {ZipcodeStart = 5390,City = "Martofte"},
new LocationCity {ZipcodeStart = 5400,City = "Bogense"},
new LocationCity {ZipcodeStart = 5450,City = "Otterup"},
new LocationCity {ZipcodeStart = 5462,City = "Morud"},
new LocationCity {ZipcodeStart = 5463,City = "Harndrup"},
new LocationCity {ZipcodeStart = 5464,City = "Brenderup Fyn"},
new LocationCity {ZipcodeStart = 5466,City = "Asperup"},
new LocationCity {ZipcodeStart = 5471,City = "Søndersø"},
new LocationCity {ZipcodeStart = 5474,City = "Veflinge"},
new LocationCity {ZipcodeStart = 5485,City = "Skamby"},
new LocationCity {ZipcodeStart = 5491,City = "Blommenslyst"},
new LocationCity {ZipcodeStart = 5492,City = "Vissenbjerg"},
new LocationCity {ZipcodeStart = 5500,City = "Middelfart"},
new LocationCity {ZipcodeStart = 5540,City = "Ullerslev"},
new LocationCity {ZipcodeStart = 5550,City = "Langeskov"},
new LocationCity {ZipcodeStart = 5560,City = "Aarup"},
new LocationCity {ZipcodeStart = 5580,City = "Nørre Aaby"},
new LocationCity {ZipcodeStart = 5591,City = "Gelsted"},
new LocationCity {ZipcodeStart = 5592,City = "Ejby"},
new LocationCity {ZipcodeStart = 5600,City = "Faaborg"},
new LocationCity {ZipcodeStart = 5610,City = "Assens"},
new LocationCity {ZipcodeStart = 5620,City = "Glamsbjerg"},
new LocationCity {ZipcodeStart = 5631,City = "Ebberup"},
new LocationCity {ZipcodeStart = 5642,City = "Millinge"},
new LocationCity {ZipcodeStart = 5672,City = "Broby"},
new LocationCity {ZipcodeStart = 5683,City = "Haarby"},
new LocationCity {ZipcodeStart = 5690,City = "Tommerup"},
new LocationCity {ZipcodeStart = 5700,City = "Svendborg"},
new LocationCity {ZipcodeStart = 5750,City = "Ringe"},
new LocationCity {ZipcodeStart = 5762,City = "Vester Skerninge"},
new LocationCity {ZipcodeStart = 5771,City = "Stenstrup"},
new LocationCity {ZipcodeStart = 5772,City = "Kværndrup"},
new LocationCity {ZipcodeStart = 5792,City = "Årslev"},
new LocationCity {ZipcodeStart = 5800,City = "Nyborg"},
new LocationCity {ZipcodeStart = 5853,City = "Ørbæk"},
new LocationCity {ZipcodeStart = 5854,City = "Gislev"},
new LocationCity {ZipcodeStart = 5856,City = "Ryslinge"},
new LocationCity {ZipcodeStart = 5863,City = "Ferritslev Fyn"},
new LocationCity {ZipcodeStart = 5871,City = "Frørup"},
new LocationCity {ZipcodeStart = 5874,City = "Hesselager"},
new LocationCity {ZipcodeStart = 5881,City = "Skårup Fyn"},
new LocationCity {ZipcodeStart = 5882,City = "Vejstrup"},
new LocationCity {ZipcodeStart = 5883,City = "Oure"},
new LocationCity {ZipcodeStart = 5884,City = "Gudme"},
new LocationCity {ZipcodeStart = 5892,City = "Gudbjerg Sydfyn"},
new LocationCity {ZipcodeStart = 5900,City = "Rudkøbing"},
new LocationCity {ZipcodeStart = 5932,City = "Humble"},
new LocationCity {ZipcodeStart = 5935,City = "Bagenkop"},
new LocationCity {ZipcodeStart = 5953,City = "Tranekær"},
new LocationCity {ZipcodeStart = 5960,City = "Marstal"},
new LocationCity {ZipcodeStart = 5970,City = "Ærøskøbing"},
new LocationCity {ZipcodeStart = 5985,City = "Søby Ærø"},
new LocationCity {ZipcodeStart = 6000,City = "Kolding"},
new LocationCity {ZipcodeStart = 6040,City = "Egtved"},
new LocationCity {ZipcodeStart = 6051,City = "Almind"},
new LocationCity {ZipcodeStart = 6052,City = "Viuf"},
new LocationCity {ZipcodeStart = 6064,City = "Jordrup"},
new LocationCity {ZipcodeStart = 6070,City = "Christiansfeld"},
new LocationCity {ZipcodeStart = 6091,City = "Bjert"},
new LocationCity {ZipcodeStart = 6092,City = "Sønder Stenderup"},
new LocationCity {ZipcodeStart = 6093,City = "Sjølund"},
new LocationCity {ZipcodeStart = 6094,City = "Hejls"},
new LocationCity {ZipcodeStart = 6100,City = "Haderslev"},
new LocationCity {ZipcodeStart = 6200,City = "Aabenraa"},
new LocationCity {ZipcodeStart = 6230,City = "Rødekro"},
new LocationCity {ZipcodeStart = 6240,City = "Løgumkloster"},
new LocationCity {ZipcodeStart = 6261,City = "Bredebro"},
new LocationCity {ZipcodeStart = 6270,City = "Tønder"},
new LocationCity {ZipcodeStart = 6280,City = "Højer"},
new LocationCity {ZipcodeStart = 6300,City = "Gråsten"},
new LocationCity {ZipcodeStart = 6310,City = "Broager"},
new LocationCity {ZipcodeStart = 6320,City = "Egernsund"},
new LocationCity {ZipcodeStart = 6330,City = "Padborg"},
new LocationCity {ZipcodeStart = 6340,City = "Kruså"},
new LocationCity {ZipcodeStart = 6360,City = "Tinglev"},
new LocationCity {ZipcodeStart = 6372,City = "Bylderup-Bov"},
new LocationCity {ZipcodeStart = 6392,City = "Bolderslev"},
new LocationCity {ZipcodeStart = 6400,City = "Sønderborg"},
new LocationCity {ZipcodeStart = 6430,City = "Nordborg"},
new LocationCity {ZipcodeStart = 6440,City = "Augustenborg"},
new LocationCity {ZipcodeStart = 6470,City = "Sydals"},
new LocationCity {ZipcodeStart = 6500,City = "Vojens"},
new LocationCity {ZipcodeStart = 6510,City = "Gram"},
new LocationCity {ZipcodeStart = 6520,City = "Toftlund"},
new LocationCity {ZipcodeStart = 6534,City = "Agerskov"},
new LocationCity {ZipcodeStart = 6535,City = "Branderup Jylland"},
new LocationCity {ZipcodeStart = 6541,City = "Bevtoft"},
new LocationCity {ZipcodeStart = 6560,City = "Sommersted"},
new LocationCity {ZipcodeStart = 6580,City = "Vamdrup"},
new LocationCity {ZipcodeStart = 6600,City = "Vejen"},
new LocationCity {ZipcodeStart = 6621,City = "Gesten"},
new LocationCity {ZipcodeStart = 6622,City = "Bække"},
new LocationCity {ZipcodeStart = 6623,City = "Vorbasse"},
new LocationCity {ZipcodeStart = 6630,City = "Rødding"},
new LocationCity {ZipcodeStart = 6640,City = "Lunderskov"},
new LocationCity {ZipcodeStart = 6650,City = "Brørup"},
new LocationCity {ZipcodeStart = 6660,City = "Lintrup"},
new LocationCity {ZipcodeStart = 6670,City = "Holsted"},
new LocationCity {ZipcodeStart = 6682,City = "Hovborg"},
new LocationCity {ZipcodeStart = 6683,City = "Føvling"},
new LocationCity {ZipcodeStart = 6690,City = "Gørding"},
new LocationCity {ZipcodeStart = 6700,City = "Esbjerg"},
new LocationCity {ZipcodeStart = 6705,City = "Esbjerg Ø"},
new LocationCity {ZipcodeStart = 6710,City = "Esbjerg V"},
new LocationCity {ZipcodeStart = 6715,City = "Esbjerg N"},
new LocationCity {ZipcodeStart = 6720,City = "Fanø"},
new LocationCity {ZipcodeStart = 6731,City = "Tjæreborg"},
new LocationCity {ZipcodeStart = 6740,City = "Bramming"},
new LocationCity {ZipcodeStart = 6752,City = "Glejbjerg"},
new LocationCity {ZipcodeStart = 6753,City = "Agerbæk"},
new LocationCity {ZipcodeStart = 6760,City = "Ribe"},
new LocationCity {ZipcodeStart = 6771,City = "Gredstedbro"},
new LocationCity {ZipcodeStart = 6780,City = "Skærbæk"},
new LocationCity {ZipcodeStart = 6792,City = "Rømø"},
new LocationCity {ZipcodeStart = 6800,City = "Varde"},
new LocationCity {ZipcodeStart = 6818,City = "Årre"},
new LocationCity {ZipcodeStart = 6823,City = "Ansager"},
new LocationCity {ZipcodeStart = 6830,City = "Nørre Nebel"},
new LocationCity {ZipcodeStart = 6840,City = "Oksbøl"},
new LocationCity {ZipcodeStart = 6851,City = "Janderup Vestjylland"},
new LocationCity {ZipcodeStart = 6852,City = "Billum"},
new LocationCity {ZipcodeStart = 6853,City = "Vejers Strand"},
new LocationCity {ZipcodeStart = 6854,City = "Henne"},
new LocationCity {ZipcodeStart = 6855,City = "Ovtrup"},
new LocationCity {ZipcodeStart = 6857,City = "Blåvand"},
new LocationCity {ZipcodeStart = 6862,City = "Tistrup"},
new LocationCity {ZipcodeStart = 6870,City = "Ølgod"},
new LocationCity {ZipcodeStart = 6880,City = "Tarm"},
new LocationCity {ZipcodeStart = 6893,City = "Hemmet"},
new LocationCity {ZipcodeStart = 6900,City = "Skjern"},
new LocationCity {ZipcodeStart = 6920,City = "Videbæk"},
new LocationCity {ZipcodeStart = 6933,City = "Kibæk"},
new LocationCity {ZipcodeStart = 6940,City = "Lem St."},
new LocationCity {ZipcodeStart = 6950,City = "Ringkøbing"},
new LocationCity {ZipcodeStart = 6960,City = "Hvide Sande"},
new LocationCity {ZipcodeStart = 6971,City = "Spjald"},
new LocationCity {ZipcodeStart = 6973,City = "Ørnhøj"},
new LocationCity {ZipcodeStart = 6980,City = "Tim"},
new LocationCity {ZipcodeStart = 6990,City = "Ulfborg"},
new LocationCity {ZipcodeStart = 7000,City = "Fredericia"},
new LocationCity {ZipcodeStart = 7007,City = "Fredericia Sydjyllands Postcenter"},
new LocationCity {ZipcodeStart = 7080,City = "Børkop"},
new LocationCity {ZipcodeStart = 7100,City = "Vejle"},
new LocationCity {ZipcodeStart = 7120,City = "Vejle Øst"},
new LocationCity {ZipcodeStart = 7130,City = "Juelsminde"},
new LocationCity {ZipcodeStart = 7140,City = "Stouby"},
new LocationCity {ZipcodeStart = 7150,City = "Barrit"},
new LocationCity {ZipcodeStart = 7160,City = "Tørring"},
new LocationCity {ZipcodeStart = 7171,City = "Uldum"},
new LocationCity {ZipcodeStart = 7173,City = "Vonge"},
new LocationCity {ZipcodeStart = 7182,City = "Bredsten"},
new LocationCity {ZipcodeStart = 7183,City = "Randbøl"},
new LocationCity {ZipcodeStart = 7184,City = "Vandel"},
new LocationCity {ZipcodeStart = 7190,City = "Billund"},
new LocationCity {ZipcodeStart = 7200,City = "Grindsted"},
new LocationCity {ZipcodeStart = 7250,City = "Hejnsvig"},
new LocationCity {ZipcodeStart = 7260,City = "Sønder Omme"},
new LocationCity {ZipcodeStart = 7270,City = "Stakroge"},
new LocationCity {ZipcodeStart = 7280,City = "Sønder Felding"},
new LocationCity {ZipcodeStart = 7300,City = "Jelling"},
new LocationCity {ZipcodeStart = 7321,City = "Gadbjerg"},
new LocationCity {ZipcodeStart = 7323,City = "Give"},
new LocationCity {ZipcodeStart = 7330,City = "Brande"},
new LocationCity {ZipcodeStart = 7361,City = "Ejstrupholm"},
new LocationCity {ZipcodeStart = 7362,City = "Hampen"},
new LocationCity {ZipcodeStart = 7400,City = "Herning"},
new LocationCity {ZipcodeStart = 7401,City = "Herning Vestjyllands Postcenter"},
new LocationCity {ZipcodeStart = 7430,City = "Ikast"},
new LocationCity {ZipcodeStart = 7441,City = "Bording"},
new LocationCity {ZipcodeStart = 7442,City = "Engesvang"},
new LocationCity {ZipcodeStart = 7451,City = "Sunds"},
new LocationCity {ZipcodeStart = 7470,City = "Karup Jylland"},
new LocationCity {ZipcodeStart = 7480,City = "Vildbjerg"},
new LocationCity {ZipcodeStart = 7490,City = "Aulum"},
new LocationCity {ZipcodeStart = 7500,City = "Holstebro"},
new LocationCity {ZipcodeStart = 7540,City = "Haderup"},
new LocationCity {ZipcodeStart = 7550,City = "Sørvad"},
new LocationCity {ZipcodeStart = 7560,City = "Hjerm"},
new LocationCity {ZipcodeStart = 7570,City = "Vemb"},
new LocationCity {ZipcodeStart = 7600,City = "Struer"},
new LocationCity {ZipcodeStart = 7620,City = "Lemvig"},
new LocationCity {ZipcodeStart = 7650,City = "Bøvlingbjerg"},
new LocationCity {ZipcodeStart = 7660,City = "Bækmarksbro"},
new LocationCity {ZipcodeStart = 7673,City = "Harboøre"},
new LocationCity {ZipcodeStart = 7680,City = "Thyborøn"},
new LocationCity {ZipcodeStart = 7700,City = "Thisted"},
new LocationCity {ZipcodeStart = 7730,City = "Hanstholm"},
new LocationCity {ZipcodeStart = 7741,City = "Frøstrup"},
new LocationCity {ZipcodeStart = 7742,City = "Vesløs"},
new LocationCity {ZipcodeStart = 7752,City = "Snedsted"},
new LocationCity {ZipcodeStart = 7755,City = "Bedsted Thy"},
new LocationCity {ZipcodeStart = 7760,City = "Hurup Thy"},
new LocationCity {ZipcodeStart = 7770,City = "Vestervig"},
new LocationCity {ZipcodeStart = 7790,City = "Thyholm"},
new LocationCity {ZipcodeStart = 7800,City = "Skive"},
new LocationCity {ZipcodeStart = 7830,City = "Vinderup"},
new LocationCity {ZipcodeStart = 7840,City = "Højslev"},
new LocationCity {ZipcodeStart = 7850,City = "Stoholm Jylland"},
new LocationCity {ZipcodeStart = 7860,City = "Spøttrup"},
new LocationCity {ZipcodeStart = 7870,City = "Roslev"},
new LocationCity {ZipcodeStart = 7884,City = "Fur"},
new LocationCity {ZipcodeStart = 7900,City = "Nykøbing Mors"},
new LocationCity {ZipcodeStart = 7950,City = "Erslev"},
new LocationCity {ZipcodeStart = 7960,City = "Karby"},
new LocationCity {ZipcodeStart = 7970,City = "Redsted Mors"},
new LocationCity {ZipcodeStart = 7980,City = "Vils"},
new LocationCity {ZipcodeStart = 7990,City = "Øster Assels"},
new LocationCity {ZipcodeStart = 8000,City = "Aarhus C"},
new LocationCity {ZipcodeStart = 8011,City = "Aarhus C Østjyllands Postcenter"},
new LocationCity {ZipcodeStart = 8200,City = "Aarhus N"},
new LocationCity {ZipcodeStart = 8210,City = "Aarhus V"},
new LocationCity {ZipcodeStart = 8220,City = "Brabrand"},
new LocationCity {ZipcodeStart = 8230,City = "Åbyhøj"},
new LocationCity {ZipcodeStart = 8240,City = "Risskov"},
new LocationCity {ZipcodeStart = 8245,City = "Risskov Ø Østjyllands Postcenter"},
new LocationCity {ZipcodeStart = 8250,City = "Egå"},
new LocationCity {ZipcodeStart = 8260,City = "Viby Jylland"},
new LocationCity {ZipcodeStart = 8270,City = "Højbjerg"},
new LocationCity {ZipcodeStart = 8300,City = "Odder"},
new LocationCity {ZipcodeStart = 8305,City = "Samsø"},
new LocationCity {ZipcodeStart = 8310,City = "Tranbjerg Jylland"},
new LocationCity {ZipcodeStart = 8320,City = "Mårslet"},
new LocationCity {ZipcodeStart = 8330,City = "Beder"},
new LocationCity {ZipcodeStart = 8340,City = "Malling"},
new LocationCity {ZipcodeStart = 8350,City = "Hundslund"},
new LocationCity {ZipcodeStart = 8355,City = "Solbjerg"},
new LocationCity {ZipcodeStart = 8361,City = "Hasselager"},
new LocationCity {ZipcodeStart = 8362,City = "Hørning"},
new LocationCity {ZipcodeStart = 8370,City = "Hadsten"},
new LocationCity {ZipcodeStart = 8380,City = "Trige"},
new LocationCity {ZipcodeStart = 8381,City = "Tilst"},
new LocationCity {ZipcodeStart = 8382,City = "Hinnerup"},
new LocationCity {ZipcodeStart = 8400,City = "Ebeltoft"},
new LocationCity {ZipcodeStart = 8410,City = "Rønde"},
new LocationCity {ZipcodeStart = 8420,City = "Knebel"},
new LocationCity {ZipcodeStart = 8444,City = "Balle"},
new LocationCity {ZipcodeStart = 8450,City = "Hammel"},
new LocationCity {ZipcodeStart = 8462,City = "Harlev Jylland"},
new LocationCity {ZipcodeStart = 8464,City = "Galten"},
new LocationCity {ZipcodeStart = 8471,City = "Sabro"},
new LocationCity {ZipcodeStart = 8472,City = "Sporup"},
new LocationCity {ZipcodeStart = 8500,City = "Grenaa"},
new LocationCity {ZipcodeStart = 8520,City = "Lystrup"},
new LocationCity {ZipcodeStart = 8530,City = "Hjortshøj"},
new LocationCity {ZipcodeStart = 8541,City = "Skødstrup"},
new LocationCity {ZipcodeStart = 8543,City = "Hornslet"},
new LocationCity {ZipcodeStart = 8544,City = "Mørke"},
new LocationCity {ZipcodeStart = 8550,City = "Ryomgård"},
new LocationCity {ZipcodeStart = 8560,City = "Kolind"},
new LocationCity {ZipcodeStart = 8570,City = "Trustrup"},
new LocationCity {ZipcodeStart = 8581,City = "Nimtofte"},
new LocationCity {ZipcodeStart = 8585,City = "Glesborg"},
new LocationCity {ZipcodeStart = 8586,City = "Ørum Djurs"},
new LocationCity {ZipcodeStart = 8592,City = "Anholt"},
new LocationCity {ZipcodeStart = 8600,City = "Silkeborg"},
new LocationCity {ZipcodeStart = 8620,City = "Kjellerup"},
new LocationCity {ZipcodeStart = 8632,City = "Lemming"},
new LocationCity {ZipcodeStart = 8641,City = "Sorring"},
new LocationCity {ZipcodeStart = 8643,City = "Ans By"},
new LocationCity {ZipcodeStart = 8653,City = "Them"},
new LocationCity {ZipcodeStart = 8654,City = "Bryrup"},
new LocationCity {ZipcodeStart = 8660,City = "Skanderborg"},
new LocationCity {ZipcodeStart = 8670,City = "Låsby"},
new LocationCity {ZipcodeStart = 8680,City = "Ry"},
new LocationCity {ZipcodeStart = 8700,City = "Horsens"},
new LocationCity {ZipcodeStart = 8721,City = "Daugård"},
new LocationCity {ZipcodeStart = 8722,City = "Hedensted"},
new LocationCity {ZipcodeStart = 8723,City = "Løsning"},
new LocationCity {ZipcodeStart = 8732,City = "Hovedgård"},
new LocationCity {ZipcodeStart = 8740,City = "Brædstrup"},
new LocationCity {ZipcodeStart = 8751,City = "Gedved"},
new LocationCity {ZipcodeStart = 8752,City = "Østbirk"},
new LocationCity {ZipcodeStart = 8762,City = "Flemming"},
new LocationCity {ZipcodeStart = 8763,City = "Rask Mølle"},
new LocationCity {ZipcodeStart = 8765,City = "Klovborg"},
new LocationCity {ZipcodeStart = 8766,City = "Nørre Snede"},
new LocationCity {ZipcodeStart = 8781,City = "Stenderup"},
new LocationCity {ZipcodeStart = 8783,City = "Hornsyld"},
new LocationCity {ZipcodeStart = 8800,City = "Viborg"},
new LocationCity {ZipcodeStart = 8830,City = "Tjele"},
new LocationCity {ZipcodeStart = 8831,City = "Løgstrup"},
new LocationCity {ZipcodeStart = 8832,City = "Skals"},
new LocationCity {ZipcodeStart = 8840,City = "Rødkærsbro"},
new LocationCity {ZipcodeStart = 8850,City = "Bjerringbro"},
new LocationCity {ZipcodeStart = 8860,City = "Ulstrup"},
new LocationCity {ZipcodeStart = 8870,City = "Langå"},
new LocationCity {ZipcodeStart = 8881,City = "Thorsø"},
new LocationCity {ZipcodeStart = 8882,City = "Fårvang"},
new LocationCity {ZipcodeStart = 8883,City = "Gjern"},
new LocationCity {ZipcodeStart = 8900,City = "Randers"},
new LocationCity {ZipcodeStart = 8950,City = "Ørsted"},
new LocationCity {ZipcodeStart = 8961,City = "Allingåbro"},
new LocationCity {ZipcodeStart = 8963,City = "Auning"},
new LocationCity {ZipcodeStart = 8970,City = "Havndal"},
new LocationCity {ZipcodeStart = 8981,City = "Spentrup"},
new LocationCity {ZipcodeStart = 8983,City = "Gjerlev Jylland"},
new LocationCity {ZipcodeStart = 8990,City = "Fårup"},
new LocationCity {ZipcodeStart = 9000,City = "Aalborg"},
new LocationCity {ZipcodeStart = 9020,City = "Aalborg Nordjyllands Postcenter"},
new LocationCity {ZipcodeStart = 9200,City = "Aalborg SV"},
new LocationCity {ZipcodeStart = 9210,City = "Aalborg SØ"},
new LocationCity {ZipcodeStart = 9220,City = "Aalborg Øst"},
new LocationCity {ZipcodeStart = 9230,City = "Svenstrup Jylland"},
new LocationCity {ZipcodeStart = 9240,City = "Nibe"},
new LocationCity {ZipcodeStart = 9260,City = "Gistrup"},
new LocationCity {ZipcodeStart = 9270,City = "Klarup"},
new LocationCity {ZipcodeStart = 9280,City = "Storvorde"},
new LocationCity {ZipcodeStart = 9293,City = "Kongerslev"},
new LocationCity {ZipcodeStart = 9300,City = "Sæby"},
new LocationCity {ZipcodeStart = 9310,City = "Vodskov"},
new LocationCity {ZipcodeStart = 9320,City = "Hjallerup"},
new LocationCity {ZipcodeStart = 9330,City = "Dronninglund"},
new LocationCity {ZipcodeStart = 9340,City = "Asaa"},
new LocationCity {ZipcodeStart = 9352,City = "Dybvad"},
new LocationCity {ZipcodeStart = 9362,City = "Gandrup"},
new LocationCity {ZipcodeStart = 9370,City = "Hals"},
new LocationCity {ZipcodeStart = 9380,City = "Vestbjerg"},
new LocationCity {ZipcodeStart = 9381,City = "Sulsted"},
new LocationCity {ZipcodeStart = 9382,City = "Tylstrup"},
new LocationCity {ZipcodeStart = 9400,City = "Nørresundby"},
new LocationCity {ZipcodeStart = 9430,City = "Vadum"},
new LocationCity {ZipcodeStart = 9440,City = "Aabybro"},
new LocationCity {ZipcodeStart = 9460,City = "Brovst"},
new LocationCity {ZipcodeStart = 9480,City = "Løkken"},
new LocationCity {ZipcodeStart = 9490,City = "Pandrup"},
new LocationCity {ZipcodeStart = 9492,City = "Blokhus"},
new LocationCity {ZipcodeStart = 9493,City = "Saltum"},
new LocationCity {ZipcodeStart = 9500,City = "Hobro"},
new LocationCity {ZipcodeStart = 9510,City = "Arden"},
new LocationCity {ZipcodeStart = 9520,City = "Skørping"},
new LocationCity {ZipcodeStart = 9530,City = "Støvring"},
new LocationCity {ZipcodeStart = 9541,City = "Suldrup"},
new LocationCity {ZipcodeStart = 9550,City = "Mariager"},
new LocationCity {ZipcodeStart = 9560,City = "Hadsund"},
new LocationCity {ZipcodeStart = 9574,City = "Bælum"},
new LocationCity {ZipcodeStart = 9575,City = "Terndrup"},
new LocationCity {ZipcodeStart = 9600,City = "Aars"},
new LocationCity {ZipcodeStart = 9610,City = "Nørager"},
new LocationCity {ZipcodeStart = 9620,City = "Aalestrup"},
new LocationCity {ZipcodeStart = 9631,City = "Gedsted"},
new LocationCity {ZipcodeStart = 9632,City = "Møldrup"},
new LocationCity {ZipcodeStart = 9640,City = "Farsø"},
new LocationCity {ZipcodeStart = 9670,City = "Løgstør"},
new LocationCity {ZipcodeStart = 9681,City = "Ranum"},
new LocationCity {ZipcodeStart = 9690,City = "Fjerritslev"},
new LocationCity {ZipcodeStart = 9700,City = "Brønderslev"},
new LocationCity {ZipcodeStart = 9740,City = "Jerslev Jylland"},
new LocationCity {ZipcodeStart = 9750,City = "Øster Vrå"},
new LocationCity {ZipcodeStart = 9760,City = "Vrå"},
new LocationCity {ZipcodeStart = 9800,City = "Hjørring"},
new LocationCity {ZipcodeStart = 9830,City = "Tårs"},
new LocationCity {ZipcodeStart = 9850,City = "Hirtshals"},
new LocationCity {ZipcodeStart = 9870,City = "Sindal"},
new LocationCity {ZipcodeStart = 9881,City = "Bindslev"},
new LocationCity {ZipcodeStart = 9900,City = "Frederikshavn"},
new LocationCity {ZipcodeStart = 9940,City = "Læsø"},
new LocationCity {ZipcodeStart = 9970,City = "Strandby"},
new LocationCity {ZipcodeStart = 9981,City = "Jerup"},
new LocationCity {ZipcodeStart = 9982,City = "Ålbæk"},
new LocationCity {ZipcodeStart = 9990,City = "Skagen"}
            };
            foreach (var zipcode in listPostNr)
            {
                if (zipcode.ZipcodeEnd == null)
                    zipcode.ZipcodeEnd = zipcode.ZipcodeStart;
                _db.LocationCitySet.Add(zipcode);
            }
            _db.SaveChanges();

            #endregion [PostNr]

            #region [PostNr Distrikt]

            var listPostNrDistrikt = new List<LocationGroup>
            {
new LocationGroup {Name = "Hele Danmark",ZipcodeStart = 1000,ZipcodeEnd = 9990},
new LocationGroup {Name = "Sjælland",ZipcodeStart = 1000,ZipcodeEnd = 4999},
new LocationGroup {Name = "Københavns Kommune, Frederiksberg og omegn",ZipcodeStart = 1000,ZipcodeEnd = 2999},
new LocationGroup {Name = "Nordsjælland ",ZipcodeStart = 3000,ZipcodeEnd = 3699},
new LocationGroup {Name = "Østsjælland, Midt- og Vestsjælland & Sydsjælland",ZipcodeStart = 4000,ZipcodeEnd = 4999},
new LocationGroup {Name = "Fyn og øerne",ZipcodeStart = 5000,ZipcodeEnd = 5999},
new LocationGroup {Name = "Jylland",ZipcodeStart = 6000,ZipcodeEnd = 9999},
new LocationGroup {Name = "Sønderjylland",ZipcodeStart = 6000,ZipcodeEnd = 6999},
new LocationGroup {Name = "Nordvestjylland, Vestjylland",ZipcodeStart = 7000,ZipcodeEnd = 7999},
new LocationGroup {Name = "Østjylland ",ZipcodeStart = 8000,ZipcodeEnd = 8999},
new LocationGroup {Name = "Nordjylland",ZipcodeStart = 9000,ZipcodeEnd = 9999}
            };

            foreach (var locationGroupSet in listPostNrDistrikt)
                _db.LocationGroupSet.Add(locationGroupSet);
            _db.SaveChanges();

            #endregion [PostNr Distrikt]

            #region [Persons]

            #region [Teacher]
            var listTeacher = new List<Person> {

new Person
{
    FirstName = "Peter",
    LastName = "Hansen",
    Email = "ph@gmail.com",
    Zipcode = 8260,
    Address = "Grøfthøjvej 20",
    Username = "teacher1",
    Password = "1234",
    Image = "Person1.jpg",
    Description = "Hej jeg hedder Peter er for nylig begyndt at undervise og finder stor glæde i det",

},
new Person
{
    FirstName = "Henrik",
    LastName = "Larsen",
    Email = "hl@gmail.com",
    Zipcode = 2720,
    Address = "Jernbane Allé 46",
    Username = "teacher2",
    Password = "1234",
    Image = "Person2.jpg",
    Description = "Hej jeg hedder Henrik jeg er uddannet lærer, ud over det går jeg meget op i mad. ",
},
new Person
{
    FirstName = "Mette",
    LastName = "Henriksen",
    Email = "mh@gmail.com",
    Zipcode = 9000,
    Address = "Hobrovej 452",
    Username = "teacher3",
    Password = "1234",
    Image = "Person8.jpg",
    Description = "Hej jeg hedder Mette jeg er underviser og har været lærer i mange forskellige fag og finder stor glæde i der.",
},
new Person
{
    FirstName = "Lars",
    LastName = "Larsen",
    Email = "ll@gmail.com",
    Zipcode = 3310,
    Address = "Grøfthøjvej 20",
    Username = "teacher4",
    Password = "1234",
    Image = "Person3.jpg",
    Description = "Hej jeg hedder Lars Larsen jeg har mange interesser, og vil utrolig gerne lærer fra mig.",
},
new Person
{
    FirstName = "Rasmus",
    LastName = "Hansen",
    Email = "rh@gmail.com",
    Zipcode = 7800,
    Address = "Albert Diges Vej 20",
    Username = "teacher5",
    Password = "1234",
    Image = "Person7.jpg",
    Description = "Hej jeg hedder Rasmus jeg underviser finder stor glæde i at undervise, og har gjort det længe",
},
new Person
{
    FirstName = "Erik",
    LastName = "Hansen",
    Email = "eh@gmail.com",
    Zipcode = 8000,
    Address = "Park Alle 12",
    Username = "teacher6",
    Password = "1234",
    Image = "Person4.jpg",
    Description = "Hej jeg hedder Erik jeg underviser finder stor glæde i at undervise, og har gjort det længe",
},
new Person
{
    FirstName = "Dennis",
    LastName = "Hansen",
    Email = "dh@gmail.com",
    Zipcode = 8000,
    Address = "Store Torv 5",
    Username = "teacher7",
    Password = "1234",
    Image = "Person6.jpg",
    Description = "Hej jeg hedder Dennis jeg underviser finder stor glæde i at undervise, og har gjort det længe",
},
new Person
{
    FirstName = "Emil",
    LastName = "Hansen",
    Email = "emilh@gmail.com",
    Zipcode = 8000,
    Address = "Banegårdspladsen 8",
    Username = "teacher8",
    Password = "1234",
    Image = "Person10.jpg",
    Description = "Hej jeg hedder Emil jeg underviser finder stor glæde i at undervise, og har gjort det længe",
},
new Person
{
    FirstName = "Heidi",
    LastName = "Hansen",
    Email = "Heidih@gmail.com",
    Zipcode = 8260,
    Address = "Viby Ringvej 22",
    Username = "teacher9",
    Password = "1234",
    Image = "Person11.jpg",
    Description = "Hej jeg hedder Heidi jeg underviser finder stor glæde i at undervise, og har gjort det længe",
},
new Person
{
    FirstName = "Inger",
    LastName = "Hansen",
    Email = "ih@gmail.com",
    Zipcode = 8000,
    Address = "Søndergade 38, 1. sal.",
    Username = "teacher10",
    Password = "1234",
    Image = "Person12.jpg",
    Description = "Hej jeg hedder Inger jeg underviser finder stor glæde i at undervise, og har gjort det længe",
}

        };

            foreach (var teacher in listTeacher)
            {
                teacher.DateCreated = DateTime.Now;
                teacher.TeacherCourse = new Collection<Course>();
                teacher.LocationCity = _db.LocationCitySet.FirstOrDefault(x => x.ZipcodeStart == teacher.Zipcode);
                _db.PersonSet.Add(teacher);
            }
            _db.SaveChanges();

            #endregion [Teacher]

            #region [Student]

            var listStudent = new List<Person>
            {
                new Person{
                FirstName = "Søren",
                LastName = "Brock",
                Email = "sørenb@gmail.com",
                Zipcode = 8200,
                Address = "Brendstrupgårdsvej 7",
                Username = "student1",
                Password = "1234",
             Image = "Person15.jpg"
            },

new Person{
                FirstName = "Simon",
                LastName = "Eldevig",
                Email = "simonh@gmail.com",
                Zipcode = 8200,
                Address = "Brendstrupvej 92",
                Username = "student2",
                Password = "1234",
             Image = "Person17.jpg"
            },
new Person{
                FirstName = "Thomas",
                LastName = "Wöbbe",
                Email = "thomasw@gmail.com",
                Zipcode = 8000,
                Address = "Banegårdspladsen 12",
                Username = "student3",
                Password = "1234",
                 Image = "Person19.jpg"
            },

new Person{
                FirstName = "Kathrine",
                LastName = "Nielsen",
                Email = "kathrinen@gmail.com",
                Zipcode = 8000,
                Address = "Sønder Alle 11",
                Username = "student4",
                Password = "1234",
                 Image = "Person26.jpg"
            },

new Person{
                FirstName = "Morten",
                LastName = "Jensen",
                Email = "mortenj@gmail.com",
                Zipcode = 9000,
                Address = "Hadsundvej 68",
                Username = "student5",
                Password = "1234",
                 Image = "Person27.jpg"
            },

new Person{
                FirstName = "Simone",
                LastName = "Eriksen",
                Email = "simonee@gmail.com",
                Zipcode = 9700,
                Address = "Algade 39",
                Username = "student6",
                Password = "1234",
                 Image = "Person22.jpg"
            },

new Person{
                FirstName = "Kristian",
                LastName = "Lauge",
                Email = "kristianl@gmail.com",
                Zipcode = 9000,
                Address = "Vesterbro 89",
                Username = "student7",
                Password = "1234",
                 Image = "Person23.jpg"
            },

new Person{
                FirstName = "Kasper",
                LastName = "Awesome",
                Email = "kaspera@gmail.com",
                Zipcode = 8900,
                Address = "Søndergade 38, 1. sal.",
                Username = "student8",
                Password = "1234",
                 Image = "Person25.jpg"
            },

new Person{
                FirstName = "Jakob",
                LastName = "Jakobsen",
                Email = "jakobj@gmail.com",
                Zipcode = 9000,
                Address = "Hadsundvej 184 B",
                Username = "student9",
                Password = "1234",
                 Image = "Person24.jpg"
            },

new Person{
                FirstName = "Rasmus",
                LastName = "Rasmusen",
                Email = "rasmusr@gmail.com",
                Zipcode = 9000,
                Address = "Nytorv 27",
                Username = "student10",
                Password = "1234",
                 Image = "Person21.jpg"
            },

new Person{
                FirstName = "Steffen",
                LastName = "Dahl",
                Email = "steffend@gmail.com",
                Zipcode = 2100,
                Address = "Nordre Frihavnsgade 10, st.",
                Username = "student11",
                Password = "1234",
                 Image = "Person13.jpg"
            },

new Person{
                FirstName = "Andreas",
                LastName = "Hundahl",
                Email = "andreash@gmail.com",
                Zipcode = 4000,
                Address = "Betonvej 12",
                Username = "student12",
                Password = "1234",
                 Image = "Person31.jpg"
            },

new Person{
                FirstName = "Jeppe",
                LastName = "Vist",
                Email = "jeppev@gmail.com",
                Zipcode = 9000,
                Address = "Østerågade 4",
                Username = "student13",
                Password = "1234",
                 Image = "Person32.jpg"
            },

new Person{
                FirstName = "Casper",
                LastName = "Bak",
                Email = "casperb@gmail.com",
                Zipcode = 8000,
                Address = "M.P.Bruuns Gade 11 - 13",
                Username = "student14",
                Password = "1234",
                  Image = "Person33.jpg"
            },

new Person{
                FirstName = "Mieke",
                LastName = "Rasmussen",
                Email = "mieker@gmail.com",
                Zipcode = 9000,
                Address = "Mester Eriks Vej 56",
                Username = "student15",
                Password = "1234",
                 Image = "Person30.jpg"
            },

new Person{
                FirstName = "Mette",
                LastName = "Eriksen",
                Email = "mettee@gmail.com",
                Zipcode = 9000,
                Address = "Skelagervej 15",
                Username = "student16",
                Password = "1234",
                 Image = "Person14.jpg"
            },
new Person{
                FirstName = "Jessica",
                LastName = "Jensen",
                Email = "jessicaj@gmail.com",
                Zipcode = 8000,
                Address = "Jægergårdsgade 66",
                Username = "student17",
                Password = "1234",
                 Image = "Person16.jpg"
            },
new Person{
                FirstName = "Emil",
                LastName = "Jensen",
                Email = "emilj@gmail.com",
                Zipcode = 8000,
                Address = "Skt.Knuds Torv 3, 1. sal",
                Username = "student18",
                Password = "1234",
                 Image = "Person27.jpg"
            },
new Person{
                FirstName = "Anne",
                LastName = "Holler",
                Email = "anneh@gmail.com",
                Zipcode = 8000,
                Address = "Ryesgade 14",
                Username = "student19",
                Password = "1234",
                 Image = "Person12.jpg"
            },
new Person{
                FirstName = "Oscar",
                LastName = "Persson",
                Email = "oscarp@gmail.com",
                Zipcode = 8000,
                Address = "Daugbjergvej 18",
                Username = "student20",
                Password = "1234",
                 Image = "Person28.jpg"
            },
new Person{
                FirstName = "Helen",
                LastName = "Rowbottom",
                Email = "helenr@gmail.com",
                Zipcode = 8000,
                Address = "Skanderborgvej 11",
                Username = "student21",
                Password = "1234",
                 Image = "Person18.jpg"
            },
new Person{
                FirstName = "Dimitry",
                LastName = "Bakshun",
                Email = "dimitryb@gmail.com",
                Zipcode = 8000,
                Address = "Eckersbergsgade 13 A",
                Username = "student22",
                Password = "1234",
                 Image = "Person10.jpg"
            },
new Person{
                FirstName = "Ian",
                LastName = "Rowbottom",
                Email = "ianr@gmail.com",
                Zipcode = 8000,
                Address = "Frederiks Alle 98",
                Username = "student23",
                Password = "1234",
                 Image = "Person1.jpg"
            },
new Person{
                FirstName = "Alex",
                LastName = "Nilsen",
                Email = "alexn@gmail.com",
                Zipcode = 7800,
                Address = "Elskjærbakken 7",
                Username = "student24",
                Password = "1234",
                 Image = "Person24.jpg"
            },
new Person{
                FirstName = "Daniel",
                LastName = "Sti",
                Email = "daniels@gmail.com",
                Zipcode = 7800,
                Address = "Viborgvej 28",
                Username = "student25",
                Password = "1234",
                 Image = "Person2.jpg"
            },
new Person{
                FirstName = "Jesper",
                LastName = "Jespersen",
                Email = "jesperj@gmail.com",
                Zipcode = 7800,
                Address = "Adelgade 8",
                Username = "student26",
                Password = "1234",
                 Image = "Person3.jpg"
            },
new Person{
                FirstName = "Lasse",
                LastName = "Hansen",
                Email = "lasseh@gmail.com",
                Zipcode = 9240,
                Address = "deterovernitusinde1",
                Username = "student27",
                Password = "1234",
                 Image = "Person4.jpg"
            },
new Person{
                FirstName = "Ole",
                LastName = "Mortensen",
                Email = "olem@gmail.com",
                Zipcode = 8600,
                Address = "Glentevej 7",
                Username = "student28",
                Password = "1234",
                 Image = "Person6.jpg"
            },
new Person{
                FirstName = "Paw",
                LastName = "Sørensen ",
                Email = "paws@gmail.com",
                Zipcode = 8000,
                Address = "Kriegersvej 27",
                Username = "student29",
                Password = "1234",
                 Image = "Person7.jpg"
            },
new Person{
                FirstName = "Kirsten",
                LastName = "Stubkjær",
                Email = "kirstens@gmail.com",
                Zipcode = 8000,
                Address = "Østergade 4",
                Username = "student30",
                Password = "1234",
                 Image = "Person8.jpg"
            }

            };


            foreach (var student in listStudent)
            {
                student.DateCreated = DateTime.Now;
                //student.StudentCourse = new Collection<Course>();
                student.LocationCity = _db.LocationCitySet.FirstOrDefault(x => x.ZipcodeStart == student.Zipcode);
                _db.PersonSet.Add(student);
            }
            _db.SaveChanges();
            #endregion [Student]

            #endregion [Persons]

            #region [Courses]

            var listCourse = new List<Course>
            {

     new Course{
                Name= "Lær at lav italiensk mad begynder",
                Description = "Hvis du gerne vil lærer de lækre italienske køkken så er dette kurset for dig ",
                Image = "ItalienskBegynder.jpg",
                 Tag = new[] { listTags.ElementAt(36), listTags.ElementAt(57), listTags.ElementAt(58) }
            },
new Course{
                Name= "Lær at lav italiensk mad øvet ",
                Description = "Hvis du bare har lidt færdigheder i et køkken, men gerne vil blive bedre, så dette helt sikkert noget du skal prøve",
Image = "ItalienskØvet.jpg",
Tag = new[] { listTags.ElementAt(36), listTags.ElementAt(57), listTags.ElementAt(58) }
            },
new Course{
                Name= "Lær at lav italiensk mad ekspert",
                Description = "Dette er kurset for dig der ved hvad du laver i et køkken, men alligevel gerne vil prøve noget nyt ",
Image = "ItalienskEkspert.jpg",
Tag = new[] { listTags.ElementAt(36), listTags.ElementAt(57), listTags.ElementAt(58) }
            },
new Course{
                Name= "Guitar spil for begyndere",
                Description = "Lær at spil guitar på en dag! ",
Image = "guitar1.jpg",
Tag = new[] { listTags.ElementAt(17), listTags.ElementAt(12), listTags.ElementAt(28), listTags.ElementAt(29), listTags.ElementAt(60), listTags.ElementAt(61), listTags.ElementAt(65) }
            },
new Course{
                Name= "Guitar for øvet",
                Description = "Hvis guitar spil er noget for dig, så er dette noget for dig, tænker at vi sidder og chiller, spiller lidt guitar og bliver bedre ",
Image = "GuitarØvet.jpg",
Tag = new[] { listTags.ElementAt(17), listTags.ElementAt(12), listTags.ElementAt(28), listTags.ElementAt(29), listTags.ElementAt(60), listTags.ElementAt(61), listTags.ElementAt(65), listTags.ElementAt(71)}
            },
new Course{
                Name= "Lær dansk",
                Description = "Jeg læser dansk på Aarhus Uni, og vil gerne hjælpe netop dig til at blive endnu bedre, uanset hvilket niveau det er på",
Image = "Dansk.jpg",
Tag = new[] { listTags.ElementAt(13), listTags.ElementAt(75), listTags.ElementAt(79)}
            },
new Course{
                Name= "Spansk for begyndere",
                Description = "Jeg er begyndt på Aarhus uni og vil gerne undervise i spansk. Så hvis du gerne vil lærer spansk på begynder niveau så skriv ",
Image = "Spansk.jpg",
Tag = new[] { listTags.ElementAt(77), listTags.ElementAt(75) ,listTags.ElementAt(79) }
            },
new Course{
                Name= "Klaver er det nye Hotpink",
                Description = "Alle elsker en der kan spille klaver, jeg underviser i det, du skal helt sikkert prøve det ",
Image = "Klaver.jpg",
Tag = new[] { listTags.ElementAt(46), listTags.ElementAt(44), listTags.ElementAt(60), listTags.ElementAt(61), listTags.ElementAt(65), }
            },
new Course{
                Name= "Java programmering ",
                Description = "Jeg er lige blevet uddannet datamatiker, og vil gerne undervise folk i Java, så hvis du lige er startet på uddannelsen, og kunne bruge noget hjælp, eller bare gerne vil blive bedre, så kontakt mig. ",
Image = "Java.jpg",
Tag = new[] { listTags.ElementAt(14), listTags.ElementAt(15), listTags.ElementAt(82)}
          },
new Course{
                Name= "C# programmering",
                Description = "Jeg er lige blevet uddannet datamatiker, og vil gerne undervise folk i C# så hvis du gerne kunne tænke dig at blive bedre, så kontakt mig. ",
Image = "C.jpg",
Tag = new[] { listTags.ElementAt(14), listTags.ElementAt(15), listTags.ElementAt(82) }
 },
new Course{
                Name= "Have kursus",
                Description = "Det er vinter, men derfor kan vi godt lærer lidt om planterne, så vi er klar til foråret",
Image = "Have.jpg",
Tag = new[] { listTags.ElementAt(34) }
            },
new Course{
                Name= "Lær fransk på 2 timer",
                Description = "Hej, jeg underviser til dagligt i fransk på en efterskole, og har tid i weekenderne til at undervise hjemme fra, så hvis du gerne vil lære fransk så skriv til mig. ",
Image = "Fransk.jpg",
Tag = new[] { listTags.ElementAt(23), listTags.ElementAt(75), listTags.ElementAt(79) }
 },
new Course{
                Name= "Italiensk for begyndere",
                Description = "Hej. Jeg er italiener og har boet i Aarhus de sidste 10 år, men har fået mod på at undervise lidt i verdens lækreste sprog nemlig det italienske. ",
Image = "Italiensk.jpg",
Tag = new[] { listTags.ElementAt(36), listTags.ElementAt(75), listTags.ElementAt(79) }
},
new Course{
                Name= "Tysk sprogkursus øvet",
                Description = "Gymnasieelev? lyst til at blive bedre til tysk? så underviser jeg i tysk på gymnasium niveau. ",
Image = "Tysk.jpg",
Tag = new[] { listTags.ElementAt(88), listTags.ElementAt(75), listTags.ElementAt(79) }
            },
new Course{
                Name= "Trompet undervisning",
                Description = "Jeg har spillet Jazz i mange år, og har taget springet til at undervise i trompet, som har været mit instrument de sidste 25år ",
Image = "Trompet.png",
Tag = new[] { listTags.ElementAt(60) }
            },
new Course{
                Name= "Italiensk begynder niveau",
                Description = "Træt af ikke at kunne snakke italiensk på ferien? Nu skal det være slut, skriv til mig så lærer du det inden din næste ferie ",
Image = "Itaiensk.jpeg",
Tag = new[] { listTags.ElementAt(36), listTags.ElementAt(75), listTags.ElementAt(79) }
            },
new Course{
                Name= "HTML for begynder",
                Description = "Har du lyst til at lærer at lave hjemme sider fra bunden af, så underviser jeg i det i min fritid. ",
Image = "html1.png",
Tag = new[] { listTags.ElementAt(14), listTags.ElementAt(15), listTags.ElementAt(59), listTags.ElementAt(82)}
            },
new Course{
                Name= "HTML øvet",
                Description = "Du kender din HTML, men vil gerne lærer mere, så underviser jeg i det. ",
Image = "html1.png",
Tag = new[] { listTags.ElementAt(14), listTags.ElementAt(15), listTags.ElementAt(59), listTags.ElementAt(82) }

            },
new Course{
                Name= "CSS for begynder",
                Description = "Du kan din HTML men vil gerne kunne style din side ordentligt, så kontakt mig ",
Image = "css.png",
Tag = new[] { listTags.ElementAt(14), listTags.ElementAt(15), listTags.ElementAt(59), listTags.ElementAt(82) }
            },
new Course{
                Name= "CSS for øvet",
                Description = "Du har styr på HTML og kan lidt CSS i forvejen, så er dette kurset for dig. ",
Image = "css.png",
Tag = new[] { listTags.ElementAt(14), listTags.ElementAt(15), listTags.ElementAt(59), listTags.ElementAt(82) }
            },
new Course{
                Name= "Lær din Iphone at kende",
                Description = "Syntes du også din Iphone kan være forvirrende, eller vil du bare gerne vide alt hvad den kan, så er dette for dig. ",
Image = "Iphone.jpg",
Tag = new[] { listTags.ElementAt(82) }
            },
new Course{
                Name= "Er haven klar til foråret? ",
                Description = " Skal haven have en ekstra omgang her til foråret, så er dette kursus for dig",
Image = "Have2.jpg",
Tag = new[] { listTags.ElementAt(34) }
            },
new Course{
                Name= "Kinesisk madlavning!",
                Description = "Vil du gerne lærer at lave det lækreste mad fra det kinesiske køkken, så skal du skrive dig op her.",
Image = "Kinesisk.jpg",
Tag = new[] { listTags.ElementAt(45), listTags.ElementAt(57)}
            },
new Course{
                Name= "Lav din egen SUSHI!!",
                Description = "Jeg er tidligere kok, og har lavet sushi de sidste 5 år. Jeg ved der sidder mange hjemme som gerne vil lærer det, så dette er chancen ",
Image = "Sushi.jpg",
Tag = new[] { listTags.ElementAt(57) }
 },
new Course{
                Name= "Øl brygning for begyndere",
                Description = "Jeg er brygmester på et lokalt bryggeri og vil da gerne fortælle lidt om hvordan det er at lave øl, og give nogle gode råd til alle jer der gerne vil prøve det ",
Image = "Øl.jpg",
Tag = new[] { listTags.ElementAt(57), listTags.ElementAt(58) }
 },
new Course{
                Name= " Indisk madlavning",
                Description = "Træt af dårlige indiske restauranter, lav din egen hjemme ved dig selv ",
Image = "Indisk.jpg",
Tag = new[] { listTags.ElementAt(57) }
            }
      };

            #endregion [Courses]

            #region [Course Builder]

            var mailDescriptionPerson = new[] { "Det lyder rigtigt spændende!", "Hvornår kan jeg begynde?",
                "Kan jeg kontakte dig for mere information?", "Er det svært at lære?",
                "Jeg har altid ønsket mig at kunne det!", "Håber du har tid til en elev mere?", "Kan du undervise mig!",
                "Har du tid i sommerferien?", "Giver du undervisning hjemme hos elever?",
                "Hvor lang tid tage det at lære?", "Hvor lang tid har du undervist?", "Kan jeg begynde i morgen?"};

            var mailDescriptionCourse = new[]
            {
                "Det er jeg glad for at høre!", "Du er mere end velkommen!", "Det kan vi sagtens finde ud af!",
                "Fortæl mere om dig selv!", "Det skal nok blive rigtig spændende!",
                "Du er altid mere end velkommen til at slå på tråden!", "Har lige set din besked:)",
                "Det skal du nok få lært!", "Jeg er optaget i morgen, ellers er resten af ugen fri",
                "Det er ikke så svært som det kan lyde :)", "Der er plads til alle ... lige fra nybegyndere til øvede!",
                "Jeg starter et nyt hold næste uge!"
            };

            var i = 0;
            foreach (var course in listCourse)
            {
                i++;
                if (i <= 6)
                    course.Teacher = listTeacher.ElementAt(1);
                else if (i > 6 && i <= 12)
                    course.Teacher = listTeacher.ElementAt(2);
                else if (i > 12 && i <= 18)
                    course.Teacher = listTeacher.ElementAt(3);
                else if (i > 18)
                    course.Teacher = listTeacher.ElementAt(4);

                //add course to student + ratings
                for (var j = 0; j < _rnd.Next(0, 5); j++)
                {
                    var student = listStudent.ElementAt(_rnd.Next(1, listStudent.Count() - 1));
                    student.StudentCourse.Add(course);

                    var dateCreated = DateTime.Now.AddDays(_rnd.Next(-30, -15)).AddHours(_rnd.Next(-30, 0)).AddMinutes(_rnd.Next(-30, 0));
                    var chatRoom = new ChatRoom
                    {
                        DateCreated = dateCreated,
                        Course = course,
                        OwnerPerson = student,
                        Person = new[] { course.Teacher, student }
                    };

                    student.ChatRoom.Add(chatRoom);
                    chatRoom.Chat.Add(new Chat
                    {
                        Person = student,
                        Message = mailDescriptionPerson[_rnd.Next(0, mailDescriptionPerson.Count())],
                        DateCreated = dateCreated,
                    });

                    student.ChatRoom.Add(chatRoom);
                    chatRoom.Chat.Add(new Chat
                    {
                        Person = course.Teacher,
                        Message = mailDescriptionCourse[_rnd.Next(0, mailDescriptionCourse.Count())],
                        DateCreated = dateCreated.AddDays(_rnd.Next(1, 7)).AddMinutes(_rnd.Next(30, 120)),
                    });

                    _db.RatingSet.Add(new Rating
                    {
                        Stars = (short?)_rnd.Next(0, 6),
                        Course = course,
                        Person = student
                    });
                }

                // Add tag to Course
                //for (var j = 0; j < _rnd.Next(3, 10); j++)
                //    course.Tag.Add(listTags.ElementAt(_rnd.Next(1, listStudent.Count() - 1)));

                course.DateCreated = DateTime.Now;
                course.Active = true;

                _db.CourseSet.Add(course);
            }

            _db.SaveChanges();


            #endregion [Course Builder]

            #region [Administrators]
            var admin = new Administrator
            {
                Name = "MySenseiAdmin",
                UserName = "Admin",
                Password = "1234",
                Active = true,
                Image = "",
                DateCreated = DateTime.Now
            };
            _db.AdministratorSet.Add(admin);
            _db.SaveChanges();

            #endregion // [Administrators]

            #endregion [Create Data]
        }
    }
}