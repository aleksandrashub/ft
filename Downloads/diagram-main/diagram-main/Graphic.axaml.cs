using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using System.Collections.Generic;

namespace diagramShubenok;

public partial class Graphic : Window
{

    public ISeries[] Series { get; set; }
    public ISeries[] RoundSeries { get; set; }

    public Graphic()
    {
        List<ObservablePoint> points = new();
        List<double> valuesX = new List<double>();
        List<double> valuesY = new List<double>();
        double a = 0;
        valuesX.Add(General.x);
        valuesY.Add(General.y);
        points.Add(new ObservablePoint()
        {
            X = General.x,
            Y = General.y,
        });
        for (int j = 1; j < General.count; j++)
            {
                int i = j - 1;
                a = (General.eps - General.alpha * valuesY[i]) * valuesX[i] + valuesX[i];
                valuesX.Add(a);
                double b = 0;
                b = (General.sigma * valuesX[j] - General.beta) * valuesY[i] + valuesY[i]; //y всегда предыдущий
                valuesY.Add(b);
            points.Add(new ObservablePoint()
            {
                X = a,
                Y = b,
            });
            }
        
        ISeries[] RoundSeries = [
             new LineSeries<ObservablePoint>
        {
            Values = points,
            Fill = null,
            GeometrySize = 5
        }];
        ISeries[] Series = [
      new LineSeries<double>
        {
            Values = valuesX,
            Fill = null,
            GeometrySize = 5
        },
        new LineSeries<double>
        {
            Values = valuesY,
            Fill = null,
            GeometrySize = 5
        }
    ];

        InitializeComponent();
        chart.Series = Series;
        chart2.Series = RoundSeries;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}