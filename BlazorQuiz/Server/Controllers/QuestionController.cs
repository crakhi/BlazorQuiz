using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorQuiz.Client.Pages;
using BlazorQuiz.EntityFramework;
using BlazorQuiz.EntityFramework.Entities;
using BlazorQuiz.Server.Data;
using BlazorQuiz.Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorQuiz.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ApplicationDbContext quizContext;

        public QuestionController(ApplicationDbContext quizContext)
        {
            this.quizContext = quizContext;
        }
        //[HttpGet]
        //public IEnumerable<Question> Get()
        //{ 
        //}

        [HttpPost]
        public async Task AddQuestion(AddQuestionViewModel addQuestionViewModel)
        {
            Question question = new Question
            {
                Options = GetOptions(addQuestionViewModel),
                AreaTags = GetAreaTags(addQuestionViewModel.AreaTags),
                ExamTags = GetExamTags(addQuestionViewModel.ExamTags),
                LanguageTags = GetLanguageTags(addQuestionViewModel.LanguageTags),
                QuestionContent = addQuestionViewModel.Question
            };
            quizContext.Questions.Add(question);

            await quizContext.SaveChangesAsync();
        }

        //[HttpGet]
        //public async Task<AddQuestionViewModel> GetQuestion(int questionId)
        //{
        //    Console.WriteLine(questionId);
        //    Console.WriteLine("Called");
        //    Question a = await quizContext.Questions.FindAsync(questionId);

        //    Console.WriteLine(JsonConvert.SerializeObject(a));
        //    return new AddQuestionViewModel {
        //        Question = a.QuestionContent,

        //    };
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            Question a = await quizContext.Questions.FindAsync(id);
            
            Console.WriteLine(JsonConvert.SerializeObject(a));
            var b =  new AddQuestionViewModel
            {
                Question = a.QuestionContent,
                

            };
            b.OptionA = b.OptionB = b.OptionC = b.OptionD = b.OptionE = b.Question;
            return Ok(b);
        }

        private ICollection<LanguageTags> GetLanguageTags(string[] langTags)
        {
            List<LanguageTags> languageTags = new List<LanguageTags>();

            foreach (var item in langTags)
            {
                LanguageTags lang = new LanguageTags { Name = item };
                languageTags.Add(lang);
            }

            return languageTags;
        }

        private ICollection<ExamTags> GetExamTags(string[] examTags1)
        {
            List<ExamTags> examTags = new List<ExamTags>();

            foreach (var item in examTags1)
            {
                ExamTags exam = new ExamTags { Name = item };
                examTags.Add(exam);
            }

            return examTags;
        }

        private ICollection<AreaTags> GetAreaTags(string[] areaTags)
        {
            List<AreaTags> areaTags1 = new List<AreaTags>();

            foreach (var item in areaTags)
            {
                AreaTags exam = new AreaTags { Name = item };
                areaTags1.Add(exam);
            }

            return areaTags1;
        }

        private ICollection<Option> GetOptions(AddQuestionViewModel addQuestionViewModel)
        {
            List<Option> options = new List<Option> {
             new Option{ OptionContent=addQuestionViewModel.OptionA, IsAnswer=addQuestionViewModel.IsOptionASelected},
             new Option{ OptionContent=addQuestionViewModel.OptionB, IsAnswer=addQuestionViewModel.IsOptionBSelected},
            new Option{ OptionContent=addQuestionViewModel.OptionC, IsAnswer=addQuestionViewModel.IsOptionCSelected},
            new Option{ OptionContent=addQuestionViewModel.OptionD, IsAnswer=addQuestionViewModel.IsOptionDSelected},
            new Option{ OptionContent=addQuestionViewModel.OptionE, IsAnswer=addQuestionViewModel.IsOptionESelected}
            };

            return options;
        }
    }
}
