// {  
//     namespace PA5Final
//     {
        

        
//         public class SessionUtility
//         {
//             private Session[] sessions;
//             private Orders[] orders;

//             public SessionUtility(Session[] sessions, Orders[] orders)
//             {
//                 this.sessions = sessions;
//                 this.orders = orders;
//             }
//             public void Sort(string sortBy = "sessionId")
//             {
//                 for(int i = 0; i < Session.GetCount() - 1; i++)
//                 {
//                     int min = i;
//                     for(int j = i + 1; j < Session.GetCount(); j++)
//                     {
//                         if (sessions[min].CompareTo(sessions[j], sortBy) > 0)
//                         {
//                             min = j;
//                         }
//                     }
//                     if (min != 1)
//                     {
//                         Swap(min,i);
//                     }
//                 }
//             }
//             public void Sort()
//             {
//                 Sort("sessionId");
//             }
//             private void Swap(int x, int y)
//             {
//                 Session temp = sessions[x];
//                 sessions[x] = sessions[y];
//                 sessions[y] = temp;
//             }
//             public int FindSession(string sessionId)
//             {
//                 // int searchId = int.Parse(searchVal);//sequencial search
//                 for (int i = 0; i < Session.GetCount(); i++)
//                 {
//                     if(sessions[i].CompareTo(sessionId) == 0)
//                     {
//                         return i;
//                     }
//                 }
//                 return -1;
//             }
//             public void UpdateSessions()
//             {
//                 System.Console.WriteLine("\nWhich Session would you like to update? (Sessionid)");
//                 string searchVal = Console.ReadLine();
//                 int foundIndex = FindSession((searchVal));
//                 System.Console.WriteLine(foundIndex);
//                 if (foundIndex >= 0)
//                 {
//                     UpdateSessionInfo(sessions[foundIndex]);
//                 }
//             }
//             private void UpdateSessionInfo(Session sessions)
//             {
//                 System.Console.WriteLine("What should the session Id be?");
//                 session.SetSessionId(Console.ReadLine());
//                 System.Console.WriteLine("What would you like to name it?");
//                 session.SetName(Console.ReadLine());
//                 System.Console.WriteLine("What kind of session should it be ????");
//                 session.SetSportType(Console.ReadLine());
//                 System.Console.WriteLine("What price do you want the session to be");
//                 session.SetSessionPrice(double.Parse(Console.ReadLine()));
//                 System.Console.WriteLine("Is this session available now? (True of false)");
//                 session.SetIsSoldOut(bool.Parse(Console.ReadLine()));
//                 System.Console.WriteLine("");

//             }
//             public void RemoveSessions()
//             {
//                 System.Console.WriteLine("Which sessions would you like to delete");
//                 Console.WriteLine("(type in the Session Id)");
//                 string searchVal = Console.ReadLine();

//                 int foundIndex = FindSession(searchVal);
//                 if (foundIndex >= 0)
//                 {
//                     System.Console.WriteLine($"Session found at {foundIndex} Removing---");
//                     for(int i = foundIndex; i < Session.GetCount() - 1; i++) //move the session down a bit
//                     {
//                         sessions[i] = sessions[i + 1];
//                     }
//                     sessions[Session.GetCount() - 1] = null;

//                     Session.DecCount();
//                     System.Console.WriteLine("Session removed");
//                 }
//                 else
//                 {
//                     System.Console.WriteLine("Session not found");
//                 }
//             }
//             public void ViewMenu()
//             {
//                 for(int i = 0; i < Session.GetCount(); i++)
//                 {
//                     if (!sessions[i].GetIsSoldOut())
//                     {
//                         System.Console.WriteLine($"{sessions[i].ToString()}");
//                     }

//                 }
//             }
//             public void PlaceOrder()
//             {
//                 orders newOrder = new orders();
//                 newOrder.SetOrderId(orders.GetCount() + "1".ToString());
//                 orders.IncCount();
//                 System.Console.WriteLine(Orders.GetCount());
//                 System.Console.WriteLine("Please enter your email.");
//                 string customeremail = Console.ReadLine();
//                 newOrder.SetEmail(customeremail);
//                 System.Console.WriteLine("What kind of Sessions would you like? (enter sessionId");
//                 string sessionOrder = Console.ReadLine();
//                 newOrder.SetSessionId(sessionOrder);
//                 System.Console.WriteLine("What is the max capacity of you session 5,20,35");
//                 string sessionCapacity = Console.ReadLine();
//                 System.Console.WriteLine($"What blank session would you like? ---");
//                 newOrder.SetRegistrationDate(DateTime.Now.ToString("MM/DD/YYYY"));
//                 for(int i = 0; i < Session.GetCount(); i++)
//                 {
//                     if(sessions[i].GetSessionId()== sessionOrder && sessions[i].GetIsSoldOut() == false)
//                     {
//                         string order = $"{sessionCapacity}' {sessions[i].ToString()}";
//                         System.Console.WriteLine($"You have scheduled a {order}");

