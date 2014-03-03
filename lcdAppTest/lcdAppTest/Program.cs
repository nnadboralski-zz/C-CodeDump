using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using GammaJul.LgLcd;


namespace lcdAppTest
{
    class Program
    {
        private static readonly int WIDTH = 156;  // 160x43
        private static readonly int HEIGHT = 39;
        private static readonly byte WALL = 1;
        private static readonly byte FLOOR = 0;
        

        private static readonly AutoResetEvent _waitAre = new AutoResetEvent(false);
        private static volatile bool _monoArrived;
        private static volatile bool _qvgaArrived;
        private static volatile bool _mustExit;
        private static volatile bool _forceUpdate;
        
        private static double _lastUpdate = 0;     
        
        private static volatile Random _random = new Random();
        
        static void Main(string[] args)
        {
            LcdApplet applet = new LcdApplet("My Test App", LcdAppletCapabilities.Both);
            applet.Configure += Applet_Configure;
            applet.DeviceArrival += Applet_DeviceArrival;
            applet.DeviceRemoval += Applet_DeviceRemoval;
            applet.IsEnabledChanged += Applet_IsEnabledChanged;
            applet.Connect();

            LcdDeviceMonochrome monoDevice = null;
            _waitAre.WaitOne();

            do
            {
                if (_monoArrived)
                {
                    if (monoDevice == null)
                    {
                        monoDevice = (LcdDeviceMonochrome)applet.OpenDeviceByType(LcdDeviceType.Monochrome);
                        monoDevice.SoftButtonsChanged += MonoDevice_SoftButtonsChanged;
                        CreateMonochromeGdiPages(monoDevice);
                    }
                    else
                    {
                        monoDevice.ReOpen();
                    }
                    _monoArrived = false;
                }
                if (_qvgaArrived)
                {
                    _qvgaArrived = false;
                }
                if (applet.IsEnabled && monoDevice != null && !monoDevice.IsDisposed)
                    monoDevice.DoUpdateAndDraw();

                Thread.Sleep(5);
            }
            while (!_mustExit);           
        }

        private static void CreateMonochromeGdiPages(LcdDevice monoDevice)
        {                       
            // Image notUsing;
            Image myImage;

            myImage = (Image)GenerateMap();

            LcdGdiPage page1 = new LcdGdiPage(monoDevice)
            {
                Children = {
                    new LcdGdiImage((Image)GenerateMap()),
                    /*
                    new LcdGdiScrollViewer {
                        Child = new LcdGdiText("Hello World! This display is " + monoDevice.PixelWidth.ToString() + "x" + monoDevice.PixelHeight.ToString()),                        
                        HorizontalAlignment = LcdGdiHorizontalAlignment.Stretch,
                        VerticalAlignment = LcdGdiVerticalAlignment.Stretch,
                       	Margin = new MarginF(0.0f, 0.0f, 0.0f, 0.0f),
						AutoScrollX = true,
                    } */
                }
            };
            page1.Updating += Page_Updating;
            monoDevice.Pages.Add(page1);
            monoDevice.CurrentPage = page1;
        }

        private static void Applet_Configure(object sender, EventArgs e)
        {
            Console.WriteLine("Someone herped the derp.");
        }

        private static void MonoDevice_SoftButtonsChanged(object sender, LcdSoftButtonsEventArgs e)
        {
            LcdDevice device = (LcdDevice)sender;
            Console.WriteLine(e.SoftButtons);

            // First button (remember that buttons start at index 0) is pressed, switch to page one
            if ((e.SoftButtons & LcdSoftButtons.Button0) == LcdSoftButtons.Button0)
                _forceUpdate = true;

            // Second button is pressed, switch to page two
            //if ((e.SoftButtons & LcdSoftButtons.Button1) == LcdSoftButtons.Button1)
                //device.CurrentPage = device.Pages[1];

            // Third button is pressed, do a garbage collection (for testing purpose only!)
            if ((e.SoftButtons & LcdSoftButtons.Button2) == LcdSoftButtons.Button2)
                GC.Collect();

            // Fourth button is pressed, exit
            if ((e.SoftButtons & LcdSoftButtons.Button3) == LcdSoftButtons.Button3)
                _mustExit = true;
        }

