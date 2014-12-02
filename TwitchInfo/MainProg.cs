using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchInfo
{
    public class MainProg : ApplicationContext
    {
        private IContainer components;
        private NotifyIcon notifyIcon;
        private ContextMenu contextMenu1;
        private MenuItem[] menuItems;

        [STAThread]
        static void Main()
        {
            Application.Run(new MainProg());
        }

        public MainProg()
        {
            this.components = new Container();

            this.notifyIcon = new NotifyIcon(this.components);

            this.contextMenu1 = new ContextMenu();
            this.menuItems = new MenuItem[] { new MenuItem(), new MenuItem() };

            // ContexMenu
            this.contextMenu1.MenuItems.AddRange( this.menuItems );


            // MenuItem
            this.menuItems[(int)MenuItemIndex.Item.EXIT].Index = (int)MenuItemIndex.Item.EXIT;
            this.menuItems[(int)MenuItemIndex.Item.EXIT].Text = "Exit";
            this.menuItems[(int)MenuItemIndex.Item.EXIT].Click += new EventHandler(this.E_MenuItemExit_Click);

            this.menuItems[(int)MenuItemIndex.Item.OPTIONS].Index = (int)MenuItemIndex.Item.OPTIONS;
            this.menuItems[(int)MenuItemIndex.Item.OPTIONS].Text = "Options";
            this.menuItems[(int)MenuItemIndex.Item.OPTIONS].Click += new EventHandler(this.E_MenuItemOptions_Click);

            // NotifyIcon
            notifyIcon.ContextMenu = this.contextMenu1;
            notifyIcon.Icon = new Icon("../../res/1416336922_167721.ico");
            notifyIcon.Visible = true;

            notifyIcon.ShowBalloonTip(5000, "Streamer online!", "kmper is streaming now!", ToolTipIcon.Info);

            Tools.RunOnStartup("TwitchInfo", Application.ExecutablePath, false);


        }

        private void E_MenuItemExit_Click(object sender, EventArgs e)
        {
            this.ExitThread();
        }

        private void E_MenuItemOptions_Click(object sender, EventArgs e)
        {
            WinOptions win = new WinOptions();
            win.Show();
        }

        protected override void Dispose(bool disposing)
        {
            // Clean up any components being used.
            if (disposing)
                if (components != null)
                    components.Dispose();

            base.Dispose(disposing);
        }
    }
}
