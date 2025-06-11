using System;
using DAL.DataAccess;
using DAL.Models;
using System.Collections.Generic;

namespace EventDb
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Event Management System =====");
            Console.WriteLine("1. Add Event");
            Console.WriteLine("2. View All Events");
            Console.WriteLine("3. Add Session");
            Console.WriteLine("4. View All Sessions");
            Console.WriteLine("5. Add User");
            Console.WriteLine("6. View All Users");
            Console.WriteLine("0. Exit");

            IEventDetailsRepo<EventDetails> eventRepo = new EventDetailsRepo();
            ISessionInfoRepo<SessionInfo> sessionRepo = new SessionInfoRepo();
            IUserInfoRepo<UserInfo> userRepo = new UserInfoRepo();

            while (true)
            {
                Console.Write("\nEnter choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EventDetails newEvent = new EventDetails
                        {
                            EventName = "AI Conference",
                            EventCategory = "Technology",
                            EventDate = DateTime.Now.AddDays(10),
                            Description = "Advanced AI topics",
                            Status = "Active"
                        };
                        eventRepo.AddEvent(newEvent);
                        Console.WriteLine("Event added successfully!");
                        break;

                    case "2":
                        List<EventDetails> events = eventRepo.GetAllEvents();
                        Console.WriteLine("\n--- All Events ---");
                        foreach (var evt in events)
                        {
                            Console.WriteLine($"{evt.EventId} | {evt.EventName} | {evt.EventCategory} | {evt.EventDate} | {evt.Status}");
                        }
                        break;

                    case "3":
                        SessionInfo newSession = new SessionInfo
                        {
                            EventId = 1, // assume EventId 1 exists
                            SessionTitle = "AI Deep Dive",
                            Description = "Deep learning concepts",
                            SpeakerId = null,
                            SessionStart = DateTime.Now.AddHours(1),
                            SessionEnd = DateTime.Now.AddHours(3),
                            SessionUrl = "http://example.com/ai"
                        };
                        sessionRepo.AddSession(newSession);
                        Console.WriteLine("Session added successfully!");
                        break;

                    case "4":
                        List<SessionInfo> sessions = sessionRepo.GetAllSessions();
                        Console.WriteLine("\n--- All Sessions ---");
                        foreach (var sess in sessions)
                        {
                            Console.WriteLine($"{sess.SessionId} | {sess.SessionTitle} | {sess.Description} | {sess.SessionStart} - {sess.SessionEnd}");
                        }
                        break;

                    case "5":
                        UserInfo newUser = new UserInfo
                        {
                            EmailId = "jerry1@example.com",
                            UserName = "jerry",
                            Role = "Participant",
                            Password = "password123"
                        };
                        userRepo.AddUser(newUser);
                        Console.WriteLine("User added successfully!");
                        break;

                    case "6":
                        List<UserInfo> users = userRepo.GetAllUsers();
                        Console.WriteLine("\n--- All Users ---");
                        foreach (var user in users)
                        {
                            Console.WriteLine($"{user.EmailId} | {user.UserName} | {user.Role}");
                        }
                        break;

                    case "0":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}
