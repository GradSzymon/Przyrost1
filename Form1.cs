using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quartz;
using Quartz.Impl;
using System.Threading;
using System.Timers;

namespace ProjektPP1
{
    public partial class Form1 : Form
    {
        int iledokonca;
        bool licznikczasu = false;
        int lZapisow = 0;
        public static List<string> listaS;
        List<string> lista = new List<string>();
        public int nrzadania, i = 0;
        public string numerZadania, zapytania, path = @"D:\Programy\Nowy folder\ProjektPP1\Zapis\odp.txt";


        public Form1()
        {


            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter ws = File.CreateText(path))
                {
                    ws.WriteLine("");
                    ws.Close();
                }
            }
            else
            {
                // Create a file to write to.
                using (StreamWriter ws = File.CreateText(path))
                {
                    ws.WriteLine("");
                    ws.Close();

                }
            }
            InitializeComponent();
            StartCzasu();


        }
        
        int duration = 30;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            path = @textBox3.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {

            if (lZapisow == 0)
            {
                timer1.Enabled = true;
                timer1.Start();
                ++lZapisow;


            }
            numerZadania = textBox1.Text;
            SprawdZapytanie(numerZadania, textBox2.Text);
        }




        private void timer1_Tick(object sender, EventArgs e)
        {

            label5.Text = duration.ToString();
            duration--;
            if (duration == 0)
            {

                Zapisz();
                duration = 30;

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

       
        public void Zmiana()
        {
           
            
        }
        public void StartCzasu()
        {
            System.Timers.Timer timer2 = new System.Timers.Timer();
            timer2.Elapsed += new ElapsedEventHandler(ZmianaCzasu);
            timer2.Interval = 60000;
            timer2.Start();
        }
        public void Zapisz()
        {



            listaS = new List<string>(lista);
            for (int k = 0; k < listaS.Capacity; k++)
            {
                listaS.RemoveAll(intem => intem == "");
            }

            File.WriteAllLines(path, listaS);

        }
        public void SprawdZapytanie(string numerzadania1, string Zapytanie)
        {
            int select, from, where, orderby;
            bool sprawdznr = Int32.TryParse(numerzadania1, out nrzadania);
            select = Zapytanie.IndexOf("SELECT");
            from = Zapytanie.IndexOf("FROM");
            where = Zapytanie.IndexOf("WHERE");
            orderby = Zapytanie.IndexOf("ORDER BY");

            if ((select == 0) && (select < from))
            {
               
                    if (sprawdznr)
                    {
                        int nrZad = Int32.Parse(numerzadania1);
                        numerZadania = textBox1.Text;
                        zapytania = textBox2.Text;
                        if ((where == (-1)) && (orderby == (-1)))
                        {
                       

                            DodajDoListy(textBox2.Text, nrZad);

                            MessageBox.Show("Dodałem do listy");
                        
                      

                        }
                        if((where == (-1))&&(orderby != (-1)))
                    {
                        if (from < orderby)
                        {
                            DodajDoListy(textBox2.Text, nrZad);

                            MessageBox.Show("Dodałem do listy");
                        }
                        else
                        {
                            MessageBox.Show("Zla odpowiedz");
                        }
                    }



                        if ((where != (-1)) && (orderby != (-1)) && (where < orderby))
                        {

                        if ((from < where) &&(from <orderby))
                        {
                            DodajDoListy(textBox2.Text, nrZad);

                            MessageBox.Show("Dodałem do listy");
                        }
                        else
                        {
                            MessageBox.Show("Zla odpowiedz");
                        }
                        }
                    if ((where != (-1)) && (orderby != (-1)) && (where > orderby))
                    {


                        MessageBox.Show("Zla odpowiedz");

                    }


                    if ((where != (-1)) && (orderby == (-1)))
                        {
                        if (from < where)
                        {
                            DodajDoListy(textBox2.Text, nrZad);

                            MessageBox.Show("Dodałem do listy");
                        }
                        else
                        {
                            MessageBox.Show("Zla odpowiedz");
                        }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Zly numer");
                    }
                }

                else
                {
                    MessageBox.Show("Zla odpowiedz");
                }
            }
        
        public static void ZmianaCzasu(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            DayOfWeek day = DateTime.Now.DayOfWeek;
            if ((day != DayOfWeek.Saturday) || (day != DayOfWeek.Sunday))
            {
                do
                {
                    start = DateTime.Now;
                } while (start.Second != 0);
                DateTime endTime = new DateTime(start.Year, start.Month, start.Day, 9, 45, 0);
                if (start <= endTime)
                {
                    TimeSpan span = endTime.Subtract(start);
                    MessageBox.Show("Do konca zajec: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(start.Year, start.Month, start.Day, 10, 0, 0);
                if (start <= endTime)
                {
                    TimeSpan span = endTime.Subtract(start);
                    MessageBox.Show("Do konca przerwy: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(start.Year, start.Month, start.Day, 11, 30, 0);
                if (start <= endTime)
                {
                    TimeSpan span = endTime.Subtract(start);
                    MessageBox.Show("Do konca zajec: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(start.Year, start.Month, start.Day, 11, 45, 0);
                if (start <= endTime)
                {
                    TimeSpan span = endTime.Subtract(start);
                    MessageBox.Show("Do konca przerwy: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(start.Year, start.Month, start.Day, 13, 15, 0);
                if (start <= endTime)
                {
                    TimeSpan span = endTime.Subtract(start);
                    MessageBox.Show("Do konca zajec: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(start.Year, start.Month, start.Day, 13, 45, 0);
                if (start<= endTime)
                {
                    TimeSpan span = endTime.Subtract(start);
                    MessageBox.Show("Do konca przerwy: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(start.Year, start.Month, start.Day, 15, 15, 0);
                if (start <= endTime)
                {
                    TimeSpan span = endTime.Subtract(start);
                    MessageBox.Show("Do konca zajec: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(start.Year, start.Month, start.Day, 15, 30, 0);
                if (start <= endTime)
                {
                    TimeSpan span = endTime.Subtract(start);
                    MessageBox.Show("Do konca przerwy: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(start.Year, start.Month, start.Day, 17, 0, 0);
                if (start <= endTime)
                {
                    TimeSpan span = endTime.Subtract(start);
                    MessageBox.Show("Do konca zajec: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(start.Year, start.Month, start.Day, 17, 15, 0);
                if (start <= endTime)
                {
                    TimeSpan span = endTime.Subtract(start);
                    MessageBox.Show("Do konca przerwy: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                endTime = new DateTime(start.Year, start.Month, start.Day, 18, 45, 0);
                if (start <= endTime)
                {
                    TimeSpan span = endTime.Subtract(start);
                    MessageBox.Show("Do konca zajec: " + Math.Round(span.TotalMinutes, 0));
                    return;
                }
                MessageBox.Show("Nie ma zajęć");
            }
            else
            {
                MessageBox.Show("Weekend");
            }
        }
        public void DodajDoListy(string odpowiedz, int nrzapytania)
        {
            if (nrzapytania > i)
            {
                for (int c = 0; c <= nrzapytania; c++)
                {
                    lista.Add("");
                }
            }

            i = nrzapytania;

            if (lista.ElementAtOrDefault(nrzapytania) != "")

                lista.RemoveAt(nrzapytania);

            else if (lista.ElementAtOrDefault(nrzapytania) != odpowiedz)

                lista.RemoveAt(nrzapytania);
            lista.Insert(nrzapytania, odpowiedz);

        }
        public void Tworz()
        {
            
            try
            {
                ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
                IScheduler scheduler = schedulerFactory.GetScheduler();
                scheduler.Start();
                iledokonca = 60;
                Zmiana();
                IJobDetail job = JobBuilder.Create<OneJob>()
                    .WithIdentity("name", "group")
                    .Build();
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1", "group")
                    .StartNow()
                    .WithCronSchedule("0/10 0 0 ? * * *")

                    .Build();

                scheduler.ScheduleJob(job, trigger);
                scheduler.Shutdown();
                


                
            }
            catch(SchedulerException se)
            {
                MessageBox.Show(se.ToString());
            }



        }
      

    }
    public class KlasaTestowa
    {
        public string numerZadania, zapytania, textzadania;
        int liczba = 0, nrzadania1;


        public bool SprawdZapytanie(string numerzadania1, string Zapytanie)
        {
            int select, from, where, orderby;
            bool sprawdznr = Int32.TryParse(numerzadania1, out nrzadania1);
            select = Zapytanie.IndexOf("SELECT");
            from = Zapytanie.IndexOf("FROM");
            where = Zapytanie.IndexOf("WHERE");
            orderby = Zapytanie.IndexOf("ORDER BY");

            if ((select != (-1)) && (select < from))
            {

                if (sprawdznr)
                {
                    int nrZad = Int32.Parse(numerzadania1);
                    numerZadania = numerzadania1;
                    zapytania = Zapytanie;
                    if ((where == (-1)) || (orderby == (-1)))
                    {





                        return true;

                    }



                    if ((where != (-1)) && (orderby != (-1)) && (where < orderby))
                    {





                        return true;

                    }

                    if ((where != (-1)) && (orderby != (-1)) && (where > orderby))
                    {

                        return false;
                    }
                    return true;
                }
                else
                {

                    return false;
                }

            }

            else
            {
                return false;
            }

        }
    }
    
    public class OneJob : IJob
        {
       public OneJob()
        {

        }
            DateTime dat = DateTime.Now;
            int godziny = 60;
            public void Execute(IJobExecutionContext context)
            {
                godziny = godziny - dat.Minute;
                MessageBox.Show("Wciśnij esc aby wyjść " + "\n" + godziny.ToString());
                



        }
        }

    }
