using System;
using System.Collections.Generic;

namespace Labb3.Models
{
    public partial class Faculty
    {
        public int PkFacultyId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public int FkFacultyTypeId { get; set; }

        public virtual FacultyType FkFacultyType { get; set; } = null!;
    }
}
