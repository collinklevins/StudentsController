using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsController {
    public class Student {

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string StateCode { get; set; }
        public int? SAT { get; set; }
        public decimal GPA { get; set; }
        public int? MajorId { get; set; }

        public Major Major { get; set; }

        public override string ToString() {
            return $"Id[{Id}], Firstname[{Firstname}], Lastname[{Lastname}], SAT[{SAT}] "
                + $" GPA[{GPA}] State[{StateCode}] Major[{(Major is null ? "Undeclared" : Major.Description)}]";
        }
    }
}
