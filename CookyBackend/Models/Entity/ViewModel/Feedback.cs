﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookyBackend.Models.Entity.ViewModel
{
    public class Feedback
    {
        public int Id { get; set; }
        public string FeedbackContent { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
    }
}
