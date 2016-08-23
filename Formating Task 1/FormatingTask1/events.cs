//-----------------------------------------------------------------------
// <copyright file="events.cs" company="Event">
//     Many things
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

/// <summary>
/// Another summary
/// </summary>
public class Event : IComparable
{
    /// <summary>
    /// Not getting tired
    /// </summary>
    private DateTime date;

    /// <summary>
    /// Why so serious
    /// </summary>
    private string title;

    /// <summary>
    /// Why the fuck this should have a freaking summary
    /// </summary>
    private string location;

    /// <summary>
    /// Initializes a new instance of the Event class
    /// </summary>
    /// <param name="date">and a date</param>
    /// <param name="title">then a title</param>
    /// <param name="location">and a goddam location</param>
    public Event(DateTime date, string title, string location)
    {
        this.date = date;
        this.title = title;
        this.location = location;
    }

    /// <summary>
    /// This method compares objects
    /// </summary>
    /// <param name="obj">Some name</param>
    /// <returns>Returns something</returns>
    public int CompareTo(object obj)
    {
        Event other = obj as Event;
        int sortedByDate = this.date.CompareTo(other.date);
        int sortedByTitle = this.title.CompareTo(other.title);
        int sortedByLocation = this.location.CompareTo(other.location);
        if (sortedByDate == 0)
        {
            if (sortedByTitle == 0)
            {
                return sortedByLocation;
            }
            else
            {
                return sortedByTitle;
            }
        }
        else
        {
            return sortedByDate;
        }
    }

    /// <summary>
    /// This method compares objects
    /// </summary>
    /// <returns>Returns something</returns>
    public override string ToString()
    {
        StringBuilder toString = new StringBuilder();
        toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
        toString.Append(" | " + this.title);
        if (this.location != null && this.location != string.Empty)
        {
            toString.Append(" | " + this.location);
        }

        return toString.ToString();
    }
}