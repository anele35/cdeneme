using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace cdeneme.Models
{
    public class Cuzdana

    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string? cuzdanadi {  get; set; }
        
        public decimal bakiye { get; set; }


    }
  
    
}
