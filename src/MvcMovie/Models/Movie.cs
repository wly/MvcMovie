using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Movie
    {
        //public int ID { get; set; }

        //public string Title { get; set; }

        //[Display(Name = "Release Date")]
        //[DataType(DataType.Date)]
        //public DateTime ReleaseDate { get; set; }

        //public string Genre { get; set; }

        //public decimal Price { get; set; }

        //public string Rating { get; set; }

        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3, ErrorMessage = "标题最大长度60，最小长度3")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "标题是必须的")]
        public string Title { get; set; }

        [Display(Name = "Release Date", Description ="发行日期")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(30)]
        [Display(Name = "Genre", Description = "流派")]
        public string Genre { get; set; }

        [Range(0.01, 1000, ErrorMessage = "价格范围为0.01至1000")]
        [Display(Name = "Price", Description = "价格")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        [Display(Name = "Rating", Description = "评级")]
        public string Rating { get; set; }
    }
}
