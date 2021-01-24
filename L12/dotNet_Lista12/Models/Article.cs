using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet_Lista12.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        //aby zapobiec sytuacji gdzie dane z formularze nie mapowałyby się 1-1 do danych domenowych
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
