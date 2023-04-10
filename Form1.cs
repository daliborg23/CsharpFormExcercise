using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WindowsFormsExcercise {

    public partial class Form1 : Form {
        public int vysledek = 0;
        public bool zobrazVetu = false;
        public string komboboks = "";
        public bool delsi = false;
        public bool vyssi = false;
        public bool hlubsi = false;
        public string delsiStr = "";
        public string vyssiStr = "";
        public string hlubsiStr = "";
        public string barvyString = "";
        public string barva = "";
        public string material = "";
        public string celaVeta = "";
        public double odpocet = 10.0;
        public string cesta = "";
        DateTime ted = DateTime.Now;
        public Form1() {
            InitializeComponent();
        }
        private void zmenaStavu1() {
            vysledek = int.Parse(textBox1.Text) + int.Parse(textBox2.Text) + ((int)numericUpDown1.Value);
            label2.Text = vysledek.ToString();
            label6.Text = (trackBar1.Value * vysledek).ToString();
        }
        private void zmenaStavu2() {
            celaVeta = label6.Text + delsiStr + vyssiStr + hlubsiStr + material + barva + komboboks;
            label7.Text = celaVeta;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, @"[^0-9-]+")) {
                MessageBox.Show("Zadejte jen cislice \"0-9\" nebo znak \"-\" (minus).");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                textBox1.Select(textBox1.Text.Length, 0);
            } else {
                if (textBox1.Text == "") {
                    textBox1.Text = 0.ToString();
                    textBox1.Select(textBox1.Text.Length, 0);
                }
                zmenaStavu1(); zmenaStavu2();
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e) {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, @"[^0-9-]+")) {
                MessageBox.Show("Zadejte jen cislice \"0-9\" nebo znak \"-\" (minus).");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                textBox2.Select(textBox2.Text.Length, 0);
            } else {
                if (textBox2.Text == "") {
                    textBox2.Text = 0.ToString();
                    textBox2.Select(textBox2.Text.Length, 0);
                }
                zmenaStavu1(); zmenaStavu2();
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            zmenaStavu1(); zmenaStavu2();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                button2.FlatAppearance.BorderColor = Color.Red;
                DialogResult dialog = MessageBox.Show("Chcete ukoncit?","Konec?",MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes) {
                    Application.Exit();
                } else {
                    button2.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 192);
                }
            }
        }
        private void label2_TextChanged(object sender, EventArgs e) {
            
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e) {
            label4.Text = trackBar1.Value.ToString();
            zmenaStavu1(); zmenaStavu2();
        }
        private void label6_TextChanged(object sender, EventArgs e) {

        }
        private void comboBox1_TextChanged(object sender, EventArgs e) {
            komboboks = this.comboBox1.Text;
            if (komboboks.Length >= 1) {
                barva = ", barva ";
            } else {
                barva = "";
            }
            zmenaStavu1(); zmenaStavu2();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            delsi = true ? !delsi : delsi;
            if (delsi) {
                delsiStr = " delsi";
            }
            else {
                delsiStr = "";
            }
            zmenaStavu2();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e) {
            vyssi = true ? !vyssi : vyssi;
            if (vyssi) {
                vyssiStr = " vyssi";
            }
            else {
                vyssiStr = "";
            }
            zmenaStavu2();
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e) {
            hlubsi = true ? !hlubsi : hlubsi;
            if (hlubsi) {
                hlubsiStr = " hlubsi";
            }
            else {
                hlubsiStr = "";
            }
            zmenaStavu2();
        }
        private void radioButton1_Click(object sender, EventArgs e) {
            material = " " + radioButton1.Text;
            zmenaStavu2();
        }
        private void radioButton2_Click(object sender, EventArgs e) {
            material = " " + radioButton2.Text;
            zmenaStavu2();
        }
        private void radioButton3_Click(object sender, EventArgs e) {
            material = " " + radioButton3.Text;
            zmenaStavu2();
        }
        private void radioButton4_Click(object sender, EventArgs e) {
            material = " " + radioButton4.Text;
            zmenaStavu2();
        }
        void timer1_Tick(object sender, EventArgs e) {
            //throw new NotImplementedException();
            if (progressBar1.Value != progressBar1.Maximum) {
                progressBar1.Value++;
                odpocet=Math.Round(odpocet - 0.1,2);
            } else {
                //timer1.Stop();
                odpocet = 0.0;
            }
            //label9.Text = progressBar1.Value.ToString();
            toolStripStatusLabel1.Text = "Aktualni cas: " + DateTime.Now.ToString();
            label9.Text = String.Format(odpocet % 1 == 0 ? "{0:0.0}" : "{0:0.0}", odpocet) + " sekund";
        }
        private void button1_Click(object sender, EventArgs e) {
            progressBar1.Value = 0;
            //timer1.Start();
            odpocet = 10;
        }
        private void button2_Click(object sender, EventArgs e) {
            DialogResult dialog = MessageBox.Show("Chcete ukoncit?", "Konec?", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes) {
                Application.Exit();
            }
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Toto je napoveda", "Napoveda", MessageBoxButtons.OK);
        }
        private void otevritToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult dr = openFileDialog1.ShowDialog();
            cesta = openFileDialog1.FileName;
            if (dr == DialogResult.OK) {
                StreamReader sr = new StreamReader(cesta);
                textBox3.Text = sr.ReadToEnd();
                sr.Close();
            }
            string toolStripStatusLabel2text = "Naposledy otevreny soubor: ";
            toolStripStatusLabel2.Text = toolStripStatusLabel2text + cesta;
        }
        private void ulozitToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog ulozit = new SaveFileDialog();
            ulozit.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ulozit.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            ulozit.Title = "Save As";
            string initPath = Path.GetTempPath() + @"\FQUL";
            ulozit.InitialDirectory = Path.GetFullPath(initPath);
            ulozit.RestoreDirectory = true;
            ulozit.CheckPathExists= true;
            //saving.FileName = "Novy soubor.txt";
            ulozit.FileName = cesta;
            if (ulozit.ShowDialog() == DialogResult.OK) {
                // Code to write the stream goes here.
                StreamWriter writing = new StreamWriter(ulozit.FileName);
                writing.Write(textBox3.Text);
                writing.Close();
            }           
        }
    }
}