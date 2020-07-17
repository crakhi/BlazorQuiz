using BlazorQuiz.Shared;
using BlazorQuiz.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
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

        public async Task AddQuestionAsync(AddQuestionViewModel addQuestionViewModel)
        {
            //await httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");

            
            await httpClient.PostAsJsonAsync<AddQuestionViewModel>("Question", addQuestionViewModel);
        }

        public async Task<AddQuestionViewModel> GetQuestionAsync(string id)
        {
            

            //return new AddQuestionViewModel { Question = "Hellow what?" };
            return await JsonSerializer.DeserializeAsync<AddQuestionViewModel>(
                await httpClient.GetStreamAsync($"Question/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive=true});
        }
    }
}
