using DevExpress.Skins;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraLayout;

namespace OopWinformsDesigner.UI {
    /// <summary>
    /// Definition of the glossary containing the references to the components to use once they are instantiated.
    /// </summary>
    public static class UIExtenders {
        /// <summary>
        /// This function extends the installation of the layout control.
        /// This is just the same thing that made the default Windows Forms Designer.
        /// </summary>
        /// <param name="layoutControl">Reference to the layout control installed</param>
        /// <returns>Self instance of the layout control but fully configured</returns>
        public static LayoutControl Install(this LayoutControl layoutControl) {
            layoutControl.BeginUpdate();

            layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl.EndUpdate();
            return layoutControl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusBar">Reference to the status bar installed</param>
        /// <returns>Self instance of the layout control but fully configured</returns>
        public static Bar InstallStatusBar(this Bar statusBar) {
            statusBar.AddItem(new DevExpress.XtraBars.BarStaticItem {
                AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True,
                ImageToTextAlignment = DevExpress.XtraBars.BarItemImageToTextAlignment.BeforeText,
                Caption = OopTranslation.StatusBar.Awaiting,
                Glyph = Properties.Resources.Message_Information,
                PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
            });
            var skinsComboEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox() {
                TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            };
            SkinManager.Default.GetRuntimeSkins().ForEach(sm => skinsComboEdit.Items.Add(sm.SkinName));
            statusBar.AddItem(new DevExpress.XtraBars.BarEditItem {
                AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True,
                Caption = OopTranslation.StatusBar.SkinSelect,
                Edit = skinsComboEdit,
                Glyph = Properties.Resources.Palette,
                PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
            });

            return statusBar;
        }
    }
}
