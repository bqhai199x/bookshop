﻿namespace Entities.ViewModel
{
    public class CategoryRq
    {
        public class InsertDto {
            public string Name { get; set; } = string.Empty;

            public string Description { get; set; } = string.Empty;
        }

        public class UpdateDto
        {
            public int Id { get; set; } = 0;

            public string Name { get; set; } = string.Empty;

            public string Description { get; set; } = string.Empty;
        }
    }
}
