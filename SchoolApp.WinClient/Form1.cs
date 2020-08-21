using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolApp.DataLayer;
using SchoolApp.Entities;
using SchoolApp.RepositoryAbstracts;
using System.Configuration;
using SchoolApp.Repositories;

namespace SchoolApp.WinClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  var stringConn = ConfigurationManager.ConnectionStrings["mySQL"].ConnectionString;
            IstudentsRepository studentsRepository = new studentsRepository();
            studentsRepository.Add(new students
            {
                FName = "فرشید",
                LName = "محمدی",
                StudentCode = "12525252",
                StudentNatinalCode =25525,
                FatherName = "یدالله",
                MotherName = "گوزل",
                HomePhone = "08738235511",
                FatherPhone = "09188726562",
                MotherPhone = "09379767393",
                SMS = "09186620474",
                BrithDate = DateTime.Now.AddDays(75),
                RegDate = DateTime.Now,
                enabled = 1
            });

            dataGridView1.DataSource = studentsRepository.All();


        }
    }
}
