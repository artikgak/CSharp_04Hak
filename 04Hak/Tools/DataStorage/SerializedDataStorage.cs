using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using KMACSharp04Hak.Models;
using KMACSharp04Hak.Tools.Managers;

namespace KMACSharp04Hak.Tools.DataStorage
{
    internal class SerializedDataStorage: IDataStorage
    {
        private static SerializedDataStorage instance;
        private ObservableCollection<Person> _persons;

        private Random rand = new Random();

        public static SerializedDataStorage Instance()
        {
            if (instance == null)
                instance = new SerializedDataStorage();
            return instance;
        }

        internal SerializedDataStorage()
        {
            try
            {
                _persons = SerializationManager.Deserialize<ObservableCollection<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _persons = new ObservableCollection<Person>();
                FillWithRandomPersons();
                SaveChanges();
            }
        }

        //private void DataStorageChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
        //{
        //    switch (eventArgs.Action)
        //    {
        //        case NotifyCollectionChangedAction.Add:
        //            PersonList = new ObservableCollection<Person>(StationManager.DataStorage.PersonList);
        //            break;
        //        case NotifyCollectionChangedAction.Remove:
        //            PersonList = new ObservableCollection<Person>(StationManager.DataStorage.PersonList);
        //            break;
        //        case NotifyCollectionChangedAction.Replace:
        //            PersonList = new ObservableCollection<Person>(StationManager.DataStorage.PersonList);
        //            break;
        //    }
        //}

        private void FillWithRandomPersons()
        {
            for (int i = 0; i < 43; ++i)
            {
                _persons.Add(new Person(RandomStringOfLenght(rand.Next(4,8), true), 
                    RandomStringOfLenght(rand.Next(4, 8),true),
                    RandomStringOfLenght(rand.Next(5, 10), false)+"@ukma.edu.ua", RandomDay()));
            }
            // add some with birth today
            for (int i = 0; i < 7; ++i)
                _persons.Add(new Person(RandomStringOfLenght(rand.Next(4, 8), true), 
                    RandomStringOfLenght(rand.Next(4, 8), true),
                RandomStringOfLenght(rand.Next(5, 10), false) + "@ukma.edu.ua", 
                    new DateTime(rand.Next(DateTime.Today.Year-120, DateTime.Today.Year), DateTime.Today.Month, DateTime.Today.Day)));
        }

        DateTime RandomDay()
        {
            DateTime start = new DateTime(1920, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rand.Next(range));
        }

        private string RandomStringOfLenght(int length, bool firstUpperCase)
        {
            StringBuilder st = firstUpperCase? new StringBuilder(((char)rand.Next('A', 'Z' + 1)).ToString()) 
                : new StringBuilder(((char)rand.Next('a', 'z' + 1)).ToString());
            for (int i = 0; i < length; ++i)
                st.Append((char)rand.Next('a', 'z'+1));
            return st.ToString();
        }

        public ObservableCollection<Person> PersonList
        {
            get { return _persons; }
            set => _persons = value;
        }

        private void SaveChanges()
        {
            SerializationManager.Serizalize(_persons, FileFolderHelper.StorageFilePath);
        }

        public bool AddPerson(Person person)
        {
            _persons.Add(person);
            SaveChanges();
            return true;
        }

        public bool EditPerson(ref Person toEditPerson, Person changedPerson)
        {
            _persons[_persons.IndexOf(toEditPerson)] = changedPerson;
            SaveChanges();
            return true;
        }

        public bool DeletePerson(Person person)
        {
            bool remove = _persons.Remove(person);
            SaveChanges();
            return remove;
        }

    }
}
