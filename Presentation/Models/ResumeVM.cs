﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class ResumeVM
    {
        public int resumeId { get; set; }
        public string description { get; set; }
        public string note { get; set; }
        public virtual ICollection<skill> skill { get; set; }
        public virtual int ownerId {get;set;}
        public virtual string ownerName { get; set; }
    }
}