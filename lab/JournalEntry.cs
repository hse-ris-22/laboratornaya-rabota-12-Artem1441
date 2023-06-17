using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class JournalEntry
    {
        public string CollectionName { get; set; } 
        public string CollectionTypeOfChange { get; set; } 
        public string CollectionChangedObject { get; set; }

        public JournalEntry(string CollectionName, string CollectionTypeOfChange, string CollectionChangedObject)
        {
            this.CollectionName = CollectionName;
            this.CollectionTypeOfChange = CollectionTypeOfChange;
            this.CollectionChangedObject = CollectionChangedObject;
        }

        public override string ToString() => $"В дереве '{CollectionName}' произошло событие: '{CollectionTypeOfChange}'.\n Изменен объект: \n{CollectionChangedObject}";
    }

    public class Journal
    {
        public List<JournalEntry> list;
        public Journal() => list = new List<JournalEntry>();

        public void Add(object source, CollectionHandlerEventArgs args)
        {
            JournalEntry elem = new JournalEntry(((NewSearchTree<Person>)source).CollectionName, args.CollectionChange, args.ObjectReference);
            list.Add(elem);
        }
    }
}
