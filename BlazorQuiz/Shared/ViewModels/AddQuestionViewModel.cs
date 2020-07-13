using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorQuiz.Shared.ViewModels
{
    public class AddQuestionViewModel
    {
        [Required]
        public string Question { get; set; }

        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string OptionE { get; set; }

        public bool IsOptionASelected { get; set; }
        public bool IsOptionBSelected { get; set; }
        public bool IsOptionCSelected { get; set; }
        public bool IsOptionDSelected { get; set; }
        public bool IsOptionESelected { get; set; }

        [Required]
        public string[] LanguageTags { get; set; }
        [Required] 
        public string[] AreaTags { get; set; }
        [Required] 
        public string[] ExamTags { get; set; }


    }
}
