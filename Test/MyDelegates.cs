using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Test
{
    class MyDelegates
    {
        private static TreeView treeViewBackPropagation;

        private static PictureBox pct;

        public static TreeView TreeViewBackPropagation
        {
            get { return MyDelegates.treeViewBackPropagation; }
            set { MyDelegates.treeViewBackPropagation = value; }
        }

        delegate void ChangeLocationValueHandler(Control ctrl, Point value);
        public static void ChangeLocation(Control ctrl, Point value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new ChangeLocationValueHandler(ChangeLocation), ctrl, value);
                return;
            }

            try
            {
                ctrl.Location = value;
            }

            catch (Exception) { }
        }

        delegate void ChangeSizeValueHandler(Control ctrl, Size value);
        public static void ChangeSize(Control ctrl, Size value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new ChangeSizeValueHandler(ChangeSize), ctrl, value);
                return;
            }

            try
            {
                ctrl.Size = value;
            }

            catch (Exception) { }
        }

        delegate void AddProgressValueHandler(ProgressBar ctrl, int value);
        public static void SetProgressValue(ProgressBar ctrl, int value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new AddProgressValueHandler(SetProgressValue), ctrl, value);
                return;
            }

            try
            {
                ctrl.Value = value;
            }

            catch (Exception) { }
        }

        delegate void SetEnableControlTHandler(Control ctrl, bool value);
        public static void SetEnableControl(Control ctrl, bool value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new SetEnableControlTHandler(SetEnableControl), ctrl, value);
                return;
            }

            try
            {
                ctrl.Enabled = value;
            }
            catch (Exception) { }
        }
        delegate void SetPCTColorHandler(PictureBox ctrl, Color value);
        public static void SetPCTColor(PictureBox ctrl, Color value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new SetPCTColorHandler(SetPCTColor), ctrl, value);
                return;
            }

            try
            {
                ctrl.BackColor = value;
            }
            catch (Exception) { }
        }

        delegate void SetPCTHandler(PictureBox ctrl, Bitmap value);
        public static void SetPCTValue(PictureBox ctrl, Bitmap value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new SetPCTHandler(SetPCTValue), ctrl, value);
                return;
            }

            try
            {
                ctrl.Image = value;
            }
            catch (Exception) { }
        }

        delegate void SetBMPHandler(Control ctrl, Bitmap value);
        public static void SetBMPValue(Control ctrl, Bitmap value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new SetBMPHandler(SetBMPValue), ctrl, value);
                return;
            }

            try
            {
                ((PictureBox)ctrl).Image = value;
            }
            catch (Exception) { }
        }

        delegate void SetControlTextHandler(Control ctrl, object value);
        public static void SetTextValue(Control ctrl, object value)
        {
            if (ctrl.InvokeRequired)
                ctrl.BeginInvoke(new SetControlTextHandler(SetTextValue), ctrl, value);
            else
                ctrl.Text = value.ToString();
        }


        delegate void SetLineValueHandler(TextBox ctrl, string value);
        public static void SetLineValue(TextBox ctrl, string value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new SetLineValueHandler(SetLineValue), ctrl, value);
                return;
            }
            try
            {
                ctrl.Text = value;
            }
            catch (Exception) { }
        }

        delegate void ClearListBoxHandler(ListBox ctrl);
        public static void ClearListBox(ListBox ctrl)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new ClearListBoxHandler(ClearListBox), ctrl);
                return;
            }
            try
            {
                ctrl.Items.Clear();
            }
            catch (Exception) { }
        }

        delegate void ListBoxAddRangeHandler(ListBox ctrl, object[] array);
        public static void ListBoxAddRange(ListBox ctrl, object[] array)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new ListBoxAddRangeHandler(ListBoxAddRange), ctrl, array);
                return;
            }
            try
            {
                ctrl.Items.AddRange(array);
            }
            catch (Exception) { }
        }

        delegate void AddLineValueHandler(TextBox ctrl, string value);
        public static void AddLineValue(TextBox ctrl, string value)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(new SetLineValueHandler(AddLineValue), ctrl, value);
                return;
            }
            try
            {
                ctrl.AppendText(value + "\r\n");
            }
            catch (Exception) { }
        }

        delegate void AddImageTrainHandler(Bitmap value);
        public static void AddImageTrainValue(Bitmap value)
        {
            if (treeViewBackPropagation.InvokeRequired)
            {
                treeViewBackPropagation.BeginInvoke(new AddProgressValueHandler(SetProgressValue), value);
                return;
            }

            try
            {
                TreeNode tmpNode = new TreeNode(value.Tag.ToString());
                tmpNode.Tag = value;
                treeViewBackPropagation.Nodes.Add(tmpNode);
                treeViewBackPropagation.Refresh();
            }

            catch (Exception) { }
        }
    }
}
