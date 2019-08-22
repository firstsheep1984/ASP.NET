﻿namespace AdmissionsOnlineSystem.Models
{
    public class EnclosedDocument
    {
        public int Id { get; set; }
        public string ApplicationId { get; set; }
        public Application Application { get; set; }
        public string DocumentType { get; set; }
        public string Name { get; set; }
        public byte[] DocumentFile { get; set; }
    }
}