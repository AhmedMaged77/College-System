﻿using System.ComponentModel.DataAnnotations;

namespace _College.Models
{
    public class Student : BaseEntity
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNum { get; set; }
        public float GPA { get; set; }
        public int BatchId { get; set; }
        public Batch Batch { get; set; }

    }
}
