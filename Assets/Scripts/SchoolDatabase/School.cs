using System.Collections.Generic;
using UnityEngine;

public class School : MonoBehaviour
{
    public static School instance { get; private set; }

    public List<Club> clubsList = new();
    public List<Classroom> classroomList = new();
    public List<Student> studentsList = new();
    public List<Teacher> teachersList = new();
    public Principal currentPrincipal;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("[School] Singleton instance initialized.");
        }
        else
        {
            Debug.LogWarning("[School] Another instance of School already exists!");
        }
    }

    // ==== CREATE ====
    public Student CreateStudents(string name, int grade)
    {
        Student student = new Student(name, grade);
        studentsList.Add(student);
        Debug.Log($"[CreateStudents] Added {name} (Grade {grade})");
        return student;
    }

    public Teacher CreateTeachers(string name, string subject, int age)
    {
        Teacher teacher = new Teacher(name, subject, age);
        teachersList.Add(teacher);
        Debug.Log($"[CreateTeachers] Added {name}, Subject: {subject}");
        return teacher;
    }

    public Classroom CreateClassroom(int maxCapacity)
    {
        Classroom classroom = new Classroom(maxCapacity);
        classroomList.Add(classroom);
        Debug.Log($"[CreateClassroom] Added classroom with capacity {maxCapacity}");
        return classroom;
    }

    public Principal CreatePrincipal(string name, int age)
    {
        Principal principal = new Principal(name, age);
        currentPrincipal = principal;
        Debug.Log($"[CreatePrincipal] New principal: {name}");
        return principal;
    }

    public Club CreateClub(string name, int classroomID, string description, int facultyID)
    {
        Club club = new Club(name, classroomID, description, facultyID);
        clubsList.Add(club);
        Debug.Log($"[CreateClub] Created club: {name}");
        return club;
    }

    // ==== REMOVE ====
    public bool RemoveTeachers(int facultyID)
    {
        Teacher teacher = GetTeacher(facultyID);
        if (teacher == null)
        {
            Debug.LogWarning($"[RemoveTeachers] Teacher with ID {facultyID} not found.");
            return false;
        }

        teachersList.Remove(teacher);
        Debug.Log($"[RemoveTeachers] Removed teacher ID {facultyID}");
        return true;
    }

    public bool RemovePrincipal()
    {
        if (currentPrincipal != null)
        {
            Debug.Log($"[RemovePrincipal] Removed principal: {currentPrincipal.staffName}");
            currentPrincipal = null;
            return true;
        }

        Debug.LogWarning("[RemovePrincipal] No principal to remove.");
        return false;
    }

    public bool RemoveClassrooms(int classroomID)
    {
        Classroom classroom = GetClassroom(classroomID);
        if (classroom == null)
        {
            Debug.LogWarning($"[RemoveClassrooms] Classroom ID {classroomID} not found.");
            return false;
        }

        classroomList.Remove(classroom);
        Debug.Log($"[RemoveClassrooms] Removed classroom ID {classroomID}");
        return true;
    }

    public bool RemoveClub(int clubID)
    {
        Club club = GetClub(clubID);
        if (club == null)
        {
            Debug.LogWarning($"[RemoveClub] Club ID {clubID} not found.");
            return false;
        }

        clubsList.Remove(club);
        Debug.Log($"[RemoveClub] Removed club ID {clubID}");
        return true;
    }

    public bool RemoveStudents(int studentID)
    {
        Student student = GetStudent(studentID);
        if (student == null)
        {
            Debug.LogWarning($"[RemoveStudents] Student ID {studentID} not found.");
            return false;
        }

        studentsList.Remove(student);
        Debug.Log($"[RemoveStudents] Removed student ID {studentID}");
        return true;
    }

    // ==== GET ====
    public Club GetClub(int clubID = 0, string name = "")
    {
        if (clubID > 0)
        {
            foreach (var club in clubsList)
                if (club.clubID == clubID)
                    return club;
        }

        if (!string.IsNullOrEmpty(name))
        {
            foreach (var club in clubsList)
                if (club.clubName == name)
                    return club;
        }

        return null;
    }

    public Teacher GetTeacher(int facultyID = 0, string name = "")
    {
        if (facultyID > 0)
        {
            foreach (var teacher in teachersList)
                if (teacher.facultyID == facultyID)
                    return teacher;
        }

        if (!string.IsNullOrEmpty(name))
        {
            foreach (var teacher in teachersList)
                if (teacher.staffName == name)
                    return teacher;
        }

        return null;
    }

    public Student GetStudent(int studentID = 0, string name = "")
    {
        if (studentID > 0)
        {
            foreach (var student in studentsList)
                if (student.studentID == studentID)
                    return student;
        }

        if (!string.IsNullOrEmpty(name))
        {
            foreach (var student in studentsList)
                if (student.studentName == name)
                    return student;
        }

        return null;
    }

    public Classroom GetClassroom(int classroomID)
    {
        if (classroomID > 0)
        {
            foreach (var classroom in classroomList)
                if (classroom.classroomID == classroomID)
                    return classroom;
        }

        return null;
    }

    public Principal GetPrincipal()
    {
        return currentPrincipal;
    }

    // ==== DEBUG TOOLS ====
    [ContextMenu("Debug/List All Students")]
    public void Debug_ListStudents()
    {
        Debug.Log($"[Debug] Total Students: {studentsList.Count}");
        foreach (var student in studentsList)
            Debug.Log($"Student: {student.studentName}, ID: {student.studentID}");
    }

    [ContextMenu("Debug/List All Clubs")]
    public void Debug_ListClubs()
    {
        Debug.Log($"[Debug] Total Clubs: {clubsList.Count}");
        foreach (var club in clubsList)
            Debug.Log($"Club: {club.clubName}, ID: {club.clubID}");
    }

    [ContextMenu("Debug/List All Teachers")]
    public void Debug_ListTeachers()
    {
        Debug.Log($"[Debug] Total Teachers: {teachersList.Count}");
        foreach (var teacher in teachersList)
            Debug.Log($"Teacher: {teacher.staffName}, ID: {teacher.facultyID}, Subject: {teacher.subject}");
    }
}
