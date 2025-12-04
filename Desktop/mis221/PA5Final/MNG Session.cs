// using System;
// using System.Collections.Generic;

// namespace PA5Final
// {
//     public class MNGSession
//     {
//         private List<TrainingSession> sessions = new List<TrainingSession>();
//         public void AddSession(TrainingSession session)
//         {
//             sessions.Add(session);
//             System.Console.WriteLine("Session successfully added");
//         }

//         public void RemoveSession(int id)
//         {
//             TrainingSession foundSession = null;
//             for (int i = 0; i < sessions.Count; i++)
//             {
//                 if (sessions[i].Id == id)
//                 {
//                     foundSession = sessions[i];
//                     break;
//                 }
//             }
//             if (foundSession != null)
//             {
//                 sessions.Remove(foundSession);
//                 System.Console.WriteLine("Session removed successfully!");
//             }
//             else
//             {
//                 System.Console.WriteLine("Session not found");
//             }
//         }
//         public void MarkSessionComplete(int id)
//         {
//             TrainingSession foundSession = null;
//             for (int i = 0; i < sessions.Count; i++)
//             {
//                 if (sessions[i].Id == id)
//                 {
//                     foundSession = sessions[i];
//                     break;
//                 }
//             }
//             if (foundSession != null)
//             {
//                 foundSession.IsComplete = true;
//                 System.Console.WriteLine("Session marked as complete!");
//             }
//             else
//             {
//                 System.Console.WriteLine("Session not found.");
//             }
//         }
//         public void DisplayReport()
//         {
//             int total = sessions.Count;
//             int completed = 0;
//             int available = 0;

//             for (int i = 0; i < sessions.Count; i++)
//             {
//                 if (sessions[i].IsComplete)
//                 {
//                     completed++;
//                 }
//                 if (sessions[i].IsAvailable)
//                 {
//                     available++;
//                 }
//             }

//             System.Console.WriteLine("Session Report");
//             System.Console.WriteLine("Total Sessions: " + total);
//             System.Console.WriteLine("Completed: " + completed);
//             System.Console.WriteLine("Available: " + available);
//         }
//         public void DisplayAllSessions()
//         {
//             System.Console.WriteLine("All Sessions");
//             if (sessions.Count == 0)
//             {
//                 System.Console.WriteLine("No sessions available");
//                 return;
//             }

//             for (int i = 0; i < sessions.Count; i++)
//             {
//                 System.Console.WriteLine(sessions[i].ToString());
//                 System.Console.WriteLine("");
//             }
//         }
//     }
// }
    
