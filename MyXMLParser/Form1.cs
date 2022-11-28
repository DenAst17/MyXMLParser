using MyXMLParser.DataStructures;
using MyXMLParser.Readers;

namespace MyXMLParser
{
    public partial class Form1 : Form
    {
        public List<IReader> XMLReaders = new List<IReader>();
        private IReader reader;
        private string filePath;


        public Form1()
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
            if (comboBox1.SelectedIndex != -1)
            {
                reader = comboBox1.SelectedItem as IReader;
            }
        }

        private void selectFile(object sender, EventArgs e)
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
                if(student.Adresses!=null)
                {
                    var adressNode = new TreeNode("Adresses(Count: " + student.Adresses.Count + ")");
                    foreach (var adress in student.Adresses)
                    {
                        foreach (var prop in adress.GetType().GetProperties())
                        {
                            adressNode.Nodes.Add(prop.Name + ": " + prop.GetValue(adress, null));
                        }
                        node.Nodes.Add(adressNode);
                    }
                    
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
    }
}