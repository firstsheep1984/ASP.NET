using AdmissionsOnlineSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmissionsOnlineSystem.ViewModels
{
    public class EnclosedDocumentViewModel
    {
        
        public string ApplicationId { get; set; }
        public Application Application { get; set; }
        public string DocumentType { get; set; }
        public string Name { get; set; }
        public HttpPostedFileBase DocumentFile { get; set; }
        public byte[] DocumentFileDB { get; set; }
    }
}