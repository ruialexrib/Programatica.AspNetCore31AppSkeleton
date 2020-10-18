﻿using System;

namespace Programatica.AspNetCore31AppSkeleton.ViewModels
{
    public class DummyViewModel
    {
        public int Id { get; set; }
        public Guid SystemId { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public string LastModifiedUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public DummyViewModel()
        {
            SystemId = Guid.NewGuid();
        }
    }
}
