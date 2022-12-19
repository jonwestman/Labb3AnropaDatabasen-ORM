using System;
using System.Collections.Generic;

namespace Labb3.Models
{
    public partial class FacultyType
    {
        public FacultyType()
        {
            Faculties = new HashSet<Faculty>();
        }

        public int PkFacultyTypeId { get; set; }
        public string FacultyType1 { get; set; } = null!;

        public virtual ICollection<Faculty> Faculties { get; set; }
    }
}
