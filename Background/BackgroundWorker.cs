using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalIM.Background
{
    public class BackgroundWorker
    {
        MainViewModel _mainViewModel;

        public BackgroundWorker(MainViewModel vm)
        {
            _mainViewModel = vm;
            var thread = new Thread(new ThreadStart(DoWork)) { IsBackground = true };
            thread.Start();
        }

        void DoWork()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                Thread.Sleep(5000);
                foreach (var c in _mainViewModel.ContactViewModels)
                {
                    c.CheckActivity();
                }                
            }
        }
    }
}
