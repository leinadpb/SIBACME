﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIBACME.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public Category Category { get; set; }
        public int Cantidad { get; set; }
        public int CantidadDisponible { get; set; }
        public bool IsOnReserveCollection { get; set; }
        public bool IsAvailable { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReservedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? LimitDate { get; set; }

        
    }
}
