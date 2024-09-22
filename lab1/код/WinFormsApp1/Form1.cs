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
            // Разрешаем cпециальные символы (например, бэкспейс)
            if (char.IsControl(c))
            {
                textBox1.BackColor = Color.White;
                return;
            }
            // Проверка на корректное использование точки или запятой
            if ((c == '.' || c == ',') && (textBox1.Text.Contains(".") || textBox1.Text.Contains(",") || textBox1.Text.Length == 0))
            {
                textBox1.BackColor = Color.Red;
                e.Handled = true;
                return;
            }
            // Разрешаем минус только в начале строки
            if (c == '-' && (textBox1.Text.Length > 0 || textBox1.Text.Contains("-")))
            {
                textBox1.BackColor = Color.Red;
                e.Handled = true;
                return;
            }
            // Отклоняем символы, которые не являются цифрами, точкой, запятой или минусом
            if (!char.IsDigit(c) && c != '.' && c != ',' && c != '-')
            {
                textBox1.BackColor = Color.Red;
                e.Handled = true;
            }
            textBox1.BackColor = Color.White;

        }
    }
}
