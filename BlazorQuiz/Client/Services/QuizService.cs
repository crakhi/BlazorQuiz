using BlazorQuiz.Shared;
using BlazorQuiz.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorQuiz.Client.Services
{
    public class QuizService : IQuizService
    {
        private readonly HttpClient httpClient;

        public QuizService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task AddQuestion(AddQuestionViewModel addQuestionViewModel)
        {
            await httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
    }
}
