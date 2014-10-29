namespace SimpleHR.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using SimpleHR.Models;
    using SimpleHR.DataAccess;
    using SimpleHR.Utils;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EmployeeDbContext";
        }

        protected override void Seed(EmployeeDbContext context)
        {
            //var roles = new List<Role>
            //{
            //    new Role { RoleName = _RoleName.HR },
            //    new Role { RoleName = _RoleName.Employee },
            //};
            //roles.ForEach(r => context.Roles.Add(r));
            //context.SaveChanges();

            var PasswordHasher = new PasswordHasher();

            var credentials = new List<Credential>
            {
                //new Credential { LoginId = "kevin", PasswordHash = PasswordHasher.HashPassword("password") },

                //These are generated
                new Credential { LoginId = "James_Johnson", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Josephine_Darakjy", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Lenna_Paprocki", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Donette_Foller", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Simona_Morasca", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Mitsue_Tollner", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Leota_Dilliard", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Sage_Wieser", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Kris_Marrier", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Minna_Amigon", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Abel_Maclead", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Kiley_Caldarera", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Graciela_Ruta", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Cammy_Albares", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Mattie_Poquette", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Meaghan_Garufi", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Gladys_Rim", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Yuki_Whobrey", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Fletcher_Flosi", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Bette_Nicka", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Veronika_Inouye", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Willard_Kolmetz", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Maryann_Royster", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Allene_Iturbide", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Chanel_Caudy", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Ezekiel_Chui", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Willow_Kusko", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Bernardo_Figeroa", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Ammie_Corrio", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Francine_Vocelka", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Alishia_Sergi", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Solange_Shinko", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Jose_Stockham", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Rozella_Ostrosky", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Valentine_Gillian", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Kati_Rulapaugh", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Youlanda_Schemmer", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Dyan_Oldroyd", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Roxane_Campain", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Lavera_Perin", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Erick_Ferencz", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Fatima_Saylors", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Kanisha_Waycott", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Emerson_Bowley", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Blair_Malet", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Brock_Bolognia", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Lorrie_Nestle", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Sabra_Uyetake", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Marjory_Mastella", PasswordHash = PasswordHasher.HashPassword("password") },
                new Credential { LoginId = "Tonette_Wenner", PasswordHash = PasswordHasher.HashPassword("password") },
            };
            credentials.ForEach(c => context.Credentials.Add(c));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee { FirstName = "Kevin", MiddleName = "H", Lastname = "Le",
                    Address = "16 Washington St", City = "Houston", County = "Harris",
                    State = "TX", ZipCode = "55555", OfficePhone = "111-222-3333", CellPhone = "444-555-6666",
                    Email = "pragmaticobjects@gmail.com", LoginId = "kevin", EmployeeId = Guid.NewGuid()},

                //These are generated
                new Employee { FirstName = "James", MiddleName = "Benton,", Lastname = "Johnson", Address = "6649 N Blue Gum St", City = "New Orleans", County = "Orleans", State = "LA", ZipCode = "70116", OfficePhone = "504-621-8927", CellPhone = "504-845-1427", Email = "jjohnson@gmail.com", LoginId = "James_Johnson", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Josephine", MiddleName = "Chanay,", Lastname = "Darakjy", Address = "4 B Blue Ridge Blvd", City = "Brighton", County = "Livingston", State = "MI", ZipCode = "48116", OfficePhone = "810-292-9388", CellPhone = "810-374-9840", Email = "josephine_darakjy@darakjy.org", LoginId = "Josephine_Darakjy", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Lenna", MiddleName = "Feltz", Lastname = "Paprocki", Address = "639 Main St", City = "Anchorage", County = "Anchorage", State = "AK", ZipCode = "99501", OfficePhone = "907-385-4412", CellPhone = "907-921-2010", Email = "lpaprocki@hotmail.com", LoginId = "Lenna_Paprocki", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Donette", MiddleName = "Printing", Lastname = "Foller", Address = "34 Center St", City = "Hamilton", County = "Butler", State = "OH", ZipCode = "45011", OfficePhone = "513-570-1893", CellPhone = "513-549-4561", Email = "donette.foller@cox.net", LoginId = "Donette_Foller", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Simona", MiddleName = "Chapman,", Lastname = "Morasca", Address = "3 Mcauley Dr", City = "Ashland", County = "Ashland", State = "OH", ZipCode = "44805", OfficePhone = "419-503-2484", CellPhone = "419-800-6759", Email = "simona@morasca.com", LoginId = "Simona_Morasca", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Mitsue", MiddleName = "Morlong", Lastname = "Tollner", Address = "7 Eads St", City = "Chicago", County = "Cook", State = "IL", ZipCode = "60632", OfficePhone = "773-573-6914", CellPhone = "773-924-8565", Email = "mitsue_tollner@yahoo.com", LoginId = "Mitsue_Tollner", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Leota", MiddleName = "Commercial", Lastname = "Dilliard", Address = "7 W Jackson Blvd", City = "San Jose", County = "Santa Clara", State = "CA", ZipCode = "95111", OfficePhone = "408-752-3500", CellPhone = "408-813-1105", Email = "leota@hotmail.com", LoginId = "Leota_Dilliard", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Sage", MiddleName = "Truhlar", Lastname = "Wieser", Address = "5 Boston Ave #88", City = "Sioux Falls", County = "Minnehaha", State = "SD", ZipCode = "57105", OfficePhone = "605-414-2147", CellPhone = "605-794-4895", Email = "sage_wieser@cox.net", LoginId = "Sage_Wieser", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Kris", MiddleName = "King,", Lastname = "Marrier", Address = "228 Runamuck Pl #2808", City = "Baltimore", County = "Baltimore City", State = "MD", ZipCode = "21224", OfficePhone = "410-655-8723", CellPhone = "410-804-4694", Email = "kris@gmail.com", LoginId = "Kris_Marrier", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Minna", MiddleName = "Dorl,", Lastname = "Amigon", Address = "2371 Jerrold Ave", City = "Kulpsville", County = "Montgomery", State = "PA", ZipCode = "19443", OfficePhone = "215-874-1229", CellPhone = "215-422-8694", Email = "minna_amigon@yahoo.com", LoginId = "Minna_Amigon", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Abel", MiddleName = "Rangoni", Lastname = "Maclead", Address = "37275 St  Rt 17m M", City = "Middle Island", County = "Suffolk", State = "NY", ZipCode = "11953", OfficePhone = "631-335-3414", CellPhone = "631-677-3675", Email = "amaclead@gmail.com", LoginId = "Abel_Maclead", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Kiley", MiddleName = "Feiner", Lastname = "Caldarera", Address = "25 E 75th St #69", City = "Los Angeles", County = "Los Angeles", State = "CA", ZipCode = "90034", OfficePhone = "310-498-5651", CellPhone = "310-254-3084", Email = "kiley.caldarera@aol.com", LoginId = "Kiley_Caldarera", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Graciela", MiddleName = "Buckley", Lastname = "Ruta", Address = "98 Connecticut Ave Nw", City = "Chagrin Falls", County = "Geauga", State = "OH", ZipCode = "44023", OfficePhone = "440-780-8425", CellPhone = "440-579-7763", Email = "gruta@cox.net", LoginId = "Graciela_Ruta", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Cammy", MiddleName = "Rousseaux,", Lastname = "Albares", Address = "56 E Morehead St", City = "Laredo", County = "Webb", State = "TX", ZipCode = "78045", OfficePhone = "956-537-6195", CellPhone = "956-841-7216", Email = "calbares@gmail.com", LoginId = "Cammy_Albares", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Mattie", MiddleName = "Century", Lastname = "Poquette", Address = "73 State Road 434 E", City = "Phoenix", County = "Maricopa", State = "AZ", ZipCode = "85013", OfficePhone = "602-277-4385", CellPhone = "602-953-6360", Email = "mattie@aol.com", LoginId = "Mattie_Poquette", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Meaghan", MiddleName = "Bolton,", Lastname = "Garufi", Address = "69734 E Carrillo St", City = "Mc Minnville", County = "Warren", State = "TN", ZipCode = "37110", OfficePhone = "931-313-9635", CellPhone = "931-235-7959", Email = "meaghan@hotmail.com", LoginId = "Meaghan_Garufi", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Gladys", MiddleName = "T", Lastname = "Rim", Address = "322 New Horizon Blvd", City = "Milwaukee", County = "Milwaukee", State = "WI", ZipCode = "53207", OfficePhone = "414-661-9598", CellPhone = "414-377-2880", Email = "gladys.rim@rim.org", LoginId = "Gladys_Rim", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Yuki", MiddleName = "Farmers", Lastname = "Whobrey", Address = "1 State Route 27", City = "Taylor", County = "Wayne", State = "MI", ZipCode = "48180", OfficePhone = "313-288-7937", CellPhone = "313-341-4470", Email = "yuki_whobrey@aol.com", LoginId = "Yuki_Whobrey", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Fletcher", MiddleName = "Post", Lastname = "Flosi", Address = "394 Manchester Blvd", City = "Rockford", County = "Winnebago", State = "IL", ZipCode = "61109", OfficePhone = "815-828-2147", CellPhone = "815-426-5657", Email = "fletcher.flosi@yahoo.com", LoginId = "Fletcher_Flosi", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Bette", MiddleName = "Sport", Lastname = "Nicka", Address = "6 S 33rd St", City = "Aston", County = "Delaware", State = "PA", ZipCode = "19014", OfficePhone = "610-545-3615", CellPhone = "610-492-4643", Email = "bette_nicka@cox.net", LoginId = "Bette_Nicka", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Veronika", MiddleName = "C", Lastname = "Inouye", Address = "6 Greenleaf Ave", City = "San Jose", County = "Santa Clara", State = "CA", ZipCode = "95111", OfficePhone = "408-540-1785", CellPhone = "408-813-4592", Email = "vinouye@aol.com", LoginId = "Veronika_Inouye", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Willard", MiddleName = "Ingalls,", Lastname = "Kolmetz", Address = "618 W Yakima Ave", City = "Irving", County = "Dallas", State = "TX", ZipCode = "75062", OfficePhone = "972-303-9197", CellPhone = "972-896-4882", Email = "willard@hotmail.com", LoginId = "Willard_Kolmetz", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Maryann", MiddleName = "Franklin,", Lastname = "Royster", Address = "74 S Westgate St", City = "Albany", County = "Albany", State = "NY", ZipCode = "12204", OfficePhone = "518-966-7987", CellPhone = "518-448-8982", Email = "mroyster@royster.com", LoginId = "Maryann_Royster", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Allene", MiddleName = "Ledecky,", Lastname = "Iturbide", Address = "1 Central Ave", City = "Stevens Point", County = "Portage", State = "WI", ZipCode = "54481", OfficePhone = "715-662-6764", CellPhone = "715-530-9863", Email = "allene_iturbide@cox.net", LoginId = "Allene_Iturbide", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Chanel", MiddleName = "Professional", Lastname = "Caudy", Address = "86 Nw 66th St #8673", City = "Shawnee", County = "Johnson", State = "KS", ZipCode = "66218", OfficePhone = "913-388-2079", CellPhone = "913-899-1103", Email = "chanel.caudy@caudy.org", LoginId = "Chanel_Caudy", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Ezekiel", MiddleName = "Sider,", Lastname = "Chui", Address = "2 Cedar Ave #84", City = "Easton", County = "Talbot", State = "MD", ZipCode = "21601", OfficePhone = "410-669-1642", CellPhone = "410-235-8738", Email = "ezekiel@chui.com", LoginId = "Ezekiel_Chui", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Willow", MiddleName = "U", Lastname = "Kusko", Address = "90991 Thorburn Ave", City = "New York", County = "New York", State = "NY", ZipCode = "10011", OfficePhone = "212-582-4976", CellPhone = "212-934-5167", Email = "wkusko@yahoo.com", LoginId = "Willow_Kusko", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Bernardo", MiddleName = "Clark,", Lastname = "Figeroa", Address = "386 9th Ave N", City = "Conroe", County = "Montgomery", State = "TX", ZipCode = "77301", OfficePhone = "936-336-3951", CellPhone = "936-597-3614", Email = "bfigeroa@aol.com", LoginId = "Bernardo_Figeroa", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Ammie", MiddleName = "Moskowitz,", Lastname = "Corrio", Address = "74874 Atlantic Ave", City = "Columbus", County = "Franklin", State = "OH", ZipCode = "43215", OfficePhone = "614-801-9788", CellPhone = "614-648-3265", Email = "ammie@corrio.com", LoginId = "Ammie_Corrio", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Francine", MiddleName = "Cascade", Lastname = "Vocelka", Address = "366 South Dr", City = "Las Cruces", County = "Dona Ana", State = "NM", ZipCode = "88011", OfficePhone = "505-977-3911", CellPhone = "505-335-5293", Email = "francine_vocelka@vocelka.com", LoginId = "Francine_Vocelka", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Alishia", MiddleName = "Milford", Lastname = "Sergi", Address = "2742 Distribution Way", City = "New York", County = "New York", State = "NY", ZipCode = "10025", OfficePhone = "212-860-1579", CellPhone = "212-753-2740", Email = "asergi@gmail.com", LoginId = "Alishia_Sergi", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Solange", MiddleName = "Mosocco,", Lastname = "Shinko", Address = "426 Wolf St", City = "Metairie", County = "Jefferson", State = "LA", ZipCode = "70002", OfficePhone = "504-979-9175", CellPhone = "504-265-8174", Email = "solange@shinko.com", LoginId = "Solange_Shinko", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Jose", MiddleName = "Tri", Lastname = "Stockham", Address = "128 Bransten Rd", City = "New York", County = "New York", State = "NY", ZipCode = "10011", OfficePhone = "212-675-8570", CellPhone = "212-569-4233", Email = "jose@yahoo.com", LoginId = "Jose_Stockham", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Rozella", MiddleName = "Parkway", Lastname = "Ostrosky", Address = "17 Morena Blvd", City = "Camarillo", County = "Ventura", State = "CA", ZipCode = "93012", OfficePhone = "805-832-6163", CellPhone = "805-609-1531", Email = "rozella.ostrosky@ostrosky.com", LoginId = "Rozella_Ostrosky", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Valentine", MiddleName = "Fbs", Lastname = "Gillian", Address = "775 W 17th St", City = "San Antonio", County = "Bexar", State = "TX", ZipCode = "78204", OfficePhone = "210-812-9597", CellPhone = "210-300-6244", Email = "valentine_gillian@gmail.com", LoginId = "Valentine_Gillian", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Kati", MiddleName = "Eder", Lastname = "Rulapaugh", Address = "6980 Dorsett Rd", City = "Abilene", County = "Dickinson", State = "KS", ZipCode = "67410", OfficePhone = "785-463-7829", CellPhone = "785-219-7724", Email = "kati.rulapaugh@hotmail.com", LoginId = "Kati_Rulapaugh", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Youlanda", MiddleName = "Tri", Lastname = "Schemmer", Address = "2881 Lewis Rd", City = "Prineville", County = "Crook", State = "OR", ZipCode = "97754", OfficePhone = "541-548-8197", CellPhone = "541-993-2611", Email = "youlanda@aol.com", LoginId = "Youlanda_Schemmer", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Dyan", MiddleName = "International", Lastname = "Oldroyd", Address = "7219 Woodfield Rd", City = "Overland Park", County = "Johnson", State = "KS", ZipCode = "66204", OfficePhone = "913-413-4604", CellPhone = "913-645-8918", Email = "doldroyd@aol.com", LoginId = "Dyan_Oldroyd", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Roxane", MiddleName = "Rapid", Lastname = "Campain", Address = "1048 Main St", City = "Fairbanks", County = "Fairbanks North Star", State = "AK", ZipCode = "99708", OfficePhone = "907-231-4722", CellPhone = "907-335-6568", Email = "roxane@hotmail.com", LoginId = "Roxane_Campain", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Lavera", MiddleName = "Abc", Lastname = "Perin", Address = "678 3rd Ave", City = "Miami", County = "Miami-Dade", State = "FL", ZipCode = "33196", OfficePhone = "305-606-7291", CellPhone = "305-995-2078", Email = "lperin@perin.org", LoginId = "Lavera_Perin", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Erick", MiddleName = "Cindy", Lastname = "Ferencz", Address = "20 S Babcock St", City = "Fairbanks", County = "Fairbanks North Star", State = "AK", ZipCode = "99712", OfficePhone = "907-741-1044", CellPhone = "907-227-6777", Email = "erick.ferencz@aol.com", LoginId = "Erick_Ferencz", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Fatima", MiddleName = "Stanton,", Lastname = "Saylors", Address = "2 Lighthouse Ave", City = "Hopkins", County = "Hennepin", State = "MN", ZipCode = "55343", OfficePhone = "952-768-2416", CellPhone = "952-479-2375", Email = "fsaylors@saylors.org", LoginId = "Fatima_Saylors", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Kanisha", MiddleName = "Schroer,", Lastname = "Waycott", Address = "5 Tomahawk Dr", City = "Los Angeles", County = "Los Angeles", State = "CA", ZipCode = "90006", OfficePhone = "323-453-2780", CellPhone = "323-315-7314", Email = "kanisha_waycott@yahoo.com", LoginId = "Kanisha_Waycott", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Emerson", MiddleName = "Knights", Lastname = "Bowley", Address = "762 S Main St", City = "Madison", County = "Dane", State = "WI", ZipCode = "53711", OfficePhone = "608-336-7444", CellPhone = "608-658-7940", Email = "emerson.bowley@bowley.org", LoginId = "Emerson_Bowley", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Blair", MiddleName = "Bollinger", Lastname = "Malet", Address = "209 Decker Dr", City = "Philadelphia", County = "Philadelphia", State = "PA", ZipCode = "19132", OfficePhone = "215-907-9111", CellPhone = "215-794-4519", Email = "bmalet@yahoo.com", LoginId = "Blair_Malet", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Brock", MiddleName = "Orinda", Lastname = "Bolognia", Address = "4486 W O St #1", City = "New York", County = "New York", State = "NY", ZipCode = "10003", OfficePhone = "212-402-9216", CellPhone = "212-617-5063", Email = "bbolognia@yahoo.com", LoginId = "Brock_Bolognia", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Lorrie", MiddleName = "Ballard", Lastname = "Nestle", Address = "39 S 7th St", City = "Tullahoma", County = "Coffee", State = "TN", ZipCode = "37388", OfficePhone = "931-875-6644", CellPhone = "931-303-6041", Email = "lnestle@hotmail.com", LoginId = "Lorrie_Nestle", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Sabra", MiddleName = "Lowy", Lastname = "Uyetake", Address = "98839 Hawthorne Blvd #6101", City = "Columbia", County = "Richland", State = "SC", ZipCode = "29201", OfficePhone = "803-925-5213", CellPhone = "803-681-3678", Email = "sabra@uyetake.org", LoginId = "Sabra_Uyetake", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Marjory", MiddleName = "Vicon", Lastname = "Mastella", Address = "71 San Mateo Ave", City = "Wayne", County = "Delaware", State = "PA", ZipCode = "19087", OfficePhone = "610-814-5533", CellPhone = "610-379-7125", Email = "mmastella@mastella.com", LoginId = "Marjory_Mastella", EmployeeId = Guid.NewGuid() },
                new Employee { FirstName = "Tonette", MiddleName = "Northwest", Lastname = "Wenner", Address = "4545 Courthouse Rd", City = "Westbury", County = "Nassau", State = "NY", ZipCode = "11590", OfficePhone = "516-968-6051", CellPhone = "516-333-4861", Email = "twenner@aol.com", LoginId = "Tonette_Wenner", EmployeeId = Guid.NewGuid() },

            };
            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();

            //var employeeRoles = new List<EmployeeRole>
            //{
            //    new EmployeeRole { LoginId = "kevin", RoleName = _RoleName.HR },
            //    new EmployeeRole { LoginId = "kevin", RoleName = _RoleName.Employee },
            //};

            //employeeRoles.ForEach(er => context.EmployeeRoles.Add(er));
            //context.SaveChanges();
        }
    }
}
