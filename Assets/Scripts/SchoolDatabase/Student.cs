using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    public string clubPosition;
    public List<Club> clubsList;
    public int grade;
    public int studentID;
    public string studentName;

    public Student(string tempName, int tempGrade)
    {
        studentName = tempName;
        grade = tempGrade;
        studentID = Random.Range(100000000, 1000000000);
        Debug.Log($"Student created: {studentName}, Grade: {grade}, ID: {studentID}");
    }

    [ContextMenu("Print Student Info")]
    public void PrintStudentInfo()
    {
        Debug.Log($"[Student Info] Name: {studentName}, Grade: {grade}, ID: {studentID}, Club Position: {clubPosition}, Clubs Count: {clubsList?.Count ?? 0}");
    }

    private void Awake()
    {
        Debug.Log($"[Student] Awake called on {gameObject.name}");
    }

    private void Start()
    {
        Debug.Log($"[Student] Start called for {studentName ?? "Unnamed Student"}");
    }
}
