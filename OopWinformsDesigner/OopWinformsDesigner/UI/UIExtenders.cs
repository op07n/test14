using DevExpress.Skins;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraLayout;

using OopWinformsDesigner.Session;

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
        /// This function extends the installation of the ribbon control with adding all required elements.
        /// </summary>
        /// <param name="ribbonControl">Reference to the ribbon control initialized</param>
        /// <returns>Self instance of the ribbon control but fully configured</returns>
        public static RibbonControl Install(this RibbonControl ribbonControl) {
            ribbonControl.ButtonGroupsLayout = ButtonGroupsLayout.ThreeRows;
            var pageSolution = new RibbonPage(OopTranslation.Ribbon.RibbonPageSolutionsProjects);
            var groupProjectsAndSolutionsLoadSolution = new RibbonPageGroup(OopTranslation.Ribbon.RibbonPageSolutionsProjectsGroupLoadSolution);
            groupProjectsAndSolutionsLoadSolution.ItemsLayout = RibbonPageGroupItemsLayout.OneRow;
            groupProjectsAndSolutionsLoadSolution.ItemLinks.Add(new BarButtonItem());

            var groupProjectsAndSolutionsLoadProject = new RibbonPageGroup(OopTranslation.Ribbon.RibbonPageSolutionsProjectsGroupLoadProject);
            groupProjectsAndSolutionsLoadProject.ItemsLayout = RibbonPageGroupItemsLayout.OneRow;
            pageSolution.Groups.Add(groupProjectsAndSolutionsLoadSolution);
            pageSolution.Groups.Add(groupProjectsAndSolutionsLoadProject);
            ribbonControl.Pages.Add(pageSolution);
            if (SessionInfo.Instance.IsSolutionOrProjectLoaded) {
                // Add alternate groups (pages).
            }
            return ribbonControl;
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
