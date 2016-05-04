using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ASILab6
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ProjectContext dataContext;
        public bool isDataChanged = false;

        private int selectedGroupIndex;
        public int SelectedGroupIndex
        {
            get { return selectedGroupIndex; }
            set
            {
                if (selectedGroupIndex != value)
                {
                    selectedGroupIndex = value;
                    OnPropertyChanged("SelectedGroupIndex");
                }
            }
        }

        private Discipline selectedDiscipline;
        public Discipline SelectedDiscipline
        {
            get { return selectedDiscipline; }
            set
            {
                if (selectedDiscipline != value)
                {
                    selectedDiscipline = value;
                    OnPropertyChanged("SelectedDiscipline");
                }
            }
        }

        private int selectedProjectIndex;
        public int SelectedProjectIndex
        {
            get { return selectedProjectIndex; }
            set
            {
                if (selectedProjectIndex != value)
                {
                    selectedProjectIndex = value;
                    OnPropertyChanged("SelectedProjectIndex");
                }
            }
        }

        private Group selectedGroup;
        public Group SelectedGroup
        {
            get { return selectedGroup; }
            set
            {
                if (selectedGroup != value)
                {
                    selectedGroup = value;
                    OnPropertyChanged("SelectedGroup");
                }
            }
        }

        private int selectedStudentIndex;
        public int SelectedStudentIndex
        {
            get { return selectedStudentIndex; }
            set
            {
                if (selectedStudentIndex != value)
                {
                    selectedStudentIndex = value;
                    OnPropertyChanged("SelectedStudentIndex");
                }
            }
        }

        private Student selectedStudent;
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                if (selectedStudent != value)
                {
                    selectedStudent = value;
                    OnPropertyChanged("SelectedStudent");
                }
            }
        }
        
        public string SelectedGroupName { get; set; }        
        
        public DbSet<Group> Groups { get { return dataContext.Groups; } }
        public DbSet<Student> Students { get { return dataContext.Students; } }
        public DbSet<Project> Projects { get { return dataContext.Projects; } }
        public DbSet<Discipline> Disciplines { get { return dataContext.Disciplines; } }
        

        public MainViewModel()
        {
            #region Design time access prevention
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }
            #endregion
            
            dataContext = new ProjectContext();
            dataContext.Projects.Load();
            dataContext.Students.Load();
            dataContext.Disciplines.Load();
            dataContext.Groups.Load();
        }
        
        public void AddGroup(string name, int year)
        {
            
            var group = new Group() { GroupName = name, Year = year };
            Groups.Add(group);
            isDataChanged = true;
            SelectedGroupIndex = Groups.Local.Count - 1;
        }
        
        public void AddProject(string name, short term, string content)
        {
            var project = new Project() { 
                ProjectName = name, 
                Term = term, 
                Content = content, 
                Discipline = selectedDiscipline, 
                Student = selectedStudent };
            Projects.Add(project);
            isDataChanged = true;
            SelectedProjectIndex = Projects.Local.Count - 1;
        }

        public void AddStudent(string name)
        {
            var student = new Student()
            {
                Name = name,
                Group = selectedGroup,
                Projects = null
            };
            Students.Add(student);
            isDataChanged = true;
            SelectedStudentIndex = Students.Local.Count - 1;
        }
            
        public void Save()
        {
            dataContext.SaveChanges();
            isDataChanged = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
