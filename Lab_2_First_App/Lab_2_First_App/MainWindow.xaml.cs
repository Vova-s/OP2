using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Lab_2_First_App
{
    public partial class MainWindow : Window
    {
        static DispatcherTimer dT;
        static int Radius = 30;
        static int PointCount = 5;
        static Polygon myPolygon = new Polygon();
        static List<Ellipse> EllipseArray = new List<Ellipse>();
        static PointCollection pC = new PointCollection();
        int Population ;
        int[,] ways ;
        static Random rnd;
        public MainWindow()
        {

            dT = new DispatcherTimer();
            InitializeComponent();
            InitPoints();
            InitPolygon();
            dT = new DispatcherTimer();
            dT.Tick += new EventHandler(OneStep);
            dT.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        }
        private void InitPoints()
        {
            Random rnd = new Random();
            pC.Clear();
            EllipseArray.Clear();
            for (int i = 0; i < PointCount; i++)
            {
                Point p = new Point();
                p.X = rnd.Next(Radius, (int)(0.75 * MainWin.Width) - 3 * Radius);

                p.Y = rnd.Next(Radius, (int)(0.90 * MainWin.Height - 3 * Radius));

                pC.Add(p);
            }
            for (int i = 0; i < PointCount; i++)
            {
                Ellipse el = new Ellipse();
                el.StrokeThickness = 2;
                el.Height = el.Width = Radius;
                el.Stroke = Brushes.Black;
                el.Fill = Brushes.LightBlue;
                EllipseArray.Add(el);
            }
        }
        private void InitPolygon()
        {
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon.StrokeThickness = 2;
        }
        private void PlotPoints()
        {
            for (int i = 0; i < PointCount; i++)
            {
                Canvas.SetLeft(EllipseArray[i], pC[i].X - Radius / 2);
                Canvas.SetTop(EllipseArray[i], pC[i].Y - Radius / 2);
                MyCanvas.Children.Add(EllipseArray[i]);
            }
        }

        private void PlotWay(int[] BestWayIndex)
        {
            PointCollection Points = new PointCollection();
            for (int i = 0; i < BestWayIndex.Length; i++)
                Points.Add(pC[BestWayIndex[i]]);
            myPolygon.Points = Points;
            MyCanvas.Children.Add(myPolygon);
        }
        private void VelCB_SelectionChanged(object sender,
        SelectionChangedEventArgs e)

        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;
            dT.Interval = new

            TimeSpan(0, 0, 0, 0, Convert.ToInt16(item.Content));

        }
        private void StopStart_Click(object sender, RoutedEventArgs e)
        {
            if (dT.IsEnabled)
            {
                dT.Stop();
                NumElemCB.IsEnabled = true;
            }
            else
            {
                NumElemCB.IsEnabled = false;
                dT.Start();
            }
        }
        private void NumElemCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;
            PointCount = Convert.ToInt32(item.Content);
            InitPoints();
            InitPolygon();
        }
        int k = 0;
        private void OneStep(object sender, EventArgs e)
        {
            
            MyCanvas.Children.Clear();
            PlotPoints();
            if (k == 0)
            {
                setCountPopulation();
                for (int i = 0; i < Population; i++)
                {
                    int[] way = Enumerable.Range(0, PointCount).ToArray();
                    Shuffle(way);
                    for (int j = 0; j < PointCount; j++)
                    {
                        ways[i, j] = way[j];
                    }  
                }
                k++;
            }
            PlotWay(Genetic_algo());
        }
        private int[] GetBestWay()
        {
            
            int[] way = new int[PointCount];
            for (int i = 0; i < PointCount; i++)
                way[i] = i;
            for (int s = 0; s < 2 * PointCount; s++)
            {
                int i1, i2, tmp;
                i1 = rnd.Next(PointCount);
                i2 = rnd.Next(PointCount);
                tmp = way[i1];
                way[i1] = way[i2];
                way[i2] = tmp;
            }
            return way;
        }
        private int[] GreedyAlgoritm()
        {
            
            int[] way = new int[PointCount];
            int FirstCity, LastCity, AfterLastCity, FirstCity_X, FirstCity_Y;
            int Index_City = 0;
            float min;

            for (int i = 0; i < PointCount; i++)
            {
                way[i] = -1;
            }

            for (int j = 0; j < PointCount; j++)
            {
                min = int.MaxValue;

                if (j == 0)
                {
                    FirstCity = rnd.Next(PointCount);
                    LastCity = FirstCity;
                    EllipseArray[LastCity].Fill = Brushes.Red;
                }
                else
                {
                    FirstCity = Index_City;
                }
                if (j == PointCount - 1)
                {
                    way[j] = FirstCity;
                    AfterLastCity = FirstCity;
                    break;
                }
                else
                {
                    way[j] = FirstCity;
                }

                FirstCity_X = (int)pC[FirstCity].X;
                FirstCity_Y = (int)pC[FirstCity].Y;

                List<double> distance = new List<double>();

                for (int i = 0; i < PointCount; i++)
                {
                    if (way.Contains(i))
                    {
                        distance.Add(0);
                    }
                    else
                    {
                        float length = (float)Math.Sqrt(Math.Pow(pC[i].X - FirstCity_X, 2) + Math.Pow(pC[i].Y - FirstCity_Y, 2));
                        distance.Add(length);
                        if (length < min)
                        {
                            min = length;
                        }
                    }
                }
                Index_City = distance.IndexOf(min);

            }

            return way;
        }

        private void Greedy_alg_Click(object sender, RoutedEventArgs e)
        {
            dT.Stop();
            for (int i = 0; i < PointCount; i++)
            {
                EllipseArray[i].Fill = Brushes.LightBlue;
            }
            MyCanvas.Children.Clear();
            PlotPoints();
            PlotWay(GreedyAlgoritm());
        }
        public static void Shuffle<T>(T[] arr)
        {
            rnd = new Random();
            
            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);

                T tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }
        }

        

       
        private int[] Genetic_algo()
        {
            //getway        
            int[] TheShortestWay = new int[PointCount];
           
            //algoritm
            for (int j = 0; j < Population; j++)
            {
                int Mother = rnd.Next(Population);
                int Father = rnd.Next(Population);
                while (Mother == Father)
                {
                    Mother = rnd.Next(Population);
                }
                int[] mother_way = new int[PointCount];
                int[] father_way = new int[PointCount];
                for (int i = 0; i < PointCount; i++)
                {
                    mother_way[i] = ways[Mother, i];
                    father_way[i] = ways[Father, i];
                }
                int crossover = rnd.Next(2, PointCount - 1);
                //childs
                int[] FirstChild = new int[PointCount];
                int[] SecondChild = new int[PointCount];
                for (int i = 0; i < PointCount; i++)
                {
                    FirstChild[i] = -1;
                    SecondChild[i] = -1;
                }
                int counter = 0;
                if (rnd.NextDouble() < 0.5)
                {
                    for (int i = 0; i < crossover; i++)
                    {
                        FirstChild[i] = mother_way[i];
                    }
                    for (int m = crossover; m < PointCount; m++)
                    {
                        if (FirstChild.Contains(father_way[counter]))
                        {
                            counter++;
                            m--;
                        }
                        else
                        {
                            FirstChild[m] = father_way[counter];
                            counter++;
                        }
                    }
                    for (int i = 0; i < PointCount; i++)
                    {
                        ways[Population + j, i] = FirstChild[i];
                    }
                }
                else
                {
                    for (int i = 0; i < crossover; i++)
                    {
                        SecondChild[i] = father_way[i];
                    }
                    for (int m = crossover; m < PointCount; m++)
                    {
                        if (SecondChild.Contains(mother_way[counter]))
                        {
                            counter++;
                            m--;
                        }
                        else
                        {
                            SecondChild[m] = mother_way[counter];
                            counter++;
                        }
                    }
                    for (int i = 0; i < PointCount; i++)
                    {
                        ways[Population + j, i] = SecondChild[i];
                    }

                    //mutation
                    if (rnd.NextDouble() < double.Parse(tb2.Text))
                    {
                        Mutation(ways, Population + j);
                    }
                }
            }
                double[] Distance = new double[2 * Population];
                double[] Distance1 = new double[2 * Population];

                for (int i = 0; i < 2 * Population; i++)
                {
                    Distance[i] = GetLength(i, ways);
                    Distance1[i] = GetLength(i, ways);
                }
                Array.Sort(Distance1);
                int IndexShortestWay = Array.IndexOf(Distance, Distance1[0]);
                
                for (int i = 0; i < PointCount; i++)
                {
                    TheShortestWay[i] = ways[IndexShortestWay, i];
                }
                int[,] Way = new int[2 * Population, PointCount];
                for (int i = 0; i < 2 * Population; i++)
                {
                    for (int k = 0; k < PointCount; k++)
                    {
                        Way[i, k] = ways[i, k];
                    }
                }
                for (int i = 0; i < Population; i++)
                {
                    int BestWay = Array.IndexOf(Distance, Distance1[i]);

                    Distance[BestWay] = 0;

                    int[] temp = new int[PointCount];

                    for (int b = 0; b < PointCount; b++)
                    {
                        temp[b] = ways[i, b];
                    }

                    for (int c = 0; c < PointCount; c++)
                    {
                        ways[i, c] = Way[BestWay, c];
                        if (BestWay > i)
                            ways[BestWay, c] = temp[c];
                    }
                }
            return TheShortestWay;
        }
        private double GetLength(int i, int[,] ways)
        {
            double summary = 0;
            for (int j = 1; j < PointCount; j++)
            {
                summary += Math.Sqrt(Math.Pow(pC[ways[i, j]].X - pC[ways[i, j - 1]].X, 2) + Math.Pow(pC[ways[i, j]].Y - pC[ways[i, j - 1]].Y, 2));
            }
            summary += Math.Sqrt(Math.Pow(pC[ways[i, PointCount - 1]].X - pC[ways[i, 0]].X, 2) + Math.Pow(pC[ways[i, PointCount - 1]].Y - pC[ways[i, 0]].Y, 2));
            return summary;
        }
        private int[,] Mutation( int [,]  ways , int height) 
        {
       
            int MutationIndex1 = rnd.Next(PointCount);
            int MutationIndex2 = rnd.Next(PointCount);
            while (MutationIndex1 == MutationIndex2)
            {
                MutationIndex1 = rnd.Next(PointCount);
            }
            if (MutationIndex1 > MutationIndex2) 
            {
                int temp = MutationIndex1;
                MutationIndex1 = MutationIndex2;
                MutationIndex2 = temp;
            }
            int[] TemporaryArray = new int[Math.Abs(MutationIndex1- MutationIndex2)];
            int counter = 0;
            for (int i = MutationIndex1; i < MutationIndex2; i++) 
            {
               TemporaryArray[counter] = ways[height,i];
               counter++;
            }
            TemporaryArray.Reverse();
            counter = 0;
            for (int i = MutationIndex1; i < MutationIndex2; i++)
            {
                ways[height, i] = TemporaryArray[counter];
                counter++;
            }
            return ways;

        }

        private void Genetic_alg_Click(object sender, RoutedEventArgs e)
        {
            setCountPopulation();
            dT.Stop();
            MyCanvas.Children.Clear();
            PlotPoints();
            PlotWay(Genetic_algo());
        }

        private void setCountPopulation()
        {
            Population = Int16.Parse(TB1.Text);
            ways = new int[2 * Population, PointCount];
        }
    }
}

