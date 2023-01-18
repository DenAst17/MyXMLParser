using MyXMLParser.DataStructures;
using MyXMLParser.Readers;

namespace MyXMLParser
{
    public partial class MyXmlParse : Form
    {
        public List<IReader> XMLReaders = new List<IReader>();
        private IReader reader;
        private string filePath;


        public MyXmlParse()
        {
            InitializeComponent();

            XMLReaders.Add(new SAXAPIReader());
            XMLReaders.Add(new DOMAPIReader());
            XMLReaders.Add(new LINQToXMLReader());

            comboBox1.DataSource = XMLReaders;
            comboBox1.DisplayMember = "";

            filePath = "";
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectReader();
        }

        private void selectReader()
        {
            if (comboBox1.SelectedIndex != -1)
            {
                reader = comboBox1.SelectedItem as IReader;
            }
        }

        private void selectFile(object sender, EventArgs e)
        {
            showFile();
        }

        private void showFile()
        {
            try
            {
                filePath = OpenDialog();
                if (filePath == "") return;
                var rep = reader.ReadFile(filePath);

                ShowRepresentation(rep);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowRepresentation(XMLRepresentation rep)
        {
            richTextBox1.Text = rep.ToString();

            treeView1.Nodes.Clear();
            foreach (var student in rep.Students)
            {
                var node = new TreeNode("[" + student.ID + "] " + student.Name + " " + student.Surname);

                foreach (var prop in student.GetType().GetProperties())
                {
                    node.Nodes.Add(prop.Name + ": " + prop.GetValue(student, null));
                }
                var adressesNode = new TreeNode("Adresses(Count: " + student.Adresses.Count + ")");
                if (student.Adresses!=null)
                {
                    foreach (var adress in student.Adresses)
                    {
                        var adressNode = new TreeNode("Adress");
                        foreach (var prop in adress.GetType().GetProperties())
                        {
                            adressNode.Nodes.Add(prop.Name + ": " + prop.GetValue(adress, null));
                        }
                        adressesNode.Nodes.Add(adressNode);
                    }
                    node.Nodes.Add(adressesNode);
                }
                
                node.Tag = student;
                treeView1.Nodes.Add(node);
            }
        }

        public string OpenDialog()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"D:\Projects\C#\MyXMLParser\MyXMLParser\";
                openFileDialog.Filter = "XML|*.xml";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
                else
                {
                    return "";
                }
                if (openFileDialog.FileName == "") throw new Exception("Incorect Name");
            }
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutForm();
        }

        private void ShowAboutForm()
        {
            var f = new AboutForm();
            f.Show();
        }
    }
}