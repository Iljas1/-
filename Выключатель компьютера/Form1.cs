using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;
using System.Data;
using System.Drawing;
using System.IO;

namespace Выключатель_компьютера
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > 0.82) 
            System.Diagnostics.Process.Start("shutdown", "/s /t 0");
        }

        private void Form1_Load(object sender, EventArgs e)
                {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ru-ru");
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice();

            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);

            Choices numbers = new Choices();
            numbers.Add(new string[] { "компьютер выключись" });

            GrammarBuilder gb = new GrammarBuilder();
            // gb.Culture = ci;
            gb.Append(numbers);

            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);

            sre.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа ожидает от пользователя устной команды КОМПЬЮТЕР ВЫКЛЮЧИСЬ, услышав данную команду, она выключает компьютер!");
        }

        private void РазработчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик программы Салихов Ильяс Расихович Эл. адрес: salikhoviljas1@mail.ru ");
        }
    }
}

