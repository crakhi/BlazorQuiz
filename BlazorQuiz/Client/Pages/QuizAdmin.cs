using BlazorQuiz.Client.Services;
using BlazorQuiz.Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorQuiz.Client.Pages
{
    public partial class QuizAdmin : ComponentBase
    {

        [Inject]
        public IQuizService QuizService { get; set; }
        public AddQuestionViewModel addQuestionViewModel { get; set; } = new AddQuestionViewModel();
        public string[] DeniedTag = new string[] { "a" };
        public string[] DeniedAttributes = new string[] { "class", "title", "id" };
        public string[] AllowedStyles = new string[] { "color", "margin", "font-size" };

        public EditContext editContext;

        protected override void OnInitialized()
        {
            editContext = new EditContext(addQuestionViewModel);
        }

        public async Task HandleSubmit()
        {
            var isValid = editContext.Validate() &&
                await CustomValidate(editContext);

            if (isValid)
            {
                Console.WriteLine("valid");
                await QuizService.AddQuestionAsync((AddQuestionViewModel)editContext.Model);

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



        public class Countries
        {
            public string Name { get; set; }
            public string Code { get; set; }
        }
        public List<Countries> Country = new List<Countries>
{
        new Countries() { Name = "Australia", Code = "AU" },
        new Countries() { Name = "Bermuda", Code = "BM" },
        new Countries() { Name = "Canada", Code = "CA" },
        new Countries() { Name = "Cameroon", Code = "CM" },
        new Countries() { Name = "Denmark", Code = "DK" },
        new Countries() { Name = "France", Code = "FR" },
        new Countries() { Name = "Finland", Code = "FI" },
        new Countries() { Name = "Germany", Code = "DE" },
        new Countries() { Name = "Greenland", Code = "GL" },
        new Countries() { Name = "Hong Kong", Code = "HK" },
        new Countries() { Name = "India", Code = "IN" },
        new Countries() { Name = "Italy", Code = "IT" },
        new Countries() { Name = "Japan", Code = "JP" },
        new Countries() { Name = "Mexico", Code = "MX" },
        new Countries() { Name = "Norway", Code = "NO" },
        new Countries() { Name = "Poland", Code = "PL" },
        new Countries() { Name = "Switzerland", Code = "CH" },
        new Countries() { Name = "United Kingdom", Code = "GB" },
        new Countries() { Name = "United States", Code = "US" },
    };

        public object[] Items = new object[] {
        "Replace", "Align", "Caption", "Remove",
        "InsertLink", "OpenImageLink", "-", "EditImageLink",
        "RemoveImageLink", "Display", "AltText", "Dimension"
    };

        public object[] Link = new object[] {
        "Open", "Edit", "UnLink"
    };
        private readonly QuizService quizService;
    }
}
