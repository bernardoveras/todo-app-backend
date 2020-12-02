using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class TodoItem : Entity
    {
        public TodoItem(string title, string user, DateTime date)
        {
            Title = title;
            Done = false;
            User = user;
            Date = date;
        }

        public string Title { get; private set; }
        public bool Done { get; private set; }
        public bool Important { get; private set; }
        public DateTime Date { get; private set; }
        public string User { get; private set; }

        public void MarkAsDone()
        {
            Done = true;
        }

        public void MarkAsUndone()
        {
            Done = false;
        }

        public void MarkAsImportant()
        {
            Important = true;
        }

        public void MarkAsNotImportant()
        {
            Important = false;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }
    }
}
