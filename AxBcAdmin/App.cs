namespace AxBcAdmin
{

    /// <summary>
    /// Helper. Represents this application
    /// </summary>
    static internal class App
    {

        /// <summary>
        /// Log method
        /// </summary>
        static public void Log(string Text)
        {
            if (MainForm != null && !MainForm.IsDisposed)
                MainForm.Log(Text);
        }
        /// <summary>
        /// Throws an Exception with the specified message.
        /// </summary>
        static public void Throw(string ErrorMessage)
        {
            throw new ApplicationException(ErrorMessage);
        }
        /// <summary>
        /// Connects a grid to its binding source and initializes the grid.
        /// </summary>
        static public void InitializeGrid(BindingSource bs, DataGridView Grid)
        {
            Grid.AutoGenerateColumns = false;
            Grid.DataSource = bs;
            Grid.ReadOnly = true;
            Grid.AllowUserToAddRows = false;
            Grid.AllowUserToDeleteRows = false;
            Grid.MultiSelect = false;
            Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //.Fill;
            Grid.BorderStyle = BorderStyle.None;
            Grid.GridColor = SystemColors.ScrollBar;
        }

        /* extensions */
        /// <summary>
        /// Returns true if Value is contained in the Instance.
        /// Performs a case-insensitive check using the invariant culture.
        /// </summary>
        static public bool ContainsText(this string Instance, string Value)
        {
            if ((Instance != null) && !string.IsNullOrWhiteSpace(Value))
            {
                return Instance.IndexOf(Value, StringComparison.InvariantCultureIgnoreCase) != -1;
            }

            return false;
        }
        /// <summary>
        /// Creates a new row, adds the row to rows, and returns the row.
        /// </summary>
        static public DataRow AddNewRow(this DataTable Table)
        {
            DataRow Result = Table.NewRow();
            Table.Rows.Add(Result);
            return Result;
        }
 
        
        /// <summary>
        /// Creates and returns a file name based on DT
        /// <para>The returned string has the format </para>
        /// <para><c>yyyy-MM-dd HH_mm_ss</c></para>
        /// </summary>
        public static string ToFileName(this DateTime DT)
        {
            return ToFileName(DT, false);
        }
        /// <summary>
        /// Creates and returns a file name based on DT.
        /// <para>The returned string has the format </para>
        /// <para><c>yyyy-MM-dd HH_mm_ss__fff</c></para>
        /// </summary>
        public static string ToFileName(this DateTime DT, bool UseMSecs)
        {
            return UseMSecs ? DT.ToString("yyyy-MM-dd HH_mm_ss__fff") : DT.ToString("yyyy-MM-dd HH_mm_ss");
        }

        /* properties */
        static public MainForm MainForm { get; set; }
        /// <summary>
        /// Gets the directory where the main assembly resides.
        /// <para>The returned string includes a trailing path separator.</para>
        /// </summary>
        static public string AppFolder { get { return System.AppContext.BaseDirectory; } }  //  { get { return typeof(App).Assembly.GetFolder(); } }
 
    }
}
