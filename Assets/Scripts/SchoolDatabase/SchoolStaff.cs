using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SchoolStaff : MonoBehaviour
{
    public string staffName;
    public float salary;
    public int facultyID;
    public int age;

    [ContextMenu("Debug/Show All Faculty (Name Filter: '')")]
    public void Context_ShowAllFacultyByName()
    {
        var result = ShowAllFaculty("");
        Debug.Log($"[ShowAllFaculty By Name] Result Count: {result?.Count ?? 0}");
    }

    [ContextMenu("Debug/Show All Faculty (ID = -1)")]
    public void Context_ShowAllFacultyByID()
    {
        var result = ShowAllFaculty(-1);
        Debug.Log($"[ShowAllFaculty By ID] Result Count: {result?.Count ?? 0}");
    }

    public List<SchoolStaff> ShowAllFaculty(string searchedName = "")
    {
        Debug.Log($"[ShowAllFaculty(string)] called. Search: {searchedName}");
        List<SchoolStaff> schoolStaff = School.instance.teachersList.Cast<SchoolStaff>().ToList();
        schoolStaff.Add(School.instance.currentPrincipal);

        if (string.IsNullOrEmpty(searchedName))
        {
            Debug.Log($"[ShowAllFaculty] Returning all ({schoolStaff.Count}) faculty.");
            return schoolStaff;
        }

        List<SchoolStaff> filteredStaff = schoolStaff.Where(s => s.staffName.Contains(searchedName)).ToList();
        Debug.Log($"[ShowAllFaculty] Filtered Count: {filteredStaff.Count}");
        return filteredStaff.Count == 0 ? null : filteredStaff;
    }

    public List<SchoolStaff> ShowAllFaculty(int tempFacultyID = -1)
    {
        Debug.Log($"[ShowAllFaculty(int)] called. ID: {tempFacultyID}");
        List<SchoolStaff> schoolStaff = School.instance.teachersList.Cast<SchoolStaff>().ToList();
        schoolStaff.Add(School.instance.currentPrincipal);

        if (tempFacultyID == -1)
        {
            Debug.LogWarning("[ShowAllFaculty] Invalid ID provided.");
            return null;
        }

        List<SchoolStaff> filteredStaff = schoolStaff.Where(s => s.facultyID == tempFacultyID).ToList();
        Debug.Log($"[ShowAllFaculty] Found {filteredStaff.Count} matching ID.");
        return filteredStaff.Count == 0 ? null : filteredStaff;
    }

    [ContextMenu("Debug/Show All Clubs (Name Filter: '')")]
    public void Context_ShowAllClubsByName()
    {
        var result = ShowAllClubs("");
        Debug.Log($"[ShowAllClubs By Name] Result Count: {result?.Count ?? 0}");
    }

    public List<Club> ShowAllClubs(string searchedName = "")
    {
        Debug.Log($"[ShowAllClubs(string)] Search: {searchedName}");
        List<Club> clubs = School.instance.clubsList;

        if (string.IsNullOrEmpty(searchedName))
        {
            Debug.Log($"[ShowAllClubs] Returning all {clubs.Count} clubs.");
            return clubs;
        }

        List<Club> filteredClubs = clubs.Where(c => c.clubName.Contains(searchedName)).ToList();
        Debug.Log($"[ShowAllClubs] Filtered Count: {filteredClubs.Count}");
        return filteredClubs.Count == 0 ? null : filteredClubs;
    }

    [ContextMenu("Debug/Show All Clubs (ID = -1)")]
    public void Context_ShowAllClubsByID()
    {
        var result = ShowAllClubs(-1);
        Debug.Log($"[ShowAllClubs By ID] Result Count: {result?.Count ?? 0}");
    }

    public List<Club> ShowAllClubs(int tempClubID = -1)
    {
        Debug.Log($"[ShowAllClubs(int)] Search ID: {tempClubID}");
        List<Club> clubs = School.instance.clubsList;

        if (tempClubID == -1)
        {
            Debug.LogWarning("[ShowAllClubs] Invalid ID.");
            return null;
        }

        List<Club> filteredClubs = clubs.Where(c => c.clubID == tempClubID).ToList();
        Debug.Log($"[ShowAllClubs] Found {filteredClubs.Count} matching ID.");
        return filteredClubs.Count == 0 ? null : filteredClubs;
    }

    [ContextMenu("Debug/Show All Students (Name Filter: '')")]
    public void Context_ShowAllStudentsByName()
    {
        var result = ShowAllStudents("");
        Debug.Log($"[ShowAllStudents By Name] Result Count: {result?.Count ?? 0}");
    }

    public List<Student> ShowAllStudents(string searchedName = "")
    {
        Debug.Log($"[ShowAllStudents(string)] Search: {searchedName}");
        List<Student> students = School.instance.studentsList;

        if (string.IsNullOrEmpty(searchedName))
        {
            Debug.Log($"[ShowAllStudents] Returning all {students.Count} students.");
            return students;
        }

        List<Student> filteredStudents = students.Where(s => s.studentName.Contains(searchedName)).ToList();
        Debug.Log($"[ShowAllStudents] Filtered Count: {filteredStudents.Count}");
        return filteredStudents.Count == 0 ? null : filteredStudents;
    }

    [ContextMenu("Debug/Show All Students (ID = -1)")]
    public void Context_ShowAllStudentsByID()
    {
        var result = ShowAllStudents(-1);
        Debug.Log($"[ShowAllStudents By ID] Result Count: {result?.Count ?? 0}");
    }

    public List<Student> ShowAllStudents(int tempStudentID = -1)
    {
        Debug.Log($"[ShowAllStudents(int)] Search ID: {tempStudentID}");
        List<Student> students = School.instance.studentsList;

        if (tempStudentID == -1)
        {
            Debug.LogWarning("[ShowAllStudents] Invalid ID.");
            return null;
        }

        List<Student> filteredStudents = students.Where(s => s.studentID == tempStudentID).ToList();
        Debug.Log($"[ShowAllStudents] Found {filteredStudents.Count} matching ID.");
        return filteredStudents.Count == 0 ? null : filteredStudents;
    }

    [ContextMenu("Debug/Show Students In Club (ID = -1)")]
    public void Context_ShowStudentsInClub()
    {
        var result = ShowStudentsInClub(-1);
        Debug.Log($"[ShowStudentsInClub] Result Count: {result?.Count ?? 0}");
    }

    public List<Student> ShowStudentsInClub(int tempClubID = -1)
    {
        Debug.Log($"[ShowStudentsInClub] Club ID: {tempClubID}");
        List<Club> clubs = School.instance.clubsList;

        if (tempClubID == -1)
        {
            Debug.LogWarning("[ShowStudentsInClub] Invalid ID.");
            return null;
        }

        foreach (var club in clubs)
        {
            if (club.clubID == tempClubID)
            {
                Debug.Log($"[ShowStudentsInClub] Found club '{club.clubName}' with {club.membersList.Count} members.");
                return club.membersList;
            }
        }

        Debug.LogWarning("[ShowStudentsInClub] No club matched the provided ID.");
        return null;
    }

    [ContextMenu("Debug/Show All Classrooms")]
    public void Context_ShowAllClassroom()
    {
        var result = ShowAllClassroom();
        Debug.Log($"[ShowAllClassroom] Count: {result?.Count ?? 0}");
    }

    public List<Classroom> ShowAllClassroom()
    {
        Debug.Log("[ShowAllClassroom] Returning classroom list.");
        return School.instance.classroomList;
    }
}
