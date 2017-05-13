////-----------------------------------------------
//// ArrowheadsDemo.cs (c) 2007 by Charles Petzold
////-----------------------------------------------
//using System;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Media;
//using System.Windows.Media.Animation;
//using Petzold.Media2D;

//namespace Petzold.Arrowheads
//{
//    public class Arrowheads : Window
//    {
//        [STAThread]
//        public static void Main()
//        {
//            Application app = new Application();
//            app.Run(new Arrowheads());
//        }

//        public Arrowheads()
//        {
//            Canvas canv = new Canvas();
//            Content = canv;

//            // ArrowLine with animated arrow properties.
//            ArrowLine aline1 = new ArrowLine();
//            aline1.Stroke = Brushes.Red;
//            aline1.StrokeThickness = 3;
//            aline1.X1 = 100;
//            aline1.Y1 = 400;
//            aline1.X2 = 400;
//            aline1.Y2 = 100;
//            canv.Children.Add(aline1);

//            DoubleAnimation animaDouble1 = new DoubleAnimation(10, 50, new Duration(new TimeSpan(0, 0, 5)));
//            animaDouble1.AutoReverse = true;
//            animaDouble1.RepeatBehavior = RepeatBehavior.Forever;
//            aline1.BeginAnimation(ArrowLine.ArrowAngleProperty, animaDouble1);

//            DoubleAnimation animaDouble2 = new DoubleAnimation(10, 200, new Duration(new TimeSpan(0, 0, 5)));
//            animaDouble2.AutoReverse = true;
//            animaDouble2.RepeatBehavior = RepeatBehavior.Forever;
//            aline1.BeginAnimation(ArrowLine.ArrowLengthProperty, animaDouble2);

//            // ArrowLine with animated point properties.
//            ArrowLine aline2 = new ArrowLine();
//            aline2.ArrowEnds = ArrowEnds.Both;

//            aline2.Stroke = Brushes.Blue;
//            aline2.StrokeThickness = 1;
//            aline2.X1 = 100;
//            aline2.Y1 = 100;
//            aline2.X2 = 200;
//            aline2.Y2 = 400;
//            canv.Children.Add(aline2);

//            AnimationTimeline animaDouble3 = new DoubleAnimation(100, 400, new Duration(new TimeSpan(0, 0, 5)));
//            animaDouble3.AutoReverse = true;
//            animaDouble3.RepeatBehavior = RepeatBehavior.Forever;
//            aline2.BeginAnimation(ArrowLine.X1Property, animaDouble3);

//            AnimationTimeline animaDouble4 = new DoubleAnimation(400, 100, new Duration(new TimeSpan(0, 0, 5)));
//            animaDouble4.AutoReverse = true;
//            animaDouble4.RepeatBehavior = RepeatBehavior.Forever;
//            aline2.BeginAnimation(ArrowLine.Y2Property, animaDouble4);

//            // ArrowPolyline rotated.            
//            ArrowPolyline apoly = new ArrowPolyline();
//            RotateTransform xform = new RotateTransform();
//            apoly.LayoutTransform = xform;
//            apoly.ArrowEnds = ArrowEnds.Both;
//            apoly.Stroke = Brushes.Green;
//            apoly.StrokeThickness = 3;

//            apoly.Points.Add(new Point(25, 25));
//            apoly.Points.Add(new Point(125, 25));
//            apoly.Points.Add(new Point(125, 125));
//            apoly.Points.Add(new Point(25, 125));

//            canv.Children.Add(apoly);

//            AnimationTimeline animaDouble5 = new DoubleAnimation(0, 360, new Duration(new TimeSpan(0, 0, 10)));
//            animaDouble5.RepeatBehavior = RepeatBehavior.Forever;
//            xform.BeginAnimation(RotateTransform.AngleProperty, animaDouble5);
//        }
//    }
//}