//                         orders[orders.GetCount()] = newOrder;
//                         File.AppendAllLines("registration.txt", new[] {newOrder.ToFile()});// do you need
//                         break;
//                     }
//                 }
//             }
//             public void CreateSessions()//finish class
//             {
//                 Session newSession = newSession();
//                 newSession.SetSessionId((Session.GetCount() + 1).ToString());
//                 System.Console.WriteLine("What is the name of the Session?");
//                 newSession.SetName(Console.ReadLine());

//                 System.Console.WriteLine("What is the sporttype");
//                 newSession.SetSportType(Console.ReadLine());
//                 System.Console.WriteLine("What is the sessions price?");
//                 newSession.SetSessionPrice(double.Parse(Console.ReadLine()));
//                 System.Console.WriteLine("Is the sessions sold out? ");
//                 newSession.SetIsSoldOut(bool.Parse(Console.ReadLine()));
//                 sessions[Session.GetCount()] = newSession;
//                 Session.IncCount();
                
//                 File.AppendAllLines("sessions.txt", new[] { newSession.ToFile()});
//             }
//             public void ViewPasteOrders()
//             {
//                 System.Console.WriteLine("please enter your email.");
//                 string customeremail = Console.ReadLine();
//                 for (int i = 0; i < Orders.GetCount(); i++)
//                 {
//                     if(orders[i].GetEmail() == customeremail)
//                     {
//                         System.Console.WriteLine($"{orders[i].ToString()}");
//                     }
//                 }
//             }
//             public void UpdateOrder()
//             {
//                 System.Console.WriteLine("\nWhich order would you like to update");
//                 string searchVal = Console.ReadLine();
//                 int foundIndex = FindOrder((searchVal));
//                 System.Console.WriteLine(foundIndex);
//                 if(foundIndex >= 0)
//                 {
//                     UpdateOrderInfo(orders[foundIndex]);
//                 }
//             }
//             private void UpdateOrderInfo(Orders orders)
//             {
//                 System.Console.WriteLine("Would you like to mark this order");
//                 orders.SetOrderStatus(bool.Parse(Console.ReadLine()));
//             }
//             public int FindOrder(string orderId)
//             {
//                 for(int i = 0; i < orders.GetCount(); i++)
//                 {
//                     if(orders[i].GetOrderId().CompareTo(orderId) == 0)
//                     {
//                         return i;
//                     }
//                     System.Console.WriteLine(orders[i].GetOrderId());
//                 }
//                 return -1;
//             }
//             public void DailySessionReport()
//             {
//                 string searchVal = DateTime.Now.ToString("mm/dd/yyyy");
//                 for (int i = 0; i < Orders.GetCount; i++)
//                 {
//                     if (orders[i].GetOrderDate() == searchVal)
//                     {
//                         System.Console.WriteLine($"{orders[i].ToString()}");
//                     }
//                 }
//             }
//             public void ViewOrdersInProgress()
//             {
//                 for(int i = 0; i < Orders.GetCount(); i++)
//                 {
//                     if(orders[i].GetOrderStatus() == false)
//                     {
//                         System.Console.WriteLine($"{orders[i].ToString}");
//                     }
//                 }
//             }
//             public void AverageSessionSizeByCount()
//             {
//                 string curr = sessions[0].GetSportType();
//                 int total = int.Parse(orders[0].GetSessionSize());
//                 int sportCount = 0;
//                 for(int i =0; i < Pizza.GetCount(); i++)
//                 {
//                     if(sessions[i].GetSportType() == curr)
//                     {
//                         total += int.Parse(orders[i].GetSportType());
//                         sportCount++;
//                     }
//                     else
//                     {
//                         ProcessBreak(ref curr, ref total, ref sportCount, i);
//                     }
//                 }
//                 ProcessBreak(curr,total,sportCount);
//             }
//             private void ProcessBreak(ref string curr, ref int total, ref int sportCount, int i)
//             {
//                 System.Console.WriteLine($"{curr}\t{total/sportCount}");
//                 curr = sessions[i].GetSportType();
//                 total = int.Parse(orders[i].GetSessionSize());
//                 sportCount = 1;
//             }
//             private void ProcessBreak(string curr, int total, int sportCount)
//             {
//                 System.Console.WriteLine($"{curr}\t{total / sportCount}");
//             }
            
            
//         }
//     }

        
        
        


        
        

        
    
// }
