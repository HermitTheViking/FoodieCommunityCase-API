﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FoodieCommunityCase.Domain.Pagination
{
    public class PaginationQuery
    {
        public string Filter { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int? Skip { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int? Take { get; set; }
    }
}
