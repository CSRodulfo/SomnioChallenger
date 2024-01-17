using Application.MainModule.Services;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.MainModule.Administration.FileManagement.DTO
{
    [DataContract()]
    public partial class DTOFile
    {
        public DTOFile()
        {
        }
        public int IdFile { get; set; }
        public byte[] FileData { get; set; }
        public string MimeType { get; set; }
        public System.DateTime Date { get; set; }
        public string FileName { get; set; }

        public DTOFile(int idfile, byte[] filedata, string mimetype, DateTime date, string filename)
        {
            this.IdFile = idfile;
            this.FileData = filedata;
            this.MimeType = mimetype;
            this.Date = date;
            this.FileName = filename;
        }
    }
}
