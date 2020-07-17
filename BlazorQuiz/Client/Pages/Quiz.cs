using BlazorQuiz.Client.Services;
using BlazorQuiz.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorQuiz.Client.Pages
{
    public partial class Quiz: ComponentBase
    {
        [Parameter]
        public string QuestionId { get; set; }
        public AddQuestionViewModel AddQuestionViewModel { get; set; } = new AddQuestionViewModel();


        [Inject]
        public IQuizService QuizService { get; set; }

        public EditContext editContext;

       

        protected async override Task OnInitializedAsync()
        {
            editContext = new EditContext(AddQuestionViewModel);
            Console.WriteLine("Writing : " + QuestionId);
            AddQuestionViewModel = await QuizService.GetQuestionAsync(QuestionId);
            
        }

        public async Task HandleSubmit()
        {
            var isValid = editContext.Validate() &&
                await CustomValidate(editContext);

            if (isValid)
            {
                Console.WriteLine("valid");
                //await QuizService.AddQuestionAsync((AddQuestionViewModel)editContext.Model);

            }
            else
            {
                Console.WriteLine("invalid");
            }
        }

        private async Task<bool> CustomValidate(EditContext editContext)
        {
            var serverChecksValid = true;

            return serverChecksValid;
        }

        public async Task NextQuestion()
        {
            AddQuestionViewModel.Question += "<p> got added</p>< /br>";
        }

        private void NextQuestion(MouseEventArgs e)
        {
            AddQuestionViewModel.Question += "<p> got added</p> <br />";
        }



    }
}
