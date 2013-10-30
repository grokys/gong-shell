using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace GongSolutions.Shell
{
    class ShellItemEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            ShellItemBrowseForm f = new ShellItemBrowseForm();

            if (f.ShowDialog() == DialogResult.OK)
            {
                return f.SelectedItem;
            }

            return value;
        }
    }
}
