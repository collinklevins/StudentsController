using StudentsController;

var studctr1 = new StudentController("localhost\\sqlexpress","EdDb");
studctr1.OpenConnection();
var majctr1 = new MajorController("localhost\\sqlexpress","EdDb");
majctr1.OpenConnection();


//var student = studctr1.GetStudentByPk(68);

//Console.WriteLine(student);
var students = studctr1.GetAllStudents();
var majors = majctr1.GetAllMajors();

var studentMajors = from s in students
                    join m in majors
                    on s.MajorId equals m.Id
                    where s.StateCode == "OH"
                    orderby s.Lastname descending
                    select new {
                        Fullname = s.Firstname + " " + s.Lastname,
                        Major = m.Description
                    };
foreach (var sm in studentMajors) {
    Console.WriteLine($"{sm.Fullname} | {sm.Major}");
}


//var studentsmajors = from student in students
//                     orderby student.Major.Description
//                     select new {
//                         student.Firstname, student.Lastname, Major = student.Major.Description
//                     };
                 

    //var studentsFromOhio = (from student in students
    //                        orderby student.SAT descending
    //                        select student).FirstOrDefault();

    //var studentFromOhio = students.Where(students => students.StateCode == "OH" && students.GPA >= 3).OrderBy(students => students.Lastname);
//    foreach (var student in studentsmajors) {
//    Console.WriteLine(student);
//}

//var student = new student() {
//    firstname = "graham", lastname = "kraker",
//    statecode = "oh", gpa = 3.0m, sat = 1200, majorid = 1
//};

//student.Id = 70;
//var rc = studctr1.ChangeStudent(student);

//var rc = studctr1.AddStudent(student);

studctr1.CloseConnection();
majctr1.CloseConnection();
