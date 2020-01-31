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
            var ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            var ribbonManager = new DevExpress.XtraBars.Ribbon.RibbonBarManager(ribbonControl);

            ribbonControl.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.True;
            Controls.Add(ribbonControl);
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
                AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True,
                ImageToTextAlignment = DevExpress.XtraBars.BarItemImageToTextAlignment.BeforeText,
                Caption = OopTranslation.StatusBar.Awaiting,
                Glyph = Properties.Resources.Message_Information,
                PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
            });
            statusBar.AddItem(new DevExpress.XtraBars.BarEditItem {
                AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True,
                Caption = OopTranslation.StatusBar.SkinSelect,
                Edit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox() {
                    TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
                },
                Glyph = Properties.Resources.Palette,
                PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
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
