using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System;
using System.Linq;

namespace diagramShubenok
{
    public partial class MainWindow : Window
    {
        public double eps;
        public double alpha;
        public double beta;
        public double sigma;
        public int x0;
        public int y0;
        public int x;
        public int y;
        public int count = 450;
        public MainWindow()
        {
            InitializeComponent();
            sigm.Source = new Bitmap($@"Assets\sigma.jpg");
            alph.Source = new Bitmap($@"Assets\alpha.png");
            bet.Source = new Bitmap($@"Assets\beta.png");
            epsilon.Source = new Bitmap($@"Assets\eps.png");
        }

        public void countPredAndVict()
        {
            eps = Convert.ToDouble(epsTb.Text);
            alpha = Convert.ToDouble(alphaTb.Text);
            beta = Convert.ToDouble(betaTb.Text);
            sigma = Convert.ToDouble(sigmTb.Text);
            x0 = Convert.ToInt32(xoTb.Text);
            y0 = Convert.ToInt32(yoTb.Text);
            x = Convert.ToInt32(victimAmount.Text);
            y = Convert.ToInt32(predAmount.Text);

            General.eps = eps;
            General.beta = beta;
            General.alpha = alpha;
            General.sigma = sigma;
            General.x0 = x0;
            General.y0 = y0;
            General.x = x;
            General.y = y;



        }

        private void OkButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            countPredAndVict();
            Graphic graphic = new Graphic();
            graphic.Show();
            Close();
        }
    }
}