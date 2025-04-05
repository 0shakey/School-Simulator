using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classroom : MonoBehaviour
{
    public Club currentClub;
    public int maxCapacity;
    public int classroomID;
    public Teacher teacher;

    public Classroom(int tempMaxCapacity)
    {
        maxCapacity = tempMaxCapacity;
        classroomID = Random.Range(100000000, 1000000000);
        Debug.Log($"[Classroom Created] ID: {classroomID}, Max Capacity: {maxCapacity}");
    }

    [ContextMenu("Debug/Report Classroom Status")]
    public void ReportStatus()
    {
        string teacherName = teacher != null ? teacher.staffName : "None";
        string clubName = currentClub != null ? currentClub.clubName : "None";
        Debug.Log($"[Classroom Report] ID: {classroomID}, Capacity: {maxCapacity}, Teacher: {teacherName}, Club: {clubName}");
    }
}

