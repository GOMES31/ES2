

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace SistemaTarefas.Entities
{
    [Table("projects")]
    public class Projeto
    {
        [Key]
        [Column("idproject")]
        public int idproject { get; set; }
        
        
        [Required]
        [StringLength(100)]
        [Column("nomeProjeto")]
        public string nomeProjeto { get; set; }
        
        [Column("precohora")]
        [Range(0, int.MaxValue)]
        public decimal? precohora { get; set; }
        [Column("nomecliente")]
        public string nomecliente { get; set; }

        [Column("utilizador")] 
        public string Username { get; set; }
        public List<Tarefa> tarefas { get; set; }
        
    }
    
}
