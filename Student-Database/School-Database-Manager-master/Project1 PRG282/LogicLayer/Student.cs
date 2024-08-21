using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_PRG282.LogicLayer
{
    internal class Student
    {
        int studentnumber;
        string name, surname ;
        Image studentImage;
        DateTime DOB;
        string gender, phone, address;
        //creates new variebles for the student class


        //creates a constructor
        public Student(int studentnumber, string name, string surname, Image studentImage, DateTime dOB, string gender, string phone, string address)
        {
            this.Studentnumber = studentnumber;
            this.Name = name;
            this.Surname = surname;
            this.StudentImage = studentImage;
            DOB1 = dOB;
            this.Gender = gender;
            this.Phone = phone;
            this.Address = address;
        }
        public Student( string name, string surname, Image studentImage, DateTime dOB, string gender, string phone, string address)
        {
            
            this.Name = name;
            this.Surname = surname;
            this.StudentImage = studentImage;
            DOB1 = dOB;
            this.Gender = gender;
            this.Phone = phone;
            this.Address = address;
        }


        //creates an empty constructor
        public Student()
        {

        }


        //gets and sets all the variables
        public int Studentnumber { get => studentnumber; set => studentnumber = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public Image StudentImage { get => studentImage; set => studentImage = value; }
        public DateTime DOB1 { get => DOB; set => DOB = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
    }
}
