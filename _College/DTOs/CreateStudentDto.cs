﻿namespace _College.DTOs
{
    public class CreateStudentDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNum { get; set; }
        public float GPA { get; set; }
        public int BatchId { get; set; }
    }
}
