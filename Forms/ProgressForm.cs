using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Monoedit
{
    public partial class ProgressWindow : MonoEditForm
    {
        public ProgressWindow()
        {
            InitializeComponent();
        }

        private void ProgressWindow_Load(object sender, EventArgs e)
        {

        }
        //this is on the task thread
        long lastpoll = 0;
        public void UpdateProgressAsync(double prog, string msg = null, int frequencyInMs = 50)
        {
            //Update the PB UI
            //50ms is a good poll frequency.  Lokos smooth and very responsive.
            //Do not set to zero because this hangs the UI and your progress will be... the UI update!
            //freuencyInMs - prevent EXCESSIVE updates by updating the ui every so many MS
            if (Environment.TickCount - lastpoll > frequencyInMs)
            {
                BeginInvoke((Action)(() =>
                {
                    //prog is between [0,1]
                    _pbProgress.Value = (int)((double)_pbProgress.Maximum * (double)prog);
                    if (msg != null)
                    {
                        _lblStatusMsg.Text = msg;
                    }

                }));
                lastpoll = Environment.TickCount;
            }
        }
        Task running = null;
        CancellationTokenSource tokenSource = null;
        public void Execute(Action<CancellationToken> stuffToDo)
        {
            Action<Task> continuewith = in_task =>
            {
                BeginInvoke((Action)(() =>
                {
                    Close();
                }));
            };
            tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            running = Task.Factory.StartNew(() => { stuffToDo(tokenSource.Token); }, tokenSource.Token).ContinueWith(continuewith);
            ShowDialog();
        }

        private void _lblStatusMsg_Click(object sender, EventArgs e)
        {

        }
    }
}
