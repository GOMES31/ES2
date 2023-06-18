
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SistemaTarefas.Entities
{
    [Table("users")]
    public class User
    {
        public User(string email, string password, string name)
        {
            this.email = email;
            this.password = password;
            this.name = name;
        }
        [Key]
        [Column("idUser")]
        public int idUser { get; set; }
        [Required]
        [Column("email")]
        [StringLength(100)]
        public string email { get; set; }
        [Required]
        [Column("password")]
        [StringLength(100)]
        public string password { get; set; }
        [Column("name")]
        [StringLength(100)]
        public string name { get; set; }
        
        [Column("nhoras")]
        [Range(0, int.MaxValue, ErrorMessage = "O número de horas tem de ser positivo.")]
        public int? nhoras { get; set; } = 0;
    }
}

