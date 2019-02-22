using System;
using System.Threading;
using System.Windows.Forms;

using Iswenzz.AION.Encdec.Task;

namespace Iswenzz.AION.Encdec
{
    public partial class Encdec : Form
    {
        public Encdec()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Out.Console = fConsole1;
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            SDK.Extract = new Thread(() => Extract.Init());
            SDK.Extract.IsBackground = true;
            SDK.Extract.Start();
        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            SDK.Decode = new Thread(() => Decode.Init());
            SDK.Decode.IsBackground = true;
            SDK.Decode.Start();
        }

        private void flatButton3_Click(object sender, EventArgs e)
        {
            SDK.Repack = new Thread(() => Repack.Init());
            SDK.Repack.IsBackground = true;
            SDK.Repack.Start();
        }
    }
}
