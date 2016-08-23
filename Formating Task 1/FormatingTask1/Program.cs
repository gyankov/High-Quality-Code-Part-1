//-----------------------------------------------------------------------
// <copyright file="program.cs" company="CompanyName">
//       Many things
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

/// <summary>
/// Some summary
/// </summary>
public class Program
{
    /// <summary>
    /// Swearing gosh
    /// </summary>
    private static StringBuilder output = new StringBuilder();

    /// <summary>
    /// They are more than us
    /// </summary>
    private static EventHolder events = new EventHolder();

    /// <summary>
    /// You are pissing me off
    /// </summary>
    /// <param name="commandForExecution">You pissing me off</param>
    /// <param name="commandType">Hello, hard </param>
    /// <param name="dateAndTime">its me</param>
    /// <param name="eventTitle">i have been calling</param>
    /// <param name="eventLocation">since monday</param>
    private static void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
    {
        dateAndTime = GetDate(commandForExecution, commandType);
        int firstPipeIndex = commandForExecution.IndexOf('|');
        int lastPipeIndex = commandForExecution.LastIndexOf('|');
        if (firstPipeIndex == lastPipeIndex)
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
            eventLocation = string.Empty;
        }
        else
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
            eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
        }
    }

    /// <summary>
    /// You are pissing me off
    /// </summary>
    /// <param name="command">The parameter is not used</param>
    private static void ListEvents(string command)
    {
        int pipeIndex = command.IndexOf('|');
        DateTime date = GetDate(command, "ListEvents");
        string countString = command.Substring(pipeIndex + 1);
        int count = int.Parse(countString);
        events.ListEvents(date, count);
    }

    /// <summary>
    /// You are pissing me off
    /// </summary>
    /// <param name="command">The parameter is not used</param>
    /// <param name="commandType">The parameter is  used</param>
    /// <returns>It returns the devil</returns>
    private static DateTime GetDate(string command, string commandType)
    {
        DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
        return date;
    }

    /// <summary>
    /// You are pissing me off
    /// </summary>
    /// <param name="command">The parameter is not used</param>
    private static void AddEvent(string command)
    {
        DateTime date;
        string title;
        string location;
        GetParameters(command, "AddEvent", out date, out title, out location);
        events.AddEvent(date, title, location);
    }

    /// <summary>
    /// You are pissing me off
    /// </summary>
    /// <param name="command">The parameter is not used</param>
    private static void DeleteEvents(string command)
    {
        string title = command.Substring("DeleteEvents".Length + 1);
        events.DeleteEvents(title);
    }

    /// <summary>
    /// You are pissing me off
    /// </summary>
    /// <returns>The parameter is not used</returns>
    private static bool ExecuteNextCommand()
    {
        string command = Console.ReadLine();
        if (command[0] == 'A')
        {
            AddEvent(command);
            return true;
        }

        if (command[0] == 'D')
        {
            DeleteEvents(command);
            return true;
        }

        if (command[0] == 'L')
        {
            ListEvents(command);
            return true;
        }

        if (command[0] == 'E')
        {
            return false;
        }

        return false;
    }

    /// <summary>
    /// You are pissing me off
    /// </summary>
    /// <param name="args">The parameter is not used</param>
    private static void Main(string[] args)
    {
        Console.WriteLine(output);
    }

    /// <summary>
    /// Some summary
    /// </summary>
    public static class Messages
    {
        /// <summary>
        /// You are pissing me off
        /// </summary>
        public static void EventAdded()
        {
            output.Append("Event added\n");
        }

        /// <summary>
        /// You are pissing me off
        /// </summary>
        /// <param name="x">The parameter is not used</param>
        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted\n", x);
            }
        }

        /// <summary>
        /// You are pissing me off
        /// </summary>
        public static void NoEventsFound()
        {
            output.Append("No events found\n");
        }

        /// <summary>
        /// You are pissing me off
        /// </summary>
        /// <param name="eventToPrint">The parameter is not used</param>
        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + "\n");
            }
        }
    }

    /// <summary>
    /// Some summary
    /// </summary>
    public class EventHolder
    {
        /// <summary>
        /// And more
        /// </summary>
        private MultiDictionary<string, Event> sortedByTitle = new MultiDictionary<string, Event>(true);

        /// <summary>
        /// You know summary
        /// </summary>
        private OrderedBag<Event> sortedByDate = new OrderedBag<Event>();

        /// <summary>
        /// Why gosh why
        /// </summary>
        /// <param name="date">Its a trap</param>
        /// <param name="title">run as</param>
        /// <param name="location">away as</param>
        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            this.sortedByTitle.Add(title.ToLower(), newEvent);
            this.sortedByDate.Add(newEvent);
            Messages.EventAdded();
        }

        /// <summary>
        /// Summary this is really
        /// </summary>
        /// <param name="titleToDelete">that is awkward</param>
        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;
            foreach (var eventToRemove in this.sortedByTitle[title])
            {
                removed++;
                this.sortedByDate.Remove(eventToRemove);
            }

            this.sortedByTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        /// <summary>
        /// Doing some fancy stuff you know
        /// </summary>
        /// <param name="date"> This some hard</param>
        /// <param name="count"> stuff you cunt</param>
        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.sortedByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}