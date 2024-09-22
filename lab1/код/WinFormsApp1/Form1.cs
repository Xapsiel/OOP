namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();  
            textBox1.KeyPress += text_changed; 
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void text_changed(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            // ��������� c���������� ������� (��������, ��������)
            if (char.IsControl(c))
            {
                textBox1.BackColor = Color.White;
                return;
            }
            // �������� �� ���������� ������������� ����� ��� �������
            if ((c == '.' || c == ',') && (textBox1.Text.Contains(".") || textBox1.Text.Contains(",") || textBox1.Text.Length == 0))
            {
                textBox1.BackColor = Color.Red;
                e.Handled = true;
                return;
            }
            // ��������� ����� ������ � ������ ������
            if (c == '-' && (textBox1.Text.Length > 0 || textBox1.Text.Contains("-")))
            {
                textBox1.BackColor = Color.Red;
                e.Handled = true;
                return;
            }
            // ��������� �������, ������� �� �������� �������, ������, ������� ��� �������
            if (!char.IsDigit(c) && c != '.' && c != ',' && c != '-')
            {
                textBox1.BackColor = Color.Red;
                e.Handled = true;
            }
            textBox1.BackColor = Color.White;

        }
    }
}
