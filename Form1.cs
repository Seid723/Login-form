namespace InventoryMgmt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                maskedTextBox1.PasswordChar = '\0';
            else
                maskedTextBox1.PasswordChar = '•';
        }

        private void label4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            maskedTextBox1.Text = "";
        }
    }
}
