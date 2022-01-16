using FixedArray_test;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            var r = new Random();
            int start = 333, length = 7000000;

            var v = new Vector<double>(int.MaxValue - 5000000);
            //var v = new Vector<double>(500000000);
            for (int i = 0; i < v.Count; i++)
            {
                v[i] = r.NextDouble();
            }

            Debug.WriteLine("Sequentail :");
            var sw = System.Diagnostics.Stopwatch.StartNew();
            Debug.WriteLine(v.Max(start, length));
            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
            Debug.WriteLine("----------------");
            Thread.Sleep(1000);

            Debug.WriteLine("4 Cores :");
            sw.Restart();
            Debug.WriteLine(await v.MaxAsync(start, length, numberOfWorkers: 4));
            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
            Debug.WriteLine("----------------");
            Thread.Sleep(1000);


            Debug.WriteLine("All Cores (TPL):");
            sw.Restart();
            Debug.WriteLine(await v.MaxAsync(start, length, useTPL: true));
            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
            Debug.WriteLine("----------------");
            Thread.Sleep(1000);


            Debug.WriteLine("All Cores:");
            sw.Restart();
            Debug.WriteLine(await v.MaxAsync(start, length, numberOfWorkers: 64));
            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
            Debug.WriteLine("----------------");
            Thread.Sleep(1000);


            Debug.WriteLine("============ Locate Max ==================");

            Debug.WriteLine("Sequentail :");
            sw.Restart();
            Debug.WriteLine(v.LocateMax(start, length));
            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
            Debug.WriteLine("----------------");
            Thread.Sleep(1000);


            Debug.WriteLine("All Cores (TPL):");
            sw.Restart();
            Debug.WriteLine(await v.LocateMaxAsync(start, length, useTPL: true));
            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
            Debug.WriteLine("----------------");
            Thread.Sleep(1000);


            Debug.WriteLine("All Cores :");
            sw.Restart();
            Debug.WriteLine(await v.LocateMaxAsync(start, length, numberOfWorkers: 64));
            sw.Stop();
            Debug.WriteLine(sw.Elapsed);
            Debug.WriteLine("----------------");
            Thread.Sleep(1000);

        }
    }
}