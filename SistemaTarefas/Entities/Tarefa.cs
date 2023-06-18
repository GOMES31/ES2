using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace SistemaTarefas.Entities

{     
    [Table("tarefas")]  

    public partial class Tarefa
    {
        [Key]
        [Column("id_tarefa")]
        public int id_tarefa { get; set; }
        
        [Column("hora_inicio", TypeName = "date")]
        public DateTime hora_inicio { get; set; }
        
        [Column("hora_fim", TypeName = "date")]
        public DateTime? hora_fim { get; set; }
        
        [Column("estado")]
        public string estado { get; set; }
        
        [Column("descricao")]
        public string descricao { get; set; }
        
        [Column("precohora")]
        [Range(0, int.MaxValue)]
        public decimal? precohora { get; set; }
        
        [ForeignKey("Projetos")]
        public int? id_projeto { get; set; }


        [ForeignKey("utilizador")]
        public string Username { get; set; }

        public Projeto projetos { get; set; }
    }
}