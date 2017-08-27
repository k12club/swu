using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Migrations
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<SwuDBContext>
    {
        private const string CID1 = "2e172c30-ba70-4036-b609-91ecabbad3b7";
        private const string CID2 = "518263c4-888d-48bc-b924-d2ccf9eb9937";
        private const string CID3 = "6a7040c9-ac77-4c5b-bb51-4e830eced91f";
        private const string CID4 = "a6533489-8ebe-45eb-ac86-b9c2a12840a5";
        private const string CID5 = "ce4bcf32-41af-49bb-9183-a815780eebfd";
        private const string CID6 = "d5429b19-de51-48f9-bd43-2b2060789a4d";
        private const string CID7 = "e1b8d39e-333b-4af8-9c92-f744427bf3b5";
        private const string CID8 = "f0e86e6e-a1f7-45ee-961b-6addae78a5fe";
        private const string CID9 = "f8d9a209-fe7c-49c0-9c2b-4993d37bdf35";
        protected override void Seed(SwuDBContext context) {

            this.AddCourses(context);
            base.Seed(context);
        }
        private void AddCourses(SwuDBContext context)
        {
            var categories = new List<CourseCategory>();
            var courses = new List<Course>();
            var curriculums = new List<Curriculum>();
            #region Curriculum
            var cur1 = new Curriculum
            {
                Name = "Lecture 1.1 Practical language work",
                Type = CurriculumType.Lecture,
                CourseId = CID1
            };
            var cur2 = new Curriculum
            {
                Name = "Lecture 1.2 Study of important works and/or topics",
                Type = CurriculumType.Lecture,
                CourseId = CID1
            };
            var cur3 = new Curriculum
            {
                Name = "Lecture 1.3 Literature of the language",
                Type = CurriculumType.Lecture,
                CourseId = CID1
            };
            var cur4 = new Curriculum
            {
                Name = "Quizzes History of the language test",
                Type = CurriculumType.Quize,
                CourseId = CID1
            };
            var cur5 = new Curriculum
            {
                Name = "Lecture 1.4 General linguistics",
                Type = CurriculumType.Lecture,
                CourseId = CID1
            };
            var cur6 = new Curriculum
            {
                Name = "Lecture 1.5 Phonetics and phonology ",
                Type = CurriculumType.Lecture,
                CourseId = CID1
            };
            var cur7 = new Curriculum
            {
                Name = "Lecture 1.6 Grammatical analysis",
                Type = CurriculumType.Lecture,
                CourseId = CID1
            };
            curriculums.Add(cur1);
            curriculums.Add(cur2);
            curriculums.Add(cur3);
            curriculums.Add(cur4);
            curriculums.Add(cur5);
            curriculums.Add(cur6);
            curriculums.Add(cur7);
            #endregion

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
                Id = CID1,
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
                Id = CID2,
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
                Id = CID3,
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
                Id = CID4,
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
                Id = CID5,
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
                Id = CID6,
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
                Id = CID7,
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
                Id = CID8,
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
                Id = CID9,
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

            context.Curriculums.AddRange(curriculums);
            context.SaveChanges();
        }
    }
}