        private static void Page_Updating(object sender, UpdateEventArgs e)
        {
            LcdGdiPage page = (LcdGdiPage)sender;
            if (_lastUpdate == 0 || (e.ElapsedTotalTime.TotalSeconds - _lastUpdate > 10) || _forceUpdate)
            {
                LcdGdiImage updateImage = (LcdGdiImage)page.Children[0];
                updateImage.Image = (Image)GenerateMap();
                ((LcdGdiPage)sender).Invalidate();
                _lastUpdate = e.ElapsedTotalTime.TotalSeconds;
                _forceUpdate = false;
            }
        }

        private static void Applet_IsEnabledChanged(object sender, EventArgs e)
        {
            Console.WriteLine(((LcdApplet)sender).IsEnabled ? "Applet was enabled." : "Applet was disabled");
        }

        private static void Applet_DeviceArrival(object sender, LcdDeviceTypeEventArgs e)
        {
            Console.WriteLine("A device of type " + e.DeviceType + " was added.");
            switch (e.DeviceType)
            {

                // A monochrome device (G13/G15/Z10) was connected
                case LcdDeviceType.Monochrome:
                    _monoArrived = true;
                    break;

            }
            _waitAre.Set();
        }

        private static void Applet_DeviceRemoval(object sender, LcdDeviceTypeEventArgs e)
        {
            Console.WriteLine("A device of type " + e.DeviceType + " was removed.");
        }

        private static Bitmap GenerateMap()
        {
            _random = new Random();
            byte[,] b = new byte[WIDTH, HEIGHT];
            byte[,] b2 = new byte[WIDTH, HEIGHT];

            // Initialise maps.
            for (int y = 1; y < HEIGHT-1; y++)
            {
                for (int x = 1; x < WIDTH-1; x++)
                {
                    b[x, y] = _random.Next(100) < 40 ? WALL : FLOOR;
                }
            }

            for (int y = 0; y < HEIGHT; y++)
            {
                for (int x = 0; x < WIDTH; x++)
                {
                    b2[x, y] = WALL;
                }
            }

            for (int y1 = 0; y1 < HEIGHT; y1++)
            {
                b[0, y1] = b[WIDTH - 1, y1] = WALL;
            }
            
            for (int x1 = 0; x1 < WIDTH; x1++)
            {
                b[x1, 0] = b[x1, HEIGHT - 1] = WALL;
            }
            // Maps Initialised.

            int Generations = 0;

            do
            {
                for (int y = 2; y < HEIGHT - 2; y++)
                {
                    for (int x = 2; x < WIDTH - 2; x++)
                    {
                        int adjCount_r1 = 0;
                        int adjCount_r2 = 0;

                        for (int y2 = -1; y2 <= 1; y2++)
                        {
                            for (int x2 = -1; x2 <= 1; x2++)
                            {
                                if (b[x + x2, y + y2] != FLOOR)
                                {
                                    adjCount_r1++;
                                }
                            }
                        }
                        for (int y2 = y - 2; y2 <= y + 2; y2++)
                        {
                            for (int x2 = x - 2; x2 <= x + 2; x2++)
                            {
                                if (Math.Abs(y2 - y) == 2 && Math.Abs(x2 - x) == 2)
                                {
                                    continue;
                                }
                                if (y2 < 0 || x2 < 0 || y2 > HEIGHT || x2 > WIDTH)
                                {
                                    continue;
                                }
                                if (b[x2, y2] != FLOOR)
                                {
                                    adjCount_r2++;
                                }
                            }
                        }
                        if (adjCount_r1 >= 5 || adjCount_r2 <= 2)
                        {
                            b2[x, y] = WALL;
                        }
                        else
                        {
                            b2[x, y] = FLOOR;
                        }
                    }
                }
                for (int y = 1; y < HEIGHT - 1; y++)
                {
                    for (int x = 1; x < WIDTH - 1; x++)
                    {
                        b[x, y] = b2[x, y];
                    }
                }
                Generations++;
            }
            while (Generations <= 4);

            Bitmap bmp = new Bitmap(WIDTH, HEIGHT);
            for (int y = 1; y < HEIGHT - 1; y++)
            {
                for (int x = 1; x < WIDTH - 1; x++)
                {
                    bmp.SetPixel(x, y, b[x, y] == WALL ? Color.Black : Color.White);
                }
            }
            return bmp;
        }
    }
}
