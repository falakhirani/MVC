using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_WEB_APP.Models
{
  public class Teacher
    {
        [Key] 
        public int TeacherId {get; set;}

        [Required]
        public string Teacher_name {get; set;}


        [Required]
        public string Subject {get; set;}

        [Range(1,5)]

        public int credits {get; set;}
    }
}