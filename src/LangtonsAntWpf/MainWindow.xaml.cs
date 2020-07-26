using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LangtonsAnt;

namespace GameOfLifeWpf
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            RenderOptions.SetBitmapScalingMode(FieldImage, BitmapScalingMode.NearestNeighbor);
            RenderOptions.SetEdgeMode(FieldImage, EdgeMode.Aliased);


            var game = new AntGame(
                (int)FieldImage.Width,
                (int)FieldImage.Height,
                new WpfRender(FieldImage));
            // FieldImage.Height = Height;
            // FieldImage.Width = Width;

            RunGame(game);
        }

        private void RunGame(AntGame game)
        {
            Task.Run(
                () =>
                {
                    try
                    {
                        long counter = 0;
                        while (true)
                        {
                            counter++;
                            game.Cycle();
                            // Dispatcher.Invoke(() => Counter.Text = counter.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                });
        }
    }
}