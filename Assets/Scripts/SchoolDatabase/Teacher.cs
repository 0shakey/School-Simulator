using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : SchoolStaff, IClubHandler
{
    public string subject;
    public List<Club> clubsList;
    public Classroom classroom;

    public Teacher(string tempName, string tempSubject, int tempAge)
    {
        staffName = tempName;
        subject = tempSubject;
        age = tempAge;
        facultyID = Random.Range(100000000, 1000000000);
        Debug.Log($"[Teacher Constructor] Created teacher {staffName}, Subject: {subject}, Age: {age}, ID: {facultyID}");
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
        var result = RequestCreateClub("Mathletes", 1, "Club for math competitions", this.facultyID);
        Debug.Log(result != null ? $"[RequestCreateClub] Created club: {result.clubName}" : "[RequestCreateClub] Failed to create club.");
    }

    public Club RequestCreateClub(string name, int classroomID, string description, int facultyID)
    {
        Debug.Log($"[RequestCreateClub] Name: {name}, Room: {classroomID}, Description: {description}, FacultyID: {facultyID}");
        return School.instance.CreateClub(name, classroomID, description, facultyID);
    }

    [ContextMenu("Debug/Remove Club (ID = 1)")]
    public void Debug_RemoveClub()
    {
        RequestRemoveClub(1);
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
}
