using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AI_PROJECT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Path> list = new List<Path>();
        graph r = new graph(19);
        public MainWindow()
        {
            InitializeComponent();          
            #region
            r.adedges(0, 4, 1);
            r.adedges(1, 2, 3, 4, 0);
            r.adedges(2, 3, 6, 1);
            r.adedges(3, 2, 4, 5, 1);
            r.adedges(4, 7, 5, 3, 1, 0);
            r.adedges(5, 8, 9, 6, 3, 4);
            r.adedges(6, 10, 2, 5);
            r.adedges(7, 11, 8, 4);
            r.adedges(8, 12, 9, 4, 7);
            r.adedges(9, 12, 10, 5, 8);
            r.adedges(10, 14, 6, 9);
            r.adedges(11, 15, 16, 12, 7);
            r.adedges(12, 17, 13, 9, 8, 11);
            r.adedges(13, 18, 14, 12);
            r.adedges(14, 13, 10);
            r.adedges(15, 16, 11);
            r.adedges(16, 17, 15);
            r.adedges(17, 18, 12, 16);
            r.adedges(18, 13, 17);
            r.arr[0].head.MYCOLOR = 2;
            r.color_map(0);
            #endregion
            pre_define();
        }   
         private void pre_define()
        {
            country0.path_of_map = map0;
            country1.path_of_map = map1;
            country2.path_of_map = map2;
            country3.path_of_map = map3;
            country4.path_of_map = map4;
            country5.path_of_map = map5;
            country6.path_of_map = map6;
            country7.path_of_map = map7;
            country8.path_of_map = map8;
            country9.path_of_map = map9;
            country10.path_of_map = map10;
            country11.path_of_map = map11;
            country12.path_of_map = map12;
            country13.path_of_map = map13;
            country14.path_of_map = map14;
            country15.path_of_map = map15;
            country16.path_of_map = map16;
            country17.path_of_map = map17;
            country18.path_of_map = map18;

            list.Add(map0);
            list.Add(map1);
            list.Add(map2);
            list.Add(map3);
            list.Add(map4);
            list.Add(map5);
            list.Add(map6);
            list.Add(map7);
            list.Add(map8);
            list.Add(map9);
            list.Add(map10);
            list.Add(map11);
            list.Add(map12);
            list.Add(map13);
            list.Add(map14);
            list.Add(map15);
            list.Add(map16);
            list.Add(map17);
            list.Add(map18);
            

        }
        private void colorcountry(Path x,int color)
        {
            switch (color)
            {
                case 1:
                    x.Fill = Brushes.Red;
                    break;
                case 2:
                    x.Fill = Brushes.Green;
                    break;
                case 3:
                    x.Fill = Brushes.Blue;
                    break;
            }
        }
        private void Ellipse_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        class country
        {
            public int index;
            int color = -1;
           // public int Available_colors = 3;
            public country next;
            public country(int index, country next)
            {
                this.index = index;
                this.next = next;
            }
            public int MYCOLOR { get { return this.color; } set { this.color = value; } }
        }
        class adjlist
        {
            public country head;
        }
        class graph
        {
            int Size = 0;
            public adjlist[] arr;                   
            // int[] colors = new int[] { 1, 2, 3 };
            public graph(int size)
            {
                this.Size = size;
                arr = new adjlist[Size];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = new adjlist();
                    arr[i].head = null;
                }
            }        
            public void adedges(int index_of_adj, params int[] list)
            {
                //country startnode = new country(index_of_adj, null);
                //  arr[index_of_adj].head = startnode;
                for (int i = 0; i < list.Length; i++)
                {
                    country n = new country(list[i], null);
                    n.next = arr[index_of_adj].head;
                    arr[index_of_adj].head = n;
                }

                country startnode = new country(index_of_adj, null);
                startnode.next = arr[index_of_adj].head;
                arr[index_of_adj].head = startnode;
            }
            public void color_map(int start_country)
            {
                Stack<int> s = new Stack<int>();
                Boolean[] visited = new Boolean[Size];
                int lenth_visited = visited.Length;
                for (int i = 0; i < lenth_visited; i++)
                {
                    visited[i] = false;
                }            
                s.Push(start_country);
                visited[start_country] = true;

                while (s.Count > 0)
                {
                    int top = s.Peek();
                    visited[top] = true;
                    country head2 = arr[top].head;
                    Boolean isdone = true;
                    while (head2 != null)
                    {
                        if (visited[head2.index] == false)
                        {
                            s.Push(head2.index);
                            visited[head2.index] = true;
                            coloring(head2.index);
                            isdone = false;
                            break;
                        }
                        else
                        {
                            head2 = head2.next;
                        }
                    }
                    if (isdone)
                    {
                        int ret = s.Pop();     
                    }
                }
            }
            public Boolean constrains_red(int countryindex)
            {
                int x1 = 0;
                int x2 = 0;
                int x3 = 0;
                country ch = arr[countryindex].head.next;
                while (ch != null)
                {
                    check(ref x1, ref x2, ref x3, ch.index);
                    if (x2 + x3 == 2)
                        return false;

                    ch = ch.next;
                }

                return true;
            }
            public Boolean constrains_green(int countryindex)
            {
                int x1 = 0;
                int x2 = 0;
                int x3 = 0;
                country ch = arr[countryindex].head.next;
                while (ch != null)
                {
                    check(ref x1, ref x2, ref x3, ch.index);
                    if (x1 + x3 == 2)
                        return false;

                    ch = ch.next;
                }

                return true;
            }
            public Boolean constrains_blue(int countryindex)
            {
                int x1 = 0;
                int x2 = 0;
                int x3 = 0;
                country ch = arr[countryindex].head.next;
                while (ch != null)
                {
                    check(ref x1, ref x2, ref x3, ch.index);
                    if (x1 + x2 == 2)
                        return false;

                    ch = ch.next;
                }

                return true;
            }
            public void check(ref int red, ref int green, ref int blue, int x)
            {
                country ch = arr[x].head.next;
                int index_of_country;
                while (ch != null)
                {
                    index_of_country = ch.index;
                    if (arr[index_of_country].head.MYCOLOR == 1)
                    {
                        red = 1;
                    }
                    if (arr[index_of_country].head.MYCOLOR == 2)
                    {
                        green = 1;
                    }
                    if (arr[index_of_country].head.MYCOLOR == 3)
                    {
                        blue = 1;
                    }
                    ch = ch.next;
                }
            }
            public void coloring(int countrynumber )
            {
                int red = 0;
                int green = 0;
                int blue = 0;
                country ch = arr[countrynumber].head.next;
                int index_of_country;
                while (ch != null)
                {
                    index_of_country = ch.index;
                    if (arr[index_of_country].head.MYCOLOR == 1)
                    {
                        red = 1;
                    }
                    if (arr[index_of_country].head.MYCOLOR == 2)
                    {
                        green = 1;
                    }
                    if (arr[index_of_country].head.MYCOLOR == 3)
                    {
                        blue = 1;
                    }
                    ch = ch.next;
                }
                #region
                //if (red > 0 && green > 0 && blue > 0)
                //{
                //   // int bactrack = s.Pop();
                //   // visited[bactrack] = false;
                //}    
                #endregion
              if (red == 0 && green == 0 && blue == 0)
              {
                  Random rand = new Random();
                  arr[countrynumber].head.MYCOLOR = rand.Next(1, 4);
                  return;

              }
              if (red + green + blue == 1)
              {
                  if (red == 0 && constrains_red(countrynumber))
                  {
                      arr[countrynumber].head.MYCOLOR = 1;
                      return;
                  }

                  if (blue == 0 && constrains_blue(countrynumber))
                  {
                      arr[countrynumber].head.MYCOLOR = 3;
                      return;
                  }

                  if (green == 0 && constrains_green(countrynumber))
                  {
                      arr[countrynumber].head.MYCOLOR = 2;
                      return;
                  }
              }

              if (red == 0)
              {
                  arr[countrynumber].head.MYCOLOR = 1;
                  return;
              }
              if (green == 0)
              {
                  arr[countrynumber].head.MYCOLOR = 2;
                  return;
              }
              if (blue == 0)
              {
                  arr[countrynumber].head.MYCOLOR = 3;
                  return;
              }
            }
            public void trace(int countrynumber)
            {
                country ch = arr[countrynumber].head.next;
                while (ch != null)
                {
                    Console.WriteLine(ch.index);
                    ch = ch.next;
                }
            }
        }
        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private async void textBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int x = 0;
            foreach (var item in list)
            {
                colorcountry(item, r.arr[x++].head.MYCOLOR);
                await Task.Delay(500);


            }
        }
    }

}

