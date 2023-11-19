using JccbIncomeExpense.Models;
using Microsoft.AspNetCore.Builder;


namespace JccbIncomeExpense.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();
                context.Database.EnsureCreated();

                if (!context.Catexpenses.Any())
                {
                    context.Catexpenses.AddRange(new List<Catexpense>()
                    {

                       new Catexpense()
                        {
                            Excategory = "Restaurant",
                            DisplayOrder = 1
                        },
                        new Catexpense()
                        {
                            Excategory = "Grocery",
                            DisplayOrder = 2
                        },
                        new Catexpense()
                        {
                            Excategory = "Gas",
                            DisplayOrder = 3
                        },
                        new Catexpense()
                        {
                            Excategory = "Insurane",
                            DisplayOrder = 4
                        },
                        new Catexpense()
                        {
                            Excategory = "Garden",
                            DisplayOrder = 5
                        },
                        new Catexpense()
                        {
                            Excategory = "Mechanic",
                            DisplayOrder = 6
                        },
                        new Catexpense()
                        {
                            Excategory = "Other",
                            DisplayOrder = 7
                        },


                     });
                    context.SaveChanges();
                }// end of Catexpenses

                // start income categories

                if (!context.incomecats.Any())
                {
                    context.incomecats.AddRange(new List<Incomecat>()
                    {

                       new Incomecat()
                        {
                            Icategory = "Salary",
                            DisplayOrder = 1
                        },
                        new Incomecat()
                        {
                            Icategory = "Stock Market",
                            DisplayOrder = 2
                        },
                        new Incomecat()
                        {
                            Icategory = "Rent Income",
                            DisplayOrder = 3
                        },
                        new Incomecat()
                        {
                            Icategory = "Property Maintenance",
                            DisplayOrder = 4
                        },

                     });
                    context.SaveChanges();
                }// Income

                if (!context.Infoincomes.Any())
                {
                    context.Infoincomes.AddRange(new List<Infoincome>()
                    {

                        new Infoincome()
                        {
                           Incomename = "Salary",
                           SaleAmount = 700,
                           Reference  = "Previously worked as a junior sales associate.",
                           Icategory = "Rent Maintenance",
                           Note = "Works well with numbers, however, has trouble socializing and prefers to work alone.",
                           Dated = DateTime.Now.AddDays(1)
                        },

                           new Infoincome()
                        {
                           Incomename = "Salary",
                           SaleAmount = 500,
                           Reference  = "Engineer at an industrial company",
                           Icategory = "Salary",
                           Note = "Tends to leave early, but works great with the time given.",
                           Dated =  DateTime.Now.AddDays(1)
                        },

                            new Infoincome()
                        {
                            Incomename = "Stock Market",
                            SaleAmount =  800,
                            Reference  = "Junior Analysist at an investment firm",
                            Icategory = "Stock Market",
                            Note = "Excellent analysis, however, her emotions prove to be an obstacle..",
                            Dated = DateTime.Now.AddDays(1),
                         },

                            new Infoincome()
                       {    Incomename = "Rent Income",
                            SaleAmount = 800,
                           Reference  = "Broker at a relatively small brokerage.",
                           Icategory = "Property Maintenance",
                           Note = " Has outstanding social skills, this helps with his sales. ",
                           Dated = DateTime.Now.AddDays(1)
                        },



                            new Infoincome()
                       {
                           Incomename = "Rent Income",
                            SaleAmount = 700,
                           Reference  = "Rent from both houses in Dallas,Tx.",
                           Icategory = "Rent Income",
                           Note = " The loan has been payed off. ",
                           Dated = DateTime.Now.AddDays(1)
                        },
                            new Infoincome()

                       {    Incomename = "Rent Income",
                            SaleAmount = 600,
                           Reference  = "Broken toilet has been replaced.",
                           Icategory = "Property Maintenance",
                           Note = " Property is well maintained and is in good condition. ",
                           Dated = DateTime.Now.AddDays(1)
                        },



                           new Infoincome()

                       {    Incomename = "Salary",
                            SaleAmount = 1900,
                           Reference  = "Proffessional Architect in a large construction company .",
                           Icategory = "Salary",
                           Note = " Very social and creative with design and is popular within the arhitectual community. ",
                           Dated = DateTime.Now.AddDays(1)
                        },
                           new Infoincome()

                       {    Incomename = "Stock Market",
                            SaleAmount = 900,
                           Reference  = "Specializes in global commodities .",
                           Icategory = "Stock Market",
                           Note = " Entries are exceptional, with minimal loss. ",
                           Dated = DateTime.Now.AddDays(1)
                        },



                            new Infoincome()

                       {    Incomename = "Rent Income",
                            SaleAmount = 700,
                           Reference  = "Rent has been payed on time.",
                           Icategory = "Rent Income",
                           Note = " Tenant has good moral and is content with his home. ",
                           Dated = DateTime.Now.AddDays(1)
                        },



                            new Infoincome()

                       {    Incomename = "Salary",
                            SaleAmount = 1100,
                           Reference  = "Exemplary programmer at a high-tech company.",
                           Icategory = "Salary",
                           Note = " Understands computers well, and can create magnificent programs. ",
                           Dated = DateTime.Now.AddDays(1)
                        },

                        //Here is one december

                          new Infoincome()
                        {
                           Incomename = "Salary",
                           SaleAmount = 1000,
                           Reference  = "Previously worked as a junior sales associate.",
                           Icategory = "Rent Maintenance",
                           Note = "Works well with numbers, however, has trouble socializing and prefers to work alone.",
                           Dated = DateTime.Now.AddDays(1)
                        },

                           new Infoincome()
                        {
                           Incomename = "Salary",
                           SaleAmount = 1200,
                           Reference  = "Engineer at an industrial company",
                           Icategory = "Salary",
                           Note = "Tends to leave early, but works great with the time given.",
                           Dated =  DateTime.Now.AddDays(-30)
                        },

                            new Infoincome()
                        {
                            Incomename = "Stock Market",
                            SaleAmount =  300,
                            Reference  = "Junior Analysist at an investment firm",
                            Icategory = "Stock Market",
                            Note = "Excellent analysis, however, her emotions prove to be an obstacle..",
                             Dated =  DateTime.Now.AddDays(-30)
                         },

                            new Infoincome()
                       {    Incomename = "Rent Income",
                            SaleAmount = 1700,
                           Reference  = "Broker at a relatively small brokerage.",
                           Icategory = "Property Maintenance",
                           Note = " Has outstanding social skills, this helps with his sales. ",
                            Dated =  DateTime.Now.AddDays(-30)
                        },



                            new Infoincome()
                       {
                           Incomename = "Rent Income",
                            SaleAmount = 1500,
                           Reference  = "Rent from both houses in Dallas,Tx.",
                           Icategory = "Rent Income",
                           Note = " The loan has been payed off. ",
                            Dated =  DateTime.Now.AddDays(-30)
                        },
                            new Infoincome()

                       {    Incomename = "Rent Income",
                            SaleAmount = 1100,
                           Reference  = "Broken toilet has been replaced.",
                           Icategory = "Property Maintenance",
                           Note = " Property is well maintained and is in good condition. ",
                            Dated =  DateTime.Now.AddDays(-30)
                        },



                           new Infoincome()

                       {    Incomename = "Salary",
                            SaleAmount = 1250,
                           Reference  = "Professional Architect in a large construction company .",
                           Icategory = "Salary",
                           Note = " Very social and creative with design and is popular within the arhitectual community. ",
                            Dated =  DateTime.Now.AddDays(-30)
                        },
                           new Infoincome()

                       {    Incomename = "Stock Market",
                            SaleAmount = 350,
                           Reference  = "Specializes in global commodities .",
                           Icategory = "Stock Market",
                           Note = " Entries are exceptional, with minimal loss. ",
                           Dated =  DateTime.Now.AddDays(-30)
                        },



                            new Infoincome()

                       {    Incomename = "Rent Income",
                            SaleAmount = 850,
                           Reference  = "Rent has been payed on time.",
                           Icategory = "Rent Income",
                           Note = " Tenant has good moral and is content with his home. ",
                           Dated =  DateTime.Now.AddDays(-30)
                        },



                            new Infoincome()

                       {    Incomename = "Salary",
                            SaleAmount = 1900,
                           Reference  = "Exemplary programmer at a high-tech company.",
                           Icategory = "Salary",
                           Note = " Understands computers well, and can create magnificent programs. ",
                            Dated =  DateTime.Now.AddDays(-30)
                        },

                         // one month before 

                            //Here is one december

                          new Infoincome()
                        {
                           Incomename = "Salary",
                           SaleAmount = 900,
                           Reference  = "Previously worked as a junior sales associate.",
                           Icategory = "Rent Maintenance",
                           Note = "Works well with numbers, however, has trouble socializing and prefers to work alone.",
                           Dated = DateTime.Now.AddDays(-60)
                        },

                           new Infoincome()
                        {
                           Incomename = "Salary",
                           SaleAmount = 600,
                           Reference  = "Engineer at an industrial company",
                           Icategory = "Salary",
                           Note = "Tends to leave early, but works great with the time given.",
                           Dated =  DateTime.Now.AddDays(-60)
                        },

                            new Infoincome()
                        {
                            Incomename = "Stock Market",
                            SaleAmount =  500,
                            Reference  = "Junior Analysist at an investment firm",
                            Icategory = "Stock Market",
                            Note = "Excellent analysis, however, her emotions prove to be an obstacle..",
                             Dated =  DateTime.Now.AddDays(-60)
                         },

                            new Infoincome()
                       {    Incomename = "Rent Income",
                            SaleAmount = 500,
                           Reference  = "Broker at a relatively small brokerage.",
                           Icategory = "Property Maintenance",
                           Note = " Has outstanding social skills, this helps with his sales. ",
                            Dated =  DateTime.Now.AddDays(-60)
                        },



                            new Infoincome()
                       {
                           Incomename = "Rent Income",
                            SaleAmount = 1100,
                           Reference  = "Rent from both houses in Dallas,Tx.",
                           Icategory = "Rent Income",
                           Note = " The loan has been payed off. ",
                            Dated =  DateTime.Now.AddDays(-60)
                        },
                            new Infoincome()

                       {    Incomename = "Rent Income",
                            SaleAmount = 900,
                           Reference  = "Broken toilet has been replaced.",
                           Icategory = "Property Maintenance",
                           Note = " Property is well maintained and is in good condition. ",
                            Dated =  DateTime.Now.AddDays(-60)
                        },



                           new Infoincome()

                       {    Incomename = "Salary",
                            SaleAmount = 1100,
                           Reference  = "Proffessional Architect in a large construction company .",
                           Icategory = "Salary",
                           Note = " Very social and creative with design and is popular within the arhitectual community. ",
                            Dated =  DateTime.Now.AddDays(-60)
                        },
                           new Infoincome()

                       {    Incomename = "Stock Market",
                            SaleAmount = 1400,
                           Reference  = "Specializes in global commodities .",
                           Icategory = "Stock Market",
                           Note = " Entries are exceptional, with minimal loss. ",
                           Dated =  DateTime.Now.AddDays(-60)
                        },



                            new Infoincome()

                       {    Incomename = "Rent Income",
                            SaleAmount = 800,
                           Reference  = "Rent has been payed on time.",
                           Icategory = "Rent Income",
                           Note = " Tenant has good moral and is content with his home. ",
                           Dated =  DateTime.Now.AddDays(-60)
                        },



                            new Infoincome()

                       {    Incomename = "Salary",
                            SaleAmount = 200,
                           Reference  = "Exemplary programmer at a high-tech company.",
                           Icategory = "Salary",
                           Note = " Understands computers well, and can create magnificent programs. ",
                            Dated =  DateTime.Now.AddDays(-60)
                        },

                         /// Before 
                         /// 
                         //Here is one december

                          new Infoincome()
                        {
                           Incomename = "Salary",
                           SaleAmount = 800,
                           Reference  = "Previously worked as a junior sales associate.",
                           Icategory = "Rent Maintenance",
                           Note = "Works well with numbers, however, has trouble socializing and prefers to work alone.",
                           Dated = DateTime.Now.AddDays(-90)
                        },

                           new Infoincome()
                        {
                           Incomename = "Salary",
                           SaleAmount = 200,
                           Reference  = "Engineer at an industrial company",
                           Icategory = "Salary",
                           Note = "Tends to leave early, but works great with the time given.",
                           Dated =  DateTime.Now.AddDays(-90)
                        },

                            new Infoincome()
                        {
                            Incomename = "Stock Market",
                            SaleAmount =  200,
                            Reference  = "Junior Analysist at an investment firm",
                            Icategory = "Stock Market",
                            Note = "Excellent analysis, however, her emotions prove to be an obstacle..",
                             Dated =  DateTime.Now.AddDays(-90)
                         },

                            new Infoincome()
                       {    Incomename = "Rent Income",
                            SaleAmount = 1200,
                           Reference  = "Broker at a relatively small brokerage.",
                           Icategory = "Property Maintenance",
                           Note = " Has outstanding social skills, this helps with his sales. ",
                            Dated =  DateTime.Now.AddDays(-90)
                        },



                            new Infoincome()
                       {
                           Incomename = "Rent Income",
                            SaleAmount = 1200,
                           Reference  = "Rent from both houses in Dallas,Tx.",
                           Icategory = "Rent Income",
                           Note = " The loan has been payed off. ",
                            Dated =  DateTime.Now.AddDays(-90)
                        },
                            new Infoincome()

                       {    Incomename = "Rent Income",
                            SaleAmount = 800,
                           Reference  = "Broken toilet has been replaced.",
                           Icategory = "Property Maintenance",
                           Note = " Property is well maintained and is in good condition. ",
                            Dated =  DateTime.Now.AddDays(-90)
                        },



                           new Infoincome()

                       {    Incomename = "Salary",
                            SaleAmount = 800,
                           Reference  = "Proffessional Architect in a large construction company .",
                           Icategory = "Salary",
                           Note = " Very social and creative with design and is popular within the arhitectual community. ",
                            Dated =  DateTime.Now.AddDays(-90)
                        },
                           new Infoincome()

                       {    Incomename = "Stock Market",
                            SaleAmount = 400,
                           Reference  = "Specializes in global commodities .",
                           Icategory = "Stock Market",
                           Note = " Entries are exceptional, with minimal loss. ",
                           Dated =  DateTime.Now.AddDays(-90)
                        },



                            new Infoincome()

                       {    Incomename = "Rent Income",
                            SaleAmount = 300,
                           Reference  = "Rent has been payed on time.",
                           Icategory = "Rent Income",
                           Note = " Tenant has good moral and is content with his home. ",
                           Dated =  DateTime.Now.AddDays(-90)
                        },



                            new Infoincome()

                       {    Incomename = "Salary",
                            SaleAmount = 950,
                           Reference  = "Exemplary programmer at a high-tech company.",
                           Icategory = "Salary",
                           Note = " Understands computers well, and can create magnificent programs. ",
                            Dated =  DateTime.Now.AddDays(-90)
                        },

                            // last 
                            //Here is one december

                          new Infoincome()
                        {
                           Incomename = "Salary",
                           SaleAmount = 420,
                           Reference  = "Previously worked as a junior sales associate.",
                           Icategory = "Rent Maintenance",
                           Note = "Works well with numbers, however, has trouble socializing and prefers to work alone.",
                           Dated = DateTime.Now.AddDays(-120)
                        },

                           new Infoincome()
                        {
                           Incomename = "Salary",
                           SaleAmount = 750,
                           Reference  = "Engineer at an industrial company",
                           Icategory = "Salary",
                           Note = "Tends to leave early, but works great with the time given.",
                           Dated =  DateTime.Now.AddDays(-120)
                        },

                            new Infoincome()
                        {
                            Incomename = "Stock Market",
                            SaleAmount =  500,
                            Reference  = "Junior Analysist at an investment firm",
                            Icategory = "Stock Market",
                            Note = "Excellent analysis, however, her emotions prove to be an obstacle..",
                             Dated =  DateTime.Now.AddDays(-120)
                         },

                            new Infoincome()
                       {    Incomename = "Rent Income",
                            SaleAmount = 450,
                           Reference  = "Broker at a relatively small brokerage.",
                           Icategory = "Property Maintenance",
                           Note = " Has outstanding social skills, this helps with his sales. ",
                            Dated =  DateTime.Now.AddDays(-120)
                        },



                            new Infoincome()
                       {
                           Incomename = "Rent Income",
                            SaleAmount = 650,
                           Reference  = "Rent from both houses in Dallas,Tx.",
                           Icategory = "Rent Income",
                           Note = " The loan has been payed off. ",
                            Dated =  DateTime.Now.AddDays(-120)
                        },
                            new Infoincome()

                       {    Incomename = "Rent Income",
                            SaleAmount = 400,
                           Reference  = "Broken toilet has been replaced.",
                           Icategory = "Property Maintenance",
                           Note = " Property is well maintained and is in good condition. ",
                            Dated =  DateTime.Now.AddDays(-120)
                        },



                           new Infoincome()

                       {    Incomename = "Salary",
                            SaleAmount = 500,
                           Reference  = "Proffessional Architect in a large construction company .",
                           Icategory = "Salary",
                           Note = " Very social and creative with design and is popular within the arhitectual community. ",
                            Dated =  DateTime.Now.AddDays(-120)
                        },
                           new Infoincome()

                       {    Incomename = "Stock Market",
                            SaleAmount = 3250,
                           Reference  = "Specializes in global commodities .",
                           Icategory = "Stock Market",
                           Note = " Entries are exceptional, with minimal loss. ",
                           Dated =  DateTime.Now.AddDays(-120)
                        },



                            new Infoincome()

                       {    Incomename = "Rent Income",
                            SaleAmount = 600,
                           Reference  = "Rent has been payed on time.",
                           Icategory = "Rent Income",
                           Note = " Tenant has good moral and is content with his home. ",
                           Dated =  DateTime.Now.AddDays(-120)
                        },



                            new Infoincome()

                       {    Incomename = "Salary",
                            SaleAmount = 100,
                            Reference  = "Exemplary programmer at a high-tech company.",
                            Icategory = "Salary",
                            Note = " Understands computers well, and can create magnificent programs. ",
                            Dated =  DateTime.Now.AddDays(-120)
                        },


                    });
                    context.SaveChanges();
                }// Income

                if (!context.myexpenses.Any())
                {
                    context.myexpenses.AddRange(new List<Myexpense>()
                    {

                       new Myexpense()
                        {
                           Expname = "Restaurant",
                           ExpAmount = 750,
                           Reference = "Dinner Wife",
                           Excategory = "Restaurant",
                           Note = "Saturday Night",
                           Datedexp =  DateTime.Now.AddDays(1)
                        },

                       new Myexpense()
                        {
                           Expname = "Restaurant",
                           ExpAmount = 650,
                           Reference = "Lunch Family",
                           Excategory = "Restaurant",
                           Note = "Sunday",
                           Datedexp =  DateTime.Now.AddDays(1)
                        },

                       new Myexpense()
                        {
                           Expname = "Groceries",
                           ExpAmount = 1100,
                           Reference = "Main Groceries",
                           Excategory = "Groceries",
                           Note = "Full week ",
                           Datedexp =  DateTime.Now.AddDays(1)
                        },

                       new Myexpense()
                        {
                           Expname = "Fixed Garden",
                           ExpAmount = 1260,
                           Reference = "Front Garage",
                           Excategory = "Garden",
                           Note = "Front Garage House ",
                           Datedexp =  DateTime.Now.AddDays(1)
                        },


                        new Myexpense()
                        {
                           Expname = "Fixed Door",
                           ExpAmount = 1100,
                           Reference = "Front Door",
                           Excategory = "Other",
                           Note = "Front Door House ",
                           Datedexp =  DateTime.Now.AddDays(1)
                        },

                        new Myexpense()
                        {
                           Expname = "Payment Car",
                           ExpAmount = 830,
                           Reference = "Insurance",
                           Excategory = "Insurance",
                           Note = "Insurance Wife ",
                           Datedexp =  DateTime.Now.AddDays(1)
                        },

                        new Myexpense()
                        {
                           Expname = "Gas Car",
                           ExpAmount = 250,
                           Reference = "Gas Office",
                           Excategory = "Gas",
                           Note = "Main Car",
                           Datedexp =  DateTime.Now.AddDays(1)
                        },
                        ///// here is the 30 
                        ///
                        new Myexpense()
                        {
                           Expname = "Restaurant",
                           ExpAmount =600,
                           Reference = "Dinner Wtih family",
                           Excategory = "Restaurant",
                           Note = "Saturday Night",
                           Datedexp =  DateTime.Now.AddDays(-30)
                        },

                       new Myexpense()
                        {
                           Expname = "Restaurant",
                           ExpAmount = 550,
                           Reference = "Lunch With Family",
                           Excategory = "Restaurant",
                           Note = "Sunday",
                           Datedexp =  DateTime.Now.AddDays(-30)
                        },

                       new Myexpense()
                        {
                           Expname = "Groceries",
                           ExpAmount = 550,
                           Reference = "Essential Groceries",
                           Excategory = "Groceries",
                           Note = "Full week ",
                           Datedexp =  DateTime.Now.AddDays(-30)
                        },

                       new Myexpense()
                        {
                           Expname = "Garden Repairment",
                           ExpAmount = 2000,
                           Reference = "Front Garage",
                           Excategory = "Garden",
                           Note = "Front Garage House ",
                           Datedexp =  DateTime.Now.AddDays(-30)
                        },


                        new Myexpense()
                        {
                           Expname = "Door Repairment",
                           ExpAmount = 240,
                           Reference = "Front Door",
                           Excategory = "Other",
                           Note = "Front Door House ",
                           Datedexp =  DateTime.Now.AddDays(-30)
                        },

                        new Myexpense()
                        {
                           Expname = "Car Payment",
                           ExpAmount = 700,
                           Reference = "Insurance",
                           Excategory = "Insurance",
                           Note = "Insurance Wife ",
                           Datedexp =  DateTime.Now.AddDays(-30)
                        },

                        new Myexpense()
                        {
                           Expname = "Gas for Car",
                           ExpAmount = 115,
                           Reference = "Gas Office",
                           Excategory = "Gas",
                           Note = "Main Car",
                           Datedexp =  DateTime.Now.AddDays(-30)
                        },
                        /// 60 
                        /// 
                        new Myexpense()
                        {
                           Expname = "Restaurant",
                           ExpAmount = 150,
                           Reference = "Dinner Wife",
                           Excategory = "Restaurant",
                           Note = "Saturday Night",
                           Datedexp =  DateTime.Now.AddDays(-60)

                        },

                       new Myexpense()
                        {
                           Expname = "Restaurant",
                           ExpAmount = 250,
                           Reference = "Lunch With Family",
                           Excategory = "Restaurant",
                           Note = "Sunday",
                           Datedexp =  DateTime.Now.AddDays(-60)
                        },

                       new Myexpense()
                        {
                           Expname = "Groceries",
                           ExpAmount = 340,
                           Reference = "Main Groceries",
                           Excategory = "Groceries",
                           Note = "Full week ",
                           Datedexp =  DateTime.Now.AddDays(-60)
                        },

                       new Myexpense()
                        {
                           Expname = "Garden Repairment",
                           ExpAmount = 860,
                           Reference = "Front of House",
                           Excategory = "Garden",
                           Note = "Front Garage House ",
                           Datedexp =  DateTime.Now.AddDays(-60)
                        },


                        new Myexpense()
                        {
                           Expname = "Door Repairment",
                           ExpAmount = 1200,
                           Reference = "Front Door",
                           Excategory = "Other",
                           Note = "Front Door House ",
                           Datedexp =  DateTime.Now.AddDays(-60)
                        },

                        new Myexpense()
                        {
                           Expname = "Car Payment",
                           ExpAmount = 640,
                           Reference = "Car Insurance",
                           Excategory = "Insurance",
                           Note = "Insurance Wife ",
                           Datedexp =  DateTime.Now.AddDays(-60)
                        },

                        new Myexpense()
                        {
                           Expname = "Gas For Car",
                           ExpAmount = 150,
                           Reference = "Gas To Go To Work",
                           Excategory = "Gas",
                           Note = "Main Car",
                           Datedexp =  DateTime.Now.AddDays(-60)
                        },
                        /// 90
                        /// 

                        new Myexpense()
                        {
                           Expname = "Restaurant",
                           ExpAmount = 130,
                           Reference = "Dinner Wtih Wife",
                           Excategory = "Restaurant",
                           Note = "Saturday Night",
                           Datedexp =  DateTime.Now.AddDays(-90)
                        },

                       new Myexpense()
                        {
                           Expname = "Restaurant",
                           ExpAmount = 100,
                           Reference = "Lunch With Family",
                           Excategory = "Restaurant",
                           Note = "Sunday",
                           Datedexp =  DateTime.Now.AddDays(-90)
                        },

                       new Myexpense()
                        {
                           Expname = "Groceries",
                           ExpAmount = 350,
                           Reference = "Main Groceries",
                           Excategory = "Groceries",
                           Note = "Full week ",
                           Datedexp =  DateTime.Now.AddDays(-90)
                        },

                       new Myexpense()
                        {
                           Expname = "Garden Repairment",
                           ExpAmount = 1750,
                           Reference = "Front Of House",
                           Excategory = "Garden",
                           Note = "Front Garage House ",
                           Datedexp =  DateTime.Now.AddDays(-90)
                        },


                        new Myexpense()
                        {
                           Expname = "Door Repairment",
                           ExpAmount = 970,
                           Reference = "Back Door",
                           Excategory = "Other",
                           Note = "Front Door House ",
                           Datedexp =  DateTime.Now.AddDays(-90)
                        },

                        new Myexpense()
                        {
                           Expname = "Car Payment",
                           ExpAmount = 750,
                           Reference = "Car Insurance",
                           Excategory = "Insurance",
                           Note = "Insurance Wife ",
                           Datedexp =  DateTime.Now.AddDays(-90)
                        },

                        new Myexpense()
                        {
                           Expname = "Gas For Car",
                           ExpAmount = 160,
                           Reference = "Gas For Vacation Road Trip",
                           Excategory = "Gas",
                           Note = "Main Car",
                           Datedexp =  DateTime.Now.AddDays(-90)
                        },
                        /// 120
                        /// 


                        new Myexpense()
                        {
                           Expname = "Restaurant",
                           ExpAmount = 450,
                           Reference = "Dinner With Wife",
                           Excategory = "Restaurant",
                           Note = "Saturday Night",
                           Datedexp =  DateTime.Now.AddDays(-120)
                        },

                       new Myexpense()
                        {
                           Expname = "Restaurant",
                           ExpAmount = 350,
                           Reference = "Dinner With Family",
                           Excategory = "Restaurant",
                           Note = "Sunday",
                           Datedexp =  DateTime.Now.AddDays(-120)
                        },

                       new Myexpense()
                        {
                           Expname = "Groceries",
                           ExpAmount = 850,
                           Reference = "Main Groceries",
                           Excategory = "Groceries",
                           Note = "Full week ",
                           Datedexp =  DateTime.Now.AddDays(-120)
                        },

                       new Myexpense()
                        {
                           Expname = "Garden Repairment",
                           ExpAmount = 1550,
                           Reference = "Front Of House",
                           Excategory = "Garden",
                           Note = "Front Garage House ",
                           Datedexp =  DateTime.Now.AddDays(-120)
                        },


                        new Myexpense()
                        {
                           Expname = "Fixed Door",
                           ExpAmount = 1300,
                           Reference = "Side Door",
                           Excategory = "Other",
                           Note = "Front Door House ",
                           Datedexp =  DateTime.Now.AddDays(-120)
                        },

                        new Myexpense()
                        {
                           Expname = "Car Payment",
                           ExpAmount = 550,
                           Reference = "Car Insurance",
                           Excategory = "Insurance",
                           Note = "Wife Must Pay Insurance Bill ",
                           Datedexp =  DateTime.Now.AddDays(-120)
                        },

                        new Myexpense()
                        {
                           Expname = "Gas For Car",
                           ExpAmount = 180,
                           Reference = "Gas For Work",
                           Excategory = "Gas",
                           Note = "Main Car",
                           Datedexp =  DateTime.Now.AddDays(-120)
                        },
                        ///





                     });
                    context.SaveChanges();
                }// Income


            }
        }
    }
}
