﻿using ECOM.WebChat.Models2.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ECOM.WebChat.Models2
{
    public class Message : BaseEntity
    {
        public Message()
        {
            base.CreatedOn = DateTime.Now;
        }

        public string Text { get; set; }

        public string SenderId { get; set; }
        [Required]
        public User Sender { get; set; }

        public string ThreadId { get; set; }
        [Required]
        public Thread Thread { get; set; }


    }

}
