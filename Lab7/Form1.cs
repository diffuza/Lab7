using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            file1.Filter = "(*.jpg)|*.jpg";
            
        }

        private void btn_Click(object sender, EventArgs e)
        {
            
            // ������� ���������� fname ���������� ����
            string fname;
            // ��������� ���������
            file1.ShowDialog();
            // ���������� ���������� ��� �������� ����� ���������� �����
            fname = file1.FileName;
            // ��������� ���� � ������� PictureBox
            pct.Image = Image.FromFile(fname);
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "����������� ���� (*.jpg)|*.jpg|��� ����� (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.SafeFileName;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pct.Image != null) //���� � pictureBox ���� �����������
            {
                //�������� ����������� ���� "��������� ���..", ��� ���������� �����������
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "��������� �������� ���...";
                //���������� �� ��������������, ���� ������������ ��������� ��� ��� ������������� �����
                savedialog.OverwritePrompt = true;
                //���������� �� ��������������, ���� ������������ ��������� �������������� ����
                savedialog.CheckPathExists = true;
                //������ �������� �����, ������������ � ���� "��� �����"
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                //������������ �� ������ "�������" � ���������� ����
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) //���� � ���������� ���� ������ ������ "��"
                {
                    try
                    {
                        pct.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("���������� ��������� �����������", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


            }

        private void pct_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}