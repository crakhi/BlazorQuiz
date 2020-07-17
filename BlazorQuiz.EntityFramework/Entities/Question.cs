using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Linq;

namespace BlazorQuiz.EntityFramework.Entities
{
    [Table("Questions", Schema = "Quiz")]

    public class Question
    {
        public int Id { get; set; }
        public string QuestionContent { get; set; }

        public virtual ICollection<LanguageTags> LanguageTags { get; set; }
        public virtual ICollection<ExamTags> ExamTags { get; set; }
        public virtual ICollection<AreaTags> AreaTags { get; set; }

        public string Slug { get; set; }

        public virtual ICollection<Option> Options { get; set; }


    }

    [Table("Options", Schema = "Quiz")]
    public class Option
    {
        [Key]
        public int Id { get; set; }
        public string OptionContent { get; set; }
        public bool IsAnswer { get; set; }
    }

    [Table("LanguageTags", Schema = "Quiz")]
    public class LanguageTags
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Table("AreaTags", Schema = "Quiz")]
    public class AreaTags
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Table("ExamTags", Schema = "Quiz")]
    public class ExamTags
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}
