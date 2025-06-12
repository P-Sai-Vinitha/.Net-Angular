using System;
using DAL.DataAccess;
using DAL.Models;

namespace EventDb
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInfoBL = new UserInfoBL(new UserInfoRepo());
            var eventDetailsBL = new EventDetailsBL(new EventDetailsRepo());
            var sessionInfoBL = new SessionInfoBL(new SessionInfoRepo());

            while (true)
            {
                Console.WriteLine("\n=== Event Management System ===");
                Console.WriteLine("1. Manage Users");
                Console.WriteLine("2. Manage Events");
                Console.WriteLine("3. Manage Sessions");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ManageUsers(userInfoBL);
                        break;
                    case "2":
                        ManageEvents(eventDetailsBL);
                        break;
                    case "3":
                        ManageSessions(sessionInfoBL);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void ManageUsers(UserInfoBL userInfoBL)
        {
            Console.WriteLine("\n--- User Management ---");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Update User");
            Console.WriteLine("3. Delete User");
            Console.WriteLine("4. View All Users");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var user = new UserInfo();
                    Console.Write("Email: ");
                    user.EmailId = Console.ReadLine();
                    Console.Write("Username: ");
                    user.UserName = Console.ReadLine();
                    Console.Write("Role: ");
                    user.Role = Console.ReadLine();
                    Console.Write("Password: ");
                    user.Password = Console.ReadLine();
                    userInfoBL.AddUser(user);
                    Console.WriteLine("User added.");
                    break;

                case "2":
                    var update = new UserInfo();
                    Console.Write("Email to update: ");
                    update.EmailId = Console.ReadLine();
                    Console.Write("New Username: ");
                    update.UserName = Console.ReadLine();
                    Console.Write("New Role: ");
                    update.Role = Console.ReadLine();
                    Console.Write("New Password: ");
                    update.Password = Console.ReadLine();
                    userInfoBL.UpdateUser(update);
                    Console.WriteLine("User updated.");
                    break;

                case "3":
                    Console.Write("Email to delete: ");
                    userInfoBL.DeleteUser(Console.ReadLine());
                    Console.WriteLine("User deleted.");
                    break;

                case "4":
                    var allUsers = userInfoBL.GetAllUsers();
                    foreach (var u in allUsers)
                        Console.WriteLine($"{u.EmailId} | {u.UserName} | {u.Role}");
                    break;
            }
        }

        static void ManageEvents(EventDetailsBL eventDetailsBL)
        {
            Console.WriteLine("\n--- Event Management ---");
            Console.WriteLine("1. Add Event");
            Console.WriteLine("2. Update Event");
            Console.WriteLine("3. Delete Event");
            Console.WriteLine("4. View All Events");
            Console.WriteLine("5. View Events by Category");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var ev = new EventDetails();
                    Console.Write("Name: ");
                    ev.EventName = Console.ReadLine();
                    Console.Write("Category: ");
                    ev.EventCategory = Console.ReadLine();
                    Console.Write("Date (yyyy-mm-dd): ");
                    ev.EventDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Description: ");
                    ev.Description = Console.ReadLine();
                    Console.Write("Status: ");
                    ev.Status = Console.ReadLine();
                    var added = eventDetailsBL.AddEvent(ev);
                    Console.WriteLine(added != null ? "Event added." : "Failed to add event.");
                    break;

                case "2":
                    var upEvent = new EventDetails();
                    Console.Write("Event ID to update: ");
                    upEvent.EventId = int.Parse(Console.ReadLine());
                    Console.Write("New Name: ");
                    upEvent.EventName = Console.ReadLine();
                    Console.Write("New Category: ");
                    upEvent.EventCategory = Console.ReadLine();
                    Console.Write("New Date: ");
                    upEvent.EventDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("New Description: ");
                    upEvent.Description = Console.ReadLine();
                    Console.Write("New Status: ");
                    upEvent.Status = Console.ReadLine();
                    var updated = eventDetailsBL.UpdateEvent(upEvent);
                    Console.WriteLine(updated != null ? "Event updated." : "Failed to update.");
                    break;

                case "3":
                    Console.Write("Event ID to delete: ");
                    var deleted = eventDetailsBL.DeleteEvent(int.Parse(Console.ReadLine()));
                    Console.WriteLine(deleted != null ? "Event deleted." : "Event not found.");
                    break;

                case "4":
                    var events = eventDetailsBL.GetAllEvents();
                    foreach (var e in events)
                        Console.WriteLine($"{e.EventId} | {e.EventName} | {e.EventDate.ToShortDateString()} | {e.Status}");
                    break;

                case "5":
                    Console.Write("Enter Category: ");
                    var cat = Console.ReadLine();
                    var catEvents = eventDetailsBL.GetEventsByCategory(cat);
                    foreach (var e in catEvents)
                        Console.WriteLine($"{e.EventId} | {e.EventName} | {e.EventCategory}");
                    break;
            }
        }

        static void ManageSessions(SessionInfoBL sessionInfoBL)
        {
            Console.WriteLine("\n--- Session Management ---");
            Console.WriteLine("1. Add Session");
            Console.WriteLine("2. Update Session");
            Console.WriteLine("3. Delete Session");
            Console.WriteLine("4. View All Sessions");
            Console.WriteLine("5. Get Session by ID");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var session = new SessionInfo();
                    Console.Write("Title: ");
                    session.SessionTitle = Console.ReadLine();
                    Console.Write("Speaker ID: ");
                    session.SpeakerId = int.Parse(Console.ReadLine());
                    Console.Write("Description: ");
                    session.Description = Console.ReadLine();
                    Console.Write("Event ID: ");
                    session.EventId = int.Parse(Console.ReadLine());
                    Console.Write("Session URL: ");
                    session.SessionUrl = Console.ReadLine();
                    sessionInfoBL.AddSession(session);
                    Console.WriteLine("Session added.");
                    break;

                case "2":
                    var upd = new SessionInfo();
                    Console.Write("Session ID to update: ");
                    upd.SessionId = int.Parse(Console.ReadLine());
                    Console.Write("New Title: ");
                    upd.SessionTitle = Console.ReadLine();
                    Console.Write("New Speaker ID: ");
                    upd.SpeakerId = int.Parse(Console.ReadLine());
                    Console.Write("New Description: ");
                    upd.Description = Console.ReadLine();
                    Console.Write("New Event ID: ");
                    upd.EventId = int.Parse(Console.ReadLine());
                    sessionInfoBL.UpdateSession(upd);
                    Console.WriteLine("Session updated.");
                    break;

                case "3":
                    Console.Write("Session ID to delete: ");
                    sessionInfoBL.DeleteSession(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Session deleted.");
                    break;

                case "4":
                    var allSessions = sessionInfoBL.GetAllSessions();
                    foreach (var s in allSessions)
                        Console.WriteLine($"{s.SessionId} | {s.SessionTitle} | Event: {s.EventId}");
                    break;

                case "5":
                    Console.Write("Enter Session ID: ");
                    var sId = int.Parse(Console.ReadLine());
                    var sInfo = sessionInfoBL.GetSessionById(sId);
                    Console.WriteLine($"{sInfo.SessionId} | {sInfo.SessionTitle} | {sInfo.Description}");
                    break;
            }
        }
    }
}
