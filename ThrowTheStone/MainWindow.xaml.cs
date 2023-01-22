using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Numerics;
using System.Security.Cryptography.Xml;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ThrowTheStone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables

        double pi = 3.1415;
        double g = 9.81;
        double l = 0.5;

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void DoWork()
        {
            double M, G, r, x, y, vx, vy, xnew, ynew, vxnew, vynew, t, dt;
            long k;
            string s = "";
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();

            M = 1;
            G = 1;
            x = 20;
            y = 0;
            vx = 0;
            vy = 0.1;
            t = 0;
            dt = 0.01;
            
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                s = dialog.SelectedPath;
                s += $"/FizykaProjektKamilSzywala.txt";
            }
            else
            {
                Environment.Exit(0);
            }

            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            if (File.Exists(s))
            {
                File.Delete(s);
            }
            while (t < 240)
            {
                r = Math.Pow(x*x+y*y, 1.5);
                xnew = x + vx * dt;
                ynew = y + vy * dt;
                vxnew = vx + dt * (-G * M) * x / r;
                vynew = vy + dt * (-G * M) * y / r;
                x = xnew;
                y = ynew;
                vx = vxnew;
                vy = vynew;
                t += dt;
                File.AppendAllText(s, $"{Math.Round(x,5)} {Math.Round(y,5)}\n");
            }
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoWork();
        }
       
        #endregion

    }
}
