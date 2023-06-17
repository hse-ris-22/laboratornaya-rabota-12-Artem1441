using MyClassLibrary;
using Lab12;
using System.Xml.Linq;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddAndCreateTest1()
        {
           Person person = new Person();
           person.RandomInit();

           var people = new DoublyLinkedList<Person>();
           people.Add(person);

           Assert.AreEqual(1, people.Count);
        }

        [TestMethod]
        public void AddAndCreateTest2()
        {
           Person person = new Person();
           person.RandomInit();
           var people = new DoublyLinkedList<Person>(person);

           Administartion administartion = new Administartion();
           administartion.RandomInit();

           people.Add(administartion);

           Assert.AreEqual(2, people.Count);
           Assert.AreEqual(person, people.Head.Data);
           Assert.AreEqual(administartion, people.Tail.Data);
        }
        [TestMethod]
        public void InsertTest()
        {
           var people = new DoublyLinkedList<Person>();
           Person person = new Person();
           Enginer enginer = new Enginer();
           Worker worker = new Worker();
           Administartion administartion = new Administartion();

           person.RandomInit();
           enginer.RandomInit();
           worker.RandomInit();
           administartion.RandomInit();

           people.Insert(worker,5);                       

           Assert.AreEqual(1, people.Count);
           Assert.AreEqual(worker, people.Head.Data);
           Assert.AreEqual(worker, people.Tail.Data);

           people.Insert(enginer, 0);

           Assert.AreEqual(2, people.Count);
           Assert.AreEqual(enginer, people.Head.Data);
           Assert.AreEqual(worker, people.Tail.Data);

           people.Insert(person, 1);

           Assert.AreEqual(3, people.Count);
           Assert.AreEqual(person, people.Head.Next.Data);
        }

        [TestMethod]
        public void ClearTest()
        {
           var people = new DoublyLinkedList<Person>();
           Person person = new Person();
           Enginer enginer = new Enginer();
           Worker worker = new Worker();

           Administartion administartion = new Administartion();
           worker.RandomInit();
           enginer.RandomInit();
           worker.RandomInit();
           administartion.RandomInit();

           people.Add(worker);
           people.Add(enginer);
           people.Add(person);
           people.Add(administartion);

           people.Clear();

           Assert.AreEqual(0, people.Count);
           Assert.AreEqual(null, people.Head);
           Assert.AreEqual(null, people.Tail);
           foreach (DoublyLinkedList<Person> item in people)
               Assert.AreNotEqual(null, item.Head.Data);
        }
        [TestMethod]
        public void CreationTest()
        {
           BinaryTree<Person> tree = new BinaryTree<Person>(10);
           Assert.AreEqual(10, tree.Count);
        }
        [TestMethod]
        public void MinAgeTest()
        {
           int count = 10;
           BinaryTree<Person> tree = new BinaryTree<Person>(count);
           tree.Root.Left.Data.Age = 15;
           tree.Root.Left.Data.Name = "Okru";
           tree.Ages.Add(18);
           string line = tree.MinAge();
           string lineExpected = $"Минимальный возраст 18 у человека с именем Okru";
           Assert.AreEqual(line, lineExpected);
        }
        [TestMethod]

        public void EraseTest()
        {
           int count = 10;
           BinaryTree<Person> tree = new BinaryTree<Person>(count);
           tree.Erase();
           Assert.AreEqual(0, tree.Count);
           Assert.AreEqual(null, tree.Root);
        }
        [TestMethod]

        public void SearchTreeTest()
        {
           int count = 20;
           BinaryTree<Person> tree = new BinaryTree<Person>(count);
           BinaryTree<int> searchTree = new BinaryTree<int>(20, tree.Ages);
           bool isBigger = false;
           if(searchTree.intRoot.Right.Data < searchTree.intRoot.Left.Data)
               isBigger = true;
           Assert.AreEqual(searchTree.Count, tree.Count);
           Assert.IsTrue(isBigger);
        }
        [TestMethod]
        public void AddTest()
        {
           HashTable<Person> people = new HashTable<Person>(30);
           for (int i = 0; i < 10; i++)
           {
               Person person = new Person();
               person.RandomInit();
               people.Add(person);
           }
           Assert.AreEqual(people.Count, 10);
           Assert.AreEqual(people.Capacity, 30);
        }
        [TestMethod]
        public void RemoveTest()
        {
           HashTable<Person> people = new HashTable<Person>(30);
           Person person = new Person(12, "Alex");
           people.Add(person);
           people.Remove(person);
           var isContains = people.Contains(person);
           Assert.IsFalse(isContains);
        }
        [TestMethod]
        public void ContainsTest()
        {
           HashTable<Person> people = new HashTable<Person>(30);
           Person person = new Person( 12, "Alex");
           people.Add(person);
           var isContains = people.Contains(person);
           Assert.IsTrue(isContains);
        }
        [TestMethod]
        public void ResizeTest()
        {
           HashTable<Person> people = new HashTable<Person>(30);
           for (int i = 0; i < 50; i++)
           {
               Person person = new Person();
               person.RandomInit();
               people.Add(person);
           }
           Assert.AreEqual(people.Count, 50);
           Assert.AreEqual(people.Capacity, 120);
        }
        public void AddTesvt()
        {

        }
        [TestMethod]
        public void Add()
        {
            SearchTree<Person> people = new SearchTree<Person>();
            for (int i = 0; i < 10; i++)
            {
                Person person = new Person();
                person.RandomInit();
                people.Add(person);
            }
            Person p1 = new Person(0, "Greg");
            people.Add(p1);
            Assert.AreEqual(11, people.Count);
            Assert.AreEqual(p1, people[0]);
        }
        [TestMethod]
        public void Remove()
        {
            SearchTree<Person> people = new SearchTree<Person>();
            for (int i = 0; i < 10; i++)
            {
                Person person = new Person();
                person.RandomInit();
                people.Add(person);
            }
            var isRemoved = people.Remove(people[3]);
            Assert.IsTrue(isRemoved);
            Assert.AreEqual(9, people.Count);
        }
        [TestMethod]
        public void Contains()
        {
            SearchTree<Person> people = new SearchTree<Person>();
            for (int i = 0; i < 10; i++)
            {
                Person person = new Person();
                person.RandomInit();
                people.Add(person);
            }
            Person p1 = new Person(500, "Greg");
            people.Add(p1);
            var index = people.Contains(p1);
            Assert.AreEqual(11, people.Count);
            Assert.IsTrue(index);
        }
        [TestMethod]
        public void CopyTo()
        {
            SearchTree<Person> people = new SearchTree<Person>();
            Person[] people2 = new Person[100];
            SearchTree<Person> people1 = new SearchTree<Person>();
            for (int i = 0; i < 10; i++)
            {
                Person person = new Person();
                person.RandomInit();
                people2[i] = person;
            }
            for (int i = 0; i < 10; i++)
            {
                Person person = new Person();
                person.RandomInit();
                people1.Add(person);
            }
            people1.CopyTo(people2, 9);
            Person p1 = new Person(500, "Greg");
            people.Add(p1);
            var index = people.Contains(p1);
            Assert.IsTrue(people2[18]!=null);
        }
    }
}
