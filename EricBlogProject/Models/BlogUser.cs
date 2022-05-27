using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EricBlogProject.Models
{
    public class BlogUser : IdentityUser
    {
        [Required]
        [StringLength(50,ErrorMessage ="The {0} must be at least {2} and no more than {1} characters long.",MinimumLength =2)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }


        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
        public string FacebookUrl { get; set; }
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
        public string TwitterUrl { get; set; }


        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName}{LastName}";
            }
        }

        public virtual ICollection<Blog> Blogs { get; set; } = new HashSet<Blog>();
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

    }
}
