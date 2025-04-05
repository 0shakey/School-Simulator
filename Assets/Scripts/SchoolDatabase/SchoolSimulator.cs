using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolSimulator : MonoBehaviour
{
    [Header("Simulation Settings")]
    public int studentCount = 50;
    public int teacherCount = 5;
    public int classroomCount = 5;
    public int clubCount = 3;
    public float actionInterval = 3f; // seconds between student join/leave events

    private Principal principal;

    private void Start()
    {
        Debug.Log("=== School Simulation Started ===");

        if (School.instance == null)
        {
            Debug.LogError("[SchoolSimulator] School instance is missing in scene!");
            return;
        }

        RunSetup();
        StartCoroutine(SimulateClubActivity());
    }

    private void RunSetup()
    {
        // Create principal
        principal = School.instance.CreatePrincipal("Principal Nova", 55);

        // Create classrooms
        for (int i = 0; i < classroomCount; i++)
        {
            School.instance.CreateClassroom(Random.Range(20, 35));
        }

        // Create teachers
        for (int i = 0; i < teacherCount; i++)
        {
            string name = $"Teacher_{i + 1}";
            string subject = $"Subject_{Random.Range(1, 5)}";
            School.instance.CreateTeachers(name, subject, Random.Range(25, 60));
        }

        // Create students
        for (int i = 0; i < studentCount; i++)
        {
            string name = $"Student_{i + 1}";
            int grade = Random.Range(9, 13); // Grades 9-12
            School.instance.CreateStudents(name, grade);
        }

        // Create clubs
        for (int i = 0; i < clubCount; i++)
        {
            string clubName = $"Club_{i + 1}";
            int classroomID = School.instance.classroomList[Random.Range(0, School.instance.classroomList.Count)].classroomID;
            int advisorID = School.instance.teachersList[Random.Range(0, School.instance.teachersList.Count)].facultyID;
            principal.RequestCreateClub(clubName, classroomID, $"Description for {clubName}", advisorID);
        }

        Debug.Log($"[Setup Complete] {studentCount} students, {teacherCount} teachers, {clubCount} clubs.");
    }

    private IEnumerator SimulateClubActivity()
    {
        while (true)
        {
            yield return new WaitForSeconds(actionInterval);

            if (School.instance.studentsList.Count == 0 || School.instance.clubsList.Count == 0)
            {
                Debug.LogWarning("[SimulateClubActivity] Not enough students or clubs to run simulation.");
                continue;
            }

            Student randomStudent = School.instance.studentsList[Random.Range(0, School.instance.studentsList.Count)];
            Club randomClub = School.instance.clubsList[Random.Range(0, School.instance.clubsList.Count)];

            bool isMember = randomClub.membersList.Contains(randomStudent);
            if (!isMember)
            {
                principal.AddStudentToClub(randomStudent.studentID, randomClub.clubID);
            }
            else
            {
                principal.RemoveStudentFromClub(randomStudent.studentID, randomClub.clubID);
            }
        }
    }
}
