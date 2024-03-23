namespace AxBcAdmin
{
    public partial class MainForm : Form
    {
        const string STitle = "AntyxSoft Business Central Admin";



        void FormInitialize()
        {

        }

        void ScrollToEnd()
        {
            edtLog.SelectionStart = edtLog.Text.Length;
            edtLog.ScrollToCaret();
        }
        public void Log(string LogText)
        {
            if (!InvokeRequired)
            {
                edtLog.AppendText(LogText + Environment.NewLine);
                ScrollToEnd();
            }
            else
            {
                Invoke(new Action(() =>
                {
                    edtLog.AppendText(LogText + Environment.NewLine);
                    ScrollToEnd();
                }));
            }
        }

        public void LogStart(string LogText)
        {
            edtLog.AppendText(LogText);
        }
        public void LogAppend(string LogText)
        {
            edtLog.AppendText(LogText);
        }
        public void LogEnd(string LogText)
        {
            edtLog.AppendText(LogText + Environment.NewLine);
            ScrollToEnd();
        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!DesignMode)
                FormInitialize();
        }

        public MainForm()
        {
            InitializeComponent();
        }




    }
}
