using System.Text.RegularExpressions;
namespace LFSR
{
    public partial class Form1 : Form
    {
        private Regex regex = new Regex("0|1");
        private byte[] sourceBytes = null;
        private byte[] resultBytes;

        public Form1(){
            InitializeComponent();

        }

        private string bytesToString(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return "";

            string res = "";
            byte a;

            int showBytes = 30;

            if (bytes.Length <= showBytes * 2){
                for (int i = 0; i < bytes.Length; i++){
                    a = 128;
                    for (int j = 0; j < 8; j++){
                        res += ((bytes[i] & a) == 0) ? "0" : "1";
                        a = (byte)(a >> 1);
                    }
                    res += ".";
                }
            }
            else
            {
                // Первые 30 байт
                for (int i = 0; i < showBytes; i++){
                    a = 128;
                    for (int j = 0; j < 8; j++){
                        res += ((bytes[i] & a) == 0) ? "0" : "1";
                        a = (byte)(a >> 1);
                    }
                    res += ".";
                }

                res += " ... ";

                // Последние
                for (int i = bytes.Length - showBytes; i < bytes.Length; i++){
                    a = 128;
                    for (int j = 0; j < 8; j++){
                        res += ((bytes[i] & a) == 0) ? "0" : "1";
                        a = (byte)(a >> 1);
                    }
                    res += ".";
                }
            }

            return res;
        }

        private void bttnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK){
                sourceBytes = File.ReadAllBytes(openFileDialog.FileName);
                if (sourceBytes.Length == 0){
                    MessageBox.Show("Выбран пустой файл (0 байт). Результат будет пустым.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                textBox.Text = bytesToString(sourceBytes);
                textBox1.Text = "";
                textBoxFile.Text = openFileDialog.FileName;
                textBoxKey.Clear();
            }
        }

        private ulong binaryStringToUlong(string s)
        {
            ulong res = 0;
            ulong a = 1;
            for (int i = s.Length - 1; i >= 0; i--){
                if (s[i] == '1'){
                    res += a;
                }
                a *= 2;
            }
            return res;
        }

        //11111111111111111111111111
        private byte[] encrypt(byte[] sourceBytes, ulong key)
        {
            byte[] resultBytes = new byte[sourceBytes.Length];
            byte[] keys = new byte[sourceBytes.Length];
            for (int i = 0; i < sourceBytes.Length; i++){
                keys[i] = 0; 
                for (int j = 7; j >= 0; j--){
                    keys[i] = (byte)(((key >> 25) << j) | keys[i]);

                    // Сдвигает регистр влево на 1 бит. маска 0x3FFFFFF для сохр только 26 битов
                    key = ((key << 1) & 0x3FFFFFF) | (((key >> 25) & 1) ^ ((key >> 7) & 1) ^ ((key >> 6) & 1) ^ ((key >> 0) & 1));
                }
                resultBytes[i] = (byte)(sourceBytes[i] ^ keys[i]);
            }
            textBoxKey.Text = bytesToString(keys);
            return resultBytes;
        }

        private void bttnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && resultBytes != null && resultBytes.Length > 0){
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK){
                    File.WriteAllBytes(saveFileDialog.FileName, resultBytes);
                    ResetKeyHighlight();
                }
            }
            else if (sourceBytes != null)
            {
                if (textBoxKey.Text.Length == 26){
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    if (saveFileDialog.ShowDialog() == DialogResult.OK){
                        resultBytes = encrypt(sourceBytes, binaryStringToUlong(textBoxKey.Text));
                        textBox1.Text = bytesToString(resultBytes);
                        File.WriteAllBytes(saveFileDialog.FileName, resultBytes);
                        ResetKeyHighlight();
                    }
                }
                else{
                    int difference = 26 - textBoxKey.Text.Length;
                    if (difference > 0)
                        MessageBox.Show($"Ключ должен быть 26 бит! Не хватает {difference} символов.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show($"Ключ должен быть 26 бит! У вас на {Math.Abs(difference)} символов больше.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else{
                MessageBox.Show("Файл не открыт!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxKey_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar != '0' && e.KeyChar != '1' && !char.IsControl(e.KeyChar)){
                e.Handled = true;
            }
        }

        private void bttnRes_Click(object sender, EventArgs e)
        {
            if (sourceBytes != null){
                if (textBoxKey.Text.Length == 26){
                    resultBytes = encrypt(sourceBytes, binaryStringToUlong(textBoxKey.Text));
                    textBox1.Text = bytesToString(resultBytes);
                    ResetKeyHighlight();
                    }
                else{
                    int difference = 26 - textBoxKey.Text.Length;
                    if (difference > 0)
                            MessageBox.Show($"Ключ должен быть 26 бит! Не хватает {difference} символов.", "Предупреждение",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                            MessageBox.Show($"Ключ должен быть 26 бит! У вас на {Math.Abs(difference)} символов больше.", "Предупреждение",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
             }
            else{
                MessageBox.Show("Файл не открыт!", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            UpdateKeyStatus();
        }
        private void UpdateKeyStatus()
        {
            int keyLength = textBoxKey.Text.Length;
            int requiredLength = 26;

            if (keyLength < requiredLength){
                int missingChars = requiredLength - keyLength;
                labPolynomial.Text = $"Не хватает {missingChars} символов для корректного ключа";
                labPolynomial.ForeColor = Color.Red;
                textBoxKey.BackColor = Color.LightPink;
            }
            else if (keyLength == requiredLength)
            {
                labPolynomial.ForeColor = Color.Green;
                textBoxKey.BackColor = Color.LightGreen;}
            else
            {
                labPolynomial.Text = $"Ключ слишком длинный. Требуется 26 бит, введено {keyLength}";
                labPolynomial.ForeColor = Color.Red;
                textBoxKey.BackColor = Color.LightPink;
            }
        }

        private void ResetKeyHighlight()
        {
            labPolynomial.Text = "";
            textBoxKey.BackColor = SystemColors.Window; 
            textBoxKey.Refresh();
            labPolynomial.Refresh();
        }

        private void bttnClear_Click(object sender, EventArgs e)
        {
            textBox.Clear();
            textBox1.Clear();
            textBoxKey.Clear();
            if (this.Controls.Find("textBoxFile", true).Length > 0)
            {
                TextBox textBoxFile = this.Controls.Find("textBoxFile", true)[0] as TextBox;
                textBoxFile.Clear();
            }

            ResetKeyHighlight();

            sourceBytes = null;
            resultBytes = null;
            MessageBox.Show("Все поля очищены.", "Информация",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
