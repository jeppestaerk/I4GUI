using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.IO;

namespace CustomDialogSample
{
    public partial class SettingsDialog : System.Windows.Window
    {

        // Data for the dialog that supports notification for data binding
        class DialogData : INotifyPropertyChanged
        {
            Color reportColor;
            public Color ReportColor
            {
                get { return reportColor; }
                set { reportColor = value; Notify("ReportColor"); }
            }

            string reportFolder;
            public string ReportFolder
            {
                get { return reportFolder; }
                set { reportFolder = value; Notify("ReportFolder"); }
            }

            string reporter;
            public string Reporter
            {
                get { return reporter; }
                set { reporter = value; Notify("Reporter"); }
            }

            // INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;
            void Notify(string prop) { if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); } }
        }

        DialogData data = new DialogData();

        public Color ReportColor
        {
            get { return data.ReportColor; }
            set { data.ReportColor = value; }
        }

        public string ReportFolder
        {
            get { return data.ReportFolder; }
            set { data.ReportFolder = value; }
        }

        public string Reporter
        {
            get { return data.Reporter; }
            set { data.Reporter = value; }
        }

        public SettingsDialog()
        {
            InitializeComponent();

            // Allow binding to the data to keep UI bindings up to date
            DataContext = data;

            reportColorButton.Click += new RoutedEventHandler(reportColorButton_Click);
            folderBrowseButton.Click += new RoutedEventHandler(folderBrowseButton_Click);
            okButton.Click += new RoutedEventHandler(OkButton_Click);
        }

        void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate all controls
            if (ValidateBindings(this))
            {
                DialogResult = true;
            }
        }

        // This is here 'til future versions of WPF provide this functionality
        public static bool ValidateBindings(DependencyObject parent)
        {
            // Validate all the bindings on the parent
            bool valid = true;
            LocalValueEnumerator localValues = parent.GetLocalValueEnumerator();
            while (localValues.MoveNext())
            {
                LocalValueEntry entry = localValues.Current;
                if (BindingOperations.IsDataBound(parent, entry.Property))
                {
                    Binding binding = BindingOperations.GetBinding(parent, entry.Property);
                    foreach (ValidationRule rule in binding.ValidationRules)
                    {
                        // TODO: where to get correct culture info?
                        ValidationResult result = rule.Validate(parent.GetValue(entry.Property), null);
                        if (!result.IsValid)
                        {
                            BindingExpression expression = BindingOperations.GetBindingExpression(parent, entry.Property);
                            Validation.MarkInvalid(expression, new ValidationError(rule, expression, result.ErrorContent, null));
                            valid = false;
                        }
                    }
                }
            }

            // Validate all the bindings on the children
            for (int i = 0; i != VisualTreeHelper.GetChildrenCount(parent); ++i)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (!ValidateBindings(child)) { valid = false; }
            }

            return valid;
        }

        void reportColorButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
            Color color = ReportColor;
            dlg.Color = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ReportColor = Color.FromArgb(dlg.Color.A, dlg.Color.R, dlg.Color.G, dlg.Color.B);
            }
        }

        void folderBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dlg = new System.Windows.Forms.FolderBrowserDialog();
            dlg.SelectedPath = ReportFolder;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ReportFolder = dlg.SelectedPath;
            }
        }

    }

    public class FolderMustExist : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (!Directory.Exists((string)value))
            {
                return new ValidationResult(false, "Folder doesn't exist");
            }

            return new ValidationResult(true, null);
        }
    }

    public class NonZeroLength : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                return new ValidationResult(false, "Please enter something");
            }

            return new ValidationResult(true, null);
        }
    }

}
