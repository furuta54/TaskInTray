using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TaskInTray
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        public MainWindow AppWindow { get; set; } = new MainWindow();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var icon = GetResourceStream(new Uri("TaskInTray.ico", UriKind.Relative)).Stream;
            var menu = new System.Windows.Forms.ContextMenuStrip();
            menu.Items.Add("終了", null, Exit_Click);
            var notifyIcon = new System.Windows.Forms.NotifyIcon
            {
                Visible = true,
                Icon = new System.Drawing.Icon(icon),
                Text = "TaskInTray",
                ContextMenuStrip = menu
            };
            notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(NotifyIcon_Click);
        }

        protected void NotifyIcon_Click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (!AppWindow.IsVisible)
                {
                    AppWindow.Show();
                    AppWindow.Activate();
                }
            }
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Shutdown();
        }
    }
}
