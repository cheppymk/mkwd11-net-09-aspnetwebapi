﻿using NotesAndTagsApp.Models.Enums;

namespace NotesAndTagsApp.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Priority Priority { get; set; }
        public List<Tag> Tags { get; set; }
     }
}
