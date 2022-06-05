using System;
using System.Windows.Forms;

namespace MGProjectUserControl
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FormOptions form = new FormOptions();
            form.SetListModes( Game1.GetResolution() );
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                StartOptions opt = form.Options;
                using (var game = new Game1(opt))
                    game.Run();
            }
        }
    }
#endif
}
