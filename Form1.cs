using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aeroport
{
    public partial class Form1: Form
    {
        private Dispatcher dispatcher;
        private Airplane plane1;
        private Airplane plane2;
        private Airplane plane3;
        public Form1()
        {
            InitializeComponent();

            dispatcher = new Dispatcher();

            plane1 = new Airplane("Літак 1", label1);
            plane2 = new Airplane("Літак 2", label2);
            plane3 = new Airplane("Літак 3", label3);

            dispatcher.RegisterPlane(plane1);
            dispatcher.RegisterPlane(plane2);
            dispatcher.RegisterPlane(plane3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            plane1.RequestLanding();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            plane2.RequestLanding();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            plane3.RequestLanding();
        }
    }
}
