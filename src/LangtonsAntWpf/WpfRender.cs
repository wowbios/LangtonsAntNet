using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LangtonsAnt;

namespace GameOfLifeWpf
{
    public class WpfRender : IRender
    {
        private readonly Image _image;
        private bool _inited;
        private WriteableBitmap _bitmap;

        public WpfRender(Image image)
        {
            _image = image ?? throw new ArgumentNullException(nameof(image));
        }

        public void Render(IEnumerable<ChangeEvent> events)
        {
            if (!_inited)
            {
                Application.Current.Dispatcher.Invoke(Init);
            }

            Application.Current.Dispatcher.Invoke(() => DrawPixelsEx(events));
        }

        private void Init()
        {
            _image.Source = _bitmap = BitmapFactory.New(
                (int)_image.Width,
                (int)_image.Height);
            _bitmap.Clear(Colors.Black);

            _inited = true;
        }

        private void DrawPixelsEx(IEnumerable<ChangeEvent> events)
        {
            using (_bitmap.GetBitmapContext())
                foreach (ChangeEvent e in events)
                    _bitmap.SetPixel(
                        e.Point.X,
                        e.Point.Y,
                        Color.FromRgb(e.Color.R, e.Color.G, e.Color.B));
        }
    }
}