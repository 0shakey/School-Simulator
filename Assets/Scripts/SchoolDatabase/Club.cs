using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    public float funding;
    public List<Student> membersList = new List<Student>();
    public int currentClassroomID;
    public int clubAdvisorID;
    public string description;
    public string clubName;
    public int clubID;

    public Club(string tempName, int tempClassroomID, string tempDescription, int tempFacultyID)
    {
        clubName = tempName;
        description = tempDescription;
        clubAdvisorID = tempFacultyID;
        currentClassroomID = tempClassroomID;

        membersList = new List<Student>();
        clubID = Random.Range(100000, 999999); // Auto-generate ID
        Debug.Log($"[Club Created] {clubName} (ID: {clubID}) in Room {currentClassroomID}, Advisor ID: {clubAdvisorID}");
    }

    public void ReportStatus()
    {
        Debug.Log($"[Club Report] Name: {clubName}, ID: {clubID}, Room: {currentClassroomID}, Advisor: {clubAdvisorID}, Members: {membersList.Count}, Funding: ${funding}");
    }

    [ContextMenu("Debug/Report Club Status")]
    public void Debug_ReportStatus()
    {
        ReportStatus();
    }
}
