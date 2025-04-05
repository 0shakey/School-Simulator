using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Principal : SchoolStaff, IClubHandler, ISchoolRegistry
{
    public List<Club> allClubsList;

    public Principal(string tempName, int tempAge)
    {
        staffName = tempName;
        age = tempAge;
        facultyID = Random.Range(100000000, 1000000000);
        Debug.Log($"[Principal Constructor] Created principal {staffName} (Age: {age}, ID: {facultyID})");
    }

    public void RequestFunding(float money, int clubID)
    {
        Debug.Log($"[RequestFunding] ClubID: {clubID}, Requested Amount: {money}");
        // TODO: Implement logic
    }

    public void AddFunding(float money, int clubID)
    {
        Debug.Log($"[AddFunding] Adding {money} to club ID {clubID}");
        // TODO: Implement logic
    }

    [ContextMenu("Debug/Create Club (Test Params)")]
    public void Debug_CreateClub()
    {
        var result = RequestCreateClub("Chess Club", 0, "A club for playing chess", this.facultyID);
        Debug.Log(result != null ? $"[RequestCreateClub] Created club: {result.clubName}" : "[RequestCreateClub] Failed to create club.");
    }

    public Club RequestCreateClub(string name, int classroomID, string description, int facultyID)
    {
        Debug.Log($"[RequestCreateClub] Name: {name}, Room: {classroomID}, Description: {description}, FacultyID: {facultyID}");
        Club club = School.instance.CreateClub(name, classroomID, description, facultyID);
        return club;
    }

    [ContextMenu("Debug/Remove Club (ID = -1)")]
    public void Debug_RemoveClub()
    {
        RequestRemoveClub(-1);
    }

    public void RequestRemoveClub(int clubID)
    {
        Debug.Log($"[RequestRemoveClub] Removing club ID: {clubID}");
        School.instance.RemoveClub(clubID);
    }

    [ContextMenu("Debug/Add Student To Club (IDs = 1, 1)")]
    public void Debug_AddStudentToClub()
    {
        AddStudentToClub(1, 1);
    }

    public void AddStudentToClub(int studentID, int clubID)
    {
        Debug.Log($"[AddStudentToClub] StudentID: {studentID}, ClubID: {clubID}");
        Student student = School.instance.GetStudent(studentID, "");
        Club club = School.instance.GetClub(clubID, "");

        if (student == null || club == null)
        {
            Debug.LogWarning("[AddStudentToClub] Student or Club not found!");
            return;
        }

        club.membersList.Add(student);
        Debug.Log($"[AddStudentToClub] Added {student.studentName} to {club.clubName}");
    }

    [ContextMenu("Debug/Remove Student From Club (IDs = 1, 1)")]
    public void Debug_RemoveStudentFromClub()
    {
        RemoveStudentFromClub(1, 1);
    }

    public void RemoveStudentFromClub(int studentID, int clubID)
    {
        Debug.Log($"[RemoveStudentFromClub] StudentID: {studentID}, ClubID: {clubID}");
        Student student = School.instance.GetStudent(studentID, "");
        Club club = School.instance.GetClub(clubID, "");

        if (student == null || club == null)
        {
            Debug.LogWarning("[RemoveStudentFromClub] Student or Club not found!");
            return;
        }

        club.membersList.Remove(student);
        Debug.Log($"[RemoveStudentFromClub] Removed {student.studentName} from {club.clubName}");
    }

    [ContextMenu("Debug/Create Student (Test)")]
    public void Debug_CreateStudent()
    {
        var student = RequestCreateStudents("Alex", 11);
        Debug.Log($"[RequestCreateStudents] Created student: {student.studentName} (Grade {student.grade})");
    }

    public Student RequestCreateStudents(string name, int grade)
    {
        Debug.Log($"[RequestCreateStudents] Name: {name}, Grade: {grade}");
        return School.instance.CreateStudents(name, grade);
    }

    [ContextMenu("Debug/Remove Student (ID = 1)")]
    public void Debug_RemoveStudent()
    {
        RequestRemoveStudents(1);
    }

    public void RequestRemoveStudents(int studentID)
    {
        Debug.Log($"[RequestRemoveStudents] StudentID: {studentID}");
        School.instance.RemoveStudents(studentID);
    }

    [ContextMenu("Debug/Create Teacher (Test)")]
    public void Debug_CreateTeacher()
    {
        var teacher = RequestCreateTeachers("Ms. Smith", "Math", 32);
        Debug.Log($"[RequestCreateTeachers] Created teacher: {teacher.staffName} (Subject: {teacher.subject})");
    }

    public Teacher RequestCreateTeachers(string name, string subject, int age)
    {
        Debug.Log($"[RequestCreateTeachers] Name: {name}, Subject: {subject}, Age: {age}");
        return School.instance.CreateTeachers(name, subject, age);
    }

    [ContextMenu("Debug/Remove Teacher (ID = 1)")]
    public void Debug_RemoveTeacher()
    {
        RequestRemoveTeachers(1);
    }

    public void RequestRemoveTeachers(int facultyID)
    {
        Debug.Log($"[RequestRemoveTeachers] FacultyID: {facultyID}");
        School.instance.RemoveTeachers(facultyID);
    }

    [ContextMenu("Debug/Create Principal (Test)")]
    public void Debug_CreatePrincipal()
    {
        var principal = RequestCreatePrincipal("Mr. White", 50);
        Debug.Log($"[RequestCreatePrincipal] Created Principal: {principal.staffName}");
    }

    public Principal RequestCreatePrincipal(string name, int age)
    {
        Debug.Log($"[RequestCreatePrincipal] Name: {name}, Age: {age}");
        return School.instance.CreatePrincipal(name, age);
    }

    [ContextMenu("Debug/Remove Principal")]
    public void Debug_RemovePrincipal()
    {
        RequestRemovePrincipal();
    }

    public void RequestRemovePrincipal()
    {
        Debug.Log("[RequestRemovePrincipal]");
        School.instance.RemovePrincipal();
    }

    [ContextMenu("Debug/Create Classroom (Capacity = 30)")]
    public void Debug_CreateClassroom()
    {
        var room = RequestCreateClassroom(30);
        Debug.Log($"[RequestCreateClassroom] Created classroom with capacity {room.maxCapacity}");
    }

    public Classroom RequestCreateClassroom(int maxCapacity)
    {
        Debug.Log($"[RequestCreateClassroom] Capacity: {maxCapacity}");
        return School.instance.CreateClassroom(maxCapacity);
    }

    [ContextMenu("Debug/Remove Classroom (ID = 0)")]
    public void Debug_RemoveClassroom()
    {
        RequestRemoveClassrooms(0);
    }

    public void RequestRemoveClassrooms(int classRoomID)
    {
        Debug.Log($"[RequestRemoveClassrooms] RoomID: {classRoomID}");
        School.instance.RemoveClassrooms(classRoomID);
    }
}
