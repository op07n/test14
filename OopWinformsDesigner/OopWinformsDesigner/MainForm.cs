using System;

namespace OopWinformsDesigner {
    public partial class MainForm : DevExpress.XtraEditors.XtraForm {
        public MainForm() {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            installRibbonMenu();
            installBarManager();
        }

        private void installRibbonMenu() {

        }
        private void installBarManager() {
            var barManager = new DevExpress.XtraBars.BarManager(this.components);

            barManager.Form = this;
            barManager.BeginUpdate();
            var statusBar = new DevExpress.XtraBars.Bar() {
                BarName = "StatusBar",
                Manager = barManager,
                DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom,
                CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom,
                DockCol = 0,
                DockRow = 0
            };
            barManager.Bars.Add(statusBar);
            statusBar.AddItem(new DevExpress.XtraBars.BarStaticItem {
                Caption = OopTranslation.StatusBar.Awaiting
            });

            barManager.Bars.Add(statusBar);
            barManager.StatusBar = statusBar;

            barManager.StatusBar.OptionsBar.AllowQuickCustomization = false;
            barManager.StatusBar.OptionsBar.UseWholeRow = true;
            barManager.StatusBar.OptionsBar.DrawDragBorder = false;
            barManager.StatusBar.OptionsBar.DrawSizeGrip = true;

            barManager.EndUpdate();
        }
    }
}
