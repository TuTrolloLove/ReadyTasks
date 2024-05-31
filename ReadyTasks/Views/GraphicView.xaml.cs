using ReadyTasks.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using LiveCharts;
using LiveCharts.Wpf;


namespace ReadyTasks.Views
{

    public partial class GraphicView : UserControl
    {
        GraphicViewModel _graphicViewModel = new GraphicViewModel();
        public int _userId;
        public GraphicView()
        {
            InitializeComponent();
            if (File.Exists(@"./ID.txt"))
            {
                _userId = int.Parse(File.ReadAllText(@"./ID.txt"));

                Debug.WriteLine("UserId del archivo: " + _userId);

                doGraphics();
                translateCaption();
            }

        }

        public void doGraphics()
        {
            string language = File.ReadAllText(@"./Language.txt");
            List<int> values = _graphicViewModel.doGraphics(_userId);
            // If there are no notes, the PieCharts are not shown
            if (values.All(x => x == 0))
            {
                if (language.Equals("es"))
                {
                    PieChartCompletedNoCompleted.Visibility = Visibility.Collapsed;
                    PieChartPriority.Visibility = Visibility.Collapsed;
                    r1.Visibility = Visibility.Collapsed;
                    r2.Visibility = Visibility.Collapsed;
                    rDontNotes.Visibility = Visibility.Visible;
                    tbDontNotes.Visibility = Visibility.Visible;
                    tbDontNotes.Text = Application.Current.Resources["GraphicViewPieChartTextBlockDontNotes"] as string;

                    return;
                }
                else if (language.Equals("en"))
                {
                    PieChartCompletedNoCompleted.Visibility = Visibility.Collapsed;
                    PieChartPriority.Visibility = Visibility.Collapsed;
                    r1.Visibility = Visibility.Collapsed;
                    r2.Visibility = Visibility.Collapsed;
                    rDontNotes.Visibility = Visibility.Visible;
                    tbDontNotes.Visibility = Visibility.Visible;
                    tbDontNotes.Text = Application.Current.Resources["EN_GraphicViewPieChartTextBlockDontNotes"] as string;
                    return;
                }
                else
                {
                    PieChartCompletedNoCompleted.Visibility = Visibility.Collapsed;
                    PieChartPriority.Visibility = Visibility.Collapsed;
                    r1.Visibility = Visibility.Collapsed;
                    r2.Visibility = Visibility.Collapsed;
                    rDontNotes.Visibility = Visibility.Visible;
                    tbDontNotes.Visibility = Visibility.Visible;
                    tbDontNotes.Text = Application.Current.Resources["VA_GraphicViewPieChartTextBlockDontNotes"] as string;
                    return;
                }

            }
            // First PieChart: Percentage of completed and not completed notes
            // Percentage of completed and not completed notes (2 decimals)
            double completedNotesPercentage = Math.Round((double)(values[0] * 100) / values[2], 2);
            double notCompletedNotesPercentage = Math.Round((double)(values[1] * 100) / values[2], 2);
            Debug.WriteLine(completedNotesPercentage + ", " + notCompletedNotesPercentage);
            // Set the values of the series
            PieChartCompletedNoCompleted.Series[0].Values = new ChartValues<double> { values[0] };
            PieChartCompletedNoCompleted.Series[1].Values = new ChartValues<double> { values[1] };

            // Translation and setting of the titles of the series
            if (language.Equals("es"))
            {
                string baseStringCompleted = Application.Current.Resources["GraphicViewCSPieChartSeriesTitleNotesCompleted"] as string;
                ((PieSeries)PieChartCompletedNoCompleted.Series[0]).Title = string.Format(baseStringCompleted, completedNotesPercentage);
                string baseStringNoCompleted = Application.Current.Resources["GraphicViewCSPieChartSeriesTitleNotesNoCompleted"] as string;
                ((PieSeries)PieChartCompletedNoCompleted.Series[1]).Title = string.Format(baseStringNoCompleted, notCompletedNotesPercentage);
                // Second PieChart: Percentage of notes by priority
                // Percentage of notes by priority (2 decimals)
                double highPriorityPercentage = Math.Round((double)(values[3] * 100) / values[2], 2);
                double mediumPriorityPercentage = Math.Round((double)(values[4] * 100) / values[2], 2);
                double lowPriorityPercentage = Math.Round((double)(values[5] * 100) / values[2], 2);

                // Set the values of the series
                PieChartPriority.Series[0].Values = new ChartValues<double> { values[3] };
                PieChartPriority.Series[1].Values = new ChartValues<double> { values[4] };
                PieChartPriority.Series[2].Values = new ChartValues<double> { values[5] };
                // Set the titles of the series translated
                string baseStringHigh = Application.Current.Resources["GraphicViewCSPieChartSeriesTitleNotesHigh"] as string;
                ((PieSeries)PieChartPriority.Series[0]).Title = string.Format(baseStringHigh, highPriorityPercentage);
                string baseStringMedium = Application.Current.Resources["GraphicViewCSPieChartSeriesTitleNotesMedium"] as string;
                ((PieSeries)PieChartPriority.Series[1]).Title = string.Format(baseStringMedium, mediumPriorityPercentage);
                string baseStringLow = Application.Current.Resources["GraphicViewCSPieChartSeriesTitleNotesLow"] as string;
                ((PieSeries)PieChartPriority.Series[2]).Title = string.Format(baseStringLow, lowPriorityPercentage);
            }
            else if (language.Equals("en"))
            {
                string baseStringCompleted = Application.Current.Resources["EN_GraphicViewCSPieChartSeriesTitleNotesCompleted"] as string;
                ((PieSeries)PieChartCompletedNoCompleted.Series[0]).Title = string.Format(baseStringCompleted, completedNotesPercentage);
                string baseStringNoCompleted = Application.Current.Resources["EN_GraphicViewCSPieChartSeriesTitleNotesNoCompleted"] as string;
                ((PieSeries)PieChartCompletedNoCompleted.Series[1]).Title = string.Format(baseStringNoCompleted, notCompletedNotesPercentage);
                // Second PieChart: Percentage of notes by priority
                // Percentage of notes by priority (2 decimals)
                double highPriorityPercentage = Math.Round((double)(values[3] * 100) / values[2], 2);
                double mediumPriorityPercentage = Math.Round((double)(values[4] * 100) / values[2], 2);
                double lowPriorityPercentage = Math.Round((double)(values[5] * 100) / values[2], 2);

                // Set the values of the series
                PieChartPriority.Series[0].Values = new ChartValues<double> { values[3] };
                PieChartPriority.Series[1].Values = new ChartValues<double> { values[4] };
                PieChartPriority.Series[2].Values = new ChartValues<double> { values[5] };
                // Set the titles of the series translated
                string baseStringHigh = Application.Current.Resources["EN_GraphicViewCSPieChartSeriesTitleNotesHigh"] as string;
                ((PieSeries)PieChartPriority.Series[0]).Title = string.Format(baseStringHigh, highPriorityPercentage);
                string baseStringMedium = Application.Current.Resources["EN_GraphicViewCSPieChartSeriesTitleNotesMedium"] as string;
                ((PieSeries)PieChartPriority.Series[1]).Title = string.Format(baseStringMedium, mediumPriorityPercentage);
                string baseStringLow = Application.Current.Resources["EN_GraphicViewCSPieChartSeriesTitleNotesLow"] as string;
                ((PieSeries)PieChartPriority.Series[2]).Title = string.Format(baseStringLow, lowPriorityPercentage);

            }
            else
            {
                string baseStringCompleted = Application.Current.Resources["VA_GraphicViewCSPieChartSeriesTitleNotesCompleted"] as string;
                ((PieSeries)PieChartCompletedNoCompleted.Series[0]).Title = string.Format(baseStringCompleted, completedNotesPercentage);
                string baseStringNoCompleted = Application.Current.Resources["VA_GraphicViewCSPieChartSeriesTitleNotesNoCompleted"] as string;
                ((PieSeries)PieChartCompletedNoCompleted.Series[1]).Title = string.Format(baseStringNoCompleted, notCompletedNotesPercentage);
                // Second PieChart: Percentage of notes by priority
                // Percentage of notes by priority (2 decimals)
                double highPriorityPercentage = Math.Round((double)(values[3] * 100) / values[2], 2);
                double mediumPriorityPercentage = Math.Round((double)(values[4] * 100) / values[2], 2);
                double lowPriorityPercentage = Math.Round((double)(values[5] * 100) / values[2], 2);

                // Set the values of the series
                PieChartPriority.Series[0].Values = new ChartValues<double> { values[3] };
                PieChartPriority.Series[1].Values = new ChartValues<double> { values[4] };
                PieChartPriority.Series[2].Values = new ChartValues<double> { values[5] };
                // Set the titles of the series translated
                string baseStringHigh = Application.Current.Resources["VA_GraphicViewCSPieChartSeriesTitleNotesHigh"] as string;
                ((PieSeries)PieChartPriority.Series[0]).Title = string.Format(baseStringHigh, highPriorityPercentage);
                string baseStringMedium = Application.Current.Resources["VA_GraphicViewCSPieChartSeriesTitleNotesMedium"] as string;
                ((PieSeries)PieChartPriority.Series[1]).Title = string.Format(baseStringMedium, mediumPriorityPercentage);
                string baseStringLow = Application.Current.Resources["VA_GraphicViewCSPieChartSeriesTitleNotesLow"] as string;
                ((PieSeries)PieChartPriority.Series[2]).Title = string.Format(baseStringLow, lowPriorityPercentage);
            }



        }

        public void translateCaption()
        {
            string language = File.ReadAllText(@"./Language.txt");
            if (language.Equals("es"))
            {

                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        MainView mainWindow = (MainView)window;
                        mainWindow.tbSecondaryViewOpened.Text = System.Windows.Application.Current.Resources["GraphicViewCaption"] as string;
                    }
                }
            }
            else if (language.Equals("en"))
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        MainView mainWindow = (MainView)window;
                        mainWindow.tbSecondaryViewOpened.Text = System.Windows.Application.Current.Resources["EN_GraphicViewCaption"] as string;
                    }
                }
            }
            else
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainView))
                    {
                        MainView mainWindow = (MainView)window;
                        mainWindow.tbSecondaryViewOpened.Text = System.Windows.Application.Current.Resources["VA_GraphicViewCaption"] as string;
                    }
                }
            }

        }
    }
}

