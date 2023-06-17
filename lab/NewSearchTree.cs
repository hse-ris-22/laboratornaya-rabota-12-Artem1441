using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab12
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

    public class CollectionHandlerEventArgs
    {
        public string? CollectionChange { get; set; } // field like 'В дерево поиска добавлен новый элемент', 'Из дерева удален элемент' or 'В коллекции был изменен элемент'
        public string? ObjectReference { get; set; } // filed with link like 'Возраст: 30, Имя: Rick, Зарплата: 162031, Возраст опыта: 25'

        public CollectionHandlerEventArgs(string? collectionChange, object? objectReference)
        {
            CollectionChange = collectionChange;
            ObjectReference = objectReference.ToString();
        }
    }

    public class NewSearchTree<T> : SearchTree<T> where T : IComparable<T>, ICloneable
    {
        public string CollectionName { get; set; }
        public event CollectionHandler CollectionCountChanged; // action of "Adding" and "Removing"
        public event CollectionHandler CollectionReferenceChanged; // action of changing link of elem in collection
        public void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args) => CollectionCountChanged?.Invoke(source, args);// обработчик событий
        public void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args) => CollectionReferenceChanged?.Invoke(source, args);

        public NewSearchTree(string name) : base() => CollectionName = name;

        public override void Add(T item)
        {
            base.Add(item);
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs("В дерево поиска добавлен новый элемент", item));
        }

        public override bool Remove(T item)
        {
            if (base.Remove(item))
            {
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs("Из дерева удален элемент", item));
                return true;
            }
            else
            {
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs("Неудачная попытка удаления элемента", item));
                return false;
            }
        }

        public T this[int index]
        {
            get => base[index];
            set => OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs("В коллекции был изменен элемент", value));
        }
    }
}