using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Documents;

namespace Sitech_ProgrammingExercise
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private volatile bool m_appIsRunning = true;
        public string TimeString { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            Thread t = new Thread(() =>
            {
                while (m_appIsRunning)
                {
                    Dispatcher.BeginInvoke((Action)(() =>
                    {
                        m_ctrl_excercise1_tb.Text = Exercise1();
                    }));

                    Thread.Sleep(1000);
                }
            });

            t.Start();

            string exepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string exe1 = Path.Combine(exepath, "day.png");
            string exe2 = Path.Combine(exepath, "foggy.png");
            string exe3 = Path.Combine(exepath, "sitech.png");
            string exe4 = Path.Combine(exepath, "sitech2.png");

            m_ctrl_exercise2.Items.Add(Exercise2(exe1, exe2) ? "exe1 and exe2 match" : "exe1 and exe2 do not match");
            m_ctrl_exercise2.Items.Add(Exercise2(exe3, exe3) ? "exe3 and exe3 match" : "exe3 and exe3 do not match");
            m_ctrl_exercise2.Items.Add(Exercise2(exe3, exe2) ? "exe3 and exe2 match" : "exe3 and exe2 do not match");
            m_ctrl_exercise2.Items.Add(Exercise2(exe3, exe4) ? "exe3 and exe4 match" : "exe3 and exe4 do not match");
            
            TextWriter current = Console.Out;
            TextWriter writer = new StringWriter();
            Console.SetOut(writer);
            Exercise3();
            m_ctrl_excercise3_tb.Text = writer.ToString();
            Console.SetOut(current);

            Exercise4(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), files => Dispatcher.BeginInvoke((Action)(() =>
            {
                m_ctrl_file_paths.ItemsSource = files;
            })));
            
            m_ctrl_lb.ItemsSource = Exercise5(new[] { "Smith", "Jhones", "Wallace", "Amos", "Lindegaard", "Smith", "Rooney", "Evans", "Ferdinand", "Carrick", "Rooney", "Giggs", "Young", "Persie", "Welbeck", "Rooney" });

            m_ctrl_exercise6_canvas.SizeChanged += m_ctrl_exercise6_canvas_SizeChanged;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_ctrl_exercise6_canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            m_ctrl_exercise6_canvas.CalcBounds();
            m_ctrl_exercise6_canvas.Lines = Exercise6(m_ctrl_exercise6_canvas.Bounds);
            m_ctrl_exercise6_canvas.InvalidateVisual();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            m_appIsRunning = false;
        }
    }
}
