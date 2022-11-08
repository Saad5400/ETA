using static System.Net.Mime.MediaTypeNames;

namespace EnglishToArabic
{
    public partial class Form1 : Form
    {

        public Dictionary<char?, char?> EtoA = new Dictionary<char?, char?>
        {
            {'`', 'Ð'},
            {'~', 'ø'},
            {'q', 'Ö'},
            {'w', 'Õ'},
            {'e', 'Ë'},
            {'r', 'Þ'},
            {'t', 'Ý'},
            {'y', 'Û'},
            {'u', 'Ú'},
            {'i', 'å'},
            {'o', 'Î'},
            {'p', 'Í'},
            {'[', 'Ì'},
            {']', 'Ï'},
            {'a', 'Ô'},
            {'s', 'Ó'},
            {'d', 'í'},
            {'f', 'È'},
            {'g', 'á'},
            {'h', 'Ç'},
            {'j', 'Ê'},
            {'k', 'ä'},
            {'l', 'ã'},
            {';', 'ß'},
            {'\'', 'Ø'},
            {'z', 'Æ'},
            {'x', 'Á'},
            {'c', 'Ä'},
            {'v', 'Ñ'},
            {'n', 'ì'},
            {'m', 'É'},
            {',', 'æ'},
            {'.', 'Ò'},
            {'/', 'Ù'},
            {'Q', 'ó'},
            {'W', 'ð'},
            {'E', 'õ'},
            {'R', 'ñ'},
            {'Y', 'Å'},
            {'U', '‘'},
            {'I', '÷'},
            {'O', '×'},
            {'P', 'º'},
            {'{', '<'},
            {'}', '>'},
            {'A', 'ö'},
            {'S', 'ò'},
            {'D', ']'},
            {'F', '['},
            {'H', 'Ã'},
            {'J', 'Ü'},
            {'K', '¡'},
            {'L', '/'},
            {'Z', '~'},
            {'X', 'ú'},
            {'C', '}'},
            {'V', '{'},
            {'N', 'Â'},
            {'M', '’'},
            {'<', ','},
            {'>', '.'},
            {'?', '¿'}
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Hide();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (Visible)
            {
                Hide();
            }
            else
            {
                Show();
                Location = new Point(MousePosition.X, MousePosition.Y - (Height + 20));
                BringToFront();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = string.Empty;

            foreach (char c in textBox1.Text)
            {
                if (EtoA.ContainsKey(c))
                {
                    text += EtoA[c];
                }
                else
                {
                    text += c;
                }
            }

            textBox2.TextChanged -= textBox2_TextChanged;

            textBox2.Text = text;

            textBox2.TextChanged += textBox2_TextChanged;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string text = string.Empty;

            foreach (char c in textBox2.Text)
            {
                char? key = EtoA.FirstOrDefault(x => x.Value == c, new KeyValuePair<char?, char?>(null, null)).Key;
                    if (key.HasValue)
                    {
                        text += key;
                    }
                    else
                    {
                        text += c;
                    }
            }

            textBox1.TextChanged -= textBox1_TextChanged;

            textBox1.Text = text;

            textBox1.TextChanged += textBox1_TextChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
        }
    }
}