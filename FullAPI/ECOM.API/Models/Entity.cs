﻿using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace ECOM.API.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        [Column(TypeName = "varchar(36)")]
        public Guid Id { get; set; }
    }
}
