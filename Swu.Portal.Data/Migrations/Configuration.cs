using System.Data.Entity.Migrations;
using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Security;

namespace Swu.Portal.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Swu.Portal.Data.Context.SwuDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(SwuDBContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SwuDBContext()));
            manager.Create(new ApplicationUser
            {
                UserName = "chansak",
                FirstName = "chansak",
                LastName = "kochasen"
            }, "password");
            this.AddCourses(context);
            base.Seed(context);
        }
        private void AddCourses(SwuDBContext context)
        {
            var categories = new List<CourseCategory>();
            var courses = new List<Course>();
            #region Category
            var cat1 = new CourseCategory
            {
                Title = "Course Category 1"
            };
            var cat2 = new CourseCategory
            {
                Title = "Course Category 2"
            };
            var cat3 = new CourseCategory
            {
                Title = "Course Category 3"
            };
            categories.Add(cat1);
            categories.Add(cat2);
            categories.Add(cat3);
            #endregion

            #region Course
            var c1 = new Course
            {
                CourseId = Guid.NewGuid().ToString(),
                Name_TH = "A11BHS Behavioural Sciences",
                Name_EN = "A11BHS Behavioural Sciences",
                ImageUrl = "Content/images/courses/1.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat1
            };
            var c2 = new Course
            {
                CourseId = Guid.NewGuid().ToString(),
                Name_TH = "A11EXT Structure, function and pharmacology of ExcitableTissues",
                Name_EN = "A11EXT Structure, function and pharmacology of ExcitableTissues",
                ImageUrl = "Content/images/courses/2.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat1
            };
            var c3 = new Course
            {
                CourseId = Guid.NewGuid().ToString(),
                Name_TH = "A11HDT Human Development and Tissue Differentiation",
                Name_EN = "A11HDT Human Development and Tissue Differentiation",
                ImageUrl = "Content/images/courses/13.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat1
            };
            var c4 = new Course
            {
                CourseId = Guid.NewGuid().ToString(),
                Name_TH = "A11MBM Molecular Basis of Medicine",
                Name_EN = "A11MBM Molecular Basis of Medicine",
                ImageUrl = "Content/images/courses/4.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat2
            };
            var c5 = new Course
            {
                CourseId = Guid.NewGuid().ToString(),
                Name_TH = "A11CS1 Communication Skills (I)",
                Name_EN = "A11CS1 Communication Skills (I)",
                ImageUrl = "Content/images/courses/5.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat2
            };
            var c6 = new Course
            {
                CourseId = Guid.NewGuid().ToString(),
                Name_TH = "A11CLS Clinical Laboratory Sciences (I)",
                Name_EN = "A11CLS Clinical Laboratory Sciences (I)",
                ImageUrl = "Content/images/courses/6.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat2
            };
            var c7 = new Course
            {
                CourseId = Guid.NewGuid().ToString(),
                Name_TH = "A11CRH Cardiovascular, Respiratory and Haematology",
                Name_EN = "A11CRH Cardiovascular, Respiratory and Haematology",
                ImageUrl = "Content/images/courses/7.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat3
            };
            var c8 = new Course
            {
                CourseId = Guid.NewGuid().ToString(),
                Name_TH = "A11SF1 Human Development Structure and Function (I)",
                Name_EN = "A11SF1 Human Development Structure and Function (I)",
                ImageUrl = "Content/images/courses/8.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat3
            };
            var c9 = new Course
            {
                CourseId = Guid.NewGuid().ToString(),
                Name_TH = "A11PD1 Early Clinical and Professional Development (I)",
                Name_EN = "A11PD1 Early Clinical and Professional Development (I)",
                ImageUrl = "Content/images/courses/11.jpg",
                BigImageUrl = "Content/images/courses/cd1.jpg",
                Price = 12,
                Language = "English",
                FullDescription = @"<p>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <p class='irs-mrgntp-thrty'>In your study of Linguistics, you will be introduced to the analysis of the nature and structure of human language (including topics such as how words and sentences are formed.</p>
                                                    <ul class='list-unstyled irs-cdtls-spara'>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Teach part time without interrupting your full-time career</li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Know you’re making a difference sharing your wisdom with students </li>
                                                        <li><span class='text-thm2 flaticon-correct-symbol'> </span>Connect with all of your students - in a classroom or online - with our smaller class sizes</li>
                                                    </ul>",
                Category = cat3
            };
            courses.Add(c1);
            courses.Add(c2);
            courses.Add(c3);
            courses.Add(c4);
            courses.Add(c5);
            courses.Add(c6);
            courses.Add(c7);
            courses.Add(c8);
            courses.Add(c9);
            #endregion

            context.CourseCategory.AddRange(categories);
            context.SaveChanges();

            context.Courses.AddRange(courses);
            context.SaveChanges();
        }
    }
}
