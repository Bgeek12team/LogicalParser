using ClassLibrary1;
using LogicalParsing;

namespace Forms
{

    public partial class Form1 : Form
    {
        Token[] tokens;
        errorMessage errorMessageForm;
        Dictionary<int, Action> actions;
        LogicalExpression expression;

        public Form1()
        {
            InitializeComponent();
            errorMessageForm = new errorMessage();
            actions = new Dictionary<int, Action>
            {
                {-1, () => {ExtensionType.BlinkColor(b4_SaveEval ,Color.Green); changeState(true, b1_GetTreeLex, b2_GetListLex, b3_ExpEval, bGetDNF, bGetKNF); } },
                {0, () => errorMessageForm.showError("Неккоректно раставлены скобки") }
            };
        }

        private void rcTxBx_InputData_TextChanged(object sender, EventArgs e)
        {
            b4_SaveEval.Enabled = rcTxBx_InputData.Text == string.Empty ? false : true;
            rcTxBx_outData.Text = string.Empty;
            changeState(false, b1_GetTreeLex, b2_GetListLex, b3_ExpEval, bGetDNF, bGetKNF, bGetTableTruth);
        }

        private void b4_SaveEval_Click(object sender, EventArgs e)
        {
            actions[rcTxBx_InputData.Text.ChekCorrect()].Invoke();
        }
        private void changeState(bool state, params Control[] controls)
        {
            foreach (var item in controls)
                item.Enabled = state;
        }

        private void b2_GetListLex_Click(object sender, EventArgs e)
        {
            rcTxBx_outData.Text = "";
            var expression = rcTxBx_InputData.Text;
            tokens = Token.Tokenize(expression);

            foreach (var token in tokens)
            {
                rcTxBx_outData.Text += $"{token}\n";
            }
        }

        private void b3_ExpEval_Click(object sender, EventArgs e)
        {
            tokens = Token.Tokenize(rcTxBx_InputData.Text);
            var test = new ExpEval();
            try { test.FormOpen(tokens, rcTxBx_InputData.Text); }
            catch { MessageBox.Show("Невозможно вычислить значение логических выражений"); }
        }

        private void b1_GetTreeLex_Click(object sender, EventArgs e)
        {
            rcTxBx_outData.Text = "";
            var expression = rcTxBx_InputData.Text;
            var tree = ParsingTree.ParseTree(expression);

            foreach (var item in tree)
                rcTxBx_outData.Text += item;
        }

        private void bGetDNF_Click(object sender, EventArgs e)
        {
            rcTxBx_outData.Text = "";
            expression = new LogicalExpression(rcTxBx_InputData.Text);
            try { rcTxBx_outData.Text += expression.GetDNF().ToString(); bGetTableTruth.Enabled = true; }
            catch (Exception) { MessageBox.Show("Невозможно построить таблицу истинности!"); }

            
        }

        private void bGetKNF_Click(object sender, EventArgs e)
        {
            rcTxBx_outData.Text = "";
            expression = new LogicalExpression(rcTxBx_InputData.Text);
            try { rcTxBx_outData.Text += expression.GetKNF().ToString(); bGetTableTruth.Enabled = true; }
            catch (Exception) { MessageBox.Show("Невозможно построить таблицу истинности!"); }
        }

        private void bGetTableTruth_Click(object sender, EventArgs e)
        {
            rcTxBx_outData.Text += $"\n{expression.GetTruthTable().ToString()}";
        }
    }
}
