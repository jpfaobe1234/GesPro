﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entity
{
    public class UserTask
    {
		[Key]
		public int UserTaskId { get; set; }

		[ForeignKey("Tasks")]
		public int? taskId { get; set; }

        [ValidateNever]
        public Tasks? Tasks { get; set; }

        [ValidateNever]
        public bool isLeave { get; set; }


        [ForeignKey("Leaves")]
        public int? leaveId { get; set; }

        [ValidateNever]
        public Leaves? Leaves { get; set; }

        [ValidateNever]
        [ForeignKey("User")]
		public int userId { get; set; }


        [ValidateNever]
        public User? User { get; set; }


        [Required]
		public DateTime date { get; set; }

		[Required]
        [DataType(DataType.Currency)]
        public double hours { get; set; }

        // Nouvelle propriété pour stocker l'utilisateur qui effectue la suppression
        [NotMapped]
        public int UserMaj { get; set; }

    }
}
