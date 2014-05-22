using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using System.IO;


namespace control
{
    public partial class Form1 : Form
    {
      
        private int currentImageIndex = 0;

        string[] arr1 = new string[] { "water", "eat", "bath", "sleep", "tv", "park", "START" };
        string[] arr2 = new string[] { "nero", "fai", "mpanio", "sleep1", "tv1", "volta", "" };
         
    
        public Form1()
        {
            InitializeComponent();
          
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            
                check();
              
            //button1.BackgroundImage = Properties.Resources.water;

                // Stop the timer if it runs already
                if (timer1.Enabled)
                {
                    timer1.Stop();
                    if (currentImageIndex != 0)
                    {
                        currentImageIndex -= 1;
                    }
                 
                      Stream stream = Properties.Resources.ResourceManager.GetStream(arr2[currentImageIndex]);
                        new SoundPlayer(stream).Play();
                 
                }

                // Start the timer if it was stopped
                else
                {
                    // Make the timer start right away
                    currentImageIndex = 0;
                    timer1.Interval = 1;

                    // Start the timer
                    timer1.Start();
                }
           
        }
     

        private void timer1_Tick(object sender, EventArgs e)
        {
         
            timer1.Stop();
            try
            {
                timer1.Interval = 5000; // Next time, wait 5 secs

                // Set the image and select next picture
                button1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(arr1[currentImageIndex]);

                        Stream stream = Properties.Resources.ResourceManager.GetStream(arr2[currentImageIndex] );
                         new SoundPlayer(stream).Play();
            

                currentImageIndex++;
            }
            finally
            {
                // Only start the timer if we have more images to show!
                if (currentImageIndex < arr1.Length)
                    timer1.Start();
            }
        }


        private void check()
        {
            DateTime now = DateTime.Now;
            DateTime morning = Convert.ToDateTime("06:00:00 AM");
            DateTime morning1 = Convert.ToDateTime("12:00:00 PM");
            DateTime noon = Convert.ToDateTime("12:00:00 PM");
            DateTime evening = Convert.ToDateTime("16:00:00 PM");
            DateTime night = Convert.ToDateTime("19:00:00 PM");
 

            if ((now >= morning) && (now < morning1))
            {
                BackgroundImage = Properties.Resources.mpez;
            }
            else if ((now >= morning1) && (now < evening))
            {
                BackgroundImage = Properties.Resources.yellow;
            }
            else if ((now >= evening) && (now < night))
            {
                BackgroundImage = Properties.Resources.graylight;
            }
            else
            {
                BackgroundImage = Properties.Resources.bleu;
             
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            check();
         
        }


    }
}
