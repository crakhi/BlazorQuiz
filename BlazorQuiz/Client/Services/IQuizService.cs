using BlazorQuiz.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorQuiz.Client.Services
{
    public interface IQuizService
    {
        public Task AddQuestionAsync(AddQuestionViewModel addQuestionViewModel);
        public Task<AddQuestionViewModel> GetQuestionAsync(string questionId);
    }
}